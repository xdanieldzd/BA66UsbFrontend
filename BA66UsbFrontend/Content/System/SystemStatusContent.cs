using BA66UsbFrontend.Display;
using System.Diagnostics;
using System.Text;

namespace BA66UsbFrontend.Content.System
{
	public class SystemStatusContent : ContentBase
	{
		PerformanceCounter processorTimePerformanceCounter = default;
		CounterSample processorTimePrevSample = default, processorTimeNextSample = default;
		PerformanceCounter memoryInUsePerformanceCounter = default;
		CounterSample memoryInUsePrevSample = default, memoryInUseNextSample = default;

		public SystemStatusContent()
		{
			DisplayDuration = TimeSpan.FromSeconds(5.0);

			Task.Run(() =>
			{
				if (OperatingSystem.IsWindows())
				{
					processorTimePerformanceCounter = new("Processor", "% Processor Time", "_Total");
					processorTimePrevSample = CounterSample.Empty;
					processorTimeNextSample = CounterSample.Empty;

					memoryInUsePerformanceCounter = new("Memory", "% Committed Bytes In Use");
					memoryInUsePrevSample = CounterSample.Empty;
					memoryInUseNextSample = CounterSample.Empty;
				}
			});
		}

		private static double GetPerfValue(PerformanceCounter counter, ref CounterSample prevSample, ref CounterSample nextSample)
		{
			if (!OperatingSystem.IsWindows() || counter == null) return 0.0;

			var currentSample = counter.NextSample();
			if (currentSample.SystemFrequency != 0)
			{
				var diff = (currentSample.TimeStamp - nextSample.TimeStamp) / currentSample.SystemFrequency;
				if (diff > 0.5 || diff < -0.5)
				{
					prevSample = nextSample;
					nextSample = currentSample;
					if (prevSample.Equals(CounterSample.Empty))
						prevSample = currentSample;
				}
			}
			else
			{
				prevSample = nextSample;
				nextSample = currentSample;
			}

			var perfValue = CounterSample.Calculate(prevSample, currentSample);
			return (double)perfValue;
		}

		public override void Update(Encoding textEncoding, Size displaySize)
		{
			var cpuUsage = GetPerfValue(processorTimePerformanceCounter, ref processorTimePrevSample, ref processorTimeNextSample);
			var ramUsage = GetPerfValue(memoryInUsePerformanceCounter, ref memoryInUsePrevSample, ref memoryInUseNextSample);

			var dataString1 = DisplayUtilities.GetHeader("System", displaySize.Width);
			var dataString2 = "\x1B[2;1H" + $"{Environment.UserName}@{Environment.MachineName}".PadRight(displaySize.Width)[..displaySize.Width];
			var dataString3 = "\x1B[3;1H" + $"CPU {cpuUsage:000}%    Mem {ramUsage:000}%".PadRight(displaySize.Width)[..displaySize.Width];
			var dataString4 = "\x1B[4;1H" + $"Up  {TimeSpan.FromMilliseconds(Environment.TickCount64):ddd'd 'hh'h 'mm'm 'ss's'}".PadRight(displaySize.Width)[..displaySize.Width];

			dataBytes = textEncoding.GetBytes(dataString1 + dataString2 + dataString3 + dataString4);
		}
	}
}
