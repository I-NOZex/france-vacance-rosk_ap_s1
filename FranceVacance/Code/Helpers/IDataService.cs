using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FranceVacance.Code.Helpers {
    interface IDataService<T> {
        Task<ObservableCollection<T>> LoadData(string fileName, bool skipDefaultData);
        Task<bool> SaveData(string fileName, ObservableCollection<T> dataCollection);
    }
}
