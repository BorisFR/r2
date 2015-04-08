using System;
using System.ComponentModel;

namespace R2B0app
{
	public class ForBinding : INotifyPropertyChanged
	{
		public double TextSizeForKeyboardTitle
		{
			get { 
				double x = Settings.GetSettingsFor("TextSizeForKeyboardTitle", Settings.textSize[0]); // Settings.TextSizeForKeyboardTitle;
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