using BA66UsbFrontend.Display;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;

namespace BA66UsbFrontend.Content.System
{
	public class NetworkStatusContent : ContentBase
	{
		static readonly Dictionary<long, string> networkSpeedThresholds = new()
		{
			{ 1000 * 1000 * 1000, "Gbps" },
			{ 1000 * 1000, "Mbps" },
			{ 1000, "Kbps" }
		};

		NetworkInterface ethernetAdapterInterface = default;

		public NetworkStatusContent()
		{
			DisplayDuration = TimeSpan.FromSeconds(5.0);

			Task.Run(() =>
			{
				foreach (var netInterface in NetworkInterface.GetAllNetworkInterfaces())
				{
					var interfaceProps = netInterface.GetIPProperties();
					if (interfaceProps.GatewayAddresses.Count != 0)
					{
						ethernetAdapterInterface = netInterface;
						break;
					}
				}
			});
		}

		private NetworkStatus GetNetworkStatus()
		{
			try
			{
				var ipAddress = ethernetAdapterInterface?.GetIPProperties()?.UnicastAddresses?.FirstOrDefault(x => x.Address.AddressFamily == AddressFamily.InterNetwork)?.Address;
				var gatewayAddress = ethernetAdapterInterface?.GetIPProperties()?.GatewayAddresses?.FirstOrDefault(x => x.Address.AddressFamily == AddressFamily.InterNetwork)?.Address;
				return new(ethernetAdapterInterface.Description, ipAddress, gatewayAddress, ethernetAdapterInterface.GetPhysicalAddress(), ethernetAdapterInterface.OperationalStatus, ethernetAdapterInterface.Speed);
			}
			catch
			{
				return new();
			}
		}

		public override void Update(Encoding textEncoding, Size displaySize)
		{
			var networkStatus = GetNetworkStatus();

			var dataString1 = DisplayUtilities.GetHeader("Network", displaySize.Width);

			var linkSpeed = networkStatus.SpeedBps;
			var linkSpeedSuffix = "Bps";
			foreach (var (val, label) in networkSpeedThresholds.OrderBy(x => x.Key))
			{
				if (networkStatus.SpeedBps >= val)
				{
					linkSpeedSuffix = label;
					linkSpeed /= 1000;
				}
			}
			var linkString = networkStatus.Status == OperationalStatus.Up ? $"Up! {$"{linkSpeed} {linkSpeedSuffix}",8}" : "Down! Check!";

			var dataString2 = "\x1B[2;1H" + $"Link is {linkString}".PadRight(displaySize.Width)[..displaySize.Width];

			var dataString3 = "\x1B[3;1H" + $"IP   {$"{string.Join('.', networkStatus.IpAddress.GetAddressBytes().Select(x => $"{x:000}"))}"}".PadRight(displaySize.Width)[..displaySize.Width];

			string dataString4;

			if (Program.Configuration.NetworkShowMacAndAdapter)
			{
				var macAddress = string.Join(':', networkStatus.MacAddress.GetAddressBytes().Select(x => $"{x:X2}"));
				var dataString = $"Gateway: {$"{string.Join('.', networkStatus.GatewayAddress.GetAddressBytes().Select(x => $"{x:000}"))}"} · MAC: {macAddress} · {networkStatus.InterfaceName}";

				dataString4 = DisplayUtilities.ScrollLine(4, 0.25, dataString, " · ", displaySize.Width);
			}
			else
				dataString4 = "\x1B[4;1H" + $"Gate {$"{string.Join('.', networkStatus.GatewayAddress.GetAddressBytes().Select(x => $"{x:000}"))}"}".PadRight(displaySize.Width)[..displaySize.Width];

			dataBytes = textEncoding.GetBytes(dataString1 + dataString2 + dataString3 + dataString4);
		}
	}
}
