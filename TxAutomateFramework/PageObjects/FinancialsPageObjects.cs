using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using GenericFramework.GenericMethod;
using GenericFramework.GenericTestCases;
using System;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using GenericFramework.Enum;
using OpenQA.Selenium.Interactions;
using System.Linq;

namespace TxAutomateFramework.PageObjects
{
    public class FinancialsPageObjects
    {
        IWebDriver webdr;
        GeneralMethods gms;
        BaseTest bt;
        LeaseGeneralPageObjects lgp;
        log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public FinancialsPageObjects()
        {
        }
        public FinancialsPageObjects(IWebDriver dr)
        {
            PageFactory.InitElements(dr, this);
            gms = new GeneralMethods(dr);
            bt = new BaseTest(dr);
            webdr = dr;
            lgp = new LeaseGeneralPageObjects(dr);
        }

        //Payee link
        [FindsBy(How = How.XPath, Using = "//*[@id='ctl00_ctl00_ctl00_ctl00_ctl00_cphBaseMain_ContentPlaceHolder1_cphContent_cphTab2_lnkPayees']")]
        public IWebElement ePayeesLink;

        //Entries link        
        [FindsBy(How = How.XPath, Using = "//*[@id='ctl00_ctl00_ctl00_ctl00_ctl00_cphBaseMain_ContentPlaceHolder1_cphContent_cphTab2_lnkSchedule']")]
        public IWebElement eEntriesLink;

        //Add Record button        
        [FindsBy(How = How.Id, Using = "btnAddScheduleRecord")]
        public IWebElement eAddRecordBtn;

        //Category
        //*[@id="tbFinancialCategory"]
        [FindsBy(How = How.Id, Using = "tbFinancialCategory")]
        public IWebElement eCategory;

        //Category select Image        
        [FindsBy(How = How.XPath, Using = "//*[@id='ctl00_ctl00_ctl00_ctl00_ctl00_cphBaseMain_ContentPlaceHolder1_cphContent_cphTab2_cphFinancialMain_Img1']")]
        public IWebElement eCategorySelectImage;

        //Select Financial Category Frame
        //*[@id="iframeExpenseSelect"]
        [FindsBy(How = How.Id, Using = "iframeExpenseSelect")]
        public IWebElement eSelectFinCategoryFrame;

        //Select payment to
        //*[@id="ddlPlanningAddPayTo"]
        [FindsBy(How = How.Id, Using = "ddlPlanningAddPayTo")]
        public IWebElement eSelectPmtTo;

        //Frequency
        //*[@id="ddlPlanningAddFrequency"]
        [FindsBy(How = How.Id, Using = "ddlPlanningAddFrequency")]
        public IWebElement eSelectFrequency;

        //Effective Date
        //*[@id="tbEffectiveDate"]
        [FindsBy(How = How.Id, Using = "tbEffectiveDate")]
        public IWebElement eEffectiveDate;

        //End Date
        //*[@id="tbEndDate"]
        [FindsBy(How = How.Id, Using = "tbEndDate")]
        public IWebElement eEndDate;

        //Arrears Date
        //*[@id="tbArrearsDate"]
        [FindsBy(How = How.Id, Using = "tbArrearsDate")]
        public IWebElement eArrearsDate;

        //Applied Date
        //*[@id="tbAppliedDate"]
        [FindsBy(How = How.Id, Using = "tbAppliedDate")]
        public IWebElement eAppliedDate;

        //Amount
        //*[@id="wnePlanningAddAmount"]
        [FindsBy(How = How.Id, Using = "wnePlanningAddAmount")]
        public IWebElement eAmount;

        //Financial Type
        //*[@id="ddlPlanningFinancialType"]
        [FindsBy(How = How.Id, Using = "ddlPlanningFinancialType")]
        public IWebElement eFinancialType;

        //Allocation Group
        //*[@id="ddlAllocationGroup"]
        [FindsBy(How = How.Id, Using = "ddlAllocationGroup")]
        public IWebElement eAllocationGroup;

        //Record Option - Subsequent payments on 1st of each period
        //*[@id="cbPaymentOnFirst"]
        [FindsBy(How = How.Id, Using = "cbPaymentOnFirst")]
        public IWebElement ePmtOnFirst;

        //Record option - Overlap other entries for this category 
        [FindsBy(How = How.XPath, Using = "//*[@id='ctl00_ctl00_ctl00_ctl00_ctl00_cphBaseMain_ContentPlaceHolder1_cphContent_cphTab2_cphFinancialMain_cbAllowOverlap']")]
        public IWebElement eOverlapOtherEntries;

        //CPI Index
        //*[@id="ddlCPIIndex"]
        [FindsBy(How = How.Id, Using = "ddlCPIIndex")]
        public IWebElement eCPIIndex;

        //Starting CPI Index
        //*[@id="wneStartingCPIIndex"]
        [FindsBy(How = How.Id, Using = "wneStartingCPIIndex")]
        public IWebElement eStartingCIPIndex;

        //Invoice Number
        //*[@id="tbInvoiceNumber"]
        [FindsBy(How = How.Id, Using = "tbInvoiceNumber")]
        public IWebElement eInvoiceNumber;

        //Variable payment - FASB 842
        [FindsBy(How = How.XPath, Using = "//*[@id='ctl00_ctl00_ctl00_ctl00_ctl00_cphBaseMain_ContentPlaceHolder1_cphContent_cphTab2_cphFinancialMain_cbFASBAccountingStandards_0']")]
        public IWebElement eVarPmtFASB;

        //Variable payment - IFRS 16
        [FindsBy(How = How.XPath, Using = "//*[@id='ctl00_ctl00_ctl00_ctl00_ctl00_cphBaseMain_ContentPlaceHolder1_cphContent_cphTab2_cphFinancialMain_cbFASBAccountingStandards_1']")]
        public IWebElement eVarPmtIFRS;

        //Add Increases link
        //*[@id="divIncreasesNew"]/h3/div/a
        [FindsBy(How = How.XPath, Using = "//*[@id='divIncreasesNew']/h3/div/a")]
        public IWebElement eAddIncreases;

        //Add recurring increases
        //*[@id="cbAddRecurringIncreases"]
        [FindsBy(How = How.XPath, Using = "//input[@id='cbAddRecurringIncreases']")]
        public IWebElement eAddRecurngIncrease;

        //Increase Date        
        [FindsBy(How = How.XPath, Using = "//div[@id='divAddRecurringIncreaseDialog']//input[starts-with(@id,'dp')]")]
        public IWebElement eIncreaseDate;

        //Amount - Add Increase 
        [FindsBy(How = How.XPath, Using = "//div[@id='divAddRecurringIncreaseDialog']//input[@class='LeaseDataRight']")]
        public IWebElement eIncreaseAmount;

        //Fixed dropdown
        [FindsBy(How = How.XPath, Using = "//div[@class='LeaseData AddNewContactAssociationIncrease']//div//select[@tabindex='220']")]
        public IWebElement eFixedDrpdown;

        //Every 
        [FindsBy(How = How.XPath, Using = "//*[@id='divAddRecurringIncreaseDialog']/div[1]/div[1]/div[3]/input")]
        public IWebElement eEvery;

        //Time Frequency (ex:Months)
        [FindsBy(How = How.XPath, Using = "//*[@id='divAddRecurringIncreaseDialog']/div[1]/div[1]/div[3]/select")]
        public IWebElement eTimeFrequency;

        //Add Increases frame        
        [FindsBy(How = How.XPath, Using = "//*[@id='ctl00_ctl00_ctl00_ctl00_ctl00_bodyTag']/div[13]")]
        public IWebElement eAddIncreasesFrame;

        //Add Increase Save button
        //*[@id="divAddRecurringIncreaseDialog"]/div[2]/div/button[1]/span
        [FindsBy(How = How.XPath, Using = "//*[@id='divAddRecurringIncreaseDialog']/div[2]/div/button[1]/span")]
        public IWebElement eAddIncreaseSaveButton;

        //Planned Increases Table        
        [FindsBy(How = How.XPath, Using = "//table[@class ='koGridContainer']")]
        public IWebElement ePlannedIncreaseTable;

        //Save&Return button
        [FindsBy(How = How.XPath, Using = "//*[@id='btnSave']")]
        public IWebElement eSaveReturnBtn;

        //Calendar link        
        [FindsBy(How = How.XPath, Using = "//*[@id='ctl00_ctl00_ctl00_ctl00_ctl00_cphBaseMain_ContentPlaceHolder1_cphContent_cphTab2_lnkCalendar']")]
        public IWebElement eCalendarlink;

        //Date Range - calendar page
        //*[@id="ddlFilterDateRange"]
        [FindsBy(How = How.Id, Using = "ddlFilterDateRange")]
        public IWebElement eDateRangeDrpdwn;

        [FindsBy(How = How.XPath, Using = "//div[@id='divAddIncreaseDialog']")]
        public IWebElement eAddIncreaseDialog;



        //Click on Entries link
        public void ClickOnEntriesLink()
        {
            //Click on Entries link
            eEntriesLink.Click();
        }

        //Verify payee details
        public void verifyPayeeDetails()
        {
            //Click on 'Payees' link
            ePayeesLink.Click();

            string FirstName = gms.GetSetValue("FIRST_NAME");
            string LastName = gms.GetSetValue("LAST_NAME");
            string JobTitle = gms.GetSetValue("JOB_TITLE");
            string CompanyName = gms.GetSetValue("COMPANY_NAME");
            string Phone = gms.GetSetValue("PHONE_NUMBER");
            string EmailAddress = gms.GetSetValue("EMAIL_ID");

            string[] payeeDtls = { FirstName, LastName, JobTitle, CompanyName, Phone, EmailAddress };

            bool bData = false;
            //Get the all the data for payee details
            string sData = gms.getTextOfWebElementByLocator(By.XPath("//*[@id='divPayeesList']"));

            //Verify payee details displayed a expected
            for(int i=0; i <= payeeDtls.Length - 1; i++)
            {
                if(sData.Contains(payeeDtls[i]))
                {
                    bData = true;
                }
                else
                {
                    bData = false;
                    break;
                }
            }
            if (bData)
            {
                log.Info("Payee details displayed as expected");
            }
            else
            {
                log.Info("Payee details are not displayed as expected");
                Assert.Fail("Payee details are not displayed as expected");
            }            

        }

        //Add Record entry
        public void AddRecordEntry(string strCategory, string strFrequency, string strAmt, string strFinType, string strRecordOption)
        {
            try
            {
                //Click on Add Record button
                gms.WaitUntillElementIsVisible(By.XPath("//*[@id='btnAddScheduleRecord']"), 1000);
                eAddRecordBtn.Click();
                gms.threadWait(1000);

                //Select Category
                gms.SendKeysForElement( eCategory, strCategory, System.Reflection.MethodBase.GetCurrentMethod().Name);
                gms.threadWait();
                eCategory.SendKeys(Keys.Enter);
                
                //Select Frequency
                gms.selectValueFromDropdownByText(eSelectFrequency, strFrequency);

                //Select End Date
                string endDt = gms.GetSetValue("LEASE_END_DATE");
                gms.SendKeysForElement(eEndDate, endDt, System.Reflection.MethodBase.GetCurrentMethod().Name);

                //Enter Amount
                gms.SendKeysForElement(eAmount, strAmt, System.Reflection.MethodBase.GetCurrentMethod().Name);

                //Select Financial Type
                gms.selectValueFromDropdownByText(eFinancialType, strFinType);

                //Record Option: Subsequent Payments on 1st of each period
                switch(strRecordOption)
                {
                    case "FirstOfEachPeriod":
                        bool bCheck1 = ePmtOnFirst.Selected;
                        if (!bCheck1)
                        {
                            ePmtOnFirst.Click();
                        }
                        break;
                    case "OverlapOtherEntries":
                        bool bCheck2 = eOverlapOtherEntries.Selected;
                        if(!bCheck2)
                        {
                            eOverlapOtherEntries.Click();
                        }
                        break;
                    default:
                        log.Info("Expected checkbox not available");
                        Assert.Fail("Expected checkbox not available");
                        break;
                }
               

            }
            catch (Exception ex)
            {
                log.Info("Fialed while filling the data");
                Assert.Fail("Failed while filling the data for Financial Entry" + ex);
            }
        }

        //Add Increses
        public void AddIncreases(bool bRecurringIncrease, string strIncAmt, string strIncType, string strTimePeriod, string strTimeFrequency)
        {
            //Click on 'Add Increases link
            eAddIncreases.Click();
            gms.threadWait(1000);            

            //Select checkbox for Recurring increases
            if (bRecurringIncrease == true)
            {
                //Select check box for Recurring Increase
                eAddRecurngIncrease.Click();

                //Enter Every - Time period
                gms.SendKeysForElement(eEvery, strTimePeriod, System.Reflection.MethodBase.GetCurrentMethod().Name);

                //Enter Every - Frequency
                gms.selectValueFromDropdownByText(eTimeFrequency, strTimeFrequency);
            }
           
        
            //webdr.SwitchTo().Frame(eAddIncreaseDialog);
            //string current_window = webdr.CurrentWindowHandle;
            
            //webdr.SwitchTo().Window(current_window); //To put you back where you started.

            //Add Increase date
            string todayDt = DateTime.Now.ToString("MM/dd/yyyy");
            DateTime dt = Convert.ToDateTime(todayDt).AddYears(1);
            string incDt = dt.ToString("MM/dd/yyyy");
            gms.SendKeysForElement(eIncreaseDate, incDt, System.Reflection.MethodBase.GetCurrentMethod().Name);
            eIncreaseDate.SendKeys(Keys.Tab);
            
            //Add Amount
            gms.SendKeysForElement(eIncreaseAmount, strIncAmt, System.Reflection.MethodBase.GetCurrentMethod().Name);

            //Increase Frequency
            gms.selectValueFromDropdownByText(eFixedDrpdown, strIncType);            

            //Click on 'Save' button
            eAddIncreaseSaveButton.Click();

            //Switch back to default frame
            //webdr.SwitchTo().DefaultContent();
           // gms.threadWait(1000);

            //Verify planned increase table displayed
            bool bDisp = ePlannedIncreaseTable.Displayed;
            if(bDisp)
            {
                log.Info("Planned increase table displayed");
            }
            else
            {
                log.Info("Planned increase table not displayed");
                Assert.Fail("Planned increase table not displayed");
            }

            //Click on 'Save&Return' button
            eSaveReturnBtn.Click();

        }

        //Click on 'Calendar' link
        public void ClickCalendarLink()
        {
            eCalendarlink.Click();
            gms.threadWait(1000);
            if(webdr.FindElement(By.XPath("//a[text() = 'Financial Calendar']")).Displayed)
            {
                log.Info("Financial calendar page displayed");
            }
            else
            {
                log.Info("Financial calendar page not displayed");
                Assert.Fail("Financial calendar page not displayed");
            }
        }

        //Select link under Category column in Financial Calendar page
        public void ClickCategoryLinkUnderFinancialCalendar(string strCategoryName)
        {
            try
            {
                IWebElement tableElement = webdr.FindElement(By.XPath("//tbody[@class='ig_Item igg_Item igg_FixedColumnCellCssClass']"));
                IList<IWebElement> tableRow = tableElement.FindElements(By.TagName("tr"));
                IList<IWebElement> rowTD;
                foreach (IWebElement row in tableRow)
                {
                    rowTD = row.FindElements(By.TagName("td"));

                    if (rowTD[0].Text.Equals(strCategoryName))  //"TOTAL BASE RENT"
                    {
                        rowTD[0].Click();
                        gms.threadWait(1000);
                        break;
                    }

                }
            }
            catch (Exception ex)
            {
                log.Info("Failed to click Category link");
                Assert.Fail("Failed to click Category link" + ex);
            }
        }

        public void ClickSubCategoryLinkUnderFinancialCalendar(string strSubCategoryName)
        {
            try
            { 
                IWebElement tableElement = webdr.FindElement(By.XPath("//tbody[@class='ig_Item igg_Item igg_FixedColumnCellCssClass']")); 
                IList<IWebElement> tableRow = tableElement.FindElements(By.TagName("tr")); 
                IList<IWebElement> rowTD;
                foreach (IWebElement row in tableRow)
                {
                    rowTD = row.FindElements(By.TagName("td"));

                    if (rowTD[0].Text.Equals(strSubCategoryName))  //"BASE RENT"
                    {
                        rowTD[0].Click();
                        gms.threadWait(1000);
                        break;
                    }

                }
            }
            catch (Exception ex)
            {
                log.Info("Failed to click Category link");
                Assert.Fail("Failed to click Category link" + ex);
            }
        }
       
        //Click year link in Financial category page
        public void ClickYearLinkInFinancialCalendar(string strYear)
        {
           //Click year link
            webdr.FindElement(By.XPath("//a[text() =  '" + strYear + "']")).Click();

        }

        public void VerifyFinancialDetailsUnderBaseRentCategory(string strCategoryName, string strSubCategoryName, string strYear)
        {
            //Click on Base rent link under financial category
            ClickCategoryLinkUnderFinancialCalendar(strCategoryName);

            //Click on SubCategory name
            ClickSubCategoryLinkUnderFinancialCalendar(strSubCategoryName);

            //Click year link
            ClickYearLinkInFinancialCalendar(strYear);
            gms.threadWait(1000);
        }

        //The system will display Base Rent and its subcategory with the monthly breakup. (which should match with the financial entry we just made)
        public void VerifyBaseRentSubCategoryWithMonthlyBreakup(string strEntryCategoryName, string strFinEntryAmt)
        {
            try
            {
                IWebElement tableElement = webdr.FindElement(By.XPath("//tbody[@class='ig_Item igg_Item igg_FixedColumnCellCssClass']"));
                IList<IWebElement> tableRow = tableElement.FindElements(By.TagName("tr"));
                IList<IWebElement> rowTD;
                foreach (IWebElement row in tableRow)
                {
                    rowTD = row.FindElements(By.TagName("td"));

                    if (rowTD[0].Text.Equals(strEntryCategoryName))  //"BASE RENT"
                    {
                        string strRowData = rowTD[1].Text;
                        if (strRowData.Contains(strFinEntryAmt))
                        {
                            log.Info("Finance entry amount dispayed");
                            break;
                        }
                        else
                        {
                            log.Info("Finance entry amount Not dispayed");
                            Assert.Fail("Finance entry amount Not dispayed");
                        }

                    }

                }
            }
            catch (Exception ex)
            {
                log.Info("Failed to click Category link");
                Assert.Fail("Failed to click Category link" + ex);
            }
        }

    }
}
