using FranceVacance.Code.User;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class UserViewModelTest
    {
        [TestMethod]
        public void Login()
        {
            UserViewModel.Instance.RegisteredUsers.Add(new UserModel()
            {
                Email = $"email",
                Password = $"password",
            });


            LoginViewModel LoginVM = new LoginViewModel();
            LoginVM.Email = $"email";
            LoginVM.Password = $"password";

            LoginVM.Login();
        }
    }
}
