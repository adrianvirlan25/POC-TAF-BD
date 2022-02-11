using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AutomationPractice.Tests
{
    [TestClass]
    [TestCategory("ContactUsPage"), TestCategory("SampleApp2")]
    public class ContactUsFeature : BaseTest
    {
        [TestMethod]
        [TestProperty("Author", "AVI")]
        [Description("Validate that the contact us page opens successfully with a form.")]
        public void TCID2()
        {
            ContactUsPage contactUsPage = new ContactUsPage(Driver);
            contactUsPage.GoTo();
            Assert.IsTrue(contactUsPage.IsLoaded,
                "The contact us page did not open successfully.");
        }
    }
}
