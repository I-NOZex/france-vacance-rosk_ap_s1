﻿using System;
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
using Windows.UI.Xaml.Navigation;
using FranceVacance.Data;
using FranceVacance.Model;
using FranceVacance.ViewModel;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace FranceVacance
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage() {

            this.InitializeComponent();
        }



        private void Slider_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {

        }

        private void autobox_QuerySubmitted(AutoSuggestBox sender, AutoSuggestBoxQuerySubmittedEventArgs args) {
            var VM = (this.DataContext as AccommodationViewModel);
                VM.Search(
                    byName: VM.SearchAccommodation.Name.Length > 0,
                    byMaxPrice: true,
                    byDate: true
                );
        }
    }
}

