using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;

namespace MySampleFramework
{
    internal class SampleApplicationPage : BaseSampleApplicationPage
    {
        public SampleApplicationPage(IWebDriver driver) : base(driver) { }

        public bool IsVisible
        {
            get
            {
                return Driver.Title.Contains(PageTitle);
            }
            internal set { }
        }

        private string PageTitle => "Sample Application Lifecycle - Sprint";

        IWebElement FirstNameField => Driver.FindElement(By.XPath("//*[@name='firstname']"));

        IWebElement SubmitButton => Driver.FindElement(By.XPath("//*[@type='submit']"));

        IWebElement LastNameField => Driver.FindElement(By.XPath("//*[@name='lastname']"));

        public IWebElement FemaleGenderRadioButton => Driver.FindElement(By.XPath("//input[@value='female']"));

        public IWebElement OtherGenderRadioButton => Driver.FindElement(By.XPath("//input[@value='other']"));

        public IWebElement FemaleGenderForEmergencyContactRadioButton => Driver.FindElement(By.Id("radio2-f"));

        public IWebElement FirstNameForEmergencyContactField => Driver.FindElement(By.Id("f2"));

        public IWebElement LastNameForEmergencyContactField => Driver.FindElement(By.Id("l2"));

        internal void GoTo()
        {
            Driver.Navigate().GoToUrl("https://ultimateqa.com/sample-application-lifecycle-sprint-4/");
            Assert.IsTrue(IsVisible, $"Found {Driver.Title} web page. Expected {PageTitle} web page.");
        }

        internal UltimateQAHomePage FillOutPrimaryContactFormAndSubmit(TestUser user)
        {
            SetGender(user);
            FirstNameField.SendKeys(user.FirstName);
            LastNameField.SendKeys(user.LastName);
            SubmitButton.Submit();
            return new UltimateQAHomePage(Driver);
        }

        internal void FillOutEmergencyContactForm(TestUser emergencyContactUser)
        {
            SetGenderForEmergencyContact(emergencyContactUser);
            FirstNameForEmergencyContactField.SendKeys(emergencyContactUser.FirstName);
            LastNameForEmergencyContactField.SendKeys(emergencyContactUser.LastName);
        }

        private void SetGender(TestUser user)
        {
            switch (user.GenderType)
            {
                case Gender.Male:
                    break;
                case Gender.Female:
                    FemaleGenderRadioButton.Click();
                    break;
                case Gender.Other:
                    OtherGenderRadioButton.Click();
                    break;
                default:
                    break;
            }
        }

        private void SetGenderForEmergencyContact(TestUser user)
        {
            switch (user.GenderType)
            {
                case Gender.Male:
                    break;
                case Gender.Female:
                    FemaleGenderForEmergencyContactRadioButton.Click();
                    break;
                case Gender.Other:
                    break;
                default:
                    break;
            }
        }
    }
}