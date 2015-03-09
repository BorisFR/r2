using R2B0app;
using R2B0app.WinPhone;
using Xamarin.Forms;
using Xamarin.Forms.Platform.WinPhone;

[assembly: ExportRenderer (typeof (MyButton), typeof (MyButtonRenderer))]
namespace R2B0app.WinPhone
{
	public class MyButtonRenderer : ButtonRenderer
	{
        protected override void OnElementChanged(ElementChangedEventArgs<Button> e)
        {
            base.OnElementChanged(e);
            if (Control == null)
                return;
            //Control.Margin = new System.Windows.Thickness(0);
            Control.Padding = new System.Windows.Thickness(0);
        }
	}
}