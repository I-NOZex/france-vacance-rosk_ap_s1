
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using FranceVacance.Code.Accommodation;
using FranceVacance.Code.Search;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class AccommodationViewModelTest {

        private SearchViewModel InitialSetup() {
            SearchViewModel VM = new SearchViewModel();
            VM.AccommodationViewModel = new AccommodationViewModel();
            VM.AccommodationViewModel.Accommodations = new ObservableCollection<AccommodationModel>() {
                new AccommodationModel() {
                    Name = "DanskHotel",
                    Price = 200
                },
                new AccommodationModel() {
                    Name = "Scandic",
                    Price = 1000
                },
                new AccommodationModel() {
                    Name = "Black Sea",
                    Price = 900
                },
                new AccommodationModel() {
                    Name = "Melia",
                    Price = 700
                },
                new AccommodationModel() {
                    Name = "The Grand Budapest Hotel",
                    Price = 700,
                },
                new AccommodationModel() {
                    Name = "Hotel Transilvania",
                    Price = 123
                }
            };

            return VM;
        }

        [TestMethod]
        public void Search_By_Name() {

            SearchViewModel VM = InitialSetup();

            AccommodationViewModel AccommodationCatalogFiltered = new AccommodationViewModel();
            AccommodationCatalogFiltered.Accommodations.Clear();

            SearchFiltersViewModel SAF = new SearchFiltersViewModel();

            SAF.MaxPrice = VM.FindMaxPrice();

            SAF.Name = "Hotel";

            VM.SearchAccommodation = SAF;

            AccommodationCatalogFiltered = VM.Search(byName:true);

            foreach (var filteredAccommodation in AccommodationCatalogFiltered.Accommodations) {
                Assert.IsTrue(filteredAccommodation.Name.Contains(SAF.Name));
            }

        }

        [TestMethod]
        public void Search_By_MaxPrice() {

            SearchViewModel VM = InitialSetup();

            AccommodationViewModel AccommodationCatalogFiltered = new AccommodationViewModel();
            AccommodationCatalogFiltered.Accommodations.Clear();

            SearchFiltersViewModel SAF = new SearchFiltersViewModel();

            SAF.MaxPrice = VM.FindMaxPrice();

            SAF.SelectedMaxPrice = 701;

            VM.SearchAccommodation = SAF;

            AccommodationCatalogFiltered = VM.Search(byMaxPrice: true);

            foreach (var filteredAccommodation in AccommodationCatalogFiltered.Accommodations) {
                Assert.IsTrue(filteredAccommodation.Price <= SAF.SelectedMaxPrice);
            }
        }

        [TestMethod]
        public void Search_By_Name_AND_MaxPrice() {

            SearchViewModel VM = InitialSetup();

            AccommodationViewModel AccommodationCatalogFiltered = new AccommodationViewModel();
            AccommodationCatalogFiltered.Accommodations.Clear();

            SearchFiltersViewModel SAF = new SearchFiltersViewModel();

            SAF.MaxPrice = VM.FindMaxPrice();

            SAF.Name = "and";
            SAF.SelectedMaxPrice = 950;

            VM.SearchAccommodation = SAF;

            AccommodationCatalogFiltered = VM.Search(byName: true, byMaxPrice:true);

            foreach (var filteredAccommodation in AccommodationCatalogFiltered.Accommodations) {
                Assert.IsTrue(filteredAccommodation.Name.Contains(SAF.Name));
                Assert.IsTrue(filteredAccommodation.Price <= SAF.SelectedMaxPrice);
            }
        }



    }
}


