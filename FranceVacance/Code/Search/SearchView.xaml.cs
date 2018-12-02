using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

using FranceVacance.Code.User;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace FranceVacance.Code.Search
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SearchView : Page
    {
        public SearchView()
        {

            this.InitializeComponent();
        }



        private void autobox_QuerySubmitted(AutoSuggestBox sender, AutoSuggestBoxQuerySubmittedEventArgs args)
        {
            var VM = (this.DataContext as SearchViewModel);
                VM.Search(
                    byName: VM.SearchAccommodation.Name.Length > 0,
                    byMaxPrice: true,
                    byAddress: VM.SearchAccommodation.Address.Length > 0,
                    byDate: true
                );
        }
        //I am Borislav's creation :), so don't mind me
        

        private void Btn_register_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            Frame.Navigate(typeof(RegisterView));
        }
    }
}

