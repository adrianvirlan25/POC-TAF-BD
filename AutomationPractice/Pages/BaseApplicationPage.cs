using OpenQA.Selenium;

namespace AutomationPractice
{
    public class BaseApplicationPage
    {
        protected IWebDriver Driver { get; set; }

        public BaseApplicationPage(IWebDriver driver)
        {
            Driver = driver;
        }
    }
}