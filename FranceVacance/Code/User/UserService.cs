using FranceVacance.Code.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FranceVacance.Code.User
{
    class UserService :  FileService<UserInfo>
    {
    private const string FILE_NAME = "users.json";

    public async Task<ObservableCollection<UserInfo>> LoadDataAsync()
    {
        return await LoadData(FILE_NAME);
    }

    public async Task<bool> SaveDataAsync(ObservableCollection<UserInfo> usersCollection)
    {
        return await SaveData(FILE_NAME, usersCollection);
    }

    /*public AccommodationService(AccommodationViewModel accommodationViewModel) {
        _accommodationViewModel = accommodationViewModel;
    }*/
    }
}
