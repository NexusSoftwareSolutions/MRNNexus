using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace MRNNexus.WPFClient.Converters
{
    class IntToInt64Converter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Int64)
            {
                Int64 i = (Int64)value;
                return (int)i;
            }
            else if (value is int)
            {
                int i = (int)value;
                return (Int64)i;                
            }
            
            else
            {
                return 0;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is int)
            {
                int i = (int)value;
                return (Int64?)i;
            }
            else if (value is Int64?)
            {
                Int64? i = (Int64?)value;
                return (int)i;
            }
            else
            {
                return 0;
            }
        
        }
    }
}
