using Device.Net;
using Hid.Net.Windows;
using Usb.Net.Windows;

namespace BA66UsbFrontend.UsbHid
{
	public abstract class UsbDevice
	{
		readonly IDeviceFactory deviceFactory;
		IDevice device = null;

		public abstract ushort VendorId { get; }
		public abstract ushort ProductId { get; }
		public abstract ushort? UsagePage { get; }
		public abstract ushort? UsageId { get; }

		public bool IsInitialized { get; private set; } = false;

		public string ProductName { get; private set; } = "<unknown>";
		public int WriteBufferSize { get; private set; } = 0;
		public int ReadBufferSize { get; private set; } = 0;

		public UsbDevice()
		{
			var hidFactory = new FilterDeviceDefinition(vendorId: VendorId, productId: ProductId).CreateWindowsHidDeviceFactory();
			var usbFactory = new FilterDeviceDefinition(vendorId: VendorId, productId: ProductId).CreateWindowsUsbDeviceFactory();
			deviceFactory = hidFactory.Aggregate(usbFactory);
		}

		public virtual async Task Initialize()
		{
			var deviceDefinitions = (await deviceFactory.GetConnectedDeviceDefinitionsAsync().ConfigureAwait(false)).ToList();

			foreach (var deviceDefinition in deviceDefinitions)
			{
				if (((UsagePage.HasValue && deviceDefinition.UsagePage == UsagePage) || !UsagePage.HasValue) &&
					((UsageId.HasValue && deviceDefinition.Usage == UsageId) || !UsageId.HasValue))
				{
					device = await deviceFactory.GetDeviceAsync(deviceDefinition).ConfigureAwait(false);
					await device.InitializeAsync().ConfigureAwait(false);

					IsInitialized = device.IsInitialized;
					ProductName = deviceDefinition.ProductName;
					WriteBufferSize = deviceDefinition.WriteBufferSize.GetValueOrDefault();
					ReadBufferSize = deviceDefinition.ReadBufferSize.GetValueOrDefault();
					return;
				}
			}

			throw new UsbDeviceNotFoundException(VendorId, ProductId)
			{
				UsagePage = UsagePage.GetValueOrDefault(),
				Usage = UsageId.GetValueOrDefault(),
				ErrorType = deviceDefinitions.Count == 0 ? UsbDeviceNotFoundExceptionType.DeviceNotFound : UsbDeviceNotFoundExceptionType.DeviceFoundButWrongUsage
			};
		}

		public void Close()
		{
			device?.Dispose();
			device = null;
		}

		protected async Task<byte[]> SendAndReceiveBuffer(params byte[] data)
		{
			try
			{
				if (device == null) throw new NullReferenceException("Device is null, initialization has failed");

				var writeBuffer = new byte[device.ConnectedDeviceDefinition.WriteBufferSize.GetValueOrDefault()];
				Buffer.BlockCopy(data, 0, writeBuffer, 1, Math.Min(data.Length, writeBuffer.Length - 1));

				return await device.WriteAndReadAsync(writeBuffer).ConfigureAwait(false);
			}
			catch (IOException)
			{
				IsInitialized = false;
				return new byte[4];
			}
		}

		protected async Task SendBuffer(params byte[] data)
		{
			try
			{
				if (device == null) throw new NullReferenceException("Device is null, initialization has failed");

				var writeBuffer = new byte[device.ConnectedDeviceDefinition.WriteBufferSize.GetValueOrDefault()];
				Buffer.BlockCopy(data, 0, writeBuffer, 1, Math.Min(data.Length, writeBuffer.Length - 1));

				await device.WriteAsync(writeBuffer).ConfigureAwait(false);
			}
			catch (IOException)
			{
				IsInitialized = false;
			}
		}
	}
}
