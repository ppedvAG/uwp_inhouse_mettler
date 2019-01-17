using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace MTODO.Helper
{
    public class DateTimeToDateTimeOffsetConverter : IValueConverter
    {
        //DateTime ->  DateTimeOffset
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if(value is DateTime date)
            {
                return (DateTimeOffset)date;
            }
            return value;
        }

        //DateTimeOffset -> DateTime
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            if(value is DateTimeOffset doffset)
            {
                return doffset.DateTime;
            }
            return value;
        }
    }
}
