using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace R2B0app
{
	// format numeric
	// https://msdn.microsoft.com/en-us/library/dwhawy9k(v=vs.110).aspx
	public partial class PageSettings : TabbedPage
	{
		public PageSettings ()
		{
			InitializeComponent ();
			this.BindingContext = Global.ForBinding;

			pickCommunication.Items.Add ("Bluetooth LE");
			pickCommunication.Items.Add ("Serial");
			pickCommunication.Items.Add ("Wifi");
			pickCommunication.Items.Add ("Wifi Direct");

		}

		protected override void OnAppearing ()
		{
			base.OnAppearing ();
			//this.Animate("", (s) => Layout(new Rectangle(((1 - s) * Width), Y, Width, Height)), 16, 600, Easing.Linear, null, null);
		}

		protected override void OnDisappearing ()
		{
			base.OnDisappearing ();
			this.Animate("", (s) => Layout(new Rectangle((s * Width) * -1, Y, Width, Height)), 16, 600, Easing.Linear, null, null);
		}
	}
}