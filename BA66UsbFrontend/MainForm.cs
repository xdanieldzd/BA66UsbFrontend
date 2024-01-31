using BA66UsbFrontend.Display;
using BA66UsbFrontend.UsbHid;
using System.Text;
using System.Diagnostics;
using System.Reflection;
using BA66UsbFrontend.Content;
using BA66UsbFrontend.Content.Clock;
using BA66UsbFrontend.Content.Music;
using BA66UsbFrontend.Content.Weather;
using BA66UsbFrontend.Content.System;

namespace BA66UsbFrontend
{
	public partial class MainForm : Form
	{
		static readonly double displayTargetFps = 10.0;
		static readonly int displayNumberOfLines = 4;
		static readonly int displayColumnsPerLine = 20;

		readonly PeriodicTimer contentTimer = new(TimeSpan.FromMilliseconds(1000.0 / displayTargetFps));
		readonly NotifyIcon notifyIcon = new()
		{
			Visible = true,
			Text = $"{Program.ProgramName} v{Program.ProgramVersionString}",
			Icon = Resources.GetEmbeddedIcon("Assets.Icon.ico", new(16, 16)),
			ContextMenuStrip = new()
		};

		readonly Queue<ContentBase> contents = [];

		UsbDisplay usbDisplay = default;
		Encoding textEncoding = Encoding.ASCII;

		public MainForm()
		{
			InitializeComponent();

			notifyIcon.ContextMenuStrip.Items.AddRange(new ToolStripItem[]
			{
				new ToolStripMenuItem("&Restore", null, (s, e) =>
				{
					Show();
					WindowState = FormWindowState.Normal;
					Invalidate();
				}),
				new ToolStripSeparator(),
				new ToolStripMenuItem("E&xit", null, (s, e) => { Close(); })
			});

			cmbWeatherUnits.DataSource = Enum.GetValues(typeof(WeatherUnits));

			Text = lblApplicationName.Text = $"{Program.ProgramName} v{Program.ProgramVersionString}";
			lblApplicationDescription.Text = Program.ProgramDescription;
			lblApplicationWrittenBy.Text = Program.ProgramCopyright;
			lklApplicationUrl.Text = Program.ProgramUrl;
		}

		private static void CreateDataBinding(ControlBindingsCollection bindings, string propertyName, object dataSource, string dataMember)
		{
			bindings.Add(new Binding(propertyName, dataSource, dataMember, false, DataSourceUpdateMode.OnPropertyChanged));
		}

		private async void MainForm_Load(object sender, EventArgs e)
		{
			CreateDataBinding(chkShowStartupMessage.DataBindings, nameof(chkShowStartupMessage.Checked), Program.Configuration, nameof(Program.Configuration.ShowStartupMessage));

			usbDisplay = await InitializeUsbDisplay();
			tsslStatus.Text = $"Connected to USB Display (VID: 0x{usbDisplay?.VendorId:X4}, PID: 0x{usbDisplay?.ProductId:X4})";

			ctrlDisplayControl.SetCountryCode(0x34);

			InitializeContents();

			if (chkShowStartupMessage.Checked)
				await SendStartupMessage();

			InitializeMainUpdateLoop();
		}

		private void MainForm_Resize(object sender, EventArgs e)
		{
			var minimized = WindowState == FormWindowState.Minimized;
			ShowInTaskbar = !minimized;
			if (minimized) Hide();
		}

		private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			Configuration.Save(Program.ConfigPath, Program.Configuration);

			notifyIcon.Visible = false;
		}

		private void InitializeContents()
		{
			static ContentBase initContent(ContentBase content, CheckBox enableCheckBox, string configEnableFlagName)
			{
				content.IsEnabled = (bool)Program.Configuration.GetType().GetProperty(configEnableFlagName, BindingFlags.Instance | BindingFlags.Public).GetValue(Program.Configuration);
				enableCheckBox.CheckedChanged += (s, e) => { content.IsEnabled = (s as CheckBox).Checked; };
				CreateDataBinding(enableCheckBox.DataBindings, nameof(enableCheckBox.Checked), Program.Configuration, configEnableFlagName);
				return content;
			}

			contents.Enqueue(initContent(new BigDateContent(), chkClockShowDate, nameof(Program.Configuration.ShowBigClockDate)));
			contents.Enqueue(initContent(new BigTimeContent(), chkClockShowTime, nameof(Program.Configuration.ShowBigClockTime)));
			contents.Enqueue(initContent(new WeatherMainContent(), chkShowWeatherMain, nameof(Program.Configuration.ShowWeatherMain)));
			contents.Enqueue(initContent(new WeatherSubContent(), chkShowWeatherSub, nameof(Program.Configuration.ShowWeatherSub)));
			contents.Enqueue(initContent(new SystemStatusContent(), chkShowSystemStatus, nameof(Program.Configuration.ShowSystemStatus)));
			contents.Enqueue(initContent(new NetworkStatusContent(), chkShowNetworkStatus, nameof(Program.Configuration.ShowNetworkStatus)));
			contents.Enqueue(initContent(new Foobar2kContent(), chkShowMedia, nameof(Program.Configuration.ShowMedia)));

			CreateDataBinding(nudWeatherMainDuration.DataBindings, nameof(nudWeatherMainDuration.Value), Program.Configuration, nameof(Program.Configuration.WeatherMainDuration));
			CreateDataBinding(nudWeatherSubDuration.DataBindings, nameof(nudWeatherSubDuration.Value), Program.Configuration, nameof(Program.Configuration.WeatherSubDuration));
			CreateDataBinding(nudClockDateDuration.DataBindings, nameof(nudClockDateDuration.Value), Program.Configuration, nameof(Program.Configuration.BigClockDateDuration));
			CreateDataBinding(nudClockTimeDuration.DataBindings, nameof(nudClockTimeDuration.Value), Program.Configuration, nameof(Program.Configuration.BigClockTimeDuration));
			CreateDataBinding(nudSystemDisplayDuration.DataBindings, nameof(nudSystemDisplayDuration.Value), Program.Configuration, nameof(Program.Configuration.SystemStatusDuration));
			CreateDataBinding(nudNetworkDisplayDuration.DataBindings, nameof(nudNetworkDisplayDuration.Value), Program.Configuration, nameof(Program.Configuration.NetworkStatusDuration));
			CreateDataBinding(nudMediaDisplayDuration.DataBindings, nameof(nudMediaDisplayDuration.Value), Program.Configuration, nameof(Program.Configuration.MediaDuration));

			CreateDataBinding(txtWeatherApiKey.DataBindings, nameof(txtWeatherApiKey.Text), Program.Configuration, nameof(Program.Configuration.WeatherApiKey));
			CreateDataBinding(txtWeatherPostcode.DataBindings, nameof(txtWeatherPostcode.Text), Program.Configuration, nameof(Program.Configuration.WeatherPostcode));
			CreateDataBinding(txtWeatherCountry.DataBindings, nameof(txtWeatherCountry.Text), Program.Configuration, nameof(Program.Configuration.WeatherCountry));
			CreateDataBinding(cmbWeatherUnits.DataBindings, nameof(cmbWeatherUnits.SelectedItem), Program.Configuration, nameof(Program.Configuration.WeatherUnits));
			CreateDataBinding(chkWeatherShowLocation.DataBindings, nameof(chkWeatherShowLocation.Checked), Program.Configuration, nameof(Program.Configuration.WeatherShowLocation));
			CreateDataBinding(chkNetworkShowMacAndAdapter.DataBindings, nameof(chkNetworkShowMacAndAdapter.Checked), Program.Configuration, nameof(Program.Configuration.NetworkShowMacAndAdapter));
			CreateDataBinding(chkMediaShowAlbum.DataBindings, nameof(chkMediaShowAlbum.Checked), Program.Configuration, nameof(Program.Configuration.MediaShowAlbum));
		}

