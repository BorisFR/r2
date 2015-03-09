using System;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;
using R2B0app;
using R2B0app.Droid;

[assembly: ExportRenderer (typeof (MyButton), typeof (MyButtonRenderer))]
namespace R2B0app.Droid
{
	public class MyButtonRenderer : ButtonRenderer
	{
		protected override void OnElementChanged (ElementChangedEventArgs<Xamarin.Forms.Button> e)
		{
			base.OnElementChanged (e);
			if (Control == null)
				return;
			//TODO: wordwrap text in button for android
			Control.SetPadding (1, 1, 1, 1);
		}
	}
}