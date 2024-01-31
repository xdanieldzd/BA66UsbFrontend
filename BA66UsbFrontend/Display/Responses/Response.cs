namespace BA66UsbFrontend.Display.Responses
{
    public class Response(byte[] data)
    {
        public static readonly int DataStartIndex = 5;

        public byte Length { get; } = data[1];
        public byte[] Status { get; } = [data[2], data[3], data[4]];

        public bool HardwareError => (Status[0] & 0b00100000) != 0;
        public bool DeviceNotReady => (Status[0] & 0b10000000) != 0;
        public bool UndefinedCommand => (Status[1] & 0b10000000) != 0;
    }
}
