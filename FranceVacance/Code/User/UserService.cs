using FranceVacance.Code.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FranceVacance.Code.User
{
    class UserService : FileService<UserModel>
    {
        private const string FileName = "users.json";

        public async Task<ObservableCollection<UserModel>> LoadDataAsync()
        {
            return await LoadData(FileName);
        }

        public async Task<bool> SaveDataAsync(ObservableCollection<UserModel> usersCollection)
        {
            return await SaveData(FileName, usersCollection);
        }
    }
}