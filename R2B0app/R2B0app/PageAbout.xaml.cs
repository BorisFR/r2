using System;
using System.Collections.Generic;

using Xamarin.Forms;
using DeviceInfo.Plugin;

namespace R2B0app
{
	public partial class PageAbout : TabbedPage
	{
		public PageAbout ()
		{
			InitializeComponent ();

			theLayout1.Children.Add (CreateTitle("Software"));
			theLayout1.Children.Add (CreateText ("R2-B0"));
			theLayout1.Children.Add (CreateText ("(c) 04-2015 by Boris"));
			theLayout1.Children.Add (Separator());
			theLayout1.Children.Add (CreateLabel ("Version: {0}", "0.1 beta"));

			theLayout2.Children.Add (CreateTitle("Smartphone"));
			theLayout2.Children.Add (CreateLabel ("Platform: {0}", CrossDeviceInfo.Current.Platform));
			theLayout2.Children.Add (CreateLabel ("Version: {0}", CrossDeviceInfo.Current.Version));
			theLayout2.Children.Add (CreateLabel ("Model: {0}", CrossDeviceInfo.Current.Model));
			theLayout2.Children.Add (CreateLabel ("Screen: {0}", App.ScreenWidth.ToString () + "x" + App.ScreenHeight.ToString()));

			//theLayout.Children.Add (Separator());
		}

		private BoxView Separator() {
			BoxView b = new BoxView ();
			b.HeightRequest = 2;
			return b;
		}

		private Label CreateTitle(string text) {
			Label l = new Label ();
			l.Text = text;
			l.XAlign = TextAlignment.Center;
			return l;
		}

		private Label CreateText(string text) {
			Label l = new Label ();
			l.Text = text;
			l.XAlign = TextAlignment.Start;
			return l;
		}

		private Label CreateLabel(string text, object value) {
			Label l = new Label ();
			l.Text = string.Format (text, value);
			l.XAlign = TextAlignment.Start;
			return l;
		}
	}
}

