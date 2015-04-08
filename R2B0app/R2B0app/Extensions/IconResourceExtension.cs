using Xamarin.Forms.Xaml;
using System;
using Xamarin.Forms;


namespace R2B0app
{
	[ContentProperty ("Icon")]
	public class IconResourceExtension : IMarkupExtension
	{

		public string Icon { get; set; }

		public object ProvideValue (IServiceProvider serviceProvider)
		{
			if (Icon == null)
				return null;
            try
            {
				var imageSource = ImageSource.FromResource ("R2B0app.Images." + Icon);
                if (imageSource == null)
					System.Diagnostics.Debug.WriteLine("******** ProvideValue null " + Icon);
                return imageSource;
            }
            catch (Exception err)
            {
                System.Diagnostics.Debug.WriteLine("******** ProvideValue " + err.Message);
                return null;
            }
		}

	}
}