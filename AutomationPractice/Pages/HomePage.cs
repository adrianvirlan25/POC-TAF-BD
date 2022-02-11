using NLog;
using OpenQA.Selenium;

namespace AutomationPractice
{
    internal class HomePage : BaseApplicationPage
    {
        private static Logger _logger = LogManager.GetCurrentClassLogger();

        public HomePage(IWebDriver driver) : base(driver)
        {
            Slider = new Slider(driver);
        }

        private IWebElement SearchBar => Driver.FindElement(By.Id("search_query_top"));

        private IWebElement SubmitButton => Driver.FindElement(By.XPath("//button[@name='submit_search']"));

        public Slider Slider { get; internal set; }

        internal void GoTo()
        {
            var url = "https://portal.sandbox.use1.cwcmddev.cwnet.io/";
            Driver.Manage().Window.Maximize();
            Driver.Navigate().GoToUrl(url);
            _logger.Info($"Opened url => {url}");
        }

        internal SearchPage Search(string itemToSearchFor)
        {
            _logger.Trace($"Attempting to perform a Search for {itemToSearchFor}");
            SearchBar.SendKeys(itemToSearchFor);
            SubmitButton.Click();
            _logger.Info($"Search for an item in the search bar => {itemToSearchFor}");
            return new SearchPage(Driver);
        }
    }
}