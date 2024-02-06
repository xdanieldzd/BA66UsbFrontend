using BA66UsbFrontend.Display;
using System.Text;

namespace BA66UsbFrontend.Content.Weather
{
	public class WeatherSubContent : OpenWeatherMapContent
	{
		public WeatherSubContent() => DisplayDuration = TimeSpan.FromSeconds(5.0);

		public override async void Update(Encoding textEncoding, Size displaySize)
		{
			var weatherReport = await GetCurrentWeather();

			if (!weatherSuffixDict.TryGetValue(Program.Configuration.WeatherUnits, out string unitSuffix)) throw new Exception($"Unsupported or invalid weather unit '{Program.Configuration.WeatherUnits}' selected");

			var dataString1 = DisplayUtilities.GetHeader("Weather", displaySize.Width);
			var dataString2 = "\x1B[2;1H" + $"Min{$"{weatherReport?.TempMin:0.0}{unitSuffix}",8}  ¤ {weatherReport?.SunriseTime.TimeOfDay:hh':'mm}".PadRight(displaySize.Width)[..displaySize.Width];
			var dataString3 = "\x1B[3;1H" + $"Max{$"{weatherReport?.TempMax:0.0}{unitSuffix}",8}  ⌂ {weatherReport?.SunsetTime.TimeOfDay:hh':'mm}".PadRight(displaySize.Width)[..displaySize.Width];
			var dataString4 = "\x1B[4;1H" + $"Hum{$"{weatherReport?.Humidity:###}%",4} Prs{$"{weatherReport?.Pressure:#####} hPA",9}".PadRight(displaySize.Width)[..displaySize.Width];

			dataBytes = textEncoding.GetBytes(dataString1 + dataString2 + dataString3 + dataString4);
		}
	}
}
