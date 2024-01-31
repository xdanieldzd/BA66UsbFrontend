namespace BA66UsbFrontend.UsbHid
{
	public enum UsbDeviceNotFoundExceptionType { Unknown = -1, DeviceNotFound, DeviceFoundButWrongUsage }

	public class UsbDeviceNotFoundException : Exception
	{
		public ushort VendorId { get; set; } = 0;
		public ushort ProductId { get; set; } = 0;
		public ushort UsagePage { get; set; } = 0;
		public ushort Usage { get; set; } = 0;
		public UsbDeviceNotFoundExceptionType ErrorType { get; set; } = UsbDeviceNotFoundExceptionType.DeviceNotFound;

		public UsbDeviceNotFoundException() : base() { }
		public UsbDeviceNotFoundException(string message) : base(message) { }
		public UsbDeviceNotFoundException(string message, Exception innerException) : base(message, innerException) { }
		public UsbDeviceNotFoundException(ushort vid, ushort pid) : base()
		{
			VendorId = vid; ProductId = pid;
		}
	}
}
