using System;
using Xamarin.Forms.Xaml;
using Xamarin.Forms;

namespace R2B0app
{
    [ContentProperty("BackgroundColor")]
    public class BGResourceExtension : IMarkupExtension
	{

        public string BackgroundColor { get; set; }

		public object ProvideValue (IServiceProvider serviceProvider)
		{
            if (BackgroundColor == null)
				return null;
            return ThemeColors.GetColor(BackgroundColor.ToUpper());
		}

	}
}