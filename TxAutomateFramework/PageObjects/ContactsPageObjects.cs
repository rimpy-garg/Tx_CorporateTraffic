using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using GenericFramework.GenericMethod;
using GenericFramework.GenericTestCases;
using System;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;

namespace TxAutomateFramework.PageObjects
{
    public class ContactsPageObjects
    {
        IWebDriver webdr;
        GeneralMethods gms;
        BaseTest bt;
        log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        LeaseGeneralPageObjects lgp;

        public ContactsPageObjects()
        {
        }
        public ContactsPageObjects(IWebDriver dr)
        {
            PageFactory.InitElements(dr, this);
            gms = new GeneralMethods(dr);
            bt = new BaseTest(dr);
            webdr = dr;
            lgp = new LeaseGeneralPageObjects(dr);
        }
        #region
        //Landlord 'Edit' link      
        [FindsBy(How = How.XPath, Using = "//*[@id='divLandlord']/table/tbody/tr/td[4]/a[1]")]
        public IWebElement eEditLandLord;

        //Contact Record message        
        [FindsBy(How = How.XPath, Using = "//div[@class='LeaseLabel' and contains(text(), 'No Contact Specified - ')]")]
        public IWebElement eContactMessage;

        //Contact record edit link
        [FindsBy(How = How.Id, Using = "lnkEditContact")]
        public IWebElement eEditContact;

        //Edit link on Tenant section        
        [FindsBy(How = How.XPath, Using = "//*[@id='divTenant']/table/tbody/tr/td[4]/a[1]")]
        public IWebElement eEditTenant;

        //Edit link on Payor section
        [FindsBy(How = How.XPath, Using = "//*[@id='divPayor']/table/tbody/tr/td[4]/a[1]")]
        public IWebElement eEditPayor;

        //Frame add contact for Landlord
        [FindsBy(How = How.Id, Using = "iframeManageLeaseParty")]
        public IWebElement eFrameAddContact;

        //First name add Contact
        [FindsBy(How = How.Id, Using = "tbFirstName")]
        public IWebElement eFName;

        //Add Contact Last Name
        [FindsBy(How = How.Id, Using = "tbLastName")]
        public IWebElement eLName;

        //Job Title - General Manager
        [FindsBy(How = How.Id, Using = "txtTitle")]
        public IWebElement eJobTitle;

        //Company Name - AA Corporation
        [FindsBy(How = How.Id, Using = "tbCompany")]
        public IWebElement eCompany;

        //Street - 1 Main Street
        [FindsBy(How = How.Id, Using = "tbAddress")]
        public IWebElement eStreet;

        //Town - Woodbridge
        [FindsBy(How = How.Id, Using = "tbCity")]
        public IWebElement eCity;

        //State - NJ //*[@id=""]
        [FindsBy(How = How.Id, Using = "selectState")]
        public IWebElement eState;

        //Pin - 07095
        [FindsBy(How = How.Id, Using = "tbZipCode")]
        public IWebElement eZip;

        //County - United States
        [FindsBy(How = How.Id, Using = "selectCountry")]
        public IWebElement eCountry;

        //Phone - 732-111-1111
        [FindsBy(How = How.Id, Using = "tbPhone")]
        public IWebElement ePhone;

        //Email Address - mzubair @aa.com
        [FindsBy(How = How.Id, Using = "txtEmail")]
        public IWebElement eEmail;

        //Contact Type - Person
        [FindsBy(How = How.Id, Using = "rdoSearchPerson")]
        public IWebElement eContactTypePerson;

        //Contact Type - Company
        [FindsBy(How = How.Id, Using = "rdoSearchCompany")]
        public IWebElement eContactTypeCompany;

        //Payee Type - Landlord
        [FindsBy(How = How.Id, Using = "selectPayeeType")]
        public IWebElement ePayeeType;

        //Vendor Number - 1211
        [FindsBy(How = How.Id, Using = "tbVendorNumber")]
        public IWebElement eVendorNumber;

        //Fed ID - 35-2521520
        [FindsBy(How = How.Id, Using = "tbFedIDNum")]
        public IWebElement eFedID;

        //Tax code        
        [FindsBy(How = How.Id, Using = "tbTaxCode")]
        public IWebElement eTaxCode;

        //Corporation Number - 665120
        [FindsBy(How = How.Id, Using = "tbCorpNum")]
        public IWebElement eCorpNumber;

        //Payee Site - 101
        [FindsBy(How = How.Id, Using = "tbSiteNum")]
        public IWebElement eSiteNumber;

        //Payment Method - Check
        [FindsBy(How = How.Id, Using = "selectPaymentMethod")]
        public IWebElement ePaymentMethod;

        //Bank Code - 02513652
        [FindsBy(How = How.Id, Using = "tbBankCode")]
        public IWebElement eBankCode;

        //Save Contact
        [FindsBy(How = How.Id, Using = "btnSaveContact")]
        public IWebElement eSaveContact;

        //Message Save conatact successfully
        [FindsBy(How = How.XPath, Using = "//*[@id='noty_1422113267004504800']/div/span")]
        public IWebElement eSaveSuccessMsg;

        //Save button on add contact
        [FindsBy(How = How.XPath, Using = "//div[@id='divManageLeaseParty']/following-sibling::div[@class='ui-dialog-buttonpane ui-widget-content ui-helper-clearfix']//child::button[text()='Save']")]
        public IWebElement eSaveLandLord;

        //Copy to payee link
        [FindsBy(How = How.XPath, Using = "//*[@id='divLandlord']/table/tbody/tr/td[4]/a[2]")]
        public IWebElement eCopyToPayeelnk;

        //Error message for Copy to Payee        
        [FindsBy(How = How.XPath, Using = "//div[@class='noty_message']/span")]
        public IWebElement eErrMsgCopyToPayee;

        

        #endregion

        //Click on 'Edit' link to add new contact
        public void ClickEditLink_Landlord()
        {
            try
            {
                eEditLandLord.Click();
                log.Info("Clicked on Landlord 'Edit' link");
            }
            catch (Exception ex)
            {
                log.Info("Edit link not clicked on Landlord section");
                Assert.Fail("Edit link  not clicked on Landlord section");
            }
        }

        public void ClickEditLink_Tenant()
        {
            try
            {
                eEditTenant.Click();
                log.Info("Clicked on Tenant 'Edit' link");
            }
            catch (Exception ex)
            {
                log.Info("Edit link not clicked on Tenant section");
                Assert.Fail("Edit link  not clicked on Tenant section");
            }
        }

        public void ClickEditLink_Payor()
        {
            try
            {
                eEditPayor.Click();
                log.Info("Clicked on Payor 'Edit' link");
            }
            catch (Exception ex)
            {
                log.Info("Edit link not clicked on Payor section");
                Assert.Fail("Edit link  not clicked on Payor section");
            }
        }
        public void VerifyContactMessage()
        {
            try
            {
                //Verify No contacts message
                webdr.SwitchTo().Frame(eFrameAddContact);
                if (eContactMessage.Displayed)
                {
                    log.Info("No contacts message displayed");
                }
            }
            catch (Exception ex)
            {
                log.Info("Message not displayed");
                Assert.Fail("Message not displayed" + ex);
            }

        }

        public void ClickEditAndEnterContactDetails(string FirstName, string LastName, string JobTitle, string CompanyName, string Street, string Town, string State, string Pin,
                                                    string Country, string Phone, string EmailAddress, string PayeeType, string VendorNumber, string FedID, string TaxCode, string CorporationNumber,
                                                    string PayeeSite, string PaymentMethod, string BankCode)
        {
            try
            {
                //Click on 'Edit' link to add landlord details
                eEditContact.Click();
                gms.threadWait(1000);
                eFName.SendKeys(FirstName);
                gms.GetSetValue("FIRST_NAME", FirstName);
                eLName.SendKeys(LastName);
                gms.GetSetValue("LAST_NAME", LastName);
                eJobTitle.SendKeys(JobTitle);
                gms.GetSetValue("JOB_TITLE", JobTitle);
                eCompany.SendKeys(CompanyName);
                gms.GetSetValue("COMPANY_NAME", CompanyName);
                eStreet.SendKeys(Street);
                eCity.SendKeys(Town);
                gms.selectValueFromDropdownByText(eState, State);
                eZip.SendKeys(Pin);
                gms.selectValueFromDropdownByText(eCountry, Country);
                ePhone.SendKeys(Phone);
                gms.GetSetValue("PHONE_NUMBER", Phone);
                eEmail.SendKeys(EmailAddress);
                gms.GetSetValue("EMAIL_ID", EmailAddress);
                eContactTypePerson.Click();
                gms.selectValueFromDropdownByText(ePayeeType, PayeeType);
                eVendorNumber.SendKeys(VendorNumber);
                eFedID.SendKeys(FedID);
                eTaxCode.SendKeys(TaxCode);
                eCorpNumber.SendKeys(CorporationNumber);
                ePayeeType.SendKeys(PayeeSite);
                gms.selectValueFromDropdownByText(ePaymentMethod, PaymentMethod);
                eBankCode.SendKeys(BankCode);

            }
            catch (Exception ex)
            {
                log.Info("Failed while entered contact details");
                Assert.Fail("Failed while entered contact details" + ex);
            }


        }

