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
    public class HomePageObjects
    {
        GeneralMethods gms;
        BaseTest bt;
        log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public HomePageObjects()
        {
        }
        public HomePageObjects(IWebDriver dr)
        {
            PageFactory.InitElements(dr, this);
            gms = new GeneralMethods(dr);
            bt = new BaseTest(dr);

        }

        //Home page 'Search' input box
        [FindsBy(How = How.Id, Using = "wteQuickSearch")]
        public IWebElement eHmePageSearch;

        //'Search' suggestion list        
        [FindsBy(How = How.XPath, Using = "//span[@class='quick-search-highlight']")]  
        public IWebElement eSearchSuggestList;

        //'Edit All' link   
        [FindsBy(How = How.Id, Using = "ctl00_ctl00_ctl00_ctl00_cphBaseMain_ContentPlaceHolder1_cphContent_cphTab0_lnkGeneralEdit")]
        public IWebElement eEditAllLink;     


        //Search Record ID
        public void SearchRecordID()
        {
            string strRecId = gms.GetSetValue("Record_ID");
            gms.SendKeysForElement(eHmePageSearch, strRecId, System.Reflection.MethodBase.GetCurrentMethod().Name);
            gms.threadWait();
            eHmePageSearch.SendKeys(Keys.ArrowDown);
            eHmePageSearch.SendKeys(Keys.Enter);
            gms.threadWait(1000);
        }

        //Enter 'Lease ID' in search box and clik on 'Edit All' link
        public void ClickEditLease()
        {            
            gms.ClickOnElementWhenElementFound(eEditAllLink, System.Reflection.MethodBase.GetCurrentMethod().Name);

        }


    }
}
