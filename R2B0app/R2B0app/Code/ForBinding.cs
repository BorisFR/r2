using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace R2B0app
{
	public class ForBinding : INotifyPropertyChanged
	{
		public string BuilderName
		{
			get { 
					return Settings.GetSettingsFor ("BuilderName", "R2 Builders");
				}
			set {
				if (Settings.GetSettingsFor ("BuilderName", "R2 Builders").Equals(value))
					return;
				Settings.SetSettingsFor ("BuilderName", value);
				OnPropertyChanged ("BuilderName");
			}
		}

		public string IpAddress
		{
			get { 
				return Settings.GetSettingsFor ("IpAddress", "192.168.4.1");
			}
			set {
				if (Settings.GetSettingsFor ("IpAddress", "192.168.4.1").Equals(value))
					return;
				Settings.SetSettingsFor ("IpAddress", value);
				OnPropertyChanged ("IpAddress");
			}
		}

		public double TextSizeForKeyboardTitle
		{
			get { 
				double x = Settings.GetSettingsFor("TextSizeForKeyboardTitle", Settings.textSize[0]);
				return x; }
			set {
				if (TextSizeForKeyboardTitle == value)
					return;
				Settings.SetSettingsFor ("TextSizeForKeyboardTitle", value);
				OnPropertyChanged ("TextSizeForKeyboardTitle");
			}
		}

		public double TextSizeForBigCommandTitle
		{
			get { 
				double x = Settings.GetSettingsFor("TextSizeForBigCommandTitle", Settings.textSize[1]); 
				return x; }
			set {
				if (TextSizeForKeyboardTitle == value)
					return;
				Settings.SetSettingsFor ("TextSizeForBigCommandTitle", value);
				OnPropertyChanged ("TextSizeForBigCommandTitle");
			}
		}


		public double TextSizeForKeyboardButton
		{
			get { 
				double x = Settings.GetSettingsFor("TextSizeForKeyboardButton", Settings.textSize[2]); 
				return x; }
			set {
				if (TextSizeForKeyboardTitle == value)
					return;
				Settings.SetSettingsFor ("TextSizeForKeyboardButton", value);
				OnPropertyChanged ("TextSizeForKeyboardButton");
			}
		}


		private int sendCommand = 0;
		private int sendCommandOk = 0;
		private int sendingCommand = 0;
		private string lastErrorMessage = string.Empty;

		public int SendCommand {
			get { return sendCommand; }
			set { if (sendCommand == value) return;
				sendCommand = value; OnPropertyChanged ("SendCommand"); } }

		public int SendCommandOk {
			get { return sendCommandOk; }
			set { if (sendCommandOk == value) return;
				sendCommandOk = value; OnPropertyChanged ("SendCommandOk"); } }

		public int SendingCommandStatus {
			get { return sendingCommand; }
			set { if (sendingCommand == value) return;
				sendingCommand = value; OnPropertyChanged ("SendingCommandStatus");OnPropertyChanged ("SendingCommandStatusSource"); } }

		public void AnimateIcons() {
			if (sendingCommand > 0) {
				if (sendingCommand == 4)
					SendingCommandStatus = 1;
				else
					SendingCommandStatus = sendingCommand + 1;
			} else if (sendingCommand < 0) {
				SendingCommandStatus = sendingCommand + 1;
			}
		}

		public ImageSource SendingCommandStatusSource {
			get { 				
				string s = sendingCommand.ToString ();
				if (sendingCommand < 0)
					s = "E";
				return ImageSource.FromResource ("R2B0app.Images.comm" + s + ".png"); }
		}

		public string LastErrorMessage {
			get { return lastErrorMessage; }
			set { if (lastErrorMessage == value) return;
				lastErrorMessage = value; OnPropertyChanged ("LastErrorMessage"); } }

		public void StartSending() {
			SendingCommandStatus = 1;
			SendCommand = sendCommand + 1;
		}

		public void StopSending() {
			SendingCommandStatus = 0;
			SendCommandOk = sendCommandOk + 1;
		}

		public void ErrorSending(string error) {
			LastErrorMessage = error;
			SendingCommandStatus = -5;
		}


		private DateTime now;

		public DateTime Now {
			get { return now; }
			set { if (now == value) return;
				now = value; OnPropertyChanged ("Now"); } }

		private int hour = 0;

		public int Hour {
			get { return hour; }
			set { if (hour == value) return;
				hour = value; OnPropertyChanged ("Hour"); } }

		private int minute = 0;

		public int Minute {
			get { return minute; }
			set { if (minute == value) return;
				minute = value; OnPropertyChanged ("Minute"); } }

		private int second = 0;

		public int Second {
			get { return second; }
			set { if (second == value) return;
				second = value; OnPropertyChanged ("Second"); } }

		private int radioSignal = 0;

		public int RadioSignal {
			get { return radioSignal; }
			set { if (radioSignal == value) return;
				radioSignal = value; OnPropertyChanged ("RadioSignal"); OnPropertyChanged ("RadioSignalSource"); } }

		public ImageSource RadioSignalSource {
			get { return ImageSource.FromResource ("R2B0app.Images.radio" + radioSignal + ".png"); }
		}

		private static int ConvertBattery12VtoPercent(int current) {
//			if (current >= 130)
//				return 100;
			if (current < 80)
				return 0;
			int t = current - 80;
			return t * 100 / 40;
		}

		private static int ConvertBattery12VtoIcon(int current) {
			if (current >= 130)
				return 7;
			if (current >= 124)
				return 6;
			if (current < 80)
				return 0;
			int t = current - 80;
			//System.Diagnostics.Debug.WriteLine (current.ToString () + " => " + (int)(t * 7 / 50));
			return t * 5 / 50 + 1;
		}

		public int batteryHead = 110;

		public int BatteryHead {
			get { return ConvertBattery12VtoPercent(batteryHead); }
			set { if (batteryHead == value) return;
				batteryHead = value; OnPropertyChanged ("BatteryHead"); OnPropertyChanged ("BatteryHeadSource"); } }

		public ImageSource BatteryHeadSource {
			get { return ImageSource.FromResource ("R2B0app.Images.battery" + ConvertBattery12VtoIcon(batteryHead) + ".png"); }
		}

		public int batteryBody = 80;

		public int BatteryBody {
			get { return ConvertBattery12VtoPercent(batteryBody); }
			set { if (batteryBody == value) return;
				batteryBody = value; OnPropertyChanged ("BatteryBody"); OnPropertyChanged ("BatteryBodySource"); } }

		public ImageSource BatteryBodySource {
			get { return ImageSource.FromResource ("R2B0app.Images.battery" + ConvertBattery12VtoIcon(batteryBody) + ".png"); }
		}


		public event PropertyChangedEventHandler PropertyChanged;

		public void OnPropertyChanged (string propertyName)
		{
			var handler = PropertyChanged;
			if (handler != null) {
				handler (this, new PropertyChangedEventArgs (propertyName));
			}
		}
	}
}