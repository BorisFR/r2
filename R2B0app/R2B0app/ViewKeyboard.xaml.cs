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
        private Screen screen = Screen.Main;

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

            for (int i = 0; i < 9; i++)
            {
				AddButton(2 + 4 * (i % 3), 3 + 4 * (i / 3), "KILL\nSERVOS", "");
            }
        }

        private void AddButton(int x, int y, string text, string command)
        {
            //theGrid.Children.Add(new Label { Text = text, TextColor = ThemeColors.GetColor("TEXT"), FontSize = 10, HorizontalOptions = LayoutOptions.Center, VerticalOptions=LayoutOptions.Center }, x, y);
			theGrid.Children.Add(new MyButton { Text = text, TextColor = ThemeColors.GetColor("TEXT"), BackgroundColor = Color.Transparent, BorderColor = ThemeColors.GetColor("TEXT"), BorderWidth = 1, FontSize = 10, HorizontalOptions = LayoutOptions.Fill, VerticalOptions = LayoutOptions.FillAndExpand }, x, y);
        } 

    }
}
