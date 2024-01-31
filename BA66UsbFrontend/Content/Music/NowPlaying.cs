using Newtonsoft.Json.Linq;

namespace BA66UsbFrontend.Content.Music
{
	public class NowPlaying
	{
		static readonly string defaultArtist = "<no artist>";
		static readonly string defaultTitle = "<no title>";
		static readonly string defaultAlbum = "<no album>";
		static readonly string defaultPlaybackState = "stopped";

		public string Artist { get; } = defaultArtist;
		public string Title { get; } = defaultTitle;
		public string Album { get; } = defaultAlbum;
		public TimeSpan Position { get; } = default;
		public TimeSpan Duration { get; } = default;
		public string PlaybackState { get; } = defaultPlaybackState;
		public bool IsMuted { get; } = true;
		public double Volume { get; } = 0.0;

		public NowPlaying() { }

		public NowPlaying(JObject playerData)
		{
			if (playerData == null) return;

			var activeItem = playerData["player"]?["activeItem"];
			Artist = activeItem?.SelectToken("columns[0]")?.Value<string>() ?? defaultArtist;
			Title = activeItem?.SelectToken("columns[1]")?.Value<string>() ?? defaultTitle;
			Album = activeItem?.SelectToken("columns[2]")?.Value<string>() ?? defaultAlbum;
			Position = TimeSpan.FromSeconds(Math.Round(activeItem?["position"]?.Value<double>() ?? 0));
			Duration = TimeSpan.FromSeconds(Math.Round(activeItem?["duration"]?.Value<double>() ?? 0));

			PlaybackState = playerData["player"]?["playbackState"]?.Value<string>() ?? defaultPlaybackState;

			var volume = playerData["player"]?["volume"];
			IsMuted = volume?["isMuted"]?.Value<bool>() ?? false;

			var volValue = volume?["value"]?.Value<double>() ?? 0.0;
			var volMin = volume?["min"]?.Value<double>() ?? 0.0;
			var volMax = volume?["max"]?.Value<double>() ?? 0.0;
			var volType = volume?["type"]?.Value<string>() ?? "db";

			if (volType == "db")
			{
				static double convertLinear(double value, double volMin, double volMax)
				{
					value = Math.Min(Math.Max(value, volMin), volMax);
					return Math.Pow(Math.E, value * Math.Log(20.0) / 50.0);
				}
				Volume = convertLinear(volValue, volMin, volMax);
			}
			else
				throw new NotImplementedException($"Volume type '{volType}' not implemented");
		}
	}
}
