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
			//Global.DetailPage = new DetailPage ();
			Global.DetailPage = new PageSplash ();
			Master = new MasterPage ();
			Detail = Global.DetailPage;

			this.MasterBehavior = MasterBehavior.Popover;

			this.Padding = new Thickness(0, 0, 0, 0);

			if (Device.OS != TargetPlatform.iOS)
			{
				if (Device.OS != TargetPlatform.WinPhone)
				{
					TapGestureRecognizer tap = new TapGestureRecognizer();
					tap.Tapped += (sender, args) =>
					{
						this.IsPresented = true;
					};

					//Global.DetailPage.AddGesture(tap);
				}
			}
		}
			
		protected override void OnAppearing ()
		{
			NavigationPage.SetHasNavigationBar (this, false);
			Global.RefreshDevice ();
			base.OnAppearing ();
		}

	}
}