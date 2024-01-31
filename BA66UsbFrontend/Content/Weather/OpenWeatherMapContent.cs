using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Diagnostics;

namespace BA66UsbFrontend.Content.Weather
{
	public enum WeatherUnits { Standard, Metric, Imperial }

	public abstract class OpenWeatherMapContent : ContentBase
	{
		protected static readonly Dictionary<WeatherUnits, string> weatherUnitsDict = new()
		{
			{ WeatherUnits.Standard, "standard" },
			{ WeatherUnits.Metric, "metric" },
			{ WeatherUnits.Imperial, "imperial" },
		};

		protected static readonly Dictionary<WeatherUnits, string> weatherSuffixDict = new()
		{
			{ WeatherUnits.Standard, " K" },
			{ WeatherUnits.Metric, "°C" },
			{ WeatherUnits.Imperial, "°F" },
		};

		static readonly TimeSpan updateDelay = TimeSpan.FromMinutes(15.0);

		static readonly string baseUri = "http://api.openweathermap.org/";
		static readonly string currentWeatherEndpoint = "data/2.5/weather";
		static readonly string geocodingZipEndpoint = "geo/1.0/zip";

		static readonly HttpClientHandler clientHandler = new();
		static readonly HttpClient client = new(clientHandler) { Timeout = TimeSpan.FromSeconds(3.0) };

		readonly Stopwatch updateStopwatch = Stopwatch.StartNew();
		bool firstRun = true;
		Report lastReport = new();

		protected static async Task<Location> GetLocation()
		{
			if (string.IsNullOrEmpty(Program.Configuration.WeatherApiKey)) return new();

			try
			{
				var uri = $"{baseUri}{geocodingZipEndpoint}?zip={Program.Configuration.WeatherPostcode},{Program.Configuration.WeatherCountry}&appid={Program.Configuration.WeatherApiKey}";
				var response = await client.GetAsync(uri).ConfigureAwait(false);
				return JsonConvert.DeserializeObject<Location>(await response.Content.ReadAsStringAsync());
			}
			catch
			{
				return new();
			}
		}

		protected async Task<Report> GetCurrentWeather()
		{
			if (string.IsNullOrEmpty(Program.Configuration.WeatherApiKey)) return new();

			try
			{
				if (!weatherUnitsDict.TryGetValue(Program.Configuration.WeatherUnits, out string unit)) throw new Exception($"Unsupported or invalid weather unit '{Program.Configuration.WeatherUnits}' selected");

				if (updateStopwatch.Elapsed >= updateDelay || firstRun)
				{
					updateStopwatch.Restart();
					firstRun = false;

					var location = await GetLocation();

					var uri = $"{baseUri}{currentWeatherEndpoint}?lat={location?.Latitude}&lon={location?.Longitude}&units={unit}&appid={Program.Configuration.WeatherApiKey}";
					var response = await client.GetAsync(uri).ConfigureAwait(false);

					lastReport = new Report(location, JObject.Parse(await response.Content.ReadAsStringAsync()));
				}
			}
			catch
			{
				firstRun = false;
			}

			return lastReport;
		}
	}
}
