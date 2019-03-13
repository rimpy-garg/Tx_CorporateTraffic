using System;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using GenericFramework.GenericTestCases;
using GenericFramework.DataClasses;
using GenericFramework.GenericMethod;
using GenericFramework.ExtentReport;
using GenericFramework.API;
using NUnit.Framework;
using System.Configuration;
using TxAutomateFramework.Drivers;
using BoDi;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using System.Reflection;
using AventStack.ExtentReports.Gherkin.Model;

namespace GenericFramework
{
    [Binding]
    public class Hooks
    {

        private readonly IObjectContainer _objectContainer;
        private IWebDriver _driver;
        private ScenarioContext scenarioContext;
        BaseTest bt;
        log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public Hooks(IObjectContainer objectContainer, ScenarioContext scenarioCont)
        {
            _objectContainer = objectContainer;  //Used for scenarios parallel execution in same type browsers
            bt = new BaseTest(_driver);
            this.scenarioContext = scenarioCont; //Scenario Context injection - to avoid static for ScenarioContext.Current.TestError or ScenarioContext.ScenarioInfo.Title
        }


        [BeforeScenario]
        public void Initialize()
        {
            Console.WriteLine("Browser Initialization");
            _driver = bt.BrowserInitialization(ConfigurationManager.AppSettings["Browser"], "");
            LaunchPage launchPage = new LaunchPage(_driver);
            launchPage.goToLoginPage();
            _objectContainer.RegisterInstanceAs<IWebDriver>(_driver);
            string sceanrio = this.scenarioContext.ScenarioInfo.Title;
            ExtentTestManager.CreateParentTest(sceanrio);
        }
     
        [AfterScenario]
        public void UpdateTheResultsAndCleanUp()
        {
            try
            {

                //Extent Report
                string sceanrio = this.scenarioContext.ScenarioInfo.Title;
                ExtentManager.AfterTest(sceanrio, GeneralMethods.lst_detail);
                ExtentManager.Instance.Flush();
                _driver.Close();
                _driver.Quit(); //Kill the browser


                //GeneralMethods gms = new GeneralMethods(_driver);
                //string path = gms.GetExcelPath();
                //string bName = _driver.GetType().ToString();
                //Console.WriteLine(bName);
               
                //DateTime startdate = System.DateTime.Now;
               
                //string[] sceNames = sceanrio.Split(new char[] { '_' }, 2);

               
                //ExcelReaderUsingNPOI xls = new ExcelReaderUsingNPOI(path + @"\Outputs\TestSuite.xlsx");
                //Console.WriteLine("Get the file to write");
                //string sheetName = sceNames[0];
                //int rows = xls.getRowCount(sheetName);
                //for (int i = 2; i <= rows; i++) //Loop for all modules
                //{
                //    string run = xls.getCellData(sheetName, 2, i);
                //    if (run == sceNames[1])
                //    {
                //        bool passed = this.scenarioContext.TestError == null;
                //        if (passed)
                //        {
                //            xls.setCellData(sheetName, 8, i, "PASS");
                //            APICommonmethods oCom = new APICommonmethods("PASS");
                //            Console.WriteLine("Before QTest Update");
                //            oCom.UpdateStatus(TestContext.CurrentContext.Test.MethodName, "Success", xls.getCellData(sheetName, 7, i), xls.getCellData(sheetName, 4, i), xls.getCellData(sheetName, 3, i), xls.getCellData(sheetName, 5, i), Convert.ToInt32(xls.getCellData(sheetName, 6, i)), ConfigurationManager.AppSettings["PROJECT_ID"].ToString(), startdate, System.DateTime.Now);
                            
                //        }
                //        else
                //        {
                //            xls.setCellData(sheetName, 8, i, "FAIL");
                //            APICommonmethods oCom = new APICommonmethods("FAIL");
                //            oCom.UpdateStatus(TestContext.CurrentContext.Test.MethodName, "Success", xls.getCellData(sheetName, 7, i), xls.getCellData(sheetName, 4, i), xls.getCellData(sheetName, 3, i), xls.getCellData(sheetName, 5, i), Convert.ToInt32(xls.getCellData(sheetName, 6, i)), ConfigurationManager.AppSettings["PROJECT_ID"].ToString(), startdate, System.DateTime.Now);

                //        }
                //    }
                //}
            }
            catch (Exception ex)
            {
                log.Info(ex.Message);
                Console.WriteLine("Exception in Hooks");
            }

        }

        [TearDown]
       public void Cleanup()
        {
            _driver.Quit();
        }

    }
}

