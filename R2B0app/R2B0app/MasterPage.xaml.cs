using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace R2B0app
{
	public partial class MasterPage : ContentPage
	{
		public MasterPage ()
		{
			InitializeComponent ();
			//this.Icon = "menu_menu.png";
			theList.ItemsSource = Global.MenuManager.All;
			theList.ItemSelected += delegate(object sender, SelectedItemChangedEventArgs e) {
				if(e.SelectedItem == null) return;
				Menu m = e.SelectedItem as Menu;
				if(m.Page == MyPage.None) {
					theList.SelectedItem = null;
					return;
				}
				Global.GotoPage (m.Page);
				Global.MainPage.IsPresented = false;
			};
		}

	}
}