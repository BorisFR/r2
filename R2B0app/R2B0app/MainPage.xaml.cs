using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace R2B0app
{
	public partial class MainPage : MasterDetailPage
	{
		public MainPage ()
		{
			InitializeComponent ();

			Global.DetailPage = new DetailPage ();
			Master = new MasterPage ();
			Detail = Global.DetailPage;

			//this.Padding = new Thickness(0, 0, 0, 0);
		}
	}
}