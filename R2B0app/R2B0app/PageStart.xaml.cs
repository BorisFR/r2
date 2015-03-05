using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace R2B0app
{
	public partial class PageStart : ContentPage
	{
		public PageStart ()
		{
			InitializeComponent ();

			btSplash.Clicked += HandleClicked;
		}

		void HandleClicked (object sender, EventArgs e)
		{
			//Global.DetailPage.ShowPage (new PageSplash ());
		}
	}
}