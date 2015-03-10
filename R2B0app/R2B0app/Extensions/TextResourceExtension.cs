using System;
using Xamarin.Forms.Xaml;
using Xamarin.Forms;

namespace R2B0app
{
    [ContentProperty("TextColor")]
    public class TextResourceExtension : IMarkupExtension
	{

        public string TextColor { get; set; }

		public object ProvideValue (IServiceProvider serviceProvider)
		{
            if (TextColor == null)
				return null;
            return ThemeColors.GetColor(TextColor.ToUpper());
		}

	}
}