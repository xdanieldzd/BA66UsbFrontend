using BA66UsbFrontend.Content.Weather;
using Newtonsoft.Json;

namespace BA66UsbFrontend
{
	public class Configuration
	{
		public bool ShowStartupMessage { get; set; } = false;

		public bool ShowBigClockDate { get; set; } = true;
		public bool ShowBigClockTime { get; set; } = true;
		public bool ShowWeatherMain { get; set; } = true;
		public bool ShowWeatherSub { get; set; } = true;
		public bool ShowSystemStatus { get; set; } = true;
		public bool ShowNetworkStatus { get; set; } = true;
		public bool ShowMedia { get; set; } = true;

		public double BigClockDateDuration { get; set; } = 5.0;
		public double BigClockTimeDuration { get; set; } = 10.0;
		public double WeatherMainDuration { get; set; } = 5.0;
		public double WeatherSubDuration { get; set; } = 5.0;
		public double SystemStatusDuration { get; set; } = 5.0;
		public double NetworkStatusDuration { get; set; } = 5.0;
		public double MediaDuration { get; set; } = 5.0;

		public string WeatherApiKey { get; set; } = string.Empty;
		public string WeatherPostcode { get; set; } = string.Empty;
		public string WeatherCountry { get; set; } = string.Empty;
		public WeatherUnits WeatherUnits { get; set; } = WeatherUnits.Metric;
		public bool WeatherShowLocation { get; set; } = false;

		public bool NetworkShowMacAndAdapter { get; set; } = true;

		public bool MediaShowAlbum { get; set; } = true;

		public static Configuration Load(string filename)
		{
			return File.Exists(filename) && JsonConvert.DeserializeObject<Configuration>(File.ReadAllText(filename)) is Configuration configuration ? configuration : new();
		}

		public static void Save(string filename, Configuration configuration)
		{
			var directory = Path.GetDirectoryName(filename) ?? throw new NullReferenceException("Configuration directory is invalid");
			_ = Directory.CreateDirectory(directory);
			File.WriteAllText(filename, JsonConvert.SerializeObject(configuration, Formatting.Indented));
		}
	}
}
