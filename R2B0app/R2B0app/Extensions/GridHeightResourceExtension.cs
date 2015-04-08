using System;
using Xamarin.Forms.Xaml;
using Xamarin.Forms;
using DeviceInfo.Plugin;

namespace R2B0app
{
	[ContentProperty("Height")]
    public class GridHeightResourceExtension : IMarkupExtension
	{

		public string Height { get; set; }

		public object ProvideValue (IServiceProvider serviceProvider)
		{
			if (Height == null)
				return null;
			switch (Height) {
			case "TextSizeForKeyboardTitle":
				if (CrossDeviceInfo.Current.Platform == DeviceInfo.Plugin.Abstractions.Platform.Android)
					return new GridLength (Global.ForBinding.TextSizeForKeyboardTitle + 2);
				return new GridLength (Global.ForBinding.TextSizeForKeyboardTitle);
			case "TextSizeForBigCommandTitle":
				if (CrossDeviceInfo.Current.Platform == DeviceInfo.Plugin.Abstractions.Platform.Android)
					return new GridLength (Global.ForBinding.TextSizeForBigCommandTitle + 2);
				return new GridLength (Global.ForBinding.TextSizeForBigCommandTitle);
			default:
				return new GridLength (18);
			}
		}

	}
}