using System.Reflection;

namespace BA66UsbFrontend
{
	public static class Resources
	{
		public static Stream GetEmbeddedResourceStream(string name)
		{
			var assembly = Assembly.GetEntryAssembly();
			return assembly.GetManifestResourceStream($"{assembly?.GetName().Name}.{name}");
		}

		public static Bitmap GetEmbeddedBitmap(string name)
		{
			using var stream = GetEmbeddedResourceStream(name);
			return stream != null ? new Bitmap(stream) : null;
		}

		public static Icon GetEmbeddedIcon(string name, Size size)
		{
			using var stream = GetEmbeddedResourceStream(name);
			return stream != null ? new Icon(stream, size) : null;
		}
	}
}
