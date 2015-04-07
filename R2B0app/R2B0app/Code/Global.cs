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
		public static DetailPage DetailPage;

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
				devicesName.Add("androidhdr", "Android");
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

		public static void RefreshDevice() {
			System.Diagnostics.Debug.WriteLine (App.ScreenWidth.ToString () + "x" + App.ScreenHeight.ToString());
			switch (CrossDeviceInfo.Current.Platform) {
			case DeviceInfo.Plugin.Abstractions.Platform.Android:
				if ((App.ScreenWidth == 1024 && App.ScreenHeight == 552) || (App.ScreenWidth == 471 && App.ScreenHeight == 552))
					CurrentDevice = "androidwsvga";
				else if ((App.ScreenWidth == 1196 && App.ScreenHeight == 768) || (App.ScreenWidth == 768 && App.ScreenHeight == 1196))
					CurrentDevice = "androidhdr";
				else if ((App.ScreenWidth == 1184 && App.ScreenHeight == 768) || (App.ScreenWidth == 768 && App.ScreenHeight == 1184))
					CurrentDevice = "androidhdr";
				else {
					System.Diagnostics.Debug.WriteLine (string.Format ("Android {0}x{1}", App.ScreenWidth, App.ScreenHeight));
				}
				break;
			case DeviceInfo.Plugin.Abstractions.Platform.iOS:
				if ((App.ScreenWidth == 320 && App.ScreenHeight == 480) || (App.ScreenWidth == 480 && App.ScreenHeight == 320))
					CurrentDevice = "ip4s";
				else if ((App.ScreenWidth == 320 && App.ScreenHeight == 568) || (App.ScreenWidth == 568 && App.ScreenHeight == 320))
					CurrentDevice = "ip5"; // or 5s...
				else if ((App.ScreenWidth == 375 && App.ScreenHeight == 667) || (App.ScreenWidth == 667 && App.ScreenHeight == 375))
					CurrentDevice = "ip6";
				else if ((App.ScreenWidth == 414 && App.ScreenHeight == 736) || (App.ScreenWidth == 736 && App.ScreenHeight == 414))
					CurrentDevice = "ip6p";
				else if ((App.ScreenWidth == 768 && App.ScreenHeight == 1024) || (App.ScreenWidth == 1024 && App.ScreenHeight == 768))
					CurrentDevice = "ipad2"; // or Retina or Air
				else {
					System.Diagnostics.Debug.WriteLine (string.Format ("iOS {0}x{1}", App.ScreenWidth, App.ScreenHeight));
				}
				break;
			case DeviceInfo.Plugin.Abstractions.Platform.WindowsPhone:
				CurrentDevice = "wp";
				if ((App.ScreenWidth == 480 && App.ScreenHeight == 728) || (App.ScreenWidth == 728 && App.ScreenHeight == 480))
					CurrentDevice = "wpwvga"; // Wide VGA and also WXGA
				else if ((App.ScreenWidth == 480 && App.ScreenHeight == 781) || (App.ScreenWidth == 781 && App.ScreenHeight == 480))
					CurrentDevice = "wphdr"; // HD Ready - 720p and also Full HD 1080p
				else {
					System.Diagnostics.Debug.WriteLine (string.Format ("WP {0}x{1}", App.ScreenWidth, App.ScreenHeight));
				}
				break;
			case DeviceInfo.Plugin.Abstractions.Platform.Windows:
				CurrentDevice = "win";
				 {
					System.Diagnostics.Debug.WriteLine (string.Format ("Win {0}x{1}", App.ScreenWidth, App.ScreenHeight));
				}
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
			case MyPage.Settings:
				MainPage.Detail = new PageSettings ();
				break;
			case MyPage.Holos:
			case MyPage.Logics:
			case MyPage.Panels:
				if (!Global.MainPage.Detail.GetType ().Equals (typeof(DetailPage)))
					Global.MainPage.Detail = Global.DetailPage;
				DetailPage.ChangeContent (newPage);
				break;
			}
		}


	}
}