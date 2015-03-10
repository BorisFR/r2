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
			mg.Add (new Menu (){ Page = MyPage.Home, Title = "Accueil", Detail = "Ecran d'accueil", Icon = "home" });
			mg.Add (new Menu (){ Page = MyPage.About, Title = "A propos de", Detail = "Informations sur l'application et le device", Icon = "info" });
			All.Add (mg);

			mg = new MenuGroup ("Showroom");
			mg.Add (new Menu (){ Page = MyPage.Settings, Title = "Settings", Detail = "Paramètres", Icon = "home" });
			mg.Add (new Menu (){ Page = MyPage.Main, Title = "Main", Detail = "Principal", Icon = "home" });
			mg.Add (new Menu (){ Page = MyPage.SplashScreen, Title = "SplashScreen", Detail = "Splash", Icon = "home" });
			All.Add (mg);
		}

	}
}