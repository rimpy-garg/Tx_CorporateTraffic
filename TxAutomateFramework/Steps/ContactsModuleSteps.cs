using log4net;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;
using TxAutomateFramework.PageObjects;

namespace TxAutomateFramework.Steps
{
    [Binding]
    public class ContactsModuleSteps
    {
        public IWebDriver _driver;
        LeaseGeneralPageObjects lpo;
        CommonMethods com;
        HomePageObjects hpo;
        GeneralInformationEditPageObjects gip;
        ContactsPageObjects cpo;
        FinancialsPageObjects fpo;

        private readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public ContactsModuleSteps(IWebDriver driver)
        {
            _driver = driver;
            com = new CommonMethods(driver);
            lpo = new LeaseGeneralPageObjects(driver);
            hpo = new HomePageObjects(driver);
            gip = new GeneralInformationEditPageObjects(driver);
            cpo = new ContactsPageObjects(driver);
            fpo = new FinancialsPageObjects(driver);
        }

        [Then(@"Enter record id in Search box and select the lease")]
        public void ThenEnterRecordIdInSearchBoxAndSelectTheLease()
        {
            hpo.SearchRecordID();
        }

        [Then(@"Select contacts tab and click on Edit for land lord section")]
        public void ThenSelectContactsTabAndClickOnEditForLandLordSection()
        {
            lpo.ClickOnContactsTab();
            cpo.ClickEditLink_Landlord();

        }

        [Then(@"Select contacts tab and click on Edit for Tenant section")]
        public void ThenSelectContactsTabAndClickOnEditForTenantSection()
        {
            lpo.ClickOnContactsTab();
            cpo.ClickEditLink_Tenant();
        }

        [Then(@"Select Contacts tab")]
        public void ThenSelectContactsTab()
        {
            lpo.ClickOnContactsTab();
        }


        [Then(@"Verify the message No contacts specified in contacts section")]
        public void ThenVerifyTheMessageNoContactsSpecifiedInContactsSection()
        {
            cpo.VerifyContactMessage();
        }

        [Then(@"User Enters valid data (.*) and (.*) and (.*) and (.*) and (.*) and (.*) and (.*) and (.*) and (.*) and (.*) and (.*) and (.*) and (.*) and (.*) and (.*) and (.*) and (.*) and (.*) and (.*)")]
        public void ThenUserEntersValidData(string FirstName, string LastName, string JobTitle, string CompanyName, string Street, string Town, string State, string Pin,
                                                    string Country, string Phone, string EmailAddress, string PayeeType, string VendorNumber, string FedID, string TaxCode, string CorporationNumber,
                                                    string PayeeSite, string PaymentMethod, string BankCode)
        {
            cpo.ClickEditAndEnterContactDetails(FirstName, LastName, JobTitle, CompanyName, Street, Town, State, Pin, Country, Phone, EmailAddress, PayeeType, VendorNumber, FedID, TaxCode, CorporationNumber, PayeeSite, PaymentMethod, BankCode);
        }

        [Then(@"Select save contacts and verify the message Contact saved successfully")]
        public void ThenSelectSaveContactsAndVerifyTheMessageContactSavedSuccessfully()
        {
            cpo.SaveContactDetails();
        }

        [Then(@"User Eners valid data for Tenant(.*) and (.*) and (.*) and (.*) and (.*) and (.*) and (.*) and (.*) and (.*) and (.*) and (.*) and (.*) and (.*) and (.*) and (.*) and (.*)")]
        public void ThenUserEnersValidDataForTenant(string CompanyName, string Street, string Town, string State, string Pin, string Country, string Phone, string EmailAddress,
                                                     string PayeeType, string VendorNumber, string FedID, string TaxCode, string CorporationNumber,
                                                    string PayeeSite, string PaymentMethod, string BankCode)
        {
            cpo.ClickEditAndEnterTenantDetails(CompanyName, Street, Town, State, Pin, Country, Phone, EmailAddress, PayeeType, VendorNumber, FedID, TaxCode, CorporationNumber, PayeeSite, PaymentMethod, BankCode);
        }

        [Then(@"Select Contacts tab and click on Edit for Payor section")]
        public void ThenSelectContactsTabAndClickOnEditForPayorSection()
        {
            lpo.ClickOnContactsTab();
            cpo.ClickEditLink_Payor();

        }

        [Then(@"User Enters valid data for Payor (.*) and (.*) and (.*) and (.*) and (.*) and (.*) and (.*) and (.*) and (.*) and (.*) and (.*) and (.*) and (.*) and (.*) and (.*) and (.*)")]
        public void ThenUserEntersValidDataForPayor(string CompanyName, string Street, string Town, string State, string Pin, string Country, string Phone, 
                                                    string EmailAddress, string PayeeType, string VendorNumber, string FedID, string TaxCode, string CorporationNumber,
                                                    string PayeeSite, string PaymentMethod, string BankCode)
        {
            cpo.ClickEditAndEnterPayorDetails(CompanyName, Street, Town, State, Pin, Country, Phone, EmailAddress, PayeeType, VendorNumber, FedID, TaxCode, CorporationNumber, PayeeSite, PaymentMethod, BankCode);
        }

        [Then(@"Click on Copy to Payee link in Landlord section")]
        public void ThenClickOnCopyToPayeeLinkInLandlordSection()
        {
            cpo.ClickOnCopyToPayee();
        }

      
        //[Then(@"Click on Financials tab and verify the Payee details (.*) and (.*) and (.*) and (.*)and (.*) and (.*)")]
        //public void ThenClickOnFinancialsTabAndVerifyThePayeeDetails()
        //{
        //    lpo.ClickOnFinancialsTab();
        //    fpo.verifyPayeeDetails();
        //}

        [Then(@"Click on Financials tab and verify the Payee details")]
        public void ThenClickOnFinancialsTabAndVerifyThePayeeDetails()
        {
            lpo.ClickOnFinancialsTab();
            fpo.verifyPayeeDetails();
        }

        [Then(@"Click on Contacts tab")]
        public void ThenClickOnContactsTab()
        {
            lpo.ClickOnContactsTab();
        }

        [Then(@"Click on Copy to Payee link and verify the error message")]
        public void ThenClickOnCopyToPayeeLinkAndVerifyTheErrorMessage()
        {
            cpo.VeifyErrorMsgWhenClickOnCopyToPayee();
        }


    }
}
