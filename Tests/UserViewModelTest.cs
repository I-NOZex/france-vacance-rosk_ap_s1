using System;
using System.IO;
using System.ServiceModel.Security;
using FranceVacance.Code.User;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class UserViewModelTest
    {
        [TestMethod]
        public void Login_Success()
        {

            UserViewModel.Instance.RegisteredUsers.Add(new UserModel()
            {
                Username = $"username",
                Password = $"password",
            });


            LoginViewModel LoginVM = new LoginViewModel();
            LoginVM.Username = $"username";
            LoginVM.Password = $"password";
           
            
            //RegisterUserViewModel RegistrVM=new RegisterUserViewModel();
            //RegistrVM.UserError = "";
           

            var result = LoginVM.Login();

            Assert.IsNotNull(UserViewModel.Instance.CurrentUser);
            Assert.AreEqual(UserViewModel.Instance.CurrentUser.Username, $"username");
            Assert.AreEqual(UserViewModel.Instance.CurrentUser.Password, $"password");
            Assert.AreEqual(UserViewModel.Instance.CurrentUser.Username,$"username not in the system");
            Assert.IsFalse(result);
        }
    }
}
