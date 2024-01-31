using BA66UsbFrontend.Display;
using Newtonsoft.Json.Linq;
using System.Text;

namespace BA66UsbFrontend.Content.Music
{
	public class Foobar2kContent : ContentBase
	{
		static readonly Dictionary<int, string> musicVolumeStrings = new()
		{
			{ 0, " x " },
			{ 1, "_  " },
			{ 2, "_▄ " },
			{ 3, "_▄█" }
		};

		static readonly Dictionary<string, string> musicPlaybackStrings = new()
		{
			{ "stopped", "ST" },
			{ "playing", "PL" },
			{ "paused", "PA" }
		};

		static readonly string baseUri = "http://localhost:8880/api/";
		static readonly string playerStateEndpoint = "player";
		static readonly string[] columns = ["artist", "title", "album"];

		static readonly HttpClientHandler clientHandler = new();
		static readonly HttpClient client = new(clientHandler) { Timeout = TimeSpan.FromSeconds(0.25) };

		readonly string requestedColumns = string.Join(',', columns.Select(x => $"%25{x}%25"));

		public Foobar2kContent() => DisplayDuration = TimeSpan.FromSeconds(5.0);

		private async Task<NowPlaying> GetPlayerState()
		{
			try
			{
				var uri = $"{baseUri}{playerStateEndpoint}?columns={requestedColumns}";
				var response = await client.GetAsync(uri).ConfigureAwait(false);
				return new NowPlaying(JObject.Parse(await response.Content.ReadAsStringAsync()));
			}
			catch
			{
				return new();
			}
		}

		public override async void Update(Encoding textEncoding, Size displaySize)
		{
			var musicNowPlaying = await GetPlayerState();

			var dataString1 = DisplayUtilities.GetHeader("Media", displaySize.Width);

			var artistAlbumTitleLine = Program.Configuration.MediaShowAlbum && !string.IsNullOrWhiteSpace(musicNowPlaying.Album) ?
				$"{musicNowPlaying.Artist} - {musicNowPlaying.Album} - {musicNowPlaying.Title}" :
				$"{musicNowPlaying.Artist} - {musicNowPlaying.Title}";

			var dataString2 = DisplayUtilities.ScrollLine(2, 0.25, artistAlbumTitleLine, "  ·  ", displaySize.Width);

			var trackPos = musicNowPlaying.Duration.TotalSeconds == 0.0 ? 0 : (int)((displaySize.Width - 3) / musicNowPlaying.Duration.TotalSeconds * musicNowPlaying.Position.TotalSeconds);
			var trackBar = new string('-', trackPos) + (musicNowPlaying.Duration.TotalSeconds == 0.0 ? "-" : "█") + new string('-', displaySize.Width - trackPos - 3);
			var dataString3 = $"\x1B[3;1H[{trackBar}]";

			var volumeLevel = musicNowPlaying.IsMuted ? 0 : (int)(musicNowPlaying.Volume * 100.0 / 50.0) + 1;
			if (!musicPlaybackStrings.TryGetValue(musicNowPlaying.PlaybackState, out string playbackString)) playbackString = "xX";
			if (!musicVolumeStrings.TryGetValue(volumeLevel, out string volumeString)) volumeString = "DED";

			var dataString4 = $"\x1B[4;1H{musicNowPlaying.Position:mm':'ss}/{musicNowPlaying.Duration:mm':'ss} {playbackString} [{volumeString}]";

			dataBytes = textEncoding.GetBytes(dataString1 + dataString2 + dataString3 + dataString4);
		}
	}
}
