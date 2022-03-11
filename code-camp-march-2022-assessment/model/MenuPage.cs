using System;
using System.Collections.ObjectModel;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace code_camp_march_2022_assessment.model
{
    public class MenuPage : BaseModel
    {
        public MenuPage(IWebDriver driver) : base(driver)
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(5)).Until(d => d.FindElement(By.CssSelector(".v-tabs")).Displayed);
        }

        internal void ClickTab(string tabName)
        {
            driver.FindElement(By.CssSelector("[role='tablist']")).FindElement(By.XPath(".//div[@role='tab' and contains(.,'" + tabName + "')]")).Click();
        }

        internal void ClickMenuItemOrderButton(string menuItemName)
        {
            Thread.Sleep(1000);
            ReadOnlyCollection<IWebElement> menuItemElements = driver.FindElements(By.CssSelector(".v-tabs .v-card.menuItem"));

            foreach (IWebElement menuItem in menuItemElements)
            {
                if (menuItem.FindElement(By.CssSelector(".name")).Text.Equals(menuItemName))
                {
                    menuItem.FindElement(By.CssSelector("button[aria-label='Add to order']")).Click();
                    return;
                }
            }
            throw new Exception("Unable to find menu item.");
        }

        internal void ClickYourOrderButton()
        {
            driver.FindElement(By.CssSelector("header .hidden-sm-and-down [aria-label='your order']")).Click();
        }

        public string GetOrderCount()
        {
            return driver.FindElement(By.CssSelector("header .hidden-sm-and-down [aria-label='your order'] .order-count")).Text;
        }
    }
}
