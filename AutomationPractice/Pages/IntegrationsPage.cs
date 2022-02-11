using OpenQA.Selenium;

namespace AutomationPractice.Pages
{
    public class IntegrationsPage : BaseApplicationPage
    {
        public IntegrationsPage(IWebDriver driver) : base(driver)
        {
            this.Driver = driver;
        }
        
        public virtual BitdefenderCloudSecurityForMSPPage ClickProductName()
        {
            IWebElement hyperlink = Driver.FindElement(By.XPath("//*[@data-testid='product-name-cell']"));
            hyperlink.Click();
            return new BitdefenderCloudSecurityForMSPPage(Driver);
        }
    }
}