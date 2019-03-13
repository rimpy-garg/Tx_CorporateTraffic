using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using GenericFramework.GenericMethod;
using GenericFramework.GenericTestCases;
using GenericFramework.Enum;
using System.Collections.Generic;
using System;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;

namespace TxAutomateFramework.PageObjects
{
    public class GeneralInformationEditPageObjects
    {
        IWebDriver webdr;
        GeneralMethods gms;
        BaseTest bt;
        log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public GeneralInformationEditPageObjects()
        {
        }
        public GeneralInformationEditPageObjects(IWebDriver dr)
        {
            PageFactory.InitElements(dr, this);
            gms = new GeneralMethods(dr);
            bt = new BaseTest(dr);
            webdr = dr;
        }

        //Record ID
        [FindsBy(How = How.Id, Using = "txtLeaseID")]
        public IWebElement eRecordID;

        //Record Type       
        [FindsBy(How = How.XPath, Using = " //*[@id='ddlAssetClass']")]
        public IWebElement eRecordType;

        //Organization
        //*[@id="lblOrganizationText"]
        [FindsBy(How = How.Id, Using = "lblOrganizationText")]
        public IWebElement eOrganization;

        //Classification
        //*[@id="ddlClassifications"]
        [FindsBy(How = How.Id, Using = "ddlClassifications")]
        public IWebElement eClassification;

        //Region
        //*[@id="lblRegionText"]
        [FindsBy(How = How.Id, Using = "lblRegionText")]
        public IWebElement eRegion;

        //Group
        //*[@id="ddlGroups"]
        [FindsBy(How = How.Id, Using = "ddlGroups")]
        public IWebElement eGroup;

        //Brand //*[@id="lblBrandText"]
        [FindsBy(How = How.Id, Using = "lblBrandText")]
        public IWebElement eBrand;

        //Owner Type  //*[@id="ddlOwnerTypes"]
        [FindsBy(How = How.Id, Using = "ddlOwnerTypes")]
        public IWebElement eOwnerType;

        //Rent Type  //*[@id="ddlCalcTypes"]
        [FindsBy(How = How.Id, Using = "ddlCalcTypes")]
        public IWebElement eRentType;

        //BuildName
        //*[@id="txtBuildingName"]
        [FindsBy(How = How.Id, Using = "txtBuildingName")]
        public IWebElement eBuildName;

        //year Build
        //*[@id="txtBuildingNumber"]
        [FindsBy(How = How.Id, Using = "txtBuildingNumber")]
        public IWebElement eYearBuild;

        //County
        //*[@id="tbCounty"]
        [FindsBy(How = How.Id, Using = "tbCounty")]
        public IWebElement eCounty;

        //Suite
        //*[@id="tbSuite"]
        [FindsBy(How = How.Id, Using = "tbSuite")]
        public IWebElement eSuite;

        //Floor
        //*[@id="tbFloor"]
        [FindsBy(How = How.Id, Using = "tbFloor")]
        public IWebElement eFloor;

        //Occupancy Date
        //*[@id="tbOccupancy"]
        [FindsBy(How = How.Id, Using = "tbOccupancy")]
        public IWebElement eOccupancyDate;

        //Store close Date
        //*[@id="tbStoreClose"]
        [FindsBy(How = How.Id, Using = "tbStoreClose")]
        public IWebElement eStoreCloseDate;

        //Rent Start Date
        //*[@id="tbRentStart"]
        [FindsBy(How = How.Id, Using = "tbRentStart")]
        public IWebElement eRentStartDate;

        //Vacate
        //*[@id="tbVacateDate"]
        [FindsBy(How = How.Id, Using = "tbVacateDate")]
        public IWebElement eVacateDate;

        //Usable
        //*[@id="wneUsableArea"]
        [FindsBy(How = How.Id, Using = "wneUsableArea")]
        public IWebElement eUsable;

        //land
        //*[@id="wneLandArea"]
        [FindsBy(How = How.Id, Using = "wneLandArea")]
        public IWebElement eLand;

        //Area custom
        //*[@id="tbAreaCustom1"]
        [FindsBy(How = How.Id, Using = "tbAreaCustom1")]
        public IWebElement eAreaCustom;

        //Save and Return button
        
        [FindsBy(How = How.XPath, Using = "//*[@id='btnSave']")]
        public IWebElement eSaveAndReturn;


        //Verify Data in the form
        public void VerifyRecordID()
        {
            // Verify Record ID
            try
            {
                gms.lst_detail = new List<string>();
                string expRecId = gms.GetSetValue("Record_ID");
                if (eRecordID.Text.Trim() == expRecId)
                {
                    gms.status = EnumClass.LogStatus.Passed;
                    gms.MethodToAddDataInList("Verify Record ID. ~ " + gms.status);
                    //ExtentManagerAfterTest(System.Reflection.MethodBase.GetCurrentMethod().Name, objmethods.lst_detail);
                }
                else
                {
                    gms.status = EnumClass.LogStatus.Failed;
                    gms.MethodToAddDataInList("Verify Record ID. ~ " + gms.status);
                    //ExtentManagerAfterTest(System.Reflection.MethodBase.GetCurrentMethod().Name, objmethods.lst_detail);
                    Assert.Fail("Record ID not matched");
                }

            }
            catch (Exception ex)
            {
                gms.status = EnumClass.LogStatus.Failed;
                gms.MethodToAddDataInList("Verify Record ID. ~ " + gms.status + ex);
                //ExtentManagerAfterTest(System.Reflection.MethodBase.GetCurrentMethod().Name, objmethods.lst_detail);
                Assert.Fail(ex.Message);
            }
        }
        //Verify Record Type
        public void  VerifyRecordType(string strRecordType)
        {
            SelectElement selectedValue = new SelectElement(eRecordType);
            string strItem = selectedValue.SelectedOption.Text;
            if (strItem.Trim() == strRecordType)
            {
                log.Info("The expected record type is displayed");
            }
           else
            {
                log.Info("The expected record type is not displayed");
                Assert.Fail("The expected record type is not displayed");
            }
        }

        //Verify Organization
        public void VerifyOrganization(string strOrganization)
        {
            if (eOrganization.Text.Trim() == strOrganization)
            {
                log.Info("The expected organization is displayed");
            }
            else
            {
                log.Info("The expected organization is not displayed");
                Assert.Fail("The expected organization is not displayed");
            }
        }
       
        //Verify Classification
        public void VerifyClassification(string strClassification)
        {
            SelectElement selectedValue = new SelectElement(eClassification);
            string strItem1 = selectedValue.SelectedOption.Text;
            if (strItem1.Trim() == strClassification)
            {
                log.Info("Expected classification is displayed");
            }
            else
            {
                log.Info("Expected classification is not displayed");
                Assert.Fail("Expected classification is not displayed");
            }
        }

        //Verify Region
        public void VerifyRegion(string strRegion)
        {
            if (eRegion.Text.Trim() == strRegion)
            {
                log.Info("Expected Region is displayed");
            }
            else
            {
                log.Info("Expected Region is not displayed");
                Assert.Fail("Expected Region is not displayed");
            }
        }
       
        //Verify Group
        public void VerifyGroup(string strGroup)
        {
            SelectElement selectedValue = new SelectElement(eGroup);
            string strItem2 = selectedValue.SelectedOption.Text;
            if (strItem2.Trim() == strGroup)
            {
                log.Info("Expected Group is displayed");
            }
            else
            {
                log.Info("Expected Group is not displayed");
                Assert.Fail("Expected Group is not displayed");
            }
        }

        //Verify Brand
        public void VerifyBrand(string strBrand)
        {
            if (eBrand.Text.Trim() == strBrand)
            {
                log.Info("Expected Brand is displayed");
            }
            else
            {
                log.Info("Expected Brand is not displayed");
                Assert.Fail("Expected Brand is not displayed");
            }
        }
       
        //Verify Owner Type
        public void VerifyOwnerType(string strOwnerType)
        {
            SelectElement selectedValue = new SelectElement(eOwnerType);
            string strItem3 = selectedValue.SelectedOption.Text;
            if (strItem3.Trim() == strOwnerType)
            {
                log.Info("Expected Owner Type is displayed");
            }
            else
            {
                log.Info("Expected Owner Type is not displayed");
                Assert.Fail("Expected Owner Type is not displayed");
            }
        }
       
        //Verify Rent Type
        public void VerifyRentType(string strRentType)
        {
            SelectElement selectedValue = new SelectElement(eRentType);
            string strItem3 = selectedValue.SelectedOption.Text;
            if (strItem3.Trim() == strRentType)
            {
                log.Info("Expected Rent Type is displayed");
            }
            else
            {
                log.Info("Expected Rent Type is not displayed");
                Assert.Fail("Expected Rent Type is not displayed");
            }
        }

        //User updates location
        public void UserUpdatesLocation(string strBuildName, string strYear, string strCounty, string strSuite, string strFloor)
        {
            try
            {
                gms.SendKeysForElement(eBuildName, strBuildName, System.Reflection.MethodBase.GetCurrentMethod().Name);
                gms.SendKeysForElement(eYearBuild, strYear, System.Reflection.MethodBase.GetCurrentMethod().Name);
                gms.SendKeysForElement(eCounty, strCounty, System.Reflection.MethodBase.GetCurrentMethod().Name);
                gms.SendKeysForElement(eSuite, strSuite, System.Reflection.MethodBase.GetCurrentMethod().Name);
                gms.SendKeysForElement(eFloor, strFloor, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
            catch(Exception ex)
            {
                Assert.Fail("Failed to update location details" + ex);
            }
        }

        //User updates Dates section
        public void UserUpdatesDateSection()
        {
            try
            {
                //Enter Occupancy Date
                string todayDt = DateTime.Now.ToString("MM/dd/yyyy");
                DateTime dt = Convert.ToDateTime(todayDt).AddMonths(2);
                string occDt = dt.ToString("MM/dd/yyyy");
                gms.SendKeysForElement(eOccupancyDate, occDt, System.Reflection.MethodBase.GetCurrentMethod().Name);

                //Enter Store Close date
                DateTime yrDt = Convert.ToDateTime(todayDt).AddYears(6);
                string closeDate = yrDt.ToString("MM/dd/yyyy");
                gms.SendKeysForElement(eStoreCloseDate, closeDate, System.Reflection.MethodBase.GetCurrentMethod().Name);

                //Enter Rent Starts date
                DateTime dt1 = Convert.ToDateTime(todayDt).AddMonths(1);
                string startDt = dt1.ToString("MM/dd/yyyy");
                gms.SendKeysForElement(eRentStartDate, startDt, System.Reflection.MethodBase.GetCurrentMethod().Name);

                //Enter Vacate Date
                DateTime vtDt = Convert.ToDateTime(todayDt).AddYears(6);
                string vacateDate = vtDt.ToString("MM/dd/yyyy");
                gms.SendKeysForElement(eVacateDate, vacateDate, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
            catch(Exception ex)
            {
                Assert.Fail("Failed to updat Date section" + ex);
            }

        }

        //User updates area section
        public void UserUpdatesAreaSection(string strUsable, string strLand, string strArCust)
        {
            try
            {
                gms.SendKeysForElement(eUsable, strUsable, System.Reflection.MethodBase.GetCurrentMethod().Name);
                gms.SendKeysForElement(eLand, strLand, System.Reflection.MethodBase.GetCurrentMethod().Name);
                gms.SendKeysForElement(eAreaCustom, strArCust, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
            catch(Exception ex)
            {
                Assert.Fail("Failed to update Area Section" + ex);
            }

        }

        //Click 'Save and Return' button
        public void ClickSaveButton()
        {
            eSaveAndReturn.SendKeys("");
            eSaveAndReturn.Click();
        }


    }
}
