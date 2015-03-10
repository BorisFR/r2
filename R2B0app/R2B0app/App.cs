using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace R2B0app
{
    public class App : Application
    {
        public App()
        {
			Global.DoInit ();
			Global.MainPage = new MainPage ();

			MainPage = Global.MainPage;
        }

        protected override void OnStart()
        {
            // Handle when your app starts
			Global.DoInit ();
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
