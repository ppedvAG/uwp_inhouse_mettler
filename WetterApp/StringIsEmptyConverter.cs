using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace WetterApp
{
    public class StringIsEmptyConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value is string str)
            {
                bool result = string.IsNullOrWhiteSpace(str);


                if (bool.TryParse(parameter?.ToString(), out bool reverse) && reverse == true)
                {
                    result = !result;
                }
                return result;
            }
            return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}