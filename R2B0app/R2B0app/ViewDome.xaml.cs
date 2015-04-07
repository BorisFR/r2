using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace R2B0app
{
	public partial class ViewDome : ContentView
	{
		private Screen screen;

		public ViewDome (Screen screen)
		{
            //System.Diagnostics.Debug.WriteLine("Loading ViewDome");
			InitializeComponent ();
            //System.Diagnostics.Debug.WriteLine("Loading ViewDome OK");
			this.screen = screen;
			ShowDome ();
        }

		private void ShowDome() {
			switch (screen) {
			case Screen.Holos:
				HidePanels ();
				HidePiePanels ();
				HideTopPanel ();
				break;
			case Screen.Panel:
				HideHPs ();
				HideMagicPanel ();
				break;
			}
		}


		private void HidePanels() {
			p1.IsVisible = false;
			p2.IsVisible = false;
			p3.IsVisible = false;
			p4.IsVisible = false;
			p7.IsVisible = false;
			p10.IsVisible = false;
			p11.IsVisible = false;
		}

		private void HidePiePanels() {
			pp1.IsVisible = false;
			pp2.IsVisible = false;
			pp5.IsVisible = false;
			pp6.IsVisible = false;
		}

		private void HideTopPanel() {
			top.IsVisible = false;
		}

		private void HideHPs() {
			hp1.IsVisible = false;
			hp2.IsVisible = false;
			hp3.IsVisible = false;
		}


		private void HideMagicPanel() {
			mp.IsVisible = false;
		}


	}
}