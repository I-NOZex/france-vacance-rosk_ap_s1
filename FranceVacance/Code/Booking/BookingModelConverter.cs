using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Windows.System;
using FranceVacance.Code.Accommodation;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace FranceVacance.Code.Booking {
    //FIXME: the approach to customize the serializer for the «BookingModel» seems a bit hacky 🙁...
    class BookingModelConverter : JsonConverter<BookingModel> {

        public override void WriteJson(JsonWriter writer, BookingModel value, JsonSerializer serializer) {
            JObject jObject = new JObject();
            Type type = value.GetType();
            foreach (PropertyInfo prop in type.GetProperties()) {
                if (prop.CanRead) {
                    object propVal = prop.GetValue(value, null);
                    if (propVal != null) {
                        if(prop.Name.Equals("Accommodation"))
                            jObject.Add(prop.Name, value.Accommodation.Id);
                        else
                            jObject.Add(prop.Name, JToken.FromObject(propVal, serializer));
                    }
                }
            }
            jObject.WriteTo(writer);
        }

        public override BookingModel ReadJson(JsonReader reader, Type objectType, BookingModel existingValue, bool hasExistingValue,
            JsonSerializer serializer) {
            JObject jObject = JObject.Load(reader);

            int accommodationId = jObject["Accommodation"].Value<int>();
            AccommodationModel accommodation = AccommodationViewModel.FirstInstance.Accommodations.FirstOrDefault(a => a.Id == accommodationId);

            BookingModel result = new BookingModel() {
                Id = jObject["Id"].Value<int>(),
                CheckIn = jObject["CheckIn"].Value<DateTime>(),
                CheckOut = jObject["CheckOut"].Value<DateTime>(),
                TotalPrice = jObject["TotalPrice"].Value<double>(),
                Accommodation = accommodation
            };

            return result;
        }
    }
}
