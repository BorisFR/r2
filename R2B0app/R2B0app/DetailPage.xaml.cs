using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace R2B0app
{
	public partial class DetailPage : ContentPage
	{
		public DetailPage ()
		{
			InitializeComponent ();


//			Grid grid = new Grid {
//				VerticalOptions = LayoutOptions.FillAndExpand,
//				RowDefinitions = { new RowDefinition { Height = new GridLength (100, GridUnitType.Star) } },
//				ColumnDefinitions = { new ColumnDefinition { Width = new GridLength (50, GridUnitType.Star) },
//					new ColumnDefinition { Width = new GridLength (50, GridUnitType.Star) }
//				}
//			};
//
//			grid.Children.Add (new Label {
//				Text = "Grid",
//				Font = Font.BoldSystemFontOfSize (50),
//				HorizontalOptions = LayoutOptions.Center
//			});
//
//			grid.Children.Add (new Label {
//				Text = "Autosized cell",
//				TextColor = Color.White,
//				BackgroundColor = Color.Blue
//			}, 1, 0);
//
//
//			// Accomodate iPhone status bar.
//			//this.Padding = new Thickness(10, Device.OnPlatform(20, 0, 0), 10, 5);
//
//			// Build the page.
//			this.Content = grid;

			viewHead.Content = new ViewHead ();
            viewLeft.Content = new ViewMain();
		}

	}
}