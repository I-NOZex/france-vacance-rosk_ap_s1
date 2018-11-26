using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using FranceVacance.Code.Accommodation;
using Microsoft.Toolkit.Uwp.Helpers;
using Newtonsoft.Json;

namespace FranceVacance.Code.Helpers {
    public class FileService<T> : IDataService<T> {

        public async Task<ObservableCollection<T>> LoadData(string fileName) {
            try {
                string jsonData = "";

                bool fileExists = await ApplicationData.Current.LocalFolder.FileExistsAsync(fileName);
                if (!fileExists) {
                    StorageFile jsonFile = await ApplicationData.Current.LocalFolder.CreateFileAsync(fileName);

                    StorageFile defaultJsonFile = await StorageFile.GetFileFromApplicationUriAsync(new Uri($"ms-appx:///Assets/{fileName}"));

                    string defaultJsonData = await FileIO.ReadTextAsync(defaultJsonFile);
                    await FileIO.WriteTextAsync(jsonFile, defaultJsonData);


                    jsonData = defaultJsonData;

                } else {
                    StorageFile jsonFile = await ApplicationData.Current.LocalFolder.GetFileAsync(fileName);
                    jsonData = await FileIO.ReadTextAsync(jsonFile);
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


            string notebookData = JsonConvert.SerializeObject(dataCollection, settings);
            StorageFile jsonFile = await ApplicationData.Current.LocalFolder.CreateFileAsync(fileName, CreationCollisionOption.ReplaceExisting);
            await FileIO.WriteTextAsync(jsonFile, notebookData);
            return true;
        }
    }
}
