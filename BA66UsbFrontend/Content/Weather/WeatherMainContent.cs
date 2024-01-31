using BA66UsbFrontend.Display;
using System.Text;

namespace BA66UsbFrontend.Content.Weather
{
	public class WeatherMainContent : OpenWeatherMapContent
	{
		public WeatherMainContent() => DisplayDuration = TimeSpan.FromSeconds(5.0);

		public override async void Update(Encoding textEncoding, Size displaySize)
		{
			var weatherReport = await GetCurrentWeather();

			if (!weatherSuffixDict.TryGetValue(Program.Configuration.WeatherUnits, out string unitSuffix)) throw new Exception($"Unsupported or invalid weather unit '{Program.Configuration.WeatherUnits}' selected");

			var dataString1 = DisplayUtilities.GetHeader("Weather", displaySize.Width);

			string dataString2;
			if (Program.Configuration.WeatherShowLocation)
			{
				var weatherLocation = $"{weatherReport?.Location?.Postcode} {weatherReport?.Location?.Name}, {weatherReport?.Location?.Country}";
				if (weatherLocation.Length > displaySize.Width)
					dataString2 = DisplayUtilities.ScrollLine(2, 0.25, weatherLocation, "   ", displaySize.Width);
				else
					dataString2 = "\x1B[2;1H" + $"{weatherLocation}".PadRight(displaySize.Width)[..displaySize.Width];
			}
			else
				dataString2 = "\x1B[2;1H" + " Current conditions ".PadRight(displaySize.Width)[..displaySize.Width];

			var dataString3 = "\x1B[3;1H" + $"{weatherReport?.Temperature:0.0}{unitSuffix}, feels {weatherReport?.TempFeelsLike:0.0}{unitSuffix}".PadRight(displaySize.Width)[..displaySize.Width];

			string dataString4;

			var weatherDescription = $"{weatherReport?.Group}, {weatherReport?.Description}";
			if (weatherDescription.Length > displaySize.Width)
				dataString4 = DisplayUtilities.ScrollLine(4, 0.25, weatherDescription, "   ", displaySize.Width);
			else
				dataString4 = $"\x1B[4;1H{weatherDescription.PadRight(displaySize.Width)[..displaySize.Width]}";

			dataBytes = textEncoding.GetBytes(dataString1 + dataString2 + dataString3 + dataString4);
		}
	}
}
