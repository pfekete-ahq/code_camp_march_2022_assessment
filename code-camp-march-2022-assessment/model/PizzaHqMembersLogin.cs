using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace code_camp_march_2022_assessment.model
{
    public class PizzaHqMembersLogin : Base
    {
        private IWebElement rootElement;

        public PizzaHqMembersLogin(IWebDriver driver) : base(driver)
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(4)).Until(d => d.FindElement(By.Id("loginDialog")).Displayed);
            this.rootElement = driver.FindElement(By.Id("loginDialog"));
        }

        public void ClickLoginButton()
        {
            rootElement.FindElement(By.CssSelector("[aria-label='login']")).Click();
        }

        public string GetAlertContent()
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(3)).Until(d => d.FindElement(By.ClassName("v-alert__content")).Displayed);
            return rootElement.FindElement(By.ClassName("v-alert__content")).Text;
        }

        public void SetUsername(string username)
        {
            TextInput.getInstance(driver, rootElement, "Username").SetText(username);   
        }

        internal void SetPassword(string password)
        {
            TextInput.getInstance(driver, rootElement, "Password").SetText(password);
        }
    }
}
