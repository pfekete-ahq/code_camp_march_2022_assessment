using OpenQA.Selenium;

namespace code_camp_march_2022_assessment.model
{
    public class BaseModel
    {
        protected IWebDriver driver;

        public BaseModel(IWebDriver driver)
        {
            this.driver = driver;
        }
    }
}
