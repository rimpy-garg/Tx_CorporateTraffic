using GenericFramework.GenericTestCases;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;
using TxAutomateFramework.PageObjects;

namespace TxAutomateFramework.Steps
{
    [Binding]
    public class RegisterSteps
    {
        public IWebDriver _driver;
        RegisterPage reg;
        public RegisterSteps(IWebDriver driver)
        {
            _driver = driver;
            //driver =(IWebDriver) ScenarioContext.Current["driver"];
        }
        [Given(@"navigate to register link")]
        public void GivenNavigateToRegisterLink()
        {
            reg = new RegisterPage(_driver);
            reg.ClickRegisterLink();
        }

        [Given(@"Enter Profile Name (.*)")]
        public void GivenEnterProfileName(string strProfileName)
        {
            reg.EnterProfileName(strProfileName);
        }

        [Given(@"Enter Password (.*)")]
        public void GivenEnterPassword(string strPassword)
        {
            reg.EnterPassword(strPassword);
        }
        [Given(@"Enter PasswordConfirm (.*)")]
        public void GivenEnterPasswordConfirm(string p0)
        {
            reg.EnterConPassword(p0);
        }

        [Given(@"Enter PasswordHint (.*)")]
        public void GivenEnterPasswordHint(string p0)
        {
            reg.EnterPasswordHint(p0);
        }
        [Given(@"Enter First Name (.*)")]
        public void GivenEnterFirstName(string p0)
        {
            reg.EnterFirstName(p0);
        }

        [Given(@"Enter Last Name (.*)")]
        public void GivenEnterLastName(string p0)
        {
            reg.EnterLastName(p0);
        }

        [Given(@"Enter Street Address (.*)")]
        public void GivenEnterStreetAddress(string p0)
        {
            reg.EnterAddress(p0);
        }

        [Given(@"Enter City (.*)")]
        public void GivenEnterCity(string p0)
        {
            reg.EnterCity(p0);
        }
        [Given(@"Enter State (.*)")]
        public void GivenEnterState(string p0)
        {
            reg.EnterState(p0);
        }

        [Given(@"Enter Zip Code (.*)")]
        public void GivenEnterZipCode(string p0)
        {
            reg.EnterZip(p0);
        }

        [Given(@"Enter Office Phone1 (.*)")]
        public void GivenEnterOfficePhone(string p1)
        {
            reg.EnterOfficePhone(p1);
        }

        [Given(@"Enter Company Name (.*)")]
        public void GivenEnterCompanyName(string p0)
        {
            reg.EnterCompanyName(p0);
        }

        [Given(@"Enter Email (.*)")]
        public void GivenEnterEmail(string p0)
        {
            reg.EnterEmail(p0);
        }

        [Then(@"click on save")]
        public void ThenClickOnSave()
        {
            reg.SaveButton();
        }

        [Then(@"verify registration")]
        public void ThenVerifyRegistration()
        {
            reg.verifyRegistration();
        }

    }
}
