﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace R2B0app
{
    public partial class ViewMain : ContentView
    {
        private Screen screen;

        public ViewMain(Screen screen)
        {
			System.Diagnostics.Debug.WriteLine ("*** ViewMain");
            InitializeComponent();

            this.screen = screen;
			ShowKeyboard ();
        }

		private void ShowKeyboard() {
			switch (screen)
			{
			case Screen.Main:
				lBigCommand.Text = "MAIN:";
				break;
			case Screen.Holos:
				lBigCommand.Text = "SELECT HOLOPROJECTORS:";
				break;
			case Screen.Logics:
				lBigCommand.Text = "TEXT MODE:";
				break;
			case Screen.Panel:
				lBigCommand.Text = "SELECT PANELS:";
				break;
			}
			viewKeyboard.Content = new ViewKeyboard(screen);
		}

    }
}
