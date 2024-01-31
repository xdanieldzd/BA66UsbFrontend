using BA66UsbFrontend.Display;
using System.Text;

namespace BA66UsbFrontend.Content
{
	public abstract class ContentBase
	{
		public TimeSpan DisplayDuration { get; set; } = TimeSpan.FromSeconds(5.0);
		public bool IsEnabled { get; set; } = true;

		protected byte[] dataBytes = [];
		public async Task SendToDevice(IDisplay displayDevice) => await displayDevice?.WriteData(dataBytes);

		public abstract void Update(Encoding textEncoding, Size displaySize);
	}
}
