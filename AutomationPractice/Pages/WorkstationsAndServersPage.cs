using NLog;
using OpenQA.Selenium;

namespace AutomationPractice.Pages
{
    public class WorkstationsAndServersPage : BaseApplicationPage
    {
        private readonly IWebDriver driver;

        private static Logger _logger = LogManager.GetCurrentClassLogger();

        private IWebElement EmailIDTextbox => driver.FindElement(By.Id("idToken1"));

        private IWebElement PasswordTextbox => driver.FindElement(By.Id("idToken2"));

        private IWebElement LogInButton => driver.FindElement(By.Id("loginButton_0"));

        public WorkstationsAndServersPage(IWebDriver driver) : base(driver)
        {
            this.driver = driver;

        }

        public virtual IntegrationsPage LeftMenuClickIntegrations()
        {
            //Need a mechanism for left menu to be visible
            IWebElement integrationsButton = driver.FindElement(By.Id("609"));
            integrationsButton.Click();            
            return new IntegrationsPage(driver);
        }

        public WorkstationsAndServersPage LoginCWSE()
        {
            //WorkstationsAndServersPage workstationsAndServers = new WorkstationsAndServersPage(Driver);
            GoTo();
            LogIn("mdruiu@bitdefender.com", "w2BnppLx5J5uy3ZE");
            return this;
        }

        //This method needs a parameter in a config file
        internal void GoTo()
        {
            var url = "https://portal.sandbox.use1.cwcmddev.cwnet.io/";
            Driver.Manage().Window.Maximize();
            Driver.Navigate().GoToUrl(url);
            _logger.Info($"Opened url => {url}");
        }

        //This method should return HomePage or LoginPageC
        public virtual WorkstationsAndServersPage LogIn(string username, string password)
        {
            SetEmailID(username);
            SetPassword(password);
            LoginClick();
            return this;
        }
        
        private WorkstationsAndServersPage SetEmailID(string username)
        {   
            EmailIDTextbox.SendKeys(username);
            return this;
        }

        private WorkstationsAndServersPage SetPassword(string password)
        {   
            PasswordTextbox.SendKeys(password);
            return this;
        }

        // We need a Click<HomePage>() method which supports type arguments
        private HomePage LoginClick()
        {
            LogInButton.Click();
            return new HomePage(Driver);
        }
    }
}
