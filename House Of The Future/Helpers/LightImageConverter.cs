﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace House_Of_The_Future.Helpers
{
    public class LightImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool lightStatus = (bool)value;
            String imagePath = (lightStatus) ? "Images/LampAan.png" : "Images/LampUit.png";
            return imagePath as String;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
