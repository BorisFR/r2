using Xamarin.Forms.Xaml;
using System;
using Xamarin.Forms;


namespace R2B0app
{
	[ContentProperty ("Source")]
	public class SendingResourceExtension : IMarkupExtension
	{

		public string Source { get; set; }

		public object ProvideValue (IServiceProvider serviceProvider)
		{
			if (Source == null)
				return null;
			try {
				string s = Source.ToString ();
				if (Source.StartsWith ("-"))
					s = "E";
				var imageSource = ImageSource.FromResource ("R2B0app.Images.com" + s + ".png");
				if (imageSource == null)
					System.Diagnostics.Debug.WriteLine ("******** ProvideValue null " + Source);
				return imageSource;
			} catch (Exception err) {
				System.Diagnostics.Debug.WriteLine ("******** ProvideValue " + err.Message);
				return null;
			}
		}

	}
}