using System.Net.NetworkInformation;
using System.Net;

namespace BA66UsbFrontend.Content.System
{
	public class NetworkStatus
	{
		public string InterfaceName { get; } = "<unknown>";
		public IPAddress IpAddress { get; } = IPAddress.None;
		public IPAddress GatewayAddress { get; } = IPAddress.None;
		public PhysicalAddress MacAddress { get; } = PhysicalAddress.None;
		public OperationalStatus Status { get; } = OperationalStatus.Unknown;
		public long SpeedBps { get; } = 0;

		public NetworkStatus() { }

		public NetworkStatus(string name, IPAddress ip, IPAddress gateway, PhysicalAddress mac, OperationalStatus status, long speed)
		{
			InterfaceName = name;
			IpAddress = ip;
			GatewayAddress = gateway;
			MacAddress = mac;
			Status = status;
			SpeedBps = speed;
		}
	}
}
