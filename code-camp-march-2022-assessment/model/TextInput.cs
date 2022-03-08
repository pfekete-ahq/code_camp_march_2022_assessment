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
    public class TextInput : Base
    {
        protected IWebElement element;

        public TextInput(IWebDriver driver, IWebElement element) : base(driver)
        {
            this.element = element;
        }

        public IWebElement label => driver.FindElement(By.TagName("label"));
        public IWebElement input => driver.FindElement(By.TagName("input"));

        public static TextInput getInstance(IWebDriver driver, IWebElement rootElement, string labelText)
        {
            ReadOnlyCollection<IWebElement> inputElements = rootElement.FindElements(By.ClassName("v-input__control"));
            foreach (IWebElement element in inputElements)
            {
                if (element.FindElement(By.TagName("label")).Text == labelText)
                {
                    TextInput textInput = new TextInput(driver, element);
                    return textInput;
                }
            }
            throw new Exception("Unable to find text input.");
        }

        public void SetText(string text)
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(3)).Until(d => input.Displayed && input.Enabled);
            this.input.Clear();
            this.input.SendKeys(text);
        }
    }
}
