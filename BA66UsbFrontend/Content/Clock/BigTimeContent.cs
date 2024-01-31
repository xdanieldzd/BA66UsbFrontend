namespace BA66UsbFrontend.Content.Clock
{
	public class BigTimeContent : BigClockContentBase
	{
		public override BigClockMode Mode => BigClockMode.Time;

		public BigTimeContent() => DisplayDuration = TimeSpan.FromSeconds(10.0);
	}
}
