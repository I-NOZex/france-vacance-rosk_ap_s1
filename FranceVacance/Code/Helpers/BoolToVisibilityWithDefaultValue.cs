using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;
using FranceVacance.Code.User;


namespace FranceVacance.Code.Helpers {
    public class BoolToVisibilityWithDefaultValue : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, string language) {
            if (value != null) {
			    if(value is UserModel) {
			        UserModel userInstance = (UserModel)value;
				    string property = parameter as string;

                    bool isAdmin = (bool)userInstance.GetType().GetProperty(property).GetValue(userInstance, null);
                    return isAdmin ? Visibility.Visible : Visibility.Collapsed;
                }
            }

            return Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language) {
            throw new NotImplementedException();
        }
    }
}

