using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using GenericFramework.GenericMethod;
using NUnit.Framework;
using GenericFramework.Enum;
using GenericFramework.ExtentReport;
using GenericFramework.GenericTestCases;

namespace TxAutomateFramework.PageObjects
{
    class RegisterPage
    {
        GeneralMethods objmethod;
        BaseTest bt;
        private static string statename;
        log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public RegisterPage()
        {
        }
        public RegisterPage(IWebDriver dr)
        {
            PageFactory.InitElements(dr, this);
            objmethod = new GeneralMethods(dr);
            bt = new BaseTest(dr);
            GeneralMethods.lst_detail = new List<string>();
        }
        #region elements

        [FindsBy(How = How.XPath, Using = "//a[text()='Register']")]
        public IWebElement register;
        
        [FindsBy(How = How.Id, Using = "profile_name")]
        public IWebElement profilename;

        [FindsBy(How = How.Id, Using = "profile_password")]
        public IWebElement profilepassword;

        [FindsBy(How = How.Id, Using = "profile_password_again")]
        public IWebElement profileConpassword;

        [FindsBy(How = How.Name, Using = "PasswordHint")]
        public IWebElement PasswordHint;

        [FindsBy(How = How.Name, Using = "FirstName")]
        public IWebElement FirstName;

        [FindsBy(How = How.Name, Using = "LastName")]
        public IWebElement LastName;

        [FindsBy(How = How.Name, Using = "Address")]
        public IWebElement Address;

        [FindsBy(How = How.Name, Using = "City")]
        public IWebElement City;

        [FindsBy(How = How.XPath, Using = "//label[contains(text(),'State')]/../span")]
        public IWebElement dropdown_state;

        [FindsBy(How = How.XPath, Using = "//li[text()='Alaska']")]
        public IWebElement state;

        [FindsBy(How = How.Name, Using = "Zip")]
        public IWebElement Zip; 

        [FindsBy(How = How.Name, Using = "OfficePhone1")]
        public IWebElement OfficePhone;

        [FindsBy(How = How.Name, Using = "CompanyName")]
        public IWebElement CompanyName;

        [FindsBy(How = How.Name, Using = "Email1")]
        public IWebElement Email1;

        [FindsBy(How = How.Id, Using = "save_button")]
        public IWebElement Save;

        [FindsBy(How = How.XPath, Using = "//label[text()='Registration Successful']")]
        public IWebElement RegMsg;

        #endregion


        public void ClickRegisterLink()
        {
            try
            {
                //objmethod.lst_detail = new List<string>();
                objmethod.ClickOnElementWhenElementFound(register, System.Reflection.MethodBase.GetCurrentMethod().Name);
                objmethod.status = EnumClass.LogStatus.Passed;
                objmethod.MethodToAddDataInList("Click Register Link. ~ " + objmethod.status);
            }
            catch (Exception ex)
            {
                objmethod.status = EnumClass.LogStatus.Failed;
                objmethod.MethodToAddDataInList("Register Link not clicked. ~ " + objmethod.status + ex);
            }
        }

        public void EnterProfileName(string strProfileName)
        {
            try
            {
                Random ran = new Random();
                int num = ran.Next(1, 999);
               // Geb.lst_detail = new List<string>();
                objmethod.SendKeysForElement(profilename, strProfileName+num, System.Reflection.MethodBase.GetCurrentMethod().Name);
                objmethod.status = EnumClass.LogStatus.Passed;
                objmethod.MethodToAddDataInList("Entered profile name as " + strProfileName + ". ~ " + objmethod.status);
            }
            catch (Exception ex)
            {
                objmethod.status = EnumClass.LogStatus.Failed;
                objmethod.MethodToAddDataInList("Entered profile name is failed. ~ " + objmethod.status + ex);
            }
        }

        public void EnterPassword(string strPassword)
        {
            try
            {
               // objmethod.lst_detail = new List<string>();
                objmethod.SendKeysForElement(profilepassword, strPassword, System.Reflection.MethodBase.GetCurrentMethod().Name);
                objmethod.status = EnumClass.LogStatus.Passed;
                objmethod.MethodToAddDataInList("Entered Password as " + strPassword + ". ~ " + objmethod.status);
            }
            catch (Exception ex)
            {
                objmethod.status = EnumClass.LogStatus.Failed;
                objmethod.MethodToAddDataInList("Entered Password is failed. ~ " + objmethod.status + ex);
            }
        }

