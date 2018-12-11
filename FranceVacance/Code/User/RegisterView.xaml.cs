using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;
using FranceVacance.Code.Search;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace FranceVacance.Code.User
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class RegisterView : Page
    {
        public RegisterView()
        {
            this.InitializeComponent();
        }

        private void Btn_Cancel_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            Frame.Navigate(typeof(SearchView), null, new DrillInNavigationTransitionInfo());
        }

        private void Button_Click(object sender, RoutedEventArgs e) {
            var VM = (this.DataContext as RegisterUserViewModel);
            if (VM.AddUser()) {
                Frame.Navigate(typeof(SearchView), UserViewModel.Instance.CurrentUser);
            }
        }

        //private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        //{
        //    throw new NotImplementedException();
        //}
    }



}