using Newtonsoft.Json;

namespace BA66UsbFrontend.Content.Weather
{
	public class Location
	{
		[JsonProperty("zip")]
		public string Postcode { get; set; } = "00000";
		[JsonProperty("name")]
		public string Name { get; set; } = "Noname";
		[JsonProperty("lat")]
		public double Latitude { get; set; } = 0.0;
		[JsonProperty("lon")]
		public double Longitude { get; set; } = 0.0;
		[JsonProperty("country")]
		public string Country { get; set; } = "??";
	}
}
