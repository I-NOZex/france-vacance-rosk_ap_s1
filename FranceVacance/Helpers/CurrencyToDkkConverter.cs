﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace FranceVacance.Helpers {
    public class CurrencyToDkkConverter : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, string language) {
            return $"{value} Dkk";
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language) {
            throw new NotImplementedException();
        }
    }
}
