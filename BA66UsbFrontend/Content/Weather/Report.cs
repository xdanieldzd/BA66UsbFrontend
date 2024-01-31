using Newtonsoft.Json.Linq;

namespace BA66UsbFrontend.Content.Weather
{
	public class Report
	{
		public Location Location { get; } = default;
		public DateTime CurrentTime { get; } = default;

		public string Group { get; } = "Unknown";
		public string Description { get; } = "check connection!";
		public double Temperature { get; } = 0.0;
		public double TempFeelsLike { get; } = 0.0;
		public double TempMin { get; } = 0.0;
		public double TempMax { get; } = 0.0;
		public double Pressure { get; } = 0.0;
		public double Humidity { get; } = 0.0;
		public DateTime SunriseTime { get; } = DateTime.UnixEpoch;
		public DateTime SunsetTime { get; } = DateTime.UnixEpoch;

		public Report() { }

		public Report(Location location, JObject weatherData)
		{
			Location = location;
			CurrentTime = DateTime.Now;

			var weatherCondition = weatherData?["weather"]?.First;
			Group = weatherCondition?["main"]?.Value<string>() ?? string.Empty;
			Description = weatherCondition?["description"]?.Value<string>() ?? string.Empty;

			var mainData = weatherData?["main"];
			Temperature = mainData?["temp"]?.Value<double>() ?? 0.0;
			TempFeelsLike = mainData?["feels_like"]?.Value<double>() ?? 0.0;
			TempMin = mainData?["temp_min"]?.Value<double>() ?? 0.0;
			TempMax = mainData?["temp_max"]?.Value<double>() ?? 0.0;
			Pressure = mainData?["pressure"]?.Value<double>() ?? 0.0;
			Humidity = mainData?["humidity"]?.Value<double>() ?? 0.0;

			var sysData = weatherData?["sys"];
			SunriseTime = DateTimeOffset.FromUnixTimeSeconds(sysData?["sunrise"]?.Value<long>() ?? 0).DateTime.ToLocalTime();
			SunsetTime = DateTimeOffset.FromUnixTimeSeconds(sysData?["sunset"]?.Value<long>() ?? 0).DateTime.ToLocalTime();
		}
	}
}
