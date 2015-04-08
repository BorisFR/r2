using System;
using Xamarin.Forms;
using System.Globalization;

namespace R2B0app
{
	
	public class IntToString : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			int v = System.Convert.ToInt32 (value);
			return v.ToString ();
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{ return System.Convert.ToInt32 (value as string); }
	}

	public class DoubleToString : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			double v = (double)value;
			return v.ToString ();
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{ throw new NotImplementedException(); }
	}

}