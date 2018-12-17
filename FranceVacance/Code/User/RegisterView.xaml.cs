using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.System;
using Windows.UI.Core;
using Windows.UI.Popups;
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
    public sealed partial class RegisterView : Page {
        private bool godMode = false;
        private List<VirtualKey> keyCurrSequence = new List<VirtualKey>();

        private List<VirtualKey> keyMagicSequence = new List<VirtualKey>() {
            VirtualKey.Up,
            VirtualKey.Down,
            VirtualKey.Left,
            VirtualKey.Right
        };

        public RegisterView()
        {
            this.InitializeComponent();
            Window.Current.CoreWindow.KeyDown += CoreWindow_KeyDown;
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

        private void CoreWindow_KeyDown(CoreWindow sender, KeyEventArgs e) {
            if (godMode) return;

            var vk = (VirtualKey) e.VirtualKey;

            if (keyMagicSequence.Contains(vk)) {
                if(keyCurrSequence.Count == keyMagicSequence.IndexOf(vk)) { 
                    keyCurrSequence.Add(vk);
                    var mbox = new MessageDialog("GOD MODE ACTIVATED");
                    if (keyCurrSequence.Count == 4) {
                        if (keyCurrSequence.SequenceEqual(keyMagicSequence)) {
                            // mbox.ShowAsync();
                            pnl_godMode.Visibility = Visibility.Visible;
                            godMode = true;
                        }
                    }
                } else {
                    keyCurrSequence.Clear();
                }
            } else {
                keyCurrSequence.Clear();
            }

        }
    }



}