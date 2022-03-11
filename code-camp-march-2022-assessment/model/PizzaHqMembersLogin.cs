using System;
using System.Collections.ObjectModel;
using System.Xml.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace code_camp_march_2022_assessment.model
{
    public class PizzaHqMembersLogin : BaseModel
    {
        public PizzaHqMembersLogin(IWebDriver driver) : base(driver)
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(4)).Until(d => RootElement.Displayed);
        }

        // Don't assign IWebElements to a variable in a constructor because it risks a StaleElementException.
        // Also perfect opportunity to remove some code duplication.
        private IWebElement RootElement => driver.FindElement(By.Id("loginDialog"));

        public void ClickLoginButton()
        {
            RootElement.FindElement(By.CssSelector("[aria-label='login']")).Click();
        }

        public string GetAlertContent()
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(3)).Until(d => d.FindElement(By.ClassName("v-alert__content")).Displayed);
            return RootElement.FindElement(By.ClassName("v-alert__content")).Text;
        }

        public void SetUsername(string username)
        {
            GetTextInput("Username").SetText(username);
        }

        internal void SetPassword(string password)
        {
            GetTextInput("Password").SetText(password);
        }

        // This refactor makes a lot more sense than the static GetInstance stuff from Morgans.
        // 1. It's much simpler and easier to read
        // 2. It doesn't mix static and dynamic typing in the same class
        // 3. It reduces the number of boiler-plate parameters to the methods which are confusing
        // 4. It eliminates a weird "GetInstance" method which takes some time to wrap your head around
        // 5. It simplifies the TextInput constructor to eliminate boiler-plate parameters
        //
        // The only reason it was used at Morgans was because Dan was trying to break everything down into
        // little re-usable components (which could pop up anywhere in Salesforce) that were also hard to
        // get with Selenium. So he was handing driver, webdriverwait, and other things around a lot and using
        // javascript to locate and that meant he couldn't really hand IWebElements to constructors. So he bundled the code for finding
        // the element into the model as a static method since it made sense to keep that locating code within
        // the class that represented the object itself.
        //
        // It's very a-typical and I wouldn't use it unless absolutely necessary - I'd have to re-review the
        // Morgans code, but I wouldn't be surprised if it could have been done more simply this way as well
        // (But I do seem to recall when I reviewed it there was a really good reason for the static methods
        // which lead to the whole getInstance stuff, but it escapes me what the reason was now.)
        private TextInput GetTextInput(string labelText)
        {
            ReadOnlyCollection<IWebElement> inputElements = RootElement.FindElements(By.ClassName("v-input__control"));
            foreach (IWebElement element in inputElements)
            {
                if (element.FindElement(By.TagName("label")).Text == labelText)
                {
                    return new TextInput(driver);
                }
            }
            throw new Exception("Unable to find text input.");
        }
    }
}
