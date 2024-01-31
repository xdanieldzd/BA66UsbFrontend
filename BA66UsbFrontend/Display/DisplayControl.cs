using System.Drawing.Drawing2D;
using System.Text;

namespace BA66UsbFrontend.Display
{
	public partial class DisplayControl : UserControl, IDisplay
	{
		// TODO: country codes etc

		readonly static int numberOfLines = 4;
		readonly static int columnsPerLine = 20;

		readonly static int pixelsPerPixelVisible = 3;
		readonly static int pixelsPerPixelGap = 2;
		readonly static int pixelsPerPixelTotal = pixelsPerPixelVisible + pixelsPerPixelGap;

		readonly static int characterGap = 8;

		readonly Rectangle[] characterRectangles = new Rectangle[256];

		readonly Size padding = new(4 * pixelsPerPixelTotal, 4 * pixelsPerPixelTotal);

		readonly char[,] characterMap = new char[numberOfLines, columnsPerLine];

		public int CodePage { get; set; } = 437;

		Rectangle displayRectangle = default;
		Bitmap characterSet = default;
		Size characterSize = default;
		Point cursorPosition = Point.Empty;
		byte countryCode = 0;

		public DisplayControl()
		{
			InitializeComponent();

			DoubleBuffered = true;
		}

		protected override void OnLoad(EventArgs e)
		{
			GenerateCharacters(0x00);

			Clear(' ');
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			displayRectangle = new(
				0,
				0,
				(padding.Width * 2) + ((columnsPerLine * (characterSize.Width + characterGap)) - characterGap),
				(padding.Height * 2) + (numberOfLines * (characterSize.Height + characterGap) - characterGap));

			e.Graphics.TranslateTransform(e.Graphics.VisibleClipBounds.Width / 2 - displayRectangle.Width / 2, e.Graphics.VisibleClipBounds.Height / 2 - displayRectangle.Height / 2);

			e.Graphics.Clear(Color.Black);

			if (!DesignMode)
			{
				e.Graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
				e.Graphics.InterpolationMode = InterpolationMode.NearestNeighbor;

				if (characterSet == null) return;
				for (var y = 0; y < numberOfLines; y++)
				{
					for (var x = 0; x < columnsPerLine; x++)
					{
						var destRect = new Rectangle(
						padding.Width + (x * (characterSize.Width + characterGap)),
							padding.Height + (y * (characterSize.Height + characterGap)),
							characterSize.Width,
							characterSize.Height);

						e.Graphics.DrawImage(characterSet,
							destRect,
							characterRectangles[characterMap[y, x]],
							GraphicsUnit.Pixel);
						//graphics.DrawRectangle(Pens.Red, destRect);
					}
				}
			}
		}

		private void GenerateCharacters(byte countryCode)
		{
			characterSet?.Dispose();

			var charactersRaw = Resources.GetEmbeddedBitmap($"Assets.Font-{countryCode:X2}.png");
			if (charactersRaw != null)
			{
				characterSet = new(charactersRaw.Width * pixelsPerPixelTotal, charactersRaw.Height * pixelsPerPixelTotal);

				for (int ySrc = 0, yDest = 0; ySrc < charactersRaw.Height; ySrc++, yDest += pixelsPerPixelTotal)
				{
					for (int xSrc = 0, xDest = 0; xSrc < charactersRaw.Width; xSrc++, xDest += pixelsPerPixelTotal)
					{
						for (var yPixel = 0; yPixel < pixelsPerPixelVisible; yPixel++)
						{
							for (var xPixel = 0; xPixel < pixelsPerPixelVisible; xPixel++)
							{
								characterSet.SetPixel(xDest + xPixel, yDest + yPixel, charactersRaw.GetPixel(xSrc, ySrc));
							}
						}
					}
				}
			}
			else
				characterSet = charactersRaw;

			characterSize = new((characterSet!.Width / 16) - pixelsPerPixelTotal, (characterSet!.Height / 16) - pixelsPerPixelTotal);

			for (var i = 0; i < characterRectangles.Length; i++)
				characterRectangles[i] = new(new(i % 16 * (characterSize.Width + pixelsPerPixelTotal), i / 16 * (characterSize.Height + pixelsPerPixelTotal)), characterSize);
		}

		public void ClearScreen() => Clear(' ');

		private void Clear(char ch)
		{
			for (var y = 0; y < numberOfLines; y++)
				for (var x = 0; x < columnsPerLine; x++)
					characterMap[y, x] = ch;
		}

		public Task WriteData(params byte[] data)
		{
			for (var i = 0; i < data.Length; i++)
			{
				switch (data[i])
				{
					case 0x1B: // ESC
						switch (data[i + 1])
						{
							case 0x5B: // '['
								if (data[i + 2] == 0x32 && data[i + 3] == 0x4A) // '2','J'
								{
									Clear(' ');
									i += 3;
								}
								else if (data[i + 3] == 0x3B && data[i + 5] == 0x48) // y,';',x,'H'
								{
									cursorPosition.Y = data[i + 2] - 0x31;
									cursorPosition.X = data[i + 4] - 0x31;
									i += 5;
								}
								else if (data[i + 2] == 0x30 && data[i + 3] == 0x4B) // '0','K'
								{
									for (var x = cursorPosition.X; x < columnsPerLine; x++)
										characterMap[cursorPosition.Y, x] = ' ';
									i += 3;
								}
								break;

							case 0x52: // 'R'
								countryCode = data[i + 2];
								i += 2;
								break;
						}
						break;

					default:
						characterMap[cursorPosition.Y, cursorPosition.X] = (char)data[i];
						if (cursorPosition.X < columnsPerLine - 1) cursorPosition.X++;
						break;
				}
			}

			return Task.CompletedTask;
		}

		public void SetCountryCode(byte countryCode)
		{
			GenerateCharacters(countryCode);
			CodePage = countryCode switch
			{
				0x29 => 866,
				0x30 => 437,
				0x31 => 850,
				0x32 => 852,
				0x33 => 857,
				0x34 => 858,
				0x35 => 866,
				0x37 => 862,
				0x38 => 813,
				_ => 437,
			};
			WriteData([.. Encoding.ASCII.GetBytes("\x1BR"), countryCode]);
		}
	}
}
