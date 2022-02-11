using OpenQA.Selenium;

namespace MySampleFramework
{
    internal class BaseSampleApplicationPage
    {
        protected IWebDriver Driver { get; set; }

        public BaseSampleApplicationPage(IWebDriver driver)
        {
            Driver = driver;
        }
    }
}