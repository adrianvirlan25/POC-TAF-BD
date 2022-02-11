using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace MySampleFramework
{
    internal class UltimateQAHomePage : BaseSampleApplicationPage
    {
        public UltimateQAHomePage(IWebDriver driver) : base(driver) { }

        public bool IsVisible
        {
            get
            {
                try
                {
                    WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
                    return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.TitleContains("Home | Ultimate QA"));
                }
                catch (NoSuchElementException)
                {
                    return false;
                }
            }
        }
    }
}
