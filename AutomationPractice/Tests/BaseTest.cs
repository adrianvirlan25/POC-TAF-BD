using AutomationResources;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;

namespace AutomationPractice.Tests
{
    public class BaseTest
    {
        public IWebDriver Driver { get; set; }

        [TestInitialize]
        public void SetupForEverySingleTestMethod()
        {
            var factory = new WebDriverFactory();
            Driver = factory.Create(BrowserType.Chrome);
        }

        [TestCleanup]
        public void CleanUpAfterEverySingleTestMethod()
        {
            Driver.Close();
            Driver.Quit();
        }
    }
}