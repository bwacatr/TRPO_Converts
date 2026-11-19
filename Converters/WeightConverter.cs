using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace TRPO_Converts.Converters
{
    class WeightConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                return String.Empty;
            }

            if (value is float f) return System.Convert.ToInt32(f * 1000);
            if (value is double d) return System.Convert.ToInt32(d * 1000);

            if (float.TryParse(value.ToString(), NumberStyles.Float, culture, out float result))
                return System.Convert.ToInt32(result * 1000);
           
            return String.Empty;
        
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) return null;

            if (float.TryParse(value.ToString(), NumberStyles.Float, culture, out float result))
                return result / 1000f;
            return null;

        }
    }
}
