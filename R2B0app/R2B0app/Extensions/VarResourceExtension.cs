using System;
using Xamarin.Forms.Xaml;
using Xamarin.Forms;

namespace R2B0app
{
	[ContentProperty("Text")]
	public class VarResourceExtension : IMarkupExtension
	{
		public string Text { get; set; }

		public object ProvideValue (IServiceProvider serviceProvider)
		{
			if (Text == null)
				return null;

			switch (Text) {
			case "Hour":
				return Global.ForBinding.Hour.ToString ("00");
			case "Minute":
				return Global.ForBinding.Minute.ToString ("00");
			case "Second":
				return Global.ForBinding.Second.ToString ("00");
			}
			return Text;
		}

	}
}