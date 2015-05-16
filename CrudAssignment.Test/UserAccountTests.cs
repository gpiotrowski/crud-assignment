using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using CrudAssignment.Web;
using CrudAssignment.Web.Controllers;
using CrudAssignment.Web.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.Practices.Unity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace CrudAssignment.Test
{
    [TestClass]
    public class UserAccountTests
    {
        [TestMethod]
        public void UserLoginSuccess()
        {
            // Arrange
            var userStore = new Mock<IUserStore<ApplicationUser>>();
            var userManager = new Mock<ApplicationUserManager>(userStore.Object);
            var authenticationManager = new Mock<IAuthenticationManager>();
            var signInManager = new Mock<ApplicationSignInManager>(userManager.Object, authenticationManager.Object);

            signInManager.Setup(s => s.PasswordSignInAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<bool>(), It.IsAny<bool>()))
                .Returns<string, string, bool, bool>(MockPasswordSignInAsync);

            var accountController = new AccountController(userManager.Object, signInManager.Object);

            var contextMock = new Mock<HttpContextBase>();
            accountController.Url = new UrlHelper(new RequestContext(contextMock.Object, new RouteData()));

            var redirectUrl = "/testSuccess";

            // Act
            var result = accountController.Login(new LoginViewModel() { Email = "a@b.cd", Password = "Pa$$w0rd", RememberMe = false }, redirectUrl);

            // Assert
            Assert.IsInstanceOfType(result.Result, typeof(RedirectResult));
            Assert.AreEqual(redirectUrl, (result.Result as RedirectResult).Url);
        }

        private async Task<SignInStatus> MockPasswordSignInAsync(string mail, string password, bool isPersistent, bool shouldLockout)
        {
            if(mail == "a@b.cd" && password == "Pa$$w0rd")
            {
                return SignInStatus.Success;
            }
            else
            {
                return SignInStatus.Failure;
            }
        }
    }
}
