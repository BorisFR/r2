using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace R2B0app
{
    public class OneColor
    {
        public int Red = 255;
        public int Green = 255;
        public int Blue = 255;
        public int Alpha = 255; 
         
        public Color Color { get { return Color.FromRgba(Red, Green, Blue, Alpha); } }
    }
}