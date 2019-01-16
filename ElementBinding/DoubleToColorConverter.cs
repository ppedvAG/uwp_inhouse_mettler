using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media;

namespace ElementBinding
{
    public class DoubleToColorConverter : IValueConverter
    {
        //Source -> Target 
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            //Double -> Color
            if (byte.TryParse(value.ToString(), out byte rgbValue))
            {
               return Color.FromArgb(255, rgbValue, rgbValue, rgbValue);
            }

            return Colors.White;
        }

        //Target -> Source
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            if(value is Color color)
            {
                return color.R;
            }
            return 0;
        }
    }
}
