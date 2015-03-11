﻿using System;
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
			this.Appearing += HandleAppearing;
		}

		void HandleAppearing (object sender, EventArgs e)
		{
			Device.StartTimer (new TimeSpan (0, 0, 0, 0, 900), DoTimer);
		}


		private bool isDone = false;

		private bool DoTimer() {
			if (isDone)
				return true;
			isDone = true;
			System.Diagnostics.Debug.WriteLine ("*** TIMER PageSplash");
			GotoMain ();
			return false;
		}

		void HandleClicked (object sender, EventArgs e)
		{
			GotoMain ();
		}

		private void GotoMain() {
			Global.DetailPage = new DetailPage ();
			Global.MainPage.Detail = Global.DetailPage;
		}

		private double width = 0;

		protected override void OnSizeAllocated (double width, double height)
		{
			base.OnSizeAllocated (width, height);
			if (this.width != width) {
				this.width = width;
				System.Diagnostics.Debug.WriteLine ("*** OnSizeAllocated PageSplash");
				Global.RefreshDevice (width, height);
			}
		}
	}
}