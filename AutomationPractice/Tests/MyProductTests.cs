using AutomationPractice.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AutomationPractice.Tests
{
    [TestClass]
    public class MyProductTests : BaseTest
    {
        [TestMethod]
        [TestProperty("Product", "MyProduct")]
        [Description("Test_Connection_With_GZ)")]
        public void TCXXX_TestRail()
        {
            #region Arrange

            string gzApiKey = "123456APIKEY";
            string gzServer = "https://myWebsite.com/api";

            #endregion

            #region Act

            WorkstationsAndServersPage workstationsAndServers = new WorkstationsAndServersPage(Driver);
            workstationsAndServers.LoginCWSE();

            IntegrationsPage integrationsPage = workstationsAndServers.LeftMenuClickIntegrations();

            BitdefenderCloudSecurityForMSPPage bcsMSPPage = integrationsPage.ClickProductName();
            bcsMSPPage.SetGZAPIKey(gzApiKey);
            bcsMSPPage.SetGZServer(gzServer);
            bcsMSPPage.TestConnectionClick();

            Assert.AreEqual("Connection established", bcsMSPPage.ConnectionStatus);

            #endregion
        }

        [TestMethod]
        [TestProperty("Author", "AVI")]
        [Description("Interact With Slider")]
        public void Interact_With_Slider()
        {
            HomePage homePage = new HomePage(Driver);
            homePage.GoTo();
            var currentImage = homePage.Slider.CurrentImage;
            homePage.Slider.ClickNextButton();            

            Assert.AreNotEqual(currentImage, homePage.Slider.CurrentImage,
                "The slider images did not change when pressing the next button.");
        }
    }
}
