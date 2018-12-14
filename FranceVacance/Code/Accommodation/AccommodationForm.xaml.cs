using FranceVacance.Code.Search;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

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
            Frame.Navigate(typeof(AccommodationForm), null, new DrillInNavigationTransitionInfo());

        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
                    }

        private void TextBlock_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }

       
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
         //   var VM = (this.DataContext as AccommodationViewModel );
           // if (VM. AcommodationForm ())
            //{
                Frame.Navigate(typeof(SearchView));
            //}
            


        }

        private async Task pickFile()
        {
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
                }
            }

        }

        private  void Button_Click(object sender, RoutedEventArgs e)
        {
            pickFile();

        }
    }
}
