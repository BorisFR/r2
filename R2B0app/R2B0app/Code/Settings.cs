using DeviceInfo.Plugin;
using System;
using System.Collections.Generic;

namespace R2B0app
{
	public static class Settings
	{

		private static bool isInit = false;
		private static object toLock = new object();
		public static double[] textSize;
		public static Dictionary<Screen, string> PanelsTitle;
		public static Dictionary<Screen, string[]> PanelsButtons;
		public static Dictionary<Screen, string[]> PanelsCommands;

		// textSize[]
		// 0: keyboard title
		// 1: keyboard button
		// 2: big command title

		public static void DoInit ()
		{
			if (isInit) return;
			lock (toLock) {
				System.Diagnostics.Debug.WriteLine ("*** Settings.DoInit");
				// adapt text size for each platform and display resolution
				switch (Global.CurrentDevice) {
// iOS iPhone
				case "ip4s":
					textSize = new double[]{16,12,12};
					break;
				case "ip5":
					textSize = new double[]{18,16,16};
					break;
				case "ip5s":
					textSize = new double[]{18,16,16};
					break;
				case "ip6":
					textSize = new double[]{22,20,20};
					break;
				case "ip6p":
					textSize = new double[]{24,22,22};
					break;
// iOS iPad
				case "ipad2":
					textSize = new double[]{34,32,32};
					break;
				case "ipadair":
					textSize = new double[]{34,32,32};
					break;
				case "ipadhd":
					textSize = new double[]{34,32,32};
					break;
// android
				case "android":
					textSize = new double[]{16,8,8};
					break;
				case "androidwsvga":
					textSize = new double[]{34,32,32};
					break;
				case "androidhdr":
					textSize = new double[]{18,16,16};
					break;
// windows phone
                case "wp":
                    textSize = new double[] { 22, 14, 14 };
                    break;
                case "wpwvga":
                    textSize = new double[] { 24, 16, 16 };
                    break;
                case "wphdr":
                    textSize = new double[] { 26, 18, 18 };
                    break;
                default:
					textSize = new double[]{18,10,10};
					System.Diagnostics.Debug.WriteLine (string.Format ("Default for {0}", Global.CurrentDevice));
					break;
				}
				PanelsTitle = new Dictionary<Screen, string> ();
				PanelsTitle.Add (Screen.Holos, "HOLOS");
				PanelsTitle.Add (Screen.Logics, "LOGICS");
				PanelsTitle.Add (Screen.Main, "MAIN");
				PanelsTitle.Add (Screen.Panel, "PANEL");
				PanelsTitle.Add (Screen.Sound, "SOUND");
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

                //CrossVibrate.Current;

				isInit = true;
			}
		}

		public static string GetSettingsFor(string key, string defaultValue) {
			if (App.Current.Properties.ContainsKey (key))
				return (string) App.Current.Properties [key];
			return defaultValue;
		}

		public static double GetSettingsFor(string key, double defaultValue) {
			if (App.Current.Properties.ContainsKey (key))
				return (double) App.Current.Properties [key];
			return defaultValue;
		}

		public static void SetSettingsFor(string key, string value) {
			if (App.Current.Properties.ContainsKey (key))
				App.Current.Properties [key] = value;
			else
				App.Current.Properties.Add (key, value);
			System.Diagnostics.Debug.WriteLine ("saving " + key + "=" + value);
		}

		public static void SetSettingsFor(string key, double value) {
			if (App.Current.Properties.ContainsKey (key))
				App.Current.Properties [key] = value;
			else
				App.Current.Properties.Add (key, value);
		}


	}
}