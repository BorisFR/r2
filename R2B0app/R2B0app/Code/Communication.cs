using System;
using System.Net.Http;

namespace R2B0app
{

	public delegate void Received(string value);

	public static class Communication
	{
		public static event Received Received;

		private static HttpClient httpClient;

//		public async static void Test () {
//			var res = await httpClient.GetStringAsync ("fonction?var=val&var2=val2");
//			System.Diagnostics.Debug.WriteLine (res);
//		}

		public static void Init ()
		{
			httpClient = new HttpClient();
			httpClient.Timeout = new TimeSpan (0, 0, 0, 3, 500);
			httpClient.BaseAddress = new Uri (string.Format("http://{0}/", Global.ForBinding.IpAddress));
		}

		public async static void SendCommand(string command) {
			Global.ForBinding.StartSending ();
			try {
				System.Diagnostics.Debug.WriteLine("sending " + command);
				string res = await httpClient.GetStringAsync (command);
				Global.ForBinding.StopSending ();
				System.Diagnostics.Debug.WriteLine("sending OK: " + res);
				if(Received != null)
					Received(res);
			} catch (Exception err) {
				Global.ForBinding.ErrorSending (err.Message);
				System.Diagnostics.Debug.WriteLine("sending error: " + err.Message);
			}
		}

		public static void SendCommand(string command, string var) {
			string toSend = string.Format ("{0}?{1}", command, var);
			SendCommand (toSend);
		}

	}
}