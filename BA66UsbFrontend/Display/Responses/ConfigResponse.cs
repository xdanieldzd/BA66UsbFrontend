using System.Text;

namespace BA66UsbFrontend.Display.Responses
{
	public class ConfigResponse : Response
	{
		public int TypeOfDisplay { get; set; } = -1;
		public int ActualCodePage { get; set; } = -1;
		public byte CountryCode { get; set; } = 0xFF;
		public int NumberOfLines { get; set; } = -1;
		public int ColumnsPerLine { get; set; } = -1;
		public int CodePageLoadedInSpacePage { get; set; } = -1;
		public string SerialNumber { get; set; } = "<not set>";

		public ConfigResponse(byte[] data) : base(data)
		{
			if (char.IsControl((char)data[DataStartIndex])) return;

			var dataString = Encoding.ASCII.GetString(data[DataStartIndex..]).TrimEnd('\0').Split(';');

			if (!string.IsNullOrWhiteSpace(dataString[0])) TypeOfDisplay = int.Parse(dataString[0]);
			if (!string.IsNullOrWhiteSpace(dataString[1])) ActualCodePage = int.Parse(dataString[1]);
			if (!string.IsNullOrWhiteSpace(dataString[2])) CountryCode = byte.Parse(dataString[2]);
			if (!string.IsNullOrWhiteSpace(dataString[3])) NumberOfLines = int.Parse(dataString[3]);
			if (!string.IsNullOrWhiteSpace(dataString[4])) ColumnsPerLine = int.Parse(dataString[4]);
			if (!string.IsNullOrWhiteSpace(dataString[5])) CodePageLoadedInSpacePage = int.Parse(dataString[5]);
			if (!string.IsNullOrWhiteSpace(dataString[6])) SerialNumber = dataString[6];
		}
	}
}
