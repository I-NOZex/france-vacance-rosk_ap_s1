using System;
using Windows.UI.Xaml.Data;

namespace FranceVacance.Code.Helpers {
    public class DateOperationsConverter : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, string language) {
            string operation = parameter as string;
            DateTimeOffset date = value is DateTimeOffset ? (DateTimeOffset) value : new DateTimeOffset();

            if(operation == "AddOneDay")
                return date.AddDays(1);
            else if (operation == "SubtractOneDay")
                return date.Subtract(TimeSpan.FromDays(1));

            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language) {
            throw new NotImplementedException();
        }
    }
}
