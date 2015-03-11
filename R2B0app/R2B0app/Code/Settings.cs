using DeviceInfo.Plugin;
using System;
using System.Collections.Generic;

namespace R2B0app
{
	public static class Settings
	{

		private static bool isInit = false;
		private static object toLock = new object();
		private static double[] textSize;
		public static Dictionary<Screen, string[]> PanelsButtons;
		public static Dictionary<Screen, string[]> PanelsCommands;

		// textSize[]
		// 0: keyboard title
		// 1: keyboard button

		public static void DoInit ()
		{
			if (isInit) return;
			lock (toLock) {
				System.Diagnostics.Debug.WriteLine ("*** DoInit");
				// adapt text size for each platform and display resolution
				switch (Global.CurrentDevice) {
// iOS iPhone
				case "ip4s":
					textSize = new double[]{16,12};
					break;
				case "ip5":
					textSize = new double[]{18,16};
					break;
				case "ip5s":
					textSize = new double[]{18,16};
					break;
				case "ip6":
					textSize = new double[]{22,20};
					break;
				case "ip6p":
					textSize = new double[]{24,22};
					break;
// iOS iPad
				case "ipad2":
					textSize = new double[]{34,32};
					break;
				case "ipadair":
					textSize = new double[]{34,32};
					break;
				case "ipadhd":
					textSize = new double[]{34,32};
					break;
// android
				case "android":
					textSize = new double[]{16,8};
					break;
				case "androidwsvga":
					textSize = new double[]{34,32};
					System.Diagnostics.Debug.WriteLine ("*** FONT OK");
					break;
// windows phone
                case "wp":
                    textSize = new double[] { 22, 14 };
                    break;
                case "wpwvga":
                    textSize = new double[] { 24, 16 };
                    break;
                case "wphdr":
                    textSize = new double[] { 26, 18 };
                    break;
                default:
					textSize = new double[]{18,10};
					break;
				}
				PanelsButtons = new Dictionary<Screen, string[]> ();
				PanelsButtons.Add (Screen.Main,
                    new string[] { "CLOSE\nALL", "OPEN\nALL", "SMIRK\nWAVE", 
						"LEIA", "CANTINA", "BEEP\nCANTINA",
						"HOLOS\nON", "HOLOS\nOFF", "TOP RC",
						"SCREAM", "SCREAM\nNo Pan", ">>",
						"PAGE 2", "", "",
						"", "", "",
						"", "", "",
						"<<", "", ""
					});
				PanelsCommands = new Dictionary<Screen, string[]> ();
				PanelsCommands.Add (Screen.Main,
					new string[] {"", "", "",
						"", "", "",
						"", "", "",
						"", "", ">>",
						"", "", "",
						"", "", "",
						"", "", "",
						"<<", "", ""
					});

//                PanelsButtons[Screen.Main][0] = CrossDeviceInfo.Current.Platform.ToString();
//                PanelsButtons[Screen.Main][1] = CrossDeviceInfo.Current.Model;
//                PanelsButtons[Screen.Main][2] = CrossDeviceInfo.Current.Version;
                System.Diagnostics.Debug.WriteLine(CrossDeviceInfo.Current.Platform.ToString());
                System.Diagnostics.Debug.WriteLine(CrossDeviceInfo.Current.Model);
                System.Diagnostics.Debug.WriteLine(CrossDeviceInfo.Current.Version);

                //CrossVibrate.Current;

				isInit = true;
			}
		}

		private static string GetSettingsFor(string key, string defaultValue) {
			return defaultValue;
		}

		private static double GetSettingsFor(string key, double defaultValue) {
			return defaultValue;
		}

		public static Xamarin.Forms.GridLength KeyboardTitleHeight {
			get {
				DoInit ();
				return new Xamarin.Forms.GridLength (GetSettingsFor ("TextSizeForKeyboardTitle", textSize [0]));
			}
		}

		public static double TextSizeForKeyboardTitle
		{
			get {
				DoInit ();
				return GetSettingsFor ("TextSizeForKeyboardTitle", textSize[0]);
			}
		}

		public static double TextSizeForKeyboardButton
		{
			get {
				DoInit ();
				return GetSettingsFor ("TextSizeForKeyboardButton", textSize[1]);
			}
		}

	}
}