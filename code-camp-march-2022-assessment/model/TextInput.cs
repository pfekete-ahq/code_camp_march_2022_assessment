using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace code_camp_march_2022_assessment.model
{
    public class TextInput : BaseModel
    {
        public TextInput(IWebDriver driver) : base(driver)
        {
        }

        public IWebElement label => driver.FindElement(By.TagName("label"));
        public IWebElement input => driver.FindElement(By.TagName("input"));

        public void SetText(string text)
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(3)).Until(d => input.Displayed && input.Enabled);
            this.input.Clear();
            this.input.SendKeys(text);
        }
    }
}