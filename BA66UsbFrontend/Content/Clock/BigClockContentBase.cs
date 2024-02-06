using System.Text;

namespace BA66UsbFrontend.Content.Clock
{
	public enum BigClockMode { Date, Time }
	public enum BigClockSize { ThreeByThree, ThreeByFour };

	public abstract class BigClockContentBase : ContentBase
	{
		static readonly string[][] digitStrings3x4 =
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

		static readonly string[][] digitStrings3x3 =
		[
			// 0
			[
				"▄▀▄",
				"█ █",
				"▀▄▀",
			],
			// 1
			[
				"▄█ ",
				" █ ",
				"▄█▄",
			],
			// 2
			[
				"▀▀▄",
				" ▄▀",
				"█▄▄",
			],
			// 3
			[
				"▀▀▄",
				" ▀▄",
				"▄▄▀",
			],
			// 4
			[
				"█ ▄",
				"█▄█",
				"  █",
			],
			// 5
			[
				"█▀▀",
				"▀▀▄",
				"▄▄▀",
			],
			// 6
			[
				"▄▀▀",
				"█▀▄",
				"▀▄▀",
			],
			// 7
			[
				"▀▀█",
				" ▄▀",
				" █ ",
			],
			// 8
			[
				"▄▀▄",
				"▄▀▄",
				"▀▄▀",
			],
			// 9
			[
				"▄▀▄",
				"▀▄█",
				"▄▄▀",
			],
		];

		public abstract BigClockMode Mode { get; }

		private string GenerateLine(int line, int[] digits, int width, bool seperatorToggle)
		{
			if (Program.Configuration.BigClockSize == BigClockSize.ThreeByFour)
			{
				var seperator = ' ';
				if (seperatorToggle && Mode == BigClockMode.Time && (line == 1 || line == 2))
					seperator = 'o';
				else if (Mode == BigClockMode.Date && line == 3)
					seperator = seperatorToggle ? 'o' : 'O';

				return
					$"{digitStrings3x4[digits[0]][line]}{digitStrings3x4[digits[1]][line]}" +
					seperator +
					$"{digitStrings3x4[digits[2]][line]}{digitStrings3x4[digits[3]][line]}" +
					seperator +
					$"{digitStrings3x4[digits[4]][line]}{digitStrings3x4[digits[5]][line]}";
			}
			else if (Program.Configuration.BigClockSize == BigClockSize.ThreeByThree)
			{
				if (line == 3)
				{
					var dataString = Mode == BigClockMode.Date ? $"{DateTime.Now:HH:mm:ss}" : $"{DateTime.Now:dd.MM.yyyy}";
					var padding = string.Join(string.Empty, Enumerable.Repeat(' ', (width - (dataString.Length + 4)) / 2));
					return $"{padding}« {dataString} »{padding}";
				}
				else
				{
					var seperator = ' ';
					if (seperatorToggle)
					{
						if (Mode == BigClockMode.Time && line == 1) seperator = ':';
						else if (Mode == BigClockMode.Date && line == 2) seperator = '.';
					}

					return
						$"{digitStrings3x3[digits[0]][line]}{digitStrings3x3[digits[1]][line]}" +
						seperator +
						$"{digitStrings3x3[digits[2]][line]}{digitStrings3x3[digits[3]][line]}" +
						seperator +
						$"{digitStrings3x3[digits[4]][line]}{digitStrings3x3[digits[5]][line]}";
				}
			}
			else
				throw new NotImplementedException($"Invalid BigClock size {Program.Configuration.BigClockSize}");
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
				var lineString = GenerateLine(i, digits, displaySize.Width, currentTime.Second % 2 == 0);
				builder.Add($"\x1B[{i + 1};1H{lineString}");
			}

			dataBytes = textEncoding.GetBytes(string.Join("", builder));
		}
	}
}
