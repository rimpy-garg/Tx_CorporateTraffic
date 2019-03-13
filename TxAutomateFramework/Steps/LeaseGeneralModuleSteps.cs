using log4net;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;
using TxAutomateFramework.PageObjects;

namespace TxAutomateFramework.Steps
{
    [Binding]
    public class LeaseGeneralModuleSteps
    {
        public IWebDriver _driver;
        LeaseGeneralPageObjects lpo;
        CommonMethods com;
        HomePageObjects hpo;
        GeneralInformationEditPageObjects gip;

        private readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public LeaseGeneralModuleSteps(IWebDriver driver)
        {
            _driver = driver;
            com = new CommonMethods(driver);
            //driver = (IWebDriver)ScenarioContext.Current["driver"];
            lpo = new LeaseGeneralPageObjects(driver);
            hpo = new HomePageObjects(driver);
            gip = new GeneralInformationEditPageObjects(driver);
        }

        [Given(@"Login to application (.*) and (.*)")]
        public void GivenLoginToApplication(string text, string text2)
        {
            try
            {                
                com.GivenEnterUserName(text);
                com.GivenEnterPassword(text2);
                com.WhenClickLoginButton();
                com.ThenHomePageShouldBeDisplayed();
                log.Info("Login to Application");
            }
            catch(Exception ex)
            {
                
                log.Error("Login not successfull" + ex);
            }
        }

        [Given(@"I Navigate to Lease -> New page")]
        public void GivenINavigateToLease_NewPage()
        {
            try
            {
                lpo.clickOnNewLease();
                log.Info("Navigate to New Lease page");
            }
            catch(Exception ex)
            {
                log.Error("New lease page not displayed" + ex);
            }
        }

        [Then(@"I entered all the mandatory information for creating new lease form (.*) and (.*) and (.*) and (.*) and (.*) and (.*) and (.*) and (.*) and (.*) and (.*) and (.*) and (.*) and (.*) and (.*) and (.*) and (.*) and (.*)")]
        public void ThenIEnteredAllTheMandatoryInformationForCreatingNewLeaseForm(string strRcrdType, string strClassification, string strBrand, string strPropType, string StrStreetName, string strTown, string strState, string strPIN, string strCountry, string strOrganization, string strRegion, string strGrpName, string strOwnerType, string strRentType, string strArea, string strMesrmtArea, string strLandUnit)
        {
            try
            {                
                log.Info("Enter Record ID");
                lpo.EnterRecordID();
                log.Info("Select Record Type");
                lpo.SelectRecordType(strRcrdType);
                log.Info("Select Classification");
                lpo.SelectClassification(strClassification);
                log.Info("Select Brand");
                lpo.SelectBrand(strBrand);
                log.Info("Enter Original Start Date");
                lpo.EnterOriginalStartDate();
                log.Info("Select Property Type");
                lpo.SelectPropertyType(strPropType);
                log.Info("Enter Start Date");
                lpo.EnterStartDate();
                log.Info("Enter Address : Street Name, Town, State PIN and Country");
                lpo.EnterAddress(StrStreetName, strTown, strState, strPIN, strCountry);
                log.Info("Select Organization");
                lpo.SelectOrganization(strOrganization);
                log.Info("Select Region");
                lpo.SelectRegion(strRegion);
                log.Info("Select Group Name");
                lpo.SelectGroup(strGrpName);
                log.Info("Select Owner Type");
                lpo.SelectOwnerType(strOwnerType);
                log.Info("Enter End Date");
                lpo.EnterEndDate();
                log.Info("Select Rent Type");
                lpo.SelectRentType(strRentType);
                log.Info("Enter Rentable Area");
                lpo.EnterRentableArea(strArea);
                log.Info("Select Measurment Area");
                lpo.SelectMeasurementArea(strMesrmtArea);
                log.Info("Select Land Unit");
                lpo.SelectLandUnit(strLandUnit);

            }
            catch(Exception ex)
            {
                log.Error("Error while entering the data for New Lease" + ex);

            }
            

        }

        [When(@"I press Save and Create Lease button")]
        public void WhenIPressSaveAndCreateLeaseButton()
        {
            try
            {
                lpo.ClickSaveCreateLease();
                log.Info("Clicked on Save and Create Lease button");
            }
            catch(Exception ex)
            {
                log.Error("Save and Create Lease button not clicked" + ex);
            }
            
        }
        
        [Then(@"The default page of lease should be displayed")]
        public void ThenTheDefaultPageOfLeaseShouldBeDisplayed()
        {

            lpo.VerifyLeaseDafaultPageDisplayed();
        }

        [Then(@"I do logout from application")]
        public void ThenIDoLogoutFromApplication()
        {
            try
            {
                com.GivenILogoutFromTheApplication();
                log.Info("Logout from application");
                
            }
            catch(Exception ex)
            {
                log.Error("Error in logout" + ex);
            }
        }

        [Then(@"Enter record id in Search box and click on EditAll link")]
        public void ThenEnterRecordIdInSearchBoxAndClickEditAllLink()
        {
            hpo.SearchRecordID();             
            hpo.ClickEditLease();
        }

        [Then(@"Verify all data in the form  (.*) and (.*) and (.*) and (.*) and (.*) and (.*) and (.*) and (.*)")]
        public void ThenVerifyAllDataInTheForm(string strRcrdType, string strClassification, string strBrand, string strOrganization, string strRegion, string strGrpName, string strOwnerType, string strRentType)
        {
            gip.VerifyRecordType(strRcrdType);
            gip.VerifyClassification(strClassification);
            gip.VerifyBrand(strBrand);
            gip.VerifyOrganization(strOrganization);
            gip.VerifyRegion(strRegion);
            gip.VerifyGroup(strGrpName);
            gip.VerifyOwnerType(strOwnerType);
            gip.VerifyRentType(strRentType);

        }


        [Then(@"User updates Location section (.*) and (.*) and (.*) and (.*) and (.*)")]
        public void ThenUserUpdatesLocationSection(string strBuildName, string strYear, string strCounty, string strSuite, string strFloor)
        {
            gip.UserUpdatesLocation(strBuildName, strYear, strCounty, strSuite, strFloor);
        }

        [Then(@"User updates Date section")]
        public void ThenUserUpdatesDateSection()
        {
            gip.UserUpdatesDateSection();
        }

        [Then(@"User Updates Area section (.*), (.*), (.*)")]
        public void ThenUserUpdatesAreaSection(string strUsable, string strLand, string strAreaCust)
        {
            gip.UserUpdatesAreaSection(strUsable, strLand, strAreaCust);
        }

        [Then(@"Click Save and Return button")]
        public void ThenClickSaveAndReturnButton()
        {
            gip.ClickSaveButton();
        }





    }
}
