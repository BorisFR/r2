using System;
using Xamarin.Forms;
using System.Collections.Generic;

namespace R2B0app
{
	public static class Global
	{

		private static Dictionary<string, string> devicesName = new Dictionary<string, string>();
		public static string CurrentDevice;

		public static DetailPage DetailPage;


		private static bool isInit = false;
		private static object toLock = new object();


		public static void DoInit ()
		{
			if (isInit) return;
			lock (toLock) {
				devicesName.Add ("ip4s", "iPhone 4S");
				devicesName.Add ("ip5", "iPhone 5");
				devicesName.Add ("ip5s", "iPhone 5s");
				devicesName.Add ("ip6", "iPhone 6");
				devicesName.Add ("ip6p", "iPhone 6+");
				devicesName.Add ("ipad2", "iPad 2");
				devicesName.Add ("ipadair", "iPad Air");
				devicesName.Add ("ipadhd", "iPad Retina");
				devicesName.Add ("android", "Android");
				devicesName.Add ("wp", "Windows Phone");
				CurrentDevice = "ip4s";
				isInit = true;
			}
		}


	}
}