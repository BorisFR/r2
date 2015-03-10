using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace R2B0app
{
	public partial class DetailPage : ContentPage
	{
		private bool isFirst = true;
		private bool on2columns = true;

		public DetailPage ()
		{
			InitializeComponent ();

			this.Appearing += delegate(object sender, EventArgs e) {
				if(isFirst) {
					//Global.GotoPage (MyPage.Home);
					viewHead.Content = new ViewHead ();
					viewLeft.Content = new ViewMain(Screen.Holos);
					viewRight.Content = new ViewMain(Screen.Logics);
					isFirst = false;
				}
			};
        }

		private double width = 0;

		protected override void OnSizeAllocated (double width, double height)
		{
			base.OnSizeAllocated (width, height);
			if (this.width != width) {
				this.width = width;
				Global.RefreshDevice (width, height);
				if (width > height) {
					on2columns = true;
					theGrid.ColumnDefinitions [1].Width = new GridLength (50, GridUnitType.Star);
				} else {
					on2columns = false;
					theGrid.ColumnDefinitions [1].Width = new GridLength (0);
				}
			}
		}

		public void SetContent(View page) {
			viewLeft.Content = page;
		}

//		public void PopupPage(Page page) {
//			this.Navigation.PushModalAsync (page);
//		}

		public void AddGesture(TapGestureRecognizer tap){
			viewHead.GestureRecognizers.Add(tap);
		}

	}
}