using OpenQA.Selenium;

namespace code_camp_march_2022_assessment.model
{
    public class HomePage : BaseModel
    {
        public HomePage(IWebDriver driver) : base(driver)
        {
        }

        internal void ClickLoginOrSignupButton()
        {
            driver.FindElement(By.CssSelector("[aria-label='login or signup']")).Click();
        }

        internal void ClickMenuButton()
        {
            driver.FindElement(By.CssSelector("[aria-label='menu']")).Click();
        }
    }
}
