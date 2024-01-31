namespace BA66UsbFrontend.Display
{
	public static class DisplayUtilities
	{
		readonly static Dictionary<string, double> scrollOffsetDict = [];

		public static string GetHeader(string label, int width)
		{
			return $"\x1B[1;1H{$"«{label}»".PadRight(width - 8)}{DateTime.Now:HH:mm:ss}";
		}

		public static string ScrollLine(int y, double speed, string text, string padding, int width)
		{
			text += padding;

			scrollOffsetDict.TryGetValue(text, out double startIndex);
			scrollOffsetDict[text] = (startIndex + speed) % text.Length;

			var substring = text[(int)startIndex..];
			if (substring.Length <= width) substring = string.Concat(substring, text);

			return $"\x1B[{y};1H" + substring.PadRight(width)[..width];
		}
	}
}