        public void EnterConPassword(string strConPassword)
        {
            try
            {
                //objmethod.lst_detail = new List<string>();
                objmethod.ImplicitWait(2);
                objmethod.SendKeysForElement(profileConpassword, strConPassword, System.Reflection.MethodBase.GetCurrentMethod().Name);
                objmethod.status = EnumClass.LogStatus.Passed;
                objmethod.MethodToAddDataInList("Entered confirm Password as " + strConPassword + ". ~ " + objmethod.status);
            }
            catch (Exception ex)
            {
                objmethod.status = EnumClass.LogStatus.Failed;
                objmethod.MethodToAddDataInList("Entered confirm Password is failed. ~ " + objmethod.status + ex);
            }
        }

        public void EnterPasswordHint(string strPasswordHint)
        {
            try
            {
               // objmethod.lst_detail = new List<string>();
                objmethod.SendKeysForElement(PasswordHint, strPasswordHint, System.Reflection.MethodBase.GetCurrentMethod().Name);
                objmethod.status = EnumClass.LogStatus.Passed;
                objmethod.MethodToAddDataInList("Entered Password Hint as " + strPasswordHint + ". ~ " + objmethod.status);
            }
            catch (Exception ex)
            {
                objmethod.status = EnumClass.LogStatus.Failed;
                objmethod.MethodToAddDataInList("Entered PasswordHint is failed. ~ " + objmethod.status + ex);
            }
        }

        public void EnterFirstName(string strFirstName)
        {
            try
            {
               // objmethod.lst_detail = new List<string>();
                objmethod.SendKeysForElement(FirstName, strFirstName, System.Reflection.MethodBase.GetCurrentMethod().Name);
                objmethod.status = EnumClass.LogStatus.Passed;
                objmethod.MethodToAddDataInList("Entered First Name as " + strFirstName + ". ~ " + objmethod.status);
            }
            catch (Exception ex)
            {
                objmethod.status = EnumClass.LogStatus.Failed;
                objmethod.MethodToAddDataInList("Entered First Name is failed. ~ " + objmethod.status + ex);
            }
        }

        public void EnterLastName(string strLastName)
        {
            try
            {
               // objmethod.lst_detail = new List<string>();
                objmethod.SendKeysForElement(LastName, strLastName, System.Reflection.MethodBase.GetCurrentMethod().Name);
                objmethod.status = EnumClass.LogStatus.Passed;
                objmethod.MethodToAddDataInList("Entered Last Name as " + strLastName + ". ~ " + objmethod.status);
            }
            catch (Exception ex)
            {
                objmethod.status = EnumClass.LogStatus.Failed;
                objmethod.MethodToAddDataInList("Entered Last Name is failed. ~ " + objmethod.status + ex);
            }
        }

        public void EnterAddress(string strAddress)
        {
            try
            {
                //objmethod.lst_detail = new List<string>();
                objmethod.SendKeysForElement(Address, strAddress, System.Reflection.MethodBase.GetCurrentMethod().Name);
                objmethod.status = EnumClass.LogStatus.Passed;
                objmethod.MethodToAddDataInList("Entered Address as " + strAddress + ". ~ " + objmethod.status);
            }
            catch (Exception ex)
            {
                objmethod.status = EnumClass.LogStatus.Failed;
                objmethod.MethodToAddDataInList("Entered Address is failed. ~ " + objmethod.status + ex);
            }
        }

        public void EnterCity(string strCity)
        {
            try
            {
                //objmethod.lst_detail = new List<string>();
                objmethod.SendKeysForElement(City, strCity, System.Reflection.MethodBase.GetCurrentMethod().Name);
                objmethod.status = EnumClass.LogStatus.Passed;
                objmethod.MethodToAddDataInList("Entered City as " + strCity + ". ~ " + objmethod.status);
            }
            catch (Exception ex)
            {
                objmethod.status = EnumClass.LogStatus.Failed;
                objmethod.MethodToAddDataInList("Entered City is failed. ~ " + objmethod.status + ex);
            }
        }

        public void EnterState(string strState)
        {
            try
            {
                statename = strState;
               // objmethod.lst_detail = new List<string>();
                objmethod.ClickOnElementWhenElementFound(dropdown_state, System.Reflection.MethodBase.GetCurrentMethod().Name);
                System.Threading.Thread.Sleep(2000);
                objmethod.ClickOnElementWhenElementFound(state, System.Reflection.MethodBase.GetCurrentMethod().Name);
                objmethod.status = EnumClass.LogStatus.Passed;
                objmethod.MethodToAddDataInList("Entered State as " + strState + ". ~ " + objmethod.status);
            }
            catch (Exception ex)
            {
                objmethod.status = EnumClass.LogStatus.Failed;
                objmethod.MethodToAddDataInList("Entered State is failed. ~ " + objmethod.status + ex);
            }
        }

        public void EnterZip(string strZip)
        {
            try
            {
               // objmethod.lst_detail = new List<string>();
                objmethod.SendKeysForElement(Zip, strZip, System.Reflection.MethodBase.GetCurrentMethod().Name);
                objmethod.status = EnumClass.LogStatus.Passed;
                objmethod.MethodToAddDataInList("Entered Zip code as " + strZip+ ". ~ " + objmethod.status);
            }
            catch (Exception ex)
            {
                objmethod.status = EnumClass.LogStatus.Failed;
                objmethod.MethodToAddDataInList("Entered Zip code is failed. ~ " + objmethod.status + ex);
            }
        }

        public void EnterOfficePhone(string strOfficePhone)
        {
            try
            {
               // objmethod.lst_detail = new List<string>();
                objmethod.SendKeysForElement(OfficePhone, strOfficePhone, System.Reflection.MethodBase.GetCurrentMethod().Name);
                objmethod.status = EnumClass.LogStatus.Passed;
                objmethod.MethodToAddDataInList("Entered Office Phone as " + strOfficePhone + ". ~ " + objmethod.status);
            }
            catch (Exception ex)
            {
                objmethod.status = EnumClass.LogStatus.Failed;
                objmethod.MethodToAddDataInList("Entered Office Phone is failed. ~ " + objmethod.status + ex);
            }
        }

        public void EnterCompanyName(string strCompanyName)
        {
            try
            {
                //objmethod.lst_detail = new List<string>();
                objmethod.SendKeysForElement(CompanyName, strCompanyName, System.Reflection.MethodBase.GetCurrentMethod().Name);
                objmethod.status = EnumClass.LogStatus.Passed;
                objmethod.MethodToAddDataInList("Entered Company Name as " + strCompanyName + ". ~ " + objmethod.status);
            }
            catch (Exception ex)
            {
                objmethod.status = EnumClass.LogStatus.Failed;
                objmethod.MethodToAddDataInList("Entered Company Name is failed. ~ " + objmethod.status + ex);
            }
        }

        public void EnterEmail(string strEmail)
        {
            try
            {
               // objmethod.lst_detail = new List<string>();
                objmethod.SendKeysForElement(Email1, strEmail, System.Reflection.MethodBase.GetCurrentMethod().Name);
                objmethod.status = EnumClass.LogStatus.Passed;
                objmethod.MethodToAddDataInList("Entered Email as " + strEmail+ ". ~ " + objmethod.status);
            }
            catch (Exception ex)
            {
                objmethod.status = EnumClass.LogStatus.Failed;
                objmethod.MethodToAddDataInList("Entered Email is failed. ~ " + objmethod.status + ex);
            }
        }

        public void SaveButton()
        {
            try
            {
                //objmethod.lst_detail = new List<string>();
                objmethod.ClickOnElementWhenElementFound(Save, System.Reflection.MethodBase.GetCurrentMethod().Name);
                objmethod.status = EnumClass.LogStatus.Passed;
                objmethod.MethodToAddDataInList("Click on save button in register page. ~ " + objmethod.status);
            }
            catch (Exception ex)
            {
                objmethod.status = EnumClass.LogStatus.Failed;
                objmethod.MethodToAddDataInList("Did not click on save button in register page. ~ " + objmethod.status + ex);
            }
        }

        public void verifyRegistration()
        {
            try
            {
               // objmethod.lst_detail = new List<string>();
                objmethod.ClickOnElementWhenElementFound(RegMsg, System.Reflection.MethodBase.GetCurrentMethod().Name);
                bool flag = objmethod.IsElementPresent(RegMsg);
                if(flag==false)
                {
                    objmethod.status = EnumClass.LogStatus.Failed;
                    objmethod.MethodToAddDataInList("Registration is not Successed. ~ " + objmethod.status);
                }
                objmethod.status = EnumClass.LogStatus.Passed;
                objmethod.MethodToAddDataInList("Registration is Successed. ~ " + objmethod.status);
            }
            catch (Exception ex)
            {
                objmethod.status = EnumClass.LogStatus.Failed;
                objmethod.MethodToAddDataInList("Registration is not Successed. ~ " + objmethod.status + ex);
            }
        }

    }
}
