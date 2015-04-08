using System;
using System.Collections.ObjectModel;

namespace R2B0app
{
	public class MenuManager
	{

		public ObservableCollection<MenuGroup> All { get; set; }

		public MenuManager ()
		{
			All = new ObservableCollection<MenuGroup> ();
		}

		public void Refresh() {
			All.Clear ();

			MenuGroup mg = new MenuGroup ("");
			mg.Add (new Menu (){ Page = MyPage.Holos, Title = "Holos", Detail = "Holos & Magic panel", Icon = "home" });
			mg.Add (new Menu (){ Page = MyPage.Panels, Title = "Panels", Detail = "Panels, Pie Panels & Top", Icon = "home" });
			mg.Add (new Menu (){ Page = MyPage.Logics, Title = "Logics", Detail = "Logics display", Icon = "home" });
			mg.Add (new Menu (){ Page = MyPage.Sound, Title = "Sound", Detail = "Making sound", Icon = "sound" });
			mg.Add (new Menu (){ Page = MyPage.Music, Title = "Music", Detail = "Playing music", Icon = "music" });
			//All.Add (mg);

			//mg = new MenuGroup ("");
			mg.Add (new Menu (){ Page = MyPage.Status, Title = "Status", Detail = "Status", Icon = "status" });
			mg.Add (new Menu (){ Page = MyPage.About, Title = "About", Detail = "About program and devices", Icon = "about" });
			mg.Add (new Menu (){ Page = MyPage.Settings, Title = "Settings", Detail = "Settings parameters", Icon = "settings" });
			All.Add (mg);
		}

	}
}