using OpenQA.Selenium;
using System;

namespace AutomationPractice.Pages
{
    public class BitdefenderCloudSecurityForMSPPage : BaseApplicationPage
    {
        private IWebElement GZAPIKeyTextbox => Driver.FindElement(By.Id("gzApiKey"));

        private IWebElement GZServerTextbox => Driver.FindElement(By.Id("gzServerAddress"));

        private IWebElement TestConnectionButton => Driver.FindElement(By.XPath("//*[@data-testid='bi-directional_test-connection']"));

        public string ConnectionStatus => Driver.FindElement(By.XPath("//*[@data-testid='connectionStatus']")).Text;

        public BitdefenderCloudSecurityForMSPPage(IWebDriver driver) : base(driver)
        {
            this.Driver = driver;
        }

        public virtual BitdefenderCloudSecurityForMSPPage SetGZAPIKey(string apiKey)
        {
            GZAPIKeyTextbox.SendKeys(apiKey);
            return this;
        }

        //Need to implement a mechanism which evaluates/clears the textbox value before filling the new value
        public virtual BitdefenderCloudSecurityForMSPPage SetGZServer(string gzServer)
        {
            if (GZServerTextbox.Text != null)
            {
                return this;
            }
            else
            {
                GZServerTextbox.SendKeys(gzServer);
                return this;
            }
        }

        public virtual BitdefenderCloudSecurityForMSPPage TestConnectionClick()
        {
            TestConnectionButton.Click();
            return this;
        }
    }
}
