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
            InitializeComponent();

            this.screen = screen;
            switch (screen)
            {
                case Screen.Main:
                    lTitle.Text = "MAIN CONTROL 1";
                    break;
                case Screen.Holos:
                    lTitle.Text = "HOLOS CONTROL 1";
                    break;
                case Screen.Logics:
                    lTitle.Text = "LOGICS CONTROL 1";
                    break;
                case Screen.Panel:
                    lTitle.Text = "PANEL CONTROL 1";
                    break;
            }
			lTitle.FontSize = Settings.TextSizeForKeyboardTitle;

			this.screen = Screen.Main;
            for (int i = 0; i < 12; i++)
            {
				AddButton(2 + 4 * (i % 3), 3 + 4 * (i / 3),Settings.PanelsButtons[this.screen][i], Settings.PanelsCommands[this.screen][i]);
            }
        }

		private void SetButtonsText() {
			int i = 0;
			foreach (View v in theGrid.Children) {
				if (v.GetType ().Equals (typeof(MyButton))) {
					MyButton b = v as MyButton;
					try {
						b.Text = Settings.PanelsButtons [screen] [i + (pageNumber * 12)];
						b.CommandParameter = Settings.PanelsCommands [screen] [i + (pageNumber * 12)];
					} catch (Exception err) {
						System.Diagnostics.Debug.WriteLine (err.Message);
					}
					i++;
				}
			}
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
        }

		bool animInProgress = false;

        async void HandleClicked (object sender, EventArgs e)
        {
			if (animInProgress)
				return;
			animInProgress = true;
			MyButton b = sender as MyButton;
			if (b.CommandParameter.Equals ("<<")) {
				await theGrid.RotateYTo (-90, 200, Easing.SinIn);
				pageNumber--;
				SetButtonsText ();
				await theGrid.RotateYTo (-360, 600, Easing.BounceOut);
				await theGrid.RotateYTo (0, 0, null);
			} else if (b.CommandParameter.Equals (">>")) {
				await theGrid.RotateYTo (90, 200, Easing.SinIn);
				pageNumber++;
				SetButtonsText ();
				await theGrid.RotateYTo (360, 600, Easing.BounceOut);
				await theGrid.RotateYTo (0, 0, null);
			} else {
				await b.ScaleTo (0, 100, Easing.SinIn);
				await b.ScaleTo (1, 100, Easing.SpringOut);
			}
			animInProgress = false;
        } 

    }
}
