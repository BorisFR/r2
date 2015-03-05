using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace R2B0app
{
	public partial class PageSplash : ContentPage
	{
		public PageSplash ()
		{
			InitializeComponent ();

			btStart.Clicked += HandleClicked;
		}

		void HandleClicked (object sender, EventArgs e)
		{
			//Global.DetailPage.ShowPage (new PageStart ());
		}

	}
}