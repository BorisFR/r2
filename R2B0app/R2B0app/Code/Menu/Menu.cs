using System;
using System.ComponentModel;
using Xamarin.Forms;
using System.Runtime.CompilerServices;

namespace R2B0app
{
	public class Menu : INotifyPropertyChanged
	{
		public MyPage Page { get; set; }
		public string Title { get; set; }

		private string detail;
		public string Detail {
			get { return detail; }
			set {
				if (value.Equals (detail))
					return;
				detail = value;
				OnPropertyChanged ();
			}
		}

		private string icon;
		public string Icon {
			get { return icon; }
			set {
				if (value.Equals (icon))
					return;
				icon = value;
				OnPropertyChanged ();
				OnPropertyChanged ("Image");
			}
		}

		public ImageSource Image {
			get {
				if (Icon.Length == 0) {
					return null;
				}
				return ImageSource.FromResource(string.Format("R2B0app.images.menu_{0}.png",Icon)); 
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;

		public void OnPropertyChanged ([CallerMemberName] string propertyName = null)
		{
			var handler = PropertyChanged;
			if (handler != null) {
				handler (this, new PropertyChangedEventArgs (propertyName));
			}
		}
	}
}