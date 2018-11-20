
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using FranceVacance.Data;
using FranceVacance.Helpers;
using FranceVacance.Model;
using FranceVacance.ViewModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class AccommodationViewModelTest {

        private AccommodationViewModel InitialSetup() {
            AccommodationViewModel VM = new AccommodationViewModel();
            VM.AccommodationCatalog = new AccommodationCatalog();
            VM.AccommodationCatalog.Accommodations = new ObservableCollection<AccommodationModel>() {
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

            AccommodationViewModel VM = InitialSetup();

            AccommodationCatalog AccommodationCatalogFiltered = new AccommodationCatalog();
            AccommodationCatalogFiltered.Accommodations.Clear();

            SearchAccommodationFilters SAF = new SearchAccommodationFilters();

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

            AccommodationViewModel VM = InitialSetup();

            AccommodationCatalog AccommodationCatalogFiltered = new AccommodationCatalog();
            AccommodationCatalogFiltered.Accommodations.Clear();

            SearchAccommodationFilters SAF = new SearchAccommodationFilters();

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

            AccommodationViewModel VM = InitialSetup();

            AccommodationCatalog AccommodationCatalogFiltered = new AccommodationCatalog();
            AccommodationCatalogFiltered.Accommodations.Clear();

            SearchAccommodationFilters SAF = new SearchAccommodationFilters();

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


