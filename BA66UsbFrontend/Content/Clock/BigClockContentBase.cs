using System.Text;

namespace BA66UsbFrontend.Content.Clock
{
	public enum BigClockMode { Date, Time }

	public abstract class BigClockContentBase : ContentBase
	{
		static readonly string[][] digitStrings =
		[
			// 0
			[
				"▄▀▄",
				"█ █",
				"█ █",
				"▀▄▀",
			],
			// 1
			[
				"▄█ ",
				" █ ",
				" █ ",
				"▄█▄",
			],
			// 2
			[
				"▄▀▄",
				"  █",
				"▄▀ ",
				"█▄▄",
			],
			// 3
			[
				"▄▀▄",
				" ▄█",
				"  █",
				"▀▄▀",
			],
			// 4
			[
				"█ ▄",
				"█ █",
				"▀▀█",
				"  █",
			],
			// 5
			[
				"█▀▀",
				"█▄ ",
				"  █",
				"▀▄▀",
			],
			// 6
			[
				"▄▀▄",
				"█▄ ",
				"█ █",
				"▀▄▀",
			],
			// 7
			[
				"▀▀█",
				" ▄▀",
				" █ ",
				" █ ",
			],
			// 8
			[
				"▄▀▄",
				"▀▄▀",
				"█ █",
				"▀▄▀",
			],
			// 9
			[
				"▄▀▄",
				"█ █",
				" ▀█",
				"▀▄▀",
			],
		];

		public abstract BigClockMode Mode { get; }

		private string GenerateLine(int line, int[] digits, bool seperatorToggle)
		{
			var seperator = ' ';
			if (seperatorToggle && Mode == BigClockMode.Time && (line == 1 || line == 2))
				seperator = 'o';
			else if (Mode == BigClockMode.Date && line == 3)
				seperator = seperatorToggle ? 'o' : 'O';

			return
				$"{digitStrings[digits[0]][line]}{digitStrings[digits[1]][line]}" +
				seperator +
				$"{digitStrings[digits[2]][line]}{digitStrings[digits[3]][line]}" +
				seperator +
				$"{digitStrings[digits[4]][line]}{digitStrings[digits[5]][line]}";
		}

		public override void Update(Encoding textEncoding, Size displaySize)
		{
			var currentTime = DateTime.Now;

			int[] digits = Mode == BigClockMode.Date ?
				[currentTime.Day / 10, currentTime.Day % 10, currentTime.Month / 10, currentTime.Month % 10, currentTime.Year % 100 / 10, currentTime.Year % 100 % 10] :
				[currentTime.Hour / 10, currentTime.Hour % 10, currentTime.Minute / 10, currentTime.Minute % 10, currentTime.Second / 10, currentTime.Second % 10];

			var builder = new List<string>();
			for (var i = 0; i < displaySize.Height; i++)
			{
				var lineString = GenerateLine(i, digits, currentTime.Second % 2 == 0);
				builder.Add($"\x1B[{i + 1};1H{lineString}");
			}

			dataBytes = textEncoding.GetBytes(string.Join("", builder));
		}
	}
}
