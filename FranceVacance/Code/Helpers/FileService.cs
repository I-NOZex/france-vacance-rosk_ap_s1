using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Windows.Storage;
using Microsoft.Toolkit.Uwp.Helpers;
using Newtonsoft.Json;

namespace FranceVacance.Code.Helpers {
    public class FileService<T> : IDataService<T> {

        private async Task<string> loadDefaultData(string fileName, StorageFile jsonFile) {
            StorageFile defaultJsonFile =
                await StorageFile.GetFileFromApplicationUriAsync(new Uri($"ms-appx:///Assets/{fileName}"));

            string defaultJsonData = await FileIO.ReadTextAsync(defaultJsonFile);
            await FileIO.WriteTextAsync(jsonFile, defaultJsonData);
            return defaultJsonData;
        }

        public async Task<ObservableCollection<T>> LoadData(string fileName, bool skipDefaultData = false) {
            try {
                string jsonData = "";

                bool fileExists = await ApplicationData.Current.LocalFolder.FileExistsAsync(fileName);
                if (!fileExists) {
                    StorageFile jsonFile = await ApplicationData.Current.LocalFolder.CreateFileAsync(fileName);
                    
                    if (!skipDefaultData) {
                        jsonData = await loadDefaultData(fileName, jsonFile);
                    }
                } else {
                    StorageFile jsonFile = await ApplicationData.Current.LocalFolder.GetFileAsync(fileName);
                    var fileProps = await jsonFile.GetBasicPropertiesAsync();

                    if (fileProps.Size < 1.0) {
                        jsonData = await loadDefaultData(fileName, jsonFile);
                    } else {
                        jsonData = await FileIO.ReadTextAsync(jsonFile);
                    }
                }

                ObservableCollection<T> dataCollection =
                    JsonConvert.DeserializeObject<ObservableCollection<T>>(jsonData);

                return dataCollection;

            } catch (Exception e) {
                var a = e;
            }

            return null;
        }

        public async Task<bool> SaveData(string fileName, ObservableCollection<T> dataCollection) {
            // Serializer settings
            JsonSerializerSettings settings = new JsonSerializerSettings();
            settings.PreserveReferencesHandling = PreserveReferencesHandling.None;
            settings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            //settings.Formatting = Formatting.None;
            settings.Formatting = Formatting.Indented;


            string jsonData = JsonConvert.SerializeObject(dataCollection, settings);
            StorageFile jsonFile = await ApplicationData.Current.LocalFolder.CreateFileAsync(fileName, CreationCollisionOption.ReplaceExisting);
            await FileIO.WriteTextAsync(jsonFile, jsonData);
            return true;
        }
    }
}
