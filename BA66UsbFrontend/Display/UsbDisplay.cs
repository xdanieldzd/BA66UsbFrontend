using BA66UsbFrontend.Display.Responses;
using BA66UsbFrontend.UsbHid;
using System.Linq.Expressions;
using System.Text;

namespace BA66UsbFrontend.Display
{
	public class UsbDisplay : UsbDevice, IDisplay
	{
		static readonly ushort displayVendorId = 0x0AA7;    // Wincor Nixdorf
		static readonly ushort displayProductId = 0x0201;   // BA66 USB
		static readonly ushort displayUsagePage = 0xFF45;   // Vendor-specific?
		static readonly ushort displayUsageId = 0x2400;     // Display, 0xA000 is Flash Update

		public override ushort VendorId => displayVendorId;
		public override ushort ProductId => displayProductId;
		public override ushort? UsagePage => displayUsagePage;
		public override ushort? UsageId => displayUsageId;

		public int CodePage { get; private set; } = Encoding.ASCII.CodePage;
		public int NumberOfLines { get; private set; } = 0;
		public int ColumnsPerLine { get; private set; } = 0;

		public ConfigResponse Configuration { get; private set; } = null;

		readonly Dictionary<Type, Func<byte[], Response>> responseCreators = [];

		public override async Task Initialize()
		{
			await base.Initialize();
			if (IsInitialized) await ReadConfiguration();
		}

		private static Func<byte[], T> CreateResponseCreator<T>() where T : Response
		{
			var param = Expression.Parameter(typeof(byte[]), "data");
			var lambda = Expression.Lambda<Func<byte[], T>>(Expression.New(typeof(T).GetConstructor([typeof(byte[])])!, param), param);
			return lambda.Compile();
		}

		public async Task<T> SendCommand<T>(params byte[] data) where T : Response
		{
			var responseType = typeof(T);
			if (!responseCreators.ContainsKey(responseType)) responseCreators[responseType] = CreateResponseCreator<T>();
			return responseCreators[responseType](await SendAndReceiveBuffer(data)) as T;
		}

		private async Task<Response> RequestSelfTest() => await SendCommand<Response>(0x00, 0x10, 0x00);
		private async Task<Response> RequestStatus() => await SendCommand<Response>(0x00, 0x20, 0x00);
		private async Task<Response> RequestReset() => await SendCommand<Response>(0x00, 0x40, 0x00);
		private async Task<ConfigResponse> RequestReadConfiguration() => await SendCommand<ConfigResponse>(0x21, 0x00, 0x00);

		public async Task ReadConfiguration()
		{
			if ((Configuration = await RequestReadConfiguration()) is ConfigResponse config)
			{
				CodePage = config.ActualCodePage;
				NumberOfLines = config.NumberOfLines;
				ColumnsPerLine = config.ColumnsPerLine;
			}
		}

		public async Task WriteData(params byte[] data)
		{
			static byte[] slice(byte[] src, int idx, int len)
			{
				var slice = new byte[len];
				Array.Copy(src, idx, slice, 0, len);
				return slice;
			}

			var maxDataLength = WriteBufferSize - 4;
			var splits = Enumerable.Range(0, data.Length / maxDataLength + 1)
				.Select(x => slice(data, x * maxDataLength, x * maxDataLength + maxDataLength <= data.Length ? maxDataLength : data.Length - x * maxDataLength))
				.ToArray();

			foreach (var split in splits)
			{
				var buffer = new List<byte>() { 0x02, 0x00, (byte)split.Length };
				buffer.AddRange(split);
				await SendBuffer([.. buffer]);
			}
		}

		public async Task ClearScreen() => await WriteData(Encoding.ASCII.GetBytes("\x1B[2J"));
		public async Task SetCursorPosition(int y, int x) => await WriteData(Encoding.ASCII.GetBytes($"\x1B[{y};{x}H"));
		public async Task ClearToLineEnd() => await WriteData(Encoding.ASCII.GetBytes("\x1B[0K"));
		public async Task SetCountryCode(byte countryCode) => await WriteData([.. Encoding.ASCII.GetBytes("\x1BR"), countryCode]);
	}
}
