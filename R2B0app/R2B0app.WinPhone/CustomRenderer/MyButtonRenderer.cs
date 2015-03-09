[assembly: ExportRenderer (typeof (MyButton), typeof (MyButtonRenderer))]
namespace R2B0app.iOS
{
	public class MyButtonRenderer : ButtonRenderer
	{
		protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
		{
			base.OnElementChanged(e);

			if (e.OldElement == null)
			{
				//var nativePhoneTextBox = (PhoneTextBox)Control.Children[0];
				//nativePhoneTextBox.Background = new SolidColorBrush(Colors.Yellow);
			}
		}
	}
}