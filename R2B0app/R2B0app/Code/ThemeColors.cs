using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace R2B0app
{
    public static class ThemeColors
    {

        private static bool isInit = false;
        private static object toLock = new object();

        private static Dictionary<string, OneColor> theme;

        private static void DoInit()
        {
            if (isInit) return;
            lock (toLock)
            {
                theme = new Dictionary<string, OneColor>();
                theme.Add("BACKGROUND", new OneColor() { Red = 11, Green = 20, Blue = 72, Alpha = 200 });
                theme.Add("BORDER", new OneColor() { Red = 123, Green = 178, Blue = 237, Alpha = 230 });
                theme.Add("FILL", new OneColor() { Red = 21, Green = 56, Blue = 126, Alpha = 220 });
                theme.Add("FILLBORDER", new OneColor() { Red = 21, Green = 56, Blue = 126, Alpha = 180 });
                theme.Add("TEXT", new OneColor() { Red = 63, Green = 118, Blue = 214, Alpha = 255 });
                theme.Add("POINTER", new OneColor() { Red = 80, Green = 98, Blue = 164, Alpha = 255 });
                theme.Add("DRAWLOW", new OneColor() { Red = 97, Green = 204, Blue = 220, Alpha = 255 });
                theme.Add("DRAWHIGH", new OneColor() { Red = 89, Green = 170, Blue = 182, Alpha = 255 });
                isInit = true;
            }
        }


        public static Color GetColor(string name)
        {
                DoInit();
                if (theme.ContainsKey(name))
                    return theme[name].Color;
                return Color.Pink;
        }

        public static Color Background
        {
            get
            {
                DoInit();
                return theme["BACKGROUND"].Color;
            }
        }


    }
}