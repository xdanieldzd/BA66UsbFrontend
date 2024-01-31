namespace BA66UsbFrontend.Content.Clock
{
	public class BigDateContent : BigClockContentBase
	{
		public override BigClockMode Mode => BigClockMode.Date;

		public BigDateContent() => DisplayDuration = TimeSpan.FromSeconds(5.0);
	}
}
