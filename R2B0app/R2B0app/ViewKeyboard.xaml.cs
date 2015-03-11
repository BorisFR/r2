using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace R2B0app
{
    public partial class ViewKeyboard : ContentView
    {
        private Screen screen;
		private int pageNumber = 0;

        public ViewKeyboard(Screen screen)
        {
			System.Diagnostics.Debug.WriteLine ("*** ViewKeyboard");
            InitializeComponent();

            this.screen = screen;
			lTitle.Text = string.Format("{0} CONTROL 1", Settings.PanelsTitle[screen]);
			lTitle.FontSize = Settings.TextSizeForKeyboardTitle;

			this.screen = Screen.Main;
            for (int i = 0; i < 12; i++)
            {
				AddButton(2 + 4 * (i % 3), 3 + 4 * (i / 3),Settings.PanelsButtons[this.screen][i], Settings.PanelsCommands[this.screen][i]);
            }
        }

		private List<Button> buttons = new List<Button>();
		private int index = 0;

		private void SetButtonsText() {
			//Device.BeginInvokeOnMainThread (() => {
			lTitle.Text = string.Format("{0} CONTROL {1}", Settings.PanelsTitle[screen], pageNumber + 1);
				index = pageNumber * 12;
				foreach (Button bt in buttons) {
					bt.Text = Settings.PanelsButtons [screen] [index];
					bt.CommandParameter = Settings.PanelsCommands [screen] [index];
					index++;
				}
			//});
		}

        private void AddButton(int x, int y, string text, string command)
        {
            //theGrid.Children.Add(new Label { Text = text, TextColor = ThemeColors.GetColor("TEXT"), FontSize = 10, HorizontalOptions = LayoutOptions.Center, VerticalOptions=LayoutOptions.Center }, x, y);
			MyButton b = new MyButton {
				Text = text,
				TextColor = ThemeColors.GetColor ("TEXT"),
				BackgroundColor = Color.Transparent,
				BorderColor = ThemeColors.GetColor ("TEXT"),
				BorderWidth = 1,
				FontSize = Settings.TextSizeForKeyboardButton,
				HorizontalOptions = LayoutOptions.Fill,
				VerticalOptions = LayoutOptions.FillAndExpand
			};
			b.CommandParameter = command;
			b.Clicked += HandleClicked;
			theGrid.Children.Add(b, x, y);
			buttons.Add (b);
        }

		bool animInProgress = false;

        async void HandleClicked (object sender, EventArgs e)
        {
			if (animInProgress)
				return;
			animInProgress = true;
			MyButton b = sender as MyButton;
			if (b.CommandParameter.Equals ("<<")) {
				foreach(Button bt in buttons)
					bt.FadeTo(0,200,null);
				await theGrid.RotateYTo (-90, 200, Easing.SinIn);
				pageNumber--;
				SetButtonsText ();
				foreach(Button bt in buttons)
					bt.FadeTo(1,200,null);
				await theGrid.RotateYTo (-360, 600, Easing.BounceOut);
				await theGrid.RotateYTo (0, 0, null);
				//SetButtonsText ();
			} else if (b.CommandParameter.Equals (">>")) {
				foreach(Button bt in buttons)
					bt.FadeTo(0,200,null);
				await theGrid.RotateYTo (90, 200, Easing.SinIn);
				pageNumber++;
				SetButtonsText ();
				foreach(Button bt in buttons)
					bt.FadeTo(1,200,null);
				await theGrid.RotateYTo (360, 600, Easing.BounceOut);
				await theGrid.RotateYTo (0, 0, null);
				//SetButtonsText ();
			} else {
				await b.ScaleTo (0, 100, Easing.SinIn);
				await b.ScaleTo (1, 100, Easing.SpringOut);
			}
			animInProgress = false;
        } 


    }
}
