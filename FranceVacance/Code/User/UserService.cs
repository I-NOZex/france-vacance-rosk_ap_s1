using FranceVacance.Code.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FranceVacance.Code.User
{
    class UserService :  FileService<UserModel>
    {
    private const string FILE_NAME = "users.json";

    public async Task<ObservableCollection<UserModel>> LoadDataAsync()
    {
        return await LoadData(FILE_NAME);
    }

    public async Task<bool> SaveDataAsync(ObservableCollection<UserModel> usersCollection)
    {
        return await SaveData(FILE_NAME, usersCollection);
    }

    /*public AccommodationService(AccommodationViewModel accommodationViewModel) {
        _accommodationViewModel = accommodationViewModel;
    }*/
    }

    
    
}
