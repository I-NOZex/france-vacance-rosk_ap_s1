using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FranceVacance.Code.Accommodation;
using FranceVacance.Code.Helpers;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace FranceVacance.Code.Booking {
    public class BookingService : FileService<BookingModel> {
        private const string FILE_NAME = "bookings.json";

        public async Task<ObservableCollection<BookingModel>> LoadDataAsync() {
            return await LoadData(FILE_NAME);
        }

        public async Task<bool> SaveDataAsync(ObservableCollection<BookingModel> accommodationCollection) {
            //SerializerSettings.ContractResolver = new DynamicContractResolver();
            return await SaveData(FILE_NAME, accommodationCollection);
        }
    }

    public class DynamicContractResolver : DefaultContractResolver {
        private readonly char _startingWithChar;

        public DynamicContractResolver() {
            
        }

        protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization) {
            IList<JsonProperty> properties = base.CreateProperties(type, memberSerialization);

            // only serializer properties that start with the specified character
            properties =
                properties.Where(p => p.PropertyName == "Id").ToList();

            return properties;
        }
    }
}
