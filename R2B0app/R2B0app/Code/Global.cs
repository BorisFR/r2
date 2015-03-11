using System;
using Xamarin.Forms;
using System.Collections.Generic;
using DeviceInfo.Plugin;

namespace R2B0app
{
	public static class Global
	{

		private static Dictionary<string, string> devicesName = new Dictionary<string, string>();
		public static string CurrentDevice;

		public static MainPage MainPage { get; set; }
		public static Page DetailPage;

		private static MenuManager menus = new MenuManager();
		public static MenuManager MenuManager { get { return menus; } }


		private static bool isInit = false;
		private static object toLock = new object();


		public static void DoInit ()
		{
			if (isInit) return;
            lock (toLock)
            {
                menus.Refresh();
                devicesName.Add("ip4s", "iPhone 4S");
                devicesName.Add("ip5", "iPhone 5");
                devicesName.Add("ip5s", "iPhone 5s");
                devicesName.Add("ip6", "iPhone 6");
                devicesName.Add("ip6p", "iPhone 6+");
                devicesName.Add("ipad2", "iPad 2");
                devicesName.Add("ipadair", "iPad Air");
                devicesName.Add("ipadhd", "iPad Retina");
                devicesName.Add("android", "Android");
				devicesName.Add("androidwsvga", "Android");
                devicesName.Add("wp", "Windows Phone");
                devicesName.Add("wpwvga", "Windows Phone");
                devicesName.Add("wpwxga", "Windows Phone");
                devicesName.Add("wphdr", "Windows Phone");
                devicesName.Add("wpfhd", "Windows Phone");
                devicesName.Add("win", "Windows");
                switch (CrossDeviceInfo.Current.Platform)
                {
                    case DeviceInfo.Plugin.Abstractions.Platform.Android:
                        CurrentDevice = "android";
                        break;
                    case DeviceInfo.Plugin.Abstractions.Platform.WindowsPhone:
                        CurrentDevice = "wp";
                        break;
                    case DeviceInfo.Plugin.Abstractions.Platform.Windows:
                        CurrentDevice = "win";
                        break;
                    case DeviceInfo.Plugin.Abstractions.Platform.iOS:
                        CurrentDevice = "ip4s";
                        break;
                    default:
                        break;
                }
                isInit = true;
            }
		}

		public static void RefreshDevice(double width, double height) {
			System.Diagnostics.Debug.WriteLine (width.ToString () + "x" + height.ToString());
			switch (CrossDeviceInfo.Current.Platform) {
			case DeviceInfo.Plugin.Abstractions.Platform.Android:
				if ((width == 1024 && height == 471) || (width == 471 && height == 1024))
					CurrentDevice = "androidwsvga";
				System.Diagnostics.Debug.WriteLine ("*** DEVICE OK");
				break;
			case DeviceInfo.Plugin.Abstractions.Platform.iOS:
				if ((width == 320 && height == 480) || (width == 480 && height == 320))
					CurrentDevice = "ip4s";
				else if ((width == 320 && height == 568) || (width == 568 && height == 320))
					CurrentDevice = "ip5"; // or 5s...
				else if ((width == 375 && height == 667) || (width == 667 && height == 375))
					CurrentDevice = "ip6";
				else if ((width == 414 && height == 736) || (width == 736 && height == 414))
					CurrentDevice = "ip6p";
				else if ((width == 768 && height == 1024) || (width == 1024 && height == 768))
					CurrentDevice = "ipad2"; // or Retina or Air
				break;
			case DeviceInfo.Plugin.Abstractions.Platform.WindowsPhone:
				CurrentDevice = "wp";
                if ((width == 480 && height == 728) || (width == 728 && height == 480))
					CurrentDevice = "wpwvga"; // Wide VGA and also WXGA
                else if ((width == 480 && height == 781) || (width == 781 && height == 480))
					CurrentDevice = "wphdr"; // HD Ready - 720p and also Full HD 1080p
				break;
			case DeviceInfo.Plugin.Abstractions.Platform.Windows:
				CurrentDevice = "win";
				break;
			default:
				break;
			}
		}

		public static void GotoPage(MyPage newPage) {
			switch (newPage) {
			case MyPage.About:
				//DetailPage.SetContent (new AboutView ());
				break;
			}
		}


	}
}