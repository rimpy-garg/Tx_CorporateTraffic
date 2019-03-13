using log4net;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;
using TxAutomateFramework.PageObjects;

namespace TxAutomateFramework.Steps
{
    [Binding]
    public class FinancialModuleSteps
    {
        public IWebDriver _driver;
        LeaseGeneralPageObjects lpo;
        CommonMethods com;
        HomePageObjects hpo;
        GeneralInformationEditPageObjects gip;
        ContactsPageObjects cpo;
        FinancialsPageObjects fpo;        

        private readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public FinancialModuleSteps(IWebDriver driver)
        {
            _driver = driver;
            com = new CommonMethods(driver);
            lpo = new LeaseGeneralPageObjects(driver);
            hpo = new HomePageObjects(driver);
            gip = new GeneralInformationEditPageObjects(driver);
            cpo = new ContactsPageObjects(driver);
            fpo = new FinancialsPageObjects(driver);
        }

        [Then(@"User clicks on Financial tab and Entries link")]
        public void ThenUserClicksOnFinancialTabAndEntriesLink()
        {
            lpo.ClickOnFinancialsTab();
            fpo.ClickOnEntriesLink();
        }

        [Then(@"Click Add Record button and enter valid data for record section (.*) and (.*) and (.*) and (.*) and (.*)")]
        public void ThenClickAddRecordButtonAndEnterValidDataForRecordSection(string strCategory, string strFrequency, string strAmt, string strFinType, string strRecordOption)
        {
            fpo.AddRecordEntry(strCategory, strFrequency, strAmt, strFinType, strRecordOption);
        }

        [Then(@"Click on Add increases link from planed increase sectionenter valid data (.*) and (.*) and (.*) and (.*) and (.*)")]
        public void ThenClickOnAddIncreasesLinkFromPlanedIncreaseSectionenterValidData(bool bRecurringIncrease, string strIncAmt, string strIncType, string strTimePeriod, string strTimeFrequency)
        {
            fpo.AddIncreases(bRecurringIncrease, strIncAmt, strIncType, strTimePeriod, strTimeFrequency);
        }

        [Then(@"Select Calendar link from Finanical sub  menu")]
        public void ThenSelectCalendarLinkFromFinanicalSubMenu()
        {
            fpo.ClickCalendarLink();
        }

        [Then(@"Click on Base Rent and select Date Range as Lease term (.*) and (.*) and (.*)")]
        public void ThenClickOnBaseRentAndSelectDateRangeAsLeaseTermAnd(string strCategoryName, string strSubCategoryName, string strYear)
        {
            fpo.VerifyFinancialDetailsUnderBaseRentCategory(strCategoryName, strSubCategoryName, strYear);
        }

        [Then(@"Validate the system will display Base Rent and its subcategory with the monthly breakup (.*) and (.*)")]
        public void ThenValidateTheSystemWillDisplayBaseRentAndItsSubcategoryWithTheMonthlyBreakup(string strEntryCategoryName, string strFinEntryAmt)
        {
            fpo.VerifyBaseRentSubCategoryWithMonthlyBreakup(strEntryCategoryName, strFinEntryAmt);
        }


    }
}
