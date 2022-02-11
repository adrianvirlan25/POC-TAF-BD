using AutomationPractice.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AutomationPractice.Tests
{
    [TestClass]
    public class UnitTest1 : BaseTest
    {
        [TestMethod]
        [TestProperty("Product", "ConnectWiseSE")]
        [Description("Test_Connection_With_GZ)")]
        public void TCXXX_TestRail()
        {
            #region Arrange

            string gzApiKey = "91eeca59e779abf4df7c2ad67adf957d8229b3d382a7562e4352f537b9606643";
            string gzServer = "https://cloudgz.gravityzone.bitdefender.com/api";

            #endregion

            #region Act

            WorkstationsAndServersPage workstationsAndServers = new WorkstationsAndServersPage(Driver);
            workstationsAndServers.LoginCWSE();

            IntegrationsPage integrationsPage = workstationsAndServers.LeftMenuClickIntegrations();

            BitdefenderCloudSecurityForMSPPage bitdefenderCloudSecurityForMSPPage = integrationsPage.ClickProductName();
            bitdefenderCloudSecurityForMSPPage.SetGZAPIKey(gzApiKey);
            bitdefenderCloudSecurityForMSPPage.SetGZServer(gzServer);
            bitdefenderCloudSecurityForMSPPage.TestConnectionClick();

            Assert.AreEqual("Connection established", bitdefenderCloudSecurityForMSPPage.ConnectionStatus);

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
