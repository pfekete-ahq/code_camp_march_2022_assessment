using System.Threading;
using code_camp_march_2022_assessment.model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace code_camp_march_2022_assessment
{
    [TestClass]
    public class LoginTests : BaseTestSuite
    {
        [TestMethod]
        public void TestFieldValidationErrorMessage()
        {
            HomePage homePage = new HomePage(driver);
            homePage.ClickLoginOrSignupButton();

            PizzaHqMembersLogin pizzaHqMembersLogin = new PizzaHqMembersLogin(driver);
            Thread.Sleep(1000);
            pizzaHqMembersLogin.SetUsername("john.smith@email.com");
            pizzaHqMembersLogin.SetPassword("12345");
            pizzaHqMembersLogin.ClickLoginButton();

            Assert.AreEqual(expected: "Your login was unsuccessful - please try again", actual: pizzaHqMembersLogin.GetAlertContent());
        }
    }
}
