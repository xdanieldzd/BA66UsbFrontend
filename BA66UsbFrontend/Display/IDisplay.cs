namespace BA66UsbFrontend.Display
{
	public interface IDisplay
	{
		Task WriteData(params byte[] data);
	}
}
