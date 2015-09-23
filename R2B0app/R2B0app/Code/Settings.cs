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
                    new string[] { "STOP", "V+", "V-", 
						"Boris", "Marche", "Cantina",
						"Leia", "HOLOS\nOFF", "TOP RC",
						"SCREAM", "SCREAM\nNo Pan", ">>",
						"", "", "",
						"", "", "",
						"", "", "",
						"<<", "", ""
					});
				PanelsButtons.Add (Screen.Sound,
					new string[] {  
						"Alarm", "Hum", "Misc",
						"Ooh", "Proc", "Razz",
						"Scream", "Sentence", "Whistle",
						"Wolf\nWhistle", "Wowie", ">>",
						"Annoyed", "Chortie", "DoDoo",
						"Failure", "Groan", "Motivator",
						"Overhere", "Patrol", "Question",
						"<<", "Shortcut", "Start"
					});
//				"Status", "State\nAUTO", "State\nDOWN",
//				"command?action=R&p1=0&p2=0", "command?action=s&p1=1&p2=0", "command?action=s&p1=0&p2=0",
				PanelsCommands = new Dictionary<Screen, string[]> ();
				PanelsCommands.Add (Screen.Main,
					new string[] {"command?action=S&p1=0&p2=0", "command?action=S&p1=0&p2=1", "command?action=S&p1=0&p2=2",
						"command?action=A&p1=0&p2=74", "command?action=A&p1=0&p2=71", "command?action=A&p1=0&p2=72",
						"command?action=A&p1=0&p2=73", "", "",
						"", "", ">>",
						"", "", "",
						"", "", "",
						"", "", "",
						"<<", "", ""
					});
				PanelsCommands.Add (Screen.Sound,
					new string[] {
						"command?action=A&p1=0&p2=0", "command?action=A&p1=0&p2=1", "command?action=A&p1=0&p2=2",
						"command?action=A&p1=0&p2=3", "command?action=A&p1=0&p2=4", "command?action=A&p1=0&p2=5",
						"command?action=A&p1=0&p2=6", "command?action=A&p1=0&p2=7", "command?action=A&p1=0&p2=8", 
						"command?action=A&p1=0&p2=100", "command?action=A&p1=0&p2=150", ">>",
						"command?action=A&p1=0&p2=20", "command?action=A&p1=0&p2=30", "command?action=A&p1=0&p2=40",
						"command?action=A&p1=0&p2=50", "command?action=A&p1=0&p2=60", "command?action=A&p1=0&p2=140",
						"command?action=A&p1=0&p2=160", "command?action=A&p1=0&p2=170", "command?action=A&p1=0&p2=200",
						"<<", "command?action=A&p1=0&p2=70", "command?action=A&p1=0&p2=180"
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