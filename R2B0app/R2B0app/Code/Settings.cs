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

		public static void DoInit ()
		{
			if (isInit) return;
			lock (toLock) {
				switch (Global.CurrentDevice) {
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
				case "ipad2":
					textSize = new double[]{34,32};
					break;
				case "ipadair":
					textSize = new double[]{34,32};
					break;
				case "ipadhd":
					textSize = new double[]{34,32};
					break;
				case "android":
					textSize = new double[]{16,8};
					break;
				default:
					textSize = new double[]{18,10};
					break;
				}
				PanelsButtons = new Dictionary<Screen, string[]> ();
				PanelsButtons.Add (Screen.Main, 
					new string[] { "CLOSE ALL", "OPEN ALL", "SMIRK WAVE", 
						"LEIA", "CANTINA", "BEEP CANTINA",
						"HOLOS ON", "HOLOS OFF", "TOP RC",
						"SCREAM", "SCREAM No Pan", ">>"
					});
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