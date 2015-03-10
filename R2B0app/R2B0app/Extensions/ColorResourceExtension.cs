using System;
using Xamarin.Forms.Xaml;
using Xamarin.Forms;

namespace R2B0app
{
    [ContentProperty("Color")]
    public class ColorResourceExtension : IMarkupExtension
	{

        public string Color { get; set; }

		public object ProvideValue (IServiceProvider serviceProvider)
		{
            if (Color == null)
				return null;
            return ThemeColors.GetColor(Color.ToUpper());
		}

	}
}