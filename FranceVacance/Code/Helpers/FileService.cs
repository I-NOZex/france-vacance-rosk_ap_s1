using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Windows.Storage;
using Microsoft.Toolkit.Uwp.Helpers;
using Newtonsoft.Json;

namespace FranceVacance.Code.Helpers {


    public class FileService<T> : IDataService<T> {
        protected JsonSerializerSettings SerializerSettings;

        //async task that returns a string
        private async Task<string> loadDefaultData(string fileName, StorageFile jsonFile) {
            //get the default data file
            StorageFile defaultJsonFile =
                await StorageFile.GetFileFromApplicationUriAsync(new Uri($"ms-appx:///Assets/{fileName}"));
            // read the file contents
            string defaultJsonData = await FileIO.ReadTextAsync(defaultJsonFile);
            //write default data contents to the new file
            await FileIO.WriteTextAsync(jsonFile, defaultJsonData);
            //returns default data file contents
            return defaultJsonData;
        }

        public async Task<ObservableCollection<T>> LoadData(string fileName, bool skipDefaultData = false) {
            try {
                string jsonData = "";

                //check if the file exists
                bool fileExists = await ApplicationData.Current.LocalFolder.FileExistsAsync(fileName);
                if (!fileExists) {
                    //if not create a new file an waits for conclusion
                    StorageFile jsonFile = await ApplicationData.Current.LocalFolder.CreateFileAsync(fileName);
                    //check if we want to load the default data
                    if (!skipDefaultData) {            
                        jsonData = await loadDefaultData(fileName, jsonFile);
                    }
                } else {
                    StorageFile jsonFile = await ApplicationData.Current.LocalFolder.GetFileAsync(fileName);
                    var fileProps = await jsonFile.GetBasicPropertiesAsync();
                    // check if the file is empty
                    if (fileProps.Size < 1.0) {
                        // if its empty, load the default data
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
            string jsonData = JsonConvert.SerializeObject(dataCollection, SerializerSettings);
            StorageFile jsonFile = await ApplicationData.Current.LocalFolder.CreateFileAsync(fileName, CreationCollisionOption.ReplaceExisting);
            await FileIO.WriteTextAsync(jsonFile, jsonData);
            return true;
        }

        public FileService() {
            // Serializer settings
            SerializerSettings = new JsonSerializerSettings();
            SerializerSettings.PreserveReferencesHandling = PreserveReferencesHandling.None;
            SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            //SerializerSettings.Formatting = Formatting.None;
            SerializerSettings.Formatting = Formatting.Indented;
        }

    }
}
