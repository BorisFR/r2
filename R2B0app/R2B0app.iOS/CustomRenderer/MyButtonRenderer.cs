using System;
using Xamarin.Forms.Platform.iOS;
using Xamarin.Forms;
using R2B0app;
using R2B0app.iOS;

[assembly: ExportRenderer (typeof (MyButton), typeof (MyButtonRenderer))]
namespace R2B0app.iOS
{
	public class MyButtonRenderer : ButtonRenderer
	{
		protected override void OnElementChanged (ElementChangedEventArgs<Xamarin.Forms.Button> e)
		{
			base.OnElementChanged (e);
			if (Control == null)
				return;
			Control.LineBreakMode = UIKit.UILineBreakMode.WordWrap;
		}
	}
}