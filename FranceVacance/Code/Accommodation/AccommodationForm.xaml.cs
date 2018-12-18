using FranceVacance.Code.Search;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;
using FranceVacance.Code.User;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace FranceVacance.Code.Accommodation
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AccommodationForm : Page
    {
        public AccommodationForm()
        {
            this.InitializeComponent();
        }

        private void Btn_addAccommodation_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(AccommodationForm), UserViewModel.Instance.CurrentUser, new DrillInNavigationTransitionInfo());

        }


       
        private void Button_cancel_Click(object sender, RoutedEventArgs e)
        {
                Frame.Navigate(typeof(SearchView), UserViewModel.Instance.CurrentUser, new DrillInNavigationTransitionInfo());
        }

        private async Task pickFile() {
            AddAccommodationViewModel VM = DataContext as AddAccommodationViewModel;

            var picker = new Windows.Storage.Pickers.FileOpenPicker();
            picker.ViewMode = Windows.Storage.Pickers.PickerViewMode.Thumbnail;
            picker.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.PicturesLibrary;
            picker.FileTypeFilter.Add(".jpg");
            picker.FileTypeFilter.Add(".jpeg");
            picker.FileTypeFilter.Add(".png");

            Windows.Storage.StorageFile file =await picker.PickSingleFileAsync();

            if (file != null)
            {
                // Application now has read/write access to the picked file
                img_accommodation.Source = new BitmapImage(new Uri(file.Path));
                using (var stream = await file.OpenAsync(Windows.Storage.FileAccessMode.Read))
                {
                    var bitmapImage = new Windows.UI.Xaml.Media.Imaging.BitmapImage();
                    await bitmapImage.SetSourceAsync(stream);
                    img_accommodation.Source = bitmapImage;
                    VM.Photo = file.Path;
                }
            }

        }

        private  void Button_selectFile_Click(object sender, RoutedEventArgs e)
        {
            pickFile();

        }

        private void Btn_save_Click(object sender, RoutedEventArgs e) {
            save();
        }

        private async void save() {
            AddAccommodationViewModel VM = DataContext as AddAccommodationViewModel;
            bool success = await VM.AddAccommodation();
            if (success) {
                Flyout MyFlyout = Resources["FlyoutSuccess"] as Flyout;
                MyFlyout.ShowAt(btn_save);

                img_accommodation.Source = null;
            }
        }

        private void Txt_price_TextChanging(TextBox sender, TextBoxTextChangingEventArgs args) {
            txt_price.Text = txt_price.Text.Replace(',', '.');
            txt_price.SelectionStart = txt_price.Text.Length;
        }
    }
}
