using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using TxAutomateFramework.PageObjects;

namespace TxAutomateFramework.Steps
{
    [Binding]
    class LoginSteps
    {
        public IWebDriver _driver;
        LoginPage loginPage;

        public LoginSteps(IWebDriver driver)
        {
            _driver = driver;
        }

        [Given(@"Enter Existed Profile Name (.*)")]
        public void GivenEnterUserName(string userName)
        {
            loginPage = new LoginPage(_driver);
            loginPage.EnterProfileName(userName);
        }

        [Given(@"Enter Existed user password (.*)")]
        public void GivenEnterUserPassword(string userPassword)
        {
            loginPage.EnterPassword(userPassword);
        }

        [When(@"User click on login")]
        public void WhenUserClickOnLogin()
        {
            loginPage.ClickLoginButton();
        }

        [Then(@"Verify login")]
        public void ThenVerifyLogin()
        {
            loginPage.verifyLogin();
        }
    }
}
