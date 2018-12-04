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
            LoginVM.Username = $"email";
            LoginVM.Password = $"password";

            LoginVM.Login();

            Assert.IsNotNull(UserViewModel.Instance.CurrentUser);
            Assert.AreEqual(UserViewModel.Instance.CurrentUser.Email, $"email");
            Assert.AreEqual(UserViewModel.Instance.CurrentUser.Password, $"password");
        }
    }
}
