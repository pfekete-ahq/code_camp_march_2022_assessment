using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace code_camp_march_2022_assessment
{
    public class BaseTestSuite
    {
        protected IWebDriver driver;
        private string pizzaHqUrl = "https://d2ju5vf8ca0qio.cloudfront.net/#/";

        [TestInitialize]
        public void TestInitialize()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(pizzaHqUrl);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            driver.Close();
        }
    }
}