		private async void InitializeMainUpdateLoop()
		{
			var stopwatch = Stopwatch.StartNew();

			while (await contentTimer.WaitForNextTickAsync())
			{
				foreach (var content in contents.Where(x => x.IsEnabled))
					content.Update(textEncoding, new(displayColumnsPerLine, displayNumberOfLines));

				if (Visible && WindowState != FormWindowState.Minimized)
					ctrlDisplayControl.Invalidate();

				if (contents.TryPeek(out ContentBase activeContent))
				{
					await activeContent.SendToDevice(usbDisplay);
					await activeContent.SendToDevice(ctrlDisplayControl);

					if (stopwatch.Elapsed >= activeContent.DisplayDuration)
					{
						stopwatch.Restart();

						void cycle()
						{
							if (contents.TryDequeue(out ContentBase activeContent))
								contents.Enqueue(activeContent);
						}

						cycle();
						while (!contents.Peek().IsEnabled) cycle();
					}
				}
			}
		}

		private async Task<UsbDisplay> InitializeUsbDisplay()
		{
			UsbDisplay usbDisplay = default;

			try
			{
				usbDisplay = new UsbDisplay();

				await usbDisplay.Initialize();

				if (usbDisplay.IsInitialized)
				{
					await usbDisplay.SetCountryCode(0x34);
					textEncoding = Encoding.GetEncoding(usbDisplay.CodePage);

					await usbDisplay.ClearScreen();
				}
			}
			catch (UsbDeviceNotFoundException ex)
			{
				var errorMessage = "Unknown USB device error.";
				if (ex.ErrorType == UsbDeviceNotFoundExceptionType.DeviceNotFound)
					errorMessage = $"No USB device with VID 0x{ex.VendorId:X4} and PID 0x{ex.ProductId:X4} found!";
				else if (ex.ErrorType == UsbDeviceNotFoundExceptionType.DeviceFoundButWrongUsage)
					errorMessage = $"USB device was found, but does not support Usage Page 0x{ex.UsagePage:X4} and/or Usage ID 0x{ex.Usage:X4}!";

				MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}

			return usbDisplay;
		}

		private async Task SendStartupMessage()
		{
			var linePattern = "-=-";
			var decorationLine = string.Join(string.Empty, Enumerable.Repeat(linePattern, displayColumnsPerLine / linePattern.Length));
			var startupMessage = new string[]
			{
				decorationLine,
				Program.ProgramName,
				$"Version {Program.ProgramVersionString}",
				decorationLine
			};

			static int getXPos(string str, int maxLen) => str.Length >= maxLen ? 1 : ((maxLen - str.Length) / 2) + 1;

			var builder = new StringBuilder();
			for (int i = 0, y = startupMessage.Length == 4 ? 1 : 2; i < startupMessage.Length; i++, y++)
			{
				builder.Append($"\x1B[{y};{getXPos(startupMessage[i], displayColumnsPerLine)}H");
				builder.Append(startupMessage[i]);
			}

			var dataBytes = textEncoding.GetBytes(builder.ToString());

			await usbDisplay.WriteData(dataBytes);
			await ctrlDisplayControl.WriteData(dataBytes);
			ctrlDisplayControl.Invalidate();

			await Task.Delay(2000);
		}

		private void LklApplicationUrl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			if (sender is LinkLabel linkLabel && e.Link is LinkLabel.Link link)
			{
				var url = link.LinkData != null ? link.LinkData as string : linkLabel.Text.Substring(link.Start, link.Length);
				Process.Start(new ProcessStartInfo(url!) { UseShellExecute = true });
			}
		}
	}
}