        public void SaveContactDetails()
        {
            try
            {
                //Click 'Save' contact
                eSaveContact.Click();
                webdr.SwitchTo().DefaultContent();
                //verify 'Save Successful message
                // gms.threadWait(1000);
                //var wait = new WebDriverWait(this.webdr, TimeSpan.FromSeconds(2));
                //wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='noty_1422113267004504800']/div/span")));
                //bool bDisp = eSaveSuccessMsg.Displayed;
                //if (bDisp)
                //{
                //    log.Info("Save success message displayed");
                //}
                //else
                //{
                //    log.Info("Success message not displayed");
                //    Assert.Fail("Success message not displayed");
                //}

                //Click on on Save land lord
                eSaveLandLord.Click();
             
            }
            catch (Exception ex)
            {
                log.Info("Error while saving the data");
                Assert.Fail("Error while saving the data");

            }
        }

        public void ClickEditAndEnterTenantDetails(string CompanyName, string Street, string Town, string State, string Pin,
                                                   string Country, string Phone, string EmailAddress, string PayeeType, string VendorNumber, string FedID, string TaxCode, string CorporationNumber,
                                                   string PayeeSite, string PaymentMethod, string BankCode)
        {
            try
            {
                //Click on 'Edit' link to add landlord details
                eEditContact.Click();
                gms.threadWait(1000);
                eCompany.SendKeys(CompanyName);
                eStreet.SendKeys(Street);
                eCity.SendKeys(Town);
                gms.selectValueFromDropdownByText(eState, State);
                eZip.SendKeys(Pin);
                gms.selectValueFromDropdownByText(eCountry, Country);
                ePhone.SendKeys(Phone);
                eEmail.SendKeys(EmailAddress);
                eContactTypeCompany.Click();
                gms.selectValueFromDropdownByText(ePayeeType, PayeeType);
                eVendorNumber.SendKeys(VendorNumber);
                eFedID.SendKeys(FedID);
                eTaxCode.SendKeys(TaxCode);
                eCorpNumber.SendKeys(CorporationNumber);
                ePayeeType.SendKeys(PayeeSite);
                gms.selectValueFromDropdownByText(ePaymentMethod, PaymentMethod);
                eBankCode.SendKeys(BankCode);

            }
            catch (Exception ex)
            {
                log.Info("Failed while entered contact details");
                Assert.Fail("Failed while entered contact details" + ex);
            }


        }

        public void ClickEditAndEnterPayorDetails(string CompanyName, string Street, string Town, string State, string Pin,
                                                  string Country, string Phone, string EmailAddress, string PayeeType, string VendorNumber, string FedID, string TaxCode, string CorporationNumber,
                                                  string PayeeSite, string PaymentMethod, string BankCode)
        {
            try
            {
                //Click on 'Edit' link to add landlord details
                eEditContact.Click();
                gms.threadWait(1000);
                eCompany.SendKeys(CompanyName);
                eStreet.SendKeys(Street);
                eCity.SendKeys(Town);
                gms.selectValueFromDropdownByText(eState, State);
                eZip.SendKeys(Pin);
                gms.selectValueFromDropdownByText(eCountry, Country);
                ePhone.SendKeys(Phone);
                eEmail.SendKeys(EmailAddress);
                eContactTypeCompany.Click();
                gms.selectValueFromDropdownByText(ePayeeType, PayeeType);
                eVendorNumber.SendKeys(VendorNumber);
                eFedID.SendKeys(FedID);
                eTaxCode.SendKeys(TaxCode);
                eCorpNumber.SendKeys(CorporationNumber);
                ePayeeType.SendKeys(PayeeSite);
                gms.selectValueFromDropdownByText(ePaymentMethod, PaymentMethod);
                eBankCode.SendKeys(BankCode);

            }
            catch (Exception ex)
            {
                log.Info("Failed while entered contact details");
                Assert.Fail("Failed while entered contact details" + ex);
            }


        }


        public void ClickOnCopyToPayee()
        {
            eCopyToPayeelnk.Click();
        }

        public void VeifyErrorMsgWhenClickOnCopyToPayee()
        {
            eCopyToPayeelnk.Click();
            gms.threadWait(1000);
            if(eErrMsgCopyToPayee.Displayed)
            {
                log.Info("Error message:The landlord is already in payee list");
            }
            else
            {
                log.Info("Error message not displayed");
                Assert.Fail("Error message not displayed");
            }


        }
    
    }
}