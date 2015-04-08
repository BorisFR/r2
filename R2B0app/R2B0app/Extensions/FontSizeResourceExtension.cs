using System;
using Xamarin.Forms.Xaml;
using Xamarin.Forms;

namespace R2B0app
{
	[ContentProperty("FontSize")]
    public class FontSizeResourceExtension : IMarkupExtension
	{

		public string FontSize { get; set; }

		public object ProvideValue (IServiceProvider serviceProvider)
		{
			if (FontSize == null)
				return null;
			switch (FontSize) {
			case "TextSizeForKeyboardTitle":
				return Global.ForBinding.TextSizeForKeyboardTitle;
			case "TextSizeForBigCommandTitle":
				return Global.ForBinding.TextSizeForBigCommandTitle;
			default:
				return 18;
			}
		}

	}
}