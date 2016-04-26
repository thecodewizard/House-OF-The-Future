using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace House_Of_The_Future.Helpers
{
    public class VerwarmingConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool VerwarmingStatus = (bool)value;
            String imagePath = (VerwarmingStatus) ? "Images/" : "/Content/lightbulb_off.png";
            return imagePath as String;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
