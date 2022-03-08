using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using code_camp_march_2022_assessment.model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace code_camp_march_2022_assessment
{
    [TestClass]
    public class OrderPageTests : BaseTestSuite
    {
        [TestMethod]
        public void TestOrderCountAndItemSubtotal()
        {
            HomePage homePage = new HomePage(driver);
            homePage.ClickMenuButton();

            MenuPage menuPage = new MenuPage(driver);
            menuPage.ClickTab("Drinks");
            menuPage.ClickMenuItemOrderButton("Espresso Thickshake");
            menuPage.ClickTab("Pizzas");
            menuPage.ClickMenuItemOrderButton("Margherita");
            menuPage.ClickMenuItemOrderButton("Margherita");
            Assert.AreEqual(expected: 3, actual: int.Parse(menuPage.GetOrderCount()));
            menuPage.ClickYourOrderButton();

            YourOrderPage yourOrderPage = new YourOrderPage(driver);
            
        }
    }
}
