namespace BA66UsbFrontend
{
	partial class MainForm
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			chkShowStartupMessage = new CheckBox();
			stpMain = new StatusStrip();
			tsslStatus = new ToolStripStatusLabel();
			ctrlDisplayControl = new Display.DisplayControl();
			tcTabs = new TabControl();
			tpGeneral = new TabPage();
			tlpGeneral = new TableLayoutPanel();
			tpBigClock = new TabPage();
			tlpBigClock = new TableLayoutPanel();
			chkClockShowDate = new CheckBox();
			chkClockShowTime = new CheckBox();
			nudClockDateDuration = new NumericUpDown();
			nudClockTimeDuration = new NumericUpDown();
			lblClockDateDuration = new Label();
			lblClockTimeDuration = new Label();
			tpWeather = new TabPage();
			tlpWeather = new TableLayoutPanel();
			chkShowWeatherMain = new CheckBox();
			lblWeatherMainDuration = new Label();
			nudWeatherMainDuration = new NumericUpDown();
			chkShowWeatherSub = new CheckBox();
			lblWeatherSubDuration = new Label();
			nudWeatherSubDuration = new NumericUpDown();
			lblWeatherApiKey = new Label();
			txtWeatherApiKey = new TextBox();
			lblWeatherPostcode = new Label();
			txtWeatherPostcode = new TextBox();
			lblWeatherCountry = new Label();
			txtWeatherCountry = new TextBox();
			lblWeatherUnits = new Label();
			cmbWeatherUnits = new ComboBox();
			chkWeatherShowLocation = new CheckBox();
			tpSystemNetwork = new TabPage();
			tableLayoutPanel2 = new TableLayoutPanel();
			chkShowSystemStatus = new CheckBox();
			lblSystemDisplayDuration = new Label();
			nudSystemDisplayDuration = new NumericUpDown();
			chkShowNetworkStatus = new CheckBox();
			lblNetworkDisplayDuration = new Label();
			nudNetworkDisplayDuration = new NumericUpDown();
			chkNetworkShowMacAndAdapter = new CheckBox();
			tpMedia = new TabPage();
			tlpMedia = new TableLayoutPanel();
			chkShowMedia = new CheckBox();
			lblMediaDisplayDuration = new Label();
			nudMediaDisplayDuration = new NumericUpDown();
			chkMediaShowAlbum = new CheckBox();
			tpAbout = new TabPage();
			tlpAbout = new TableLayoutPanel();
			lblApplicationDescription = new Label();
			lblApplicationWrittenBy = new Label();
			lblApplicationName = new Label();
			lklApplicationUrl = new LinkLabel();
			stpMain.SuspendLayout();
			tcTabs.SuspendLayout();
			tpGeneral.SuspendLayout();
			tlpGeneral.SuspendLayout();
			tpBigClock.SuspendLayout();
			tlpBigClock.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)nudClockDateDuration).BeginInit();
			((System.ComponentModel.ISupportInitialize)nudClockTimeDuration).BeginInit();
			tpWeather.SuspendLayout();
			tlpWeather.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)nudWeatherMainDuration).BeginInit();
			((System.ComponentModel.ISupportInitialize)nudWeatherSubDuration).BeginInit();
			tpSystemNetwork.SuspendLayout();
			tableLayoutPanel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)nudSystemDisplayDuration).BeginInit();
			((System.ComponentModel.ISupportInitialize)nudNetworkDisplayDuration).BeginInit();
			tpMedia.SuspendLayout();
			tlpMedia.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)nudMediaDisplayDuration).BeginInit();
			tpAbout.SuspendLayout();
			tlpAbout.SuspendLayout();
			SuspendLayout();
			// 
			// chkShowStartupMessage
			// 
			chkShowStartupMessage.AutoSize = true;
			chkShowStartupMessage.Dock = DockStyle.Fill;
			chkShowStartupMessage.Location = new Point(3, 3);
			chkShowStartupMessage.Name = "chkShowStartupMessage";
			chkShowStartupMessage.Size = new Size(750, 19);
			chkShowStartupMessage.TabIndex = 4;
			chkShowStartupMessage.Text = "Show Startup Message";
			chkShowStartupMessage.UseVisualStyleBackColor = true;
			// 
			// stpMain
			// 
			stpMain.Items.AddRange(new ToolStripItem[] { tsslStatus });
			stpMain.Location = new Point(0, 478);
			stpMain.Name = "stpMain";
			stpMain.Size = new Size(800, 22);
			stpMain.TabIndex = 2;
			// 
			// tsslStatus
			// 
			tsslStatus.Name = "tsslStatus";
			tsslStatus.Size = new Size(785, 17);
			tsslStatus.Spring = true;
			tsslStatus.Text = "Ready";
			tsslStatus.TextAlign = ContentAlignment.MiddleLeft;
			// 
			// ctrlDisplayControl
			// 
			ctrlDisplayControl.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			ctrlDisplayControl.CodePage = 437;
			ctrlDisplayControl.Location = new Point(12, 12);
			ctrlDisplayControl.Name = "ctrlDisplayControl";
			ctrlDisplayControl.Size = new Size(776, 200);
			ctrlDisplayControl.TabIndex = 3;
			// 
			// tcTabs
			// 
			tcTabs.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			tcTabs.Controls.Add(tpGeneral);
			tcTabs.Controls.Add(tpBigClock);
			tcTabs.Controls.Add(tpWeather);
			tcTabs.Controls.Add(tpSystemNetwork);
			tcTabs.Controls.Add(tpMedia);
			tcTabs.Controls.Add(tpAbout);
			tcTabs.Location = new Point(12, 218);
			tcTabs.Name = "tcTabs";
			tcTabs.SelectedIndex = 0;
			tcTabs.Size = new Size(776, 257);
			tcTabs.TabIndex = 6;
			// 
			// tpGeneral
			// 
			tpGeneral.Controls.Add(tlpGeneral);
			tpGeneral.Location = new Point(4, 24);
			tpGeneral.Name = "tpGeneral";
			tpGeneral.Padding = new Padding(3);
			tpGeneral.Size = new Size(768, 229);
			tpGeneral.TabIndex = 0;
			tpGeneral.Text = "General";
			tpGeneral.UseVisualStyleBackColor = true;
			// 
			// tlpGeneral
			// 
			tlpGeneral.ColumnCount = 1;
			tlpGeneral.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
			tlpGeneral.Controls.Add(chkShowStartupMessage, 0, 0);
			tlpGeneral.Location = new Point(6, 6);
			tlpGeneral.Name = "tlpGeneral";
			tlpGeneral.RowCount = 2;
			tlpGeneral.RowStyles.Add(new RowStyle());
			tlpGeneral.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
			tlpGeneral.Size = new Size(756, 217);
			tlpGeneral.TabIndex = 6;
			// 
			// tpBigClock
			// 
			tpBigClock.Controls.Add(tlpBigClock);
			tpBigClock.Location = new Point(4, 24);
			tpBigClock.Name = "tpBigClock";
			tpBigClock.Padding = new Padding(3);
			tpBigClock.Size = new Size(768, 229);
			tpBigClock.TabIndex = 1;
			tpBigClock.Text = "Big Clock";
			tpBigClock.UseVisualStyleBackColor = true;
			// 
			// tlpBigClock
			// 
			tlpBigClock.ColumnCount = 2;
			tlpBigClock.ColumnStyles.Add(new ColumnStyle());
			tlpBigClock.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
			tlpBigClock.Controls.Add(chkClockShowDate, 0, 0);
			tlpBigClock.Controls.Add(chkClockShowTime, 0, 3);
			tlpBigClock.Controls.Add(nudClockDateDuration, 1, 2);
			tlpBigClock.Controls.Add(nudClockTimeDuration, 1, 4);
			tlpBigClock.Controls.Add(lblClockDateDuration, 0, 2);
			tlpBigClock.Controls.Add(lblClockTimeDuration, 0, 4);
			tlpBigClock.Location = new Point(6, 6);
			tlpBigClock.Name = "tlpBigClock";
			tlpBigClock.RowCount = 6;
			tlpBigClock.RowStyles.Add(new RowStyle());
			tlpBigClock.RowStyles.Add(new RowStyle());
			tlpBigClock.RowStyles.Add(new RowStyle());
			tlpBigClock.RowStyles.Add(new RowStyle());
			tlpBigClock.RowStyles.Add(new RowStyle());
			tlpBigClock.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
			tlpBigClock.Size = new Size(756, 217);
			tlpBigClock.TabIndex = 7;
			// 
			// chkClockShowDate
			// 
			chkClockShowDate.AutoSize = true;
			tlpBigClock.SetColumnSpan(chkClockShowDate, 2);
			chkClockShowDate.Dock = DockStyle.Fill;
			chkClockShowDate.Location = new Point(3, 3);
			chkClockShowDate.Name = "chkClockShowDate";
			chkClockShowDate.Size = new Size(750, 19);
			chkClockShowDate.TabIndex = 4;
			chkClockShowDate.Text = "Show Date";
			chkClockShowDate.UseVisualStyleBackColor = true;
			// 
			// chkClockShowTime
			// 
			chkClockShowTime.AutoSize = true;
			tlpBigClock.SetColumnSpan(chkClockShowTime, 2);
			chkClockShowTime.Dock = DockStyle.Fill;
			chkClockShowTime.Location = new Point(3, 57);
			chkClockShowTime.Name = "chkClockShowTime";
			chkClockShowTime.Size = new Size(750, 19);
			chkClockShowTime.TabIndex = 5;
			chkClockShowTime.Text = "Show Time";
			chkClockShowTime.UseVisualStyleBackColor = true;
			// 
			// nudClockDateDuration
			// 
			nudClockDateDuration.Dock = DockStyle.Fill;
			nudClockDateDuration.Location = new Point(190, 28);
			nudClockDateDuration.Name = "nudClockDateDuration";
			nudClockDateDuration.Size = new Size(563, 23);
			nudClockDateDuration.TabIndex = 6;
			// 
			// nudClockTimeDuration
			// 
			nudClockTimeDuration.Dock = DockStyle.Fill;
			nudClockTimeDuration.Location = new Point(190, 82);
			nudClockTimeDuration.Name = "nudClockTimeDuration";
			nudClockTimeDuration.Size = new Size(563, 23);
			nudClockTimeDuration.TabIndex = 7;
			// 
			// lblClockDateDuration
			// 
			lblClockDateDuration.AutoSize = true;
			lblClockDateDuration.Dock = DockStyle.Fill;
			lblClockDateDuration.Location = new Point(3, 25);
			lblClockDateDuration.Name = "lblClockDateDuration";
			lblClockDateDuration.Size = new Size(181, 29);
			lblClockDateDuration.TabIndex = 8;
			lblClockDateDuration.Text = "Date Display Duration (Seconds):";
			lblClockDateDuration.TextAlign = ContentAlignment.MiddleLeft;
			// 
			// lblClockTimeDuration
			// 
			lblClockTimeDuration.AutoSize = true;
			lblClockTimeDuration.Dock = DockStyle.Fill;
			lblClockTimeDuration.Location = new Point(3, 79);
			lblClockTimeDuration.Name = "lblClockTimeDuration";
			lblClockTimeDuration.Size = new Size(181, 29);
			lblClockTimeDuration.TabIndex = 9;
			lblClockTimeDuration.Text = "Time Display Duration (Seconds):";
			lblClockTimeDuration.TextAlign = ContentAlignment.MiddleLeft;
			// 
			// tpWeather
			// 
			tpWeather.Controls.Add(tlpWeather);
			tpWeather.Location = new Point(4, 24);
			tpWeather.Name = "tpWeather";
			tpWeather.Size = new Size(768, 229);
			tpWeather.TabIndex = 2;
			tpWeather.Text = "Weather";
			tpWeather.UseVisualStyleBackColor = true;
			// 
			// tlpWeather
			// 
			tlpWeather.ColumnCount = 4;
			tlpWeather.ColumnStyles.Add(new ColumnStyle());
			tlpWeather.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
			tlpWeather.ColumnStyles.Add(new ColumnStyle());
			tlpWeather.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
			tlpWeather.Controls.Add(chkShowWeatherMain, 0, 0);
			tlpWeather.Controls.Add(lblWeatherMainDuration, 0, 1);
			tlpWeather.Controls.Add(nudWeatherMainDuration, 1, 1);
			tlpWeather.Controls.Add(chkShowWeatherSub, 0, 2);
			tlpWeather.Controls.Add(lblWeatherSubDuration, 0, 3);
			tlpWeather.Controls.Add(nudWeatherSubDuration, 1, 3);
			tlpWeather.Controls.Add(lblWeatherApiKey, 0, 4);
			tlpWeather.Controls.Add(txtWeatherApiKey, 1, 4);
			tlpWeather.Controls.Add(lblWeatherPostcode, 0, 5);
			tlpWeather.Controls.Add(txtWeatherPostcode, 1, 5);
			tlpWeather.Controls.Add(lblWeatherCountry, 2, 5);
			tlpWeather.Controls.Add(txtWeatherCountry, 3, 5);
			tlpWeather.Controls.Add(lblWeatherUnits, 0, 6);
			tlpWeather.Controls.Add(cmbWeatherUnits, 1, 6);
			tlpWeather.Controls.Add(chkWeatherShowLocation, 0, 7);
			tlpWeather.Location = new Point(6, 6);
			tlpWeather.Name = "tlpWeather";
			tlpWeather.RowCount = 10;
			tlpWeather.RowStyles.Add(new RowStyle());
			tlpWeather.RowStyles.Add(new RowStyle());
			tlpWeather.RowStyles.Add(new RowStyle());
			tlpWeather.RowStyles.Add(new RowStyle());
			tlpWeather.RowStyles.Add(new RowStyle());
			tlpWeather.RowStyles.Add(new RowStyle());
			tlpWeather.RowStyles.Add(new RowStyle());
			tlpWeather.RowStyles.Add(new RowStyle());
			tlpWeather.RowStyles.Add(new RowStyle());
			tlpWeather.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
			tlpWeather.Size = new Size(756, 217);
			tlpWeather.TabIndex = 7;
			// 
			// chkShowWeatherMain
			// 
			chkShowWeatherMain.AutoSize = true;
			tlpWeather.SetColumnSpan(chkShowWeatherMain, 4);
			chkShowWeatherMain.Dock = DockStyle.Fill;
			chkShowWeatherMain.Location = new Point(3, 3);
			chkShowWeatherMain.Name = "chkShowWeatherMain";
			chkShowWeatherMain.Size = new Size(750, 19);
			chkShowWeatherMain.TabIndex = 4;
			chkShowWeatherMain.Text = "Show Main Page (Current Temperature, Conditions)";
			chkShowWeatherMain.UseVisualStyleBackColor = true;
			// 
			// lblWeatherMainDuration
			// 
			lblWeatherMainDuration.AutoSize = true;
			lblWeatherMainDuration.Dock = DockStyle.Fill;
			lblWeatherMainDuration.Location = new Point(3, 25);
			lblWeatherMainDuration.Name = "lblWeatherMainDuration";
			lblWeatherMainDuration.Size = new Size(182, 29);
			lblWeatherMainDuration.TabIndex = 16;
			lblWeatherMainDuration.Text = "Main Display Duration (Seconds):";
			lblWeatherMainDuration.TextAlign = ContentAlignment.MiddleLeft;
			// 
			// nudWeatherMainDuration
			// 
			tlpWeather.SetColumnSpan(nudWeatherMainDuration, 3);
			nudWeatherMainDuration.Dock = DockStyle.Fill;
			nudWeatherMainDuration.Location = new Point(191, 28);
			nudWeatherMainDuration.Name = "nudWeatherMainDuration";
			nudWeatherMainDuration.Size = new Size(562, 23);
			nudWeatherMainDuration.TabIndex = 15;
			// 
			// chkShowWeatherSub
			// 
			chkShowWeatherSub.AutoSize = true;
			tlpWeather.SetColumnSpan(chkShowWeatherSub, 4);
			chkShowWeatherSub.Dock = DockStyle.Fill;
			chkShowWeatherSub.Location = new Point(3, 57);
			chkShowWeatherSub.Name = "chkShowWeatherSub";
			chkShowWeatherSub.Size = new Size(750, 19);
			chkShowWeatherSub.TabIndex = 5;
			chkShowWeatherSub.Text = "Show Sub Page (Min/Max Temperatur, Sunset/Sunrise)";
			chkShowWeatherSub.UseVisualStyleBackColor = true;
			// 
			// lblWeatherSubDuration
			// 
			lblWeatherSubDuration.AutoSize = true;
			lblWeatherSubDuration.Dock = DockStyle.Fill;
			lblWeatherSubDuration.Location = new Point(3, 79);
			lblWeatherSubDuration.Name = "lblWeatherSubDuration";
			lblWeatherSubDuration.Size = new Size(182, 29);
			lblWeatherSubDuration.TabIndex = 17;
			lblWeatherSubDuration.Text = "Sub Display Duration (Seconds):";
			lblWeatherSubDuration.TextAlign = ContentAlignment.MiddleLeft;
			// 
			// nudWeatherSubDuration
			// 
			tlpWeather.SetColumnSpan(nudWeatherSubDuration, 3);
			nudWeatherSubDuration.Dock = DockStyle.Fill;
			nudWeatherSubDuration.Location = new Point(191, 82);
			nudWeatherSubDuration.Name = "nudWeatherSubDuration";
			nudWeatherSubDuration.Size = new Size(562, 23);
			nudWeatherSubDuration.TabIndex = 18;
			// 
			// lblWeatherApiKey
			// 
			lblWeatherApiKey.AutoSize = true;
			lblWeatherApiKey.Dock = DockStyle.Fill;
			lblWeatherApiKey.Location = new Point(3, 108);
			lblWeatherApiKey.Name = "lblWeatherApiKey";
			lblWeatherApiKey.Size = new Size(182, 29);
			lblWeatherApiKey.TabIndex = 6;
			lblWeatherApiKey.Text = "OpenWeatherMap API Key:";
			lblWeatherApiKey.TextAlign = ContentAlignment.MiddleLeft;
			// 
			// txtWeatherApiKey
			// 
			tlpWeather.SetColumnSpan(txtWeatherApiKey, 3);
			txtWeatherApiKey.Dock = DockStyle.Fill;
			txtWeatherApiKey.Location = new Point(191, 111);
			txtWeatherApiKey.Name = "txtWeatherApiKey";
			txtWeatherApiKey.Size = new Size(562, 23);
			txtWeatherApiKey.TabIndex = 7;
			// 
			// lblWeatherPostcode
			// 
			lblWeatherPostcode.AutoSize = true;
			lblWeatherPostcode.Dock = DockStyle.Fill;
			lblWeatherPostcode.Location = new Point(3, 137);
			lblWeatherPostcode.Name = "lblWeatherPostcode";
			lblWeatherPostcode.Size = new Size(182, 29);
			lblWeatherPostcode.TabIndex = 8;
			lblWeatherPostcode.Text = "Postcode:";
			lblWeatherPostcode.TextAlign = ContentAlignment.MiddleLeft;
			// 
			// txtWeatherPostcode
			// 
			txtWeatherPostcode.Dock = DockStyle.Fill;
			txtWeatherPostcode.Location = new Point(191, 140);
			txtWeatherPostcode.Name = "txtWeatherPostcode";
			txtWeatherPostcode.Size = new Size(248, 23);
			txtWeatherPostcode.TabIndex = 9;
			// 
			// lblWeatherCountry
			// 
			lblWeatherCountry.AutoSize = true;
			lblWeatherCountry.Dock = DockStyle.Fill;
			lblWeatherCountry.Location = new Point(445, 137);
			lblWeatherCountry.Name = "lblWeatherCountry";
			lblWeatherCountry.Size = new Size(53, 29);
			lblWeatherCountry.TabIndex = 10;
			lblWeatherCountry.Text = "Country:";
			lblWeatherCountry.TextAlign = ContentAlignment.MiddleLeft;
			// 
			// txtWeatherCountry
			// 
			txtWeatherCountry.Dock = DockStyle.Fill;
			txtWeatherCountry.Location = new Point(504, 140);
			txtWeatherCountry.Name = "txtWeatherCountry";
			txtWeatherCountry.Size = new Size(249, 23);
			txtWeatherCountry.TabIndex = 11;
			// 
			// lblWeatherUnits
			// 
			lblWeatherUnits.AutoSize = true;
			lblWeatherUnits.Dock = DockStyle.Fill;
			lblWeatherUnits.Location = new Point(3, 166);
			lblWeatherUnits.Name = "lblWeatherUnits";
			lblWeatherUnits.Size = new Size(182, 29);
			lblWeatherUnits.TabIndex = 12;
			lblWeatherUnits.Text = "Units:";
			lblWeatherUnits.TextAlign = ContentAlignment.MiddleLeft;
			// 
			// cmbWeatherUnits
			// 
			cmbWeatherUnits.Dock = DockStyle.Fill;
			cmbWeatherUnits.DropDownStyle = ComboBoxStyle.DropDownList;
			cmbWeatherUnits.FormattingEnabled = true;
			cmbWeatherUnits.Location = new Point(191, 169);
			cmbWeatherUnits.Name = "cmbWeatherUnits";
			cmbWeatherUnits.Size = new Size(248, 23);
			cmbWeatherUnits.TabIndex = 14;
			// 
			// chkWeatherShowLocation
			// 
			chkWeatherShowLocation.AutoSize = true;
			tlpWeather.SetColumnSpan(chkWeatherShowLocation, 4);
			chkWeatherShowLocation.Dock = DockStyle.Fill;
			chkWeatherShowLocation.Location = new Point(3, 198);
			chkWeatherShowLocation.Name = "chkWeatherShowLocation";
			chkWeatherShowLocation.Size = new Size(750, 19);
			chkWeatherShowLocation.TabIndex = 13;
			chkWeatherShowLocation.Text = "Show Location";
			chkWeatherShowLocation.UseVisualStyleBackColor = true;
			// 
			// tpSystemNetwork
			// 
			tpSystemNetwork.Controls.Add(tableLayoutPanel2);
			tpSystemNetwork.Location = new Point(4, 24);
			tpSystemNetwork.Name = "tpSystemNetwork";
			tpSystemNetwork.Size = new Size(768, 229);
			tpSystemNetwork.TabIndex = 3;
			tpSystemNetwork.Text = "System && Network";
			tpSystemNetwork.UseVisualStyleBackColor = true;
			// 
			// tableLayoutPanel2
			// 
			tableLayoutPanel2.ColumnCount = 2;
			tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle());
			tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
			tableLayoutPanel2.Controls.Add(chkShowSystemStatus, 0, 0);
			tableLayoutPanel2.Controls.Add(lblSystemDisplayDuration, 0, 1);
			tableLayoutPanel2.Controls.Add(nudSystemDisplayDuration, 1, 1);
			tableLayoutPanel2.Controls.Add(chkShowNetworkStatus, 0, 2);
			tableLayoutPanel2.Controls.Add(lblNetworkDisplayDuration, 0, 3);
			tableLayoutPanel2.Controls.Add(nudNetworkDisplayDuration, 1, 3);
			tableLayoutPanel2.Controls.Add(chkNetworkShowMacAndAdapter, 0, 4);
			tableLayoutPanel2.Location = new Point(6, 6);
			tableLayoutPanel2.Name = "tableLayoutPanel2";
			tableLayoutPanel2.RowCount = 6;
			tableLayoutPanel2.RowStyles.Add(new RowStyle());
			tableLayoutPanel2.RowStyles.Add(new RowStyle());
			tableLayoutPanel2.RowStyles.Add(new RowStyle());
			tableLayoutPanel2.RowStyles.Add(new RowStyle());
			tableLayoutPanel2.RowStyles.Add(new RowStyle());
			tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
			tableLayoutPanel2.Size = new Size(756, 217);
			tableLayoutPanel2.TabIndex = 7;
			// 
			// chkShowSystemStatus
			// 
			chkShowSystemStatus.AutoSize = true;
			chkShowSystemStatus.Dock = DockStyle.Fill;
			chkShowSystemStatus.Location = new Point(3, 3);
			chkShowSystemStatus.Name = "chkShowSystemStatus";
			chkShowSystemStatus.Size = new Size(233, 19);
			chkShowSystemStatus.TabIndex = 4;
			chkShowSystemStatus.Text = "Show System Status";
			chkShowSystemStatus.UseVisualStyleBackColor = true;
			// 
			// lblSystemDisplayDuration
			// 
			lblSystemDisplayDuration.AutoSize = true;
			lblSystemDisplayDuration.Dock = DockStyle.Fill;
			lblSystemDisplayDuration.Location = new Point(3, 25);
			lblSystemDisplayDuration.Name = "lblSystemDisplayDuration";
			lblSystemDisplayDuration.Size = new Size(233, 29);
			lblSystemDisplayDuration.TabIndex = 22;
			lblSystemDisplayDuration.Text = "System Display Duration (Seconds):";
			lblSystemDisplayDuration.TextAlign = ContentAlignment.MiddleLeft;
			// 
			// nudSystemDisplayDuration
			// 
			nudSystemDisplayDuration.Dock = DockStyle.Fill;
			nudSystemDisplayDuration.Location = new Point(242, 28);
			nudSystemDisplayDuration.Name = "nudSystemDisplayDuration";
			nudSystemDisplayDuration.Size = new Size(511, 23);
			nudSystemDisplayDuration.TabIndex = 19;
			// 
			// chkShowNetworkStatus
			// 
			chkShowNetworkStatus.AutoSize = true;
			chkShowNetworkStatus.Dock = DockStyle.Fill;
			chkShowNetworkStatus.Location = new Point(3, 57);
			chkShowNetworkStatus.Name = "chkShowNetworkStatus";
			chkShowNetworkStatus.Size = new Size(233, 19);
			chkShowNetworkStatus.TabIndex = 5;
			chkShowNetworkStatus.Text = "Show Network Status";
			chkShowNetworkStatus.UseVisualStyleBackColor = true;
			// 
			// lblNetworkDisplayDuration
			// 
			lblNetworkDisplayDuration.AutoSize = true;
			lblNetworkDisplayDuration.Dock = DockStyle.Fill;
			lblNetworkDisplayDuration.Location = new Point(3, 79);
			lblNetworkDisplayDuration.Name = "lblNetworkDisplayDuration";
			lblNetworkDisplayDuration.Size = new Size(233, 29);
			lblNetworkDisplayDuration.TabIndex = 20;
			lblNetworkDisplayDuration.Text = "Network Display Duration (Seconds):";
			lblNetworkDisplayDuration.TextAlign = ContentAlignment.MiddleLeft;
			// 
			// nudNetworkDisplayDuration
			// 
			nudNetworkDisplayDuration.Dock = DockStyle.Fill;
			nudNetworkDisplayDuration.Location = new Point(242, 82);
			nudNetworkDisplayDuration.Name = "nudNetworkDisplayDuration";
			nudNetworkDisplayDuration.Size = new Size(511, 23);
			nudNetworkDisplayDuration.TabIndex = 21;
			// 
			// chkNetworkShowMacAndAdapter
			// 
			chkNetworkShowMacAndAdapter.AutoSize = true;
			chkNetworkShowMacAndAdapter.Dock = DockStyle.Fill;
			chkNetworkShowMacAndAdapter.Location = new Point(3, 111);
			chkNetworkShowMacAndAdapter.Name = "chkNetworkShowMacAndAdapter";
			chkNetworkShowMacAndAdapter.Size = new Size(233, 19);
			chkNetworkShowMacAndAdapter.TabIndex = 6;
			chkNetworkShowMacAndAdapter.Text = "Show Adapter MAC Address and Name";
			chkNetworkShowMacAndAdapter.UseVisualStyleBackColor = true;
			// 
			// tpMedia
			// 
			tpMedia.Controls.Add(tlpMedia);
			tpMedia.Location = new Point(4, 24);
			tpMedia.Name = "tpMedia";
			tpMedia.Size = new Size(768, 229);
			tpMedia.TabIndex = 4;
			tpMedia.Text = "Media";
			tpMedia.UseVisualStyleBackColor = true;
			// 
			// tlpMedia
			// 
			tlpMedia.ColumnCount = 2;
			tlpMedia.ColumnStyles.Add(new ColumnStyle());
			tlpMedia.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
			tlpMedia.Controls.Add(chkShowMedia, 0, 0);
			tlpMedia.Controls.Add(lblMediaDisplayDuration, 0, 1);
			tlpMedia.Controls.Add(nudMediaDisplayDuration, 1, 1);
			tlpMedia.Controls.Add(chkMediaShowAlbum, 0, 2);
			tlpMedia.Location = new Point(6, 6);
			tlpMedia.Name = "tlpMedia";
			tlpMedia.RowCount = 4;
			tlpMedia.RowStyles.Add(new RowStyle());
			tlpMedia.RowStyles.Add(new RowStyle());
			tlpMedia.RowStyles.Add(new RowStyle());
			tlpMedia.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
			tlpMedia.Size = new Size(756, 217);
			tlpMedia.TabIndex = 7;
			// 
			// chkShowMedia
			// 
			chkShowMedia.AutoSize = true;
			tlpMedia.SetColumnSpan(chkShowMedia, 2);
			chkShowMedia.Dock = DockStyle.Fill;
			chkShowMedia.Location = new Point(3, 3);
			chkShowMedia.Name = "chkShowMedia";
			chkShowMedia.Size = new Size(750, 19);
			chkShowMedia.TabIndex = 4;
			chkShowMedia.Text = "Show Media Status (foobar2000)";
			chkShowMedia.UseVisualStyleBackColor = true;
			// 
			// lblMediaDisplayDuration
			// 
			lblMediaDisplayDuration.AutoSize = true;
			lblMediaDisplayDuration.Dock = DockStyle.Fill;
			lblMediaDisplayDuration.Location = new Point(3, 25);
			lblMediaDisplayDuration.Name = "lblMediaDisplayDuration";
			lblMediaDisplayDuration.Size = new Size(182, 29);
			lblMediaDisplayDuration.TabIndex = 18;
			lblMediaDisplayDuration.Text = "Main Display Duration (Seconds):";
			lblMediaDisplayDuration.TextAlign = ContentAlignment.MiddleLeft;
			// 
			// nudMediaDisplayDuration
			// 
			nudMediaDisplayDuration.Dock = DockStyle.Fill;
			nudMediaDisplayDuration.Location = new Point(191, 28);
			nudMediaDisplayDuration.Name = "nudMediaDisplayDuration";
			nudMediaDisplayDuration.Size = new Size(562, 23);
			nudMediaDisplayDuration.TabIndex = 17;
			// 
			// chkMediaShowAlbum
			// 
			chkMediaShowAlbum.AutoSize = true;
			tlpMedia.SetColumnSpan(chkMediaShowAlbum, 2);
			chkMediaShowAlbum.Dock = DockStyle.Fill;
			chkMediaShowAlbum.Location = new Point(3, 57);
			chkMediaShowAlbum.Name = "chkMediaShowAlbum";
			chkMediaShowAlbum.Size = new Size(750, 19);
			chkMediaShowAlbum.TabIndex = 19;
			chkMediaShowAlbum.Text = "Show Album Title";
			chkMediaShowAlbum.UseVisualStyleBackColor = true;
			// 
			// tpAbout
			// 
			tpAbout.Controls.Add(tlpAbout);
			tpAbout.Location = new Point(4, 24);
			tpAbout.Name = "tpAbout";
			tpAbout.Size = new Size(768, 229);
			tpAbout.TabIndex = 5;
			tpAbout.Text = "About";
			tpAbout.UseVisualStyleBackColor = true;
			// 
			// tlpAbout
			// 
			tlpAbout.ColumnCount = 1;
			tlpAbout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
			tlpAbout.Controls.Add(lblApplicationDescription, 0, 2);
			tlpAbout.Controls.Add(lblApplicationWrittenBy, 0, 3);
			tlpAbout.Controls.Add(lblApplicationName, 0, 1);
			tlpAbout.Controls.Add(lklApplicationUrl, 0, 4);
			tlpAbout.Dock = DockStyle.Fill;
			tlpAbout.Location = new Point(0, 0);
			tlpAbout.Name = "tlpAbout";
			tlpAbout.RowCount = 6;
			tlpAbout.RowStyles.Add(new RowStyle(SizeType.Percent, 18.75F));
			tlpAbout.RowStyles.Add(new RowStyle(SizeType.Percent, 15.625F));
			tlpAbout.RowStyles.Add(new RowStyle(SizeType.Percent, 15.625F));
			tlpAbout.RowStyles.Add(new RowStyle(SizeType.Percent, 15.625F));
			tlpAbout.RowStyles.Add(new RowStyle(SizeType.Percent, 15.625F));
			tlpAbout.RowStyles.Add(new RowStyle(SizeType.Percent, 18.75F));
			tlpAbout.Size = new Size(768, 229);
			tlpAbout.TabIndex = 1;
			// 
			// lblApplicationDescription
			// 
			lblApplicationDescription.AutoSize = true;
			lblApplicationDescription.Dock = DockStyle.Fill;
			lblApplicationDescription.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
			lblApplicationDescription.Location = new Point(3, 77);
			lblApplicationDescription.Name = "lblApplicationDescription";
			lblApplicationDescription.Size = new Size(762, 35);
			lblApplicationDescription.TabIndex = 3;
			lblApplicationDescription.Text = "---";
			lblApplicationDescription.TextAlign = ContentAlignment.MiddleCenter;
			// 
			// lblApplicationWrittenBy
			// 
			lblApplicationWrittenBy.AutoSize = true;
			lblApplicationWrittenBy.Dock = DockStyle.Fill;
			lblApplicationWrittenBy.Location = new Point(3, 112);
			lblApplicationWrittenBy.Name = "lblApplicationWrittenBy";
			lblApplicationWrittenBy.Size = new Size(762, 35);
			lblApplicationWrittenBy.TabIndex = 1;
			lblApplicationWrittenBy.Text = "---";
			lblApplicationWrittenBy.TextAlign = ContentAlignment.MiddleCenter;
			// 
			// lblApplicationName
			// 
			lblApplicationName.AutoSize = true;
			lblApplicationName.Dock = DockStyle.Fill;
			lblApplicationName.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
			lblApplicationName.Location = new Point(3, 42);
			lblApplicationName.Name = "lblApplicationName";
			lblApplicationName.Size = new Size(762, 35);
			lblApplicationName.TabIndex = 0;
			lblApplicationName.Text = "---";
			lblApplicationName.TextAlign = ContentAlignment.MiddleCenter;
			// 
			// lklApplicationUrl
			// 
			lklApplicationUrl.AutoSize = true;
			lklApplicationUrl.Dock = DockStyle.Fill;
			lklApplicationUrl.Location = new Point(3, 147);
			lklApplicationUrl.Name = "lklApplicationUrl";
			lklApplicationUrl.Size = new Size(762, 35);
			lklApplicationUrl.TabIndex = 2;
			lklApplicationUrl.TabStop = true;
			lklApplicationUrl.Text = "---";
			lklApplicationUrl.TextAlign = ContentAlignment.MiddleCenter;
			lklApplicationUrl.LinkClicked += LklApplicationUrl_LinkClicked;
			// 
			// MainForm
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(800, 500);
			Controls.Add(tcTabs);
			Controls.Add(ctrlDisplayControl);
			Controls.Add(stpMain);
			DoubleBuffered = true;
			Icon = (Icon)resources.GetObject("$this.Icon");
			MaximizeBox = false;
			MinimumSize = new Size(816, 539);
			Name = "MainForm";
			StartPosition = FormStartPosition.CenterScreen;
			FormClosing += MainForm_FormClosing;
			Load += MainForm_Load;
			Resize += MainForm_Resize;
			stpMain.ResumeLayout(false);
			stpMain.PerformLayout();
			tcTabs.ResumeLayout(false);
			tpGeneral.ResumeLayout(false);
			tlpGeneral.ResumeLayout(false);
			tlpGeneral.PerformLayout();
			tpBigClock.ResumeLayout(false);
			tlpBigClock.ResumeLayout(false);
			tlpBigClock.PerformLayout();
			((System.ComponentModel.ISupportInitialize)nudClockDateDuration).EndInit();
			((System.ComponentModel.ISupportInitialize)nudClockTimeDuration).EndInit();
			tpWeather.ResumeLayout(false);
			tlpWeather.ResumeLayout(false);
			tlpWeather.PerformLayout();
			((System.ComponentModel.ISupportInitialize)nudWeatherMainDuration).EndInit();
			((System.ComponentModel.ISupportInitialize)nudWeatherSubDuration).EndInit();
			tpSystemNetwork.ResumeLayout(false);
			tableLayoutPanel2.ResumeLayout(false);
			tableLayoutPanel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)nudSystemDisplayDuration).EndInit();
			((System.ComponentModel.ISupportInitialize)nudNetworkDisplayDuration).EndInit();
			tpMedia.ResumeLayout(false);
			tlpMedia.ResumeLayout(false);
			tlpMedia.PerformLayout();
			((System.ComponentModel.ISupportInitialize)nudMediaDisplayDuration).EndInit();
			tpAbout.ResumeLayout(false);
			tlpAbout.ResumeLayout(false);
			tlpAbout.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion
		private StatusStrip stpMain;
		private ToolStripStatusLabel tsslStatus;
		private CheckBox chkShowStartupMessage;
		private Display.DisplayControl ctrlDisplayControl;
		private TabControl tcTabs;
		private TabPage tpGeneral;
		private TabPage tpBigClock;
		private TabPage tpWeather;
		private TabPage tpSystemNetwork;
		private TabPage tpMedia;
		private TableLayoutPanel tlpGeneral;
		private TabPage tpAbout;
		private TableLayoutPanel tlpAbout;
		private Label lblApplicationDescription;
		private Label lblApplicationWrittenBy;
		private Label lblApplicationName;
		private LinkLabel lklApplicationUrl;
		private TableLayoutPanel tlpBigClock;
		private CheckBox chkClockShowDate;
		private TableLayoutPanel tlpWeather;
		private CheckBox chkShowWeatherMain;
		private TableLayoutPanel tableLayoutPanel2;
		private CheckBox chkShowSystemStatus;
		private TableLayoutPanel tlpMedia;
		private CheckBox chkShowMedia;
		private CheckBox chkClockShowTime;
		private CheckBox chkShowWeatherSub;
		private CheckBox chkShowNetworkStatus;
		private CheckBox chkNetworkShowMacAndAdapter;
		private Label lblWeatherApiKey;
		private TextBox txtWeatherApiKey;
		private Label lblWeatherPostcode;
		private TextBox txtWeatherPostcode;
		private Label lblWeatherCountry;
		private TextBox txtWeatherCountry;
		private Label lblWeatherUnits;
		private ComboBox cmbWeatherUnits;
		private NumericUpDown nudClockDateDuration;
		private NumericUpDown nudClockTimeDuration;
		private Label lblClockDateDuration;
		private Label lblClockTimeDuration;
		private CheckBox chkWeatherShowLocation;
		private NumericUpDown nudWeatherMainDuration;
		private Label lblWeatherMainDuration;
		private NumericUpDown nudWeatherSubDuration;
		private Label lblWeatherSubDuration;
		private Label lblMediaDisplayDuration;
		private NumericUpDown nudMediaDisplayDuration;
		private CheckBox chkMediaShowAlbum;
		private Label lblSystemDisplayDuration;
		private NumericUpDown nudNetworkDisplayDuration;
		private Label lblNetworkDisplayDuration;
		private NumericUpDown nudSystemDisplayDuration;
	}
}
