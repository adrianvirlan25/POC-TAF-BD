using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MySampleFramework
{
    [TestClass]
    [TestCategory("SyncAndMapping")]
    public class SampleApplicationOneTests : BaseTest
    {
        internal TestUser TheTestUser { get; private set; }
        internal TestUser EmergencyContactUser { get; private set; }
        internal SampleApplicationPage SampleAppPage { get; private set; }


        [TestMethod]
        [Description("Validate that user is able to fill out form successfully using valid data.")]
        public void Fill_Form_And_Submit_Retreives_UltimateQAPage()
        {
            SampleAppPage = new SampleApplicationPage(Driver);
            TheTestUser = new TestUser
            {
                FirstName = "Sarah",
                LastName = "Jones"
            };
            EmergencyContactUser = new TestUser
            {
                FirstName = "Ronald",
                LastName = "McDonald"
            };

            TheTestUser.GenderType = Gender.Female;

            SampleAppPage.GoTo();
            SampleAppPage.FillOutEmergencyContactForm(EmergencyContactUser);
            var ultimateQAHomePage = SampleAppPage.FillOutPrimaryContactFormAndSubmit(TheTestUser);
            AssertPageVisible(ultimateQAHomePage);
        }

        [TestMethod]
        [Description("Fake 2-nd test")]
        public void Test2()
        {
            SampleAppPage.GoTo();

            SampleAppPage.FillOutEmergencyContactForm(EmergencyContactUser);
            var ultimateQAHomePage = SampleAppPage.FillOutPrimaryContactFormAndSubmit(TheTestUser);
            AssertPageVisible(ultimateQAHomePage);
        }

        [TestMethod]
        [TestProperty("Author", "AdrianVirlan")]
        [Description("Validate that the form can be sucessfully submitted")]
        public void TCID3()
        {
            SampleAppPage.GoTo();
            TheTestUser.GenderType = Gender.Other;

            SampleAppPage.FillOutEmergencyContactForm(EmergencyContactUser);
            var ultimateQAHomePage = SampleAppPage.FillOutPrimaryContactFormAndSubmit(TheTestUser);
            AssertPageVisible(ultimateQAHomePage);
        }

        private static void AssertPageVisible(UltimateQAHomePage ultimateQAHomePage)
        {
            Assert.IsTrue(ultimateQAHomePage.IsVisible,
                            $"{ultimateQAHomePage} was not visible.");
        }
    }
}
