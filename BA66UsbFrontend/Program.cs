using System.Configuration;
using System.Globalization;
using System.Reflection;
using System.Text;

namespace BA66UsbFrontend
{
	internal static class Program
	{
		public static string ProgramName { get; } = Assembly.GetEntryAssembly()?.GetCustomAttribute<AssemblyProductAttribute>()?.Product ?? string.Empty;
		public static Version ProgramVersion { get; } = new(Assembly.GetEntryAssembly()?.GetCustomAttribute<AssemblyFileVersionAttribute>()?.Version ?? "0.0");
		public static string ProgramVersionString { get; } = $"{ProgramVersion.Major}.{ProgramVersion.Minor}.{ProgramVersion.Build}";
		public static string ProgramDescription { get; } = Assembly.GetEntryAssembly()?.GetCustomAttribute<AssemblyDescriptionAttribute>()?.Description ?? string.Empty;
		public static string ProgramCopyright { get; } = Assembly.GetEntryAssembly()?.GetCustomAttribute<AssemblyCopyrightAttribute>()?.Copyright ?? string.Empty;
		public static string ProgramUrl { get; } = $"https://github.com/xdanieldzd/{ProgramName}/";

		public static string ConfigFilename { get; } = "config.json";
		public static string ConfigPath { get; } = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), ProgramName, ConfigFilename);

		public static Configuration Configuration { get; private set; } = default;

		[STAThread]
		static void Main()
		{
			ApplicationConfiguration.Initialize();

			Thread.CurrentThread.CurrentCulture = Thread.CurrentThread.CurrentUICulture = CultureInfo.InvariantCulture;
			Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

			Configuration = Configuration.Load(ConfigPath);

			Application.Run(new MainForm() { WindowState = Configuration.StartMinimized ? FormWindowState.Minimized : FormWindowState.Normal });
		}
	}
}
