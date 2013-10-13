using System;
using System.IO;

namespace Brake
{

	public class MainClass
	{
		public const int DEBUG = 1;
		public enum Platform
		{
			Windows,
			Linux,
			Mac
		}

		public static Platform RunningPlatform()
		{
			switch (Environment.OSVersion.Platform)
			{
				case PlatformID.Unix:
				// Well, there are chances MacOSX is reported as Unix instead of MacOSX.
				// Instead of platform check, we'll do a feature checks (Mac specific root folders)
				if (Directory.Exists("/Applications")
				    & Directory.Exists("/System")
				    & Directory.Exists("/Users")
				    & Directory.Exists("/Volumes"))
					return Platform.Mac;
				else
					return Platform.Linux;

				case PlatformID.MacOSX:
				return Platform.Mac;

				default:
				return Platform.Windows;
			}
		}

		public static void Main (string[] args)
		{
			String location;
			AppHelper appHelper = new AppHelper ();
			Console.WriteLine ("Hello World!");
			switch (RunningPlatform ()) {
			case Platform.Mac:
				{
					location = Environment.GetEnvironmentVariable ("HOME") + "/Music/iTunes/iTunes Media/Mobile Applications";
					break;
				}
			case Platform.Windows:
				{
					//windows sucks
					break;
				}
			default:
				{
					Console.WriteLine ("Unknown operating system!");
					return;
				}
			}
			appHelper.setupDirectory (location);

		}
	}
}