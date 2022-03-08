using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace code_camp_march_2022_assessment.model
{
    public class Base
    {
        protected IWebDriver driver;

        public Base(IWebDriver driver)
        {
            this.driver = driver;
        }
    }
}
