using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace R2B0app
{
	public partial class ViewHead : ContentView
	{
		public ViewHead ()
		{
			InitializeComponent ();
			theGrid.BindingContext = Global.ForBinding;
		}
	}
}

