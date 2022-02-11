using OpenQA.Selenium;

namespace AutomationPractice
{
    internal class ContactUsPage : BaseApplicationPage
    {
        public ContactUsPage(IWebDriver driver) : base(driver)
        {
        }

        public bool IsLoaded
        {
            get
            {
                try
                {
                    return CenterColumn.Displayed;
                }
                catch (NoSuchElementException)
                {
                    return false;
                }
            }
        }

        private IWebElement CenterColumn => Driver.FindElement(By.Id("center_column"));

        internal void GoTo()
        {
            Driver.Navigate().
                GoToUrl("http://automationpractice.com/index.php?controller=contact");
        }
    }
}