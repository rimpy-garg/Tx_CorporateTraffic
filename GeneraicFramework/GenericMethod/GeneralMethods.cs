using GenericFramework.Enum;
using GenericFramework.ExtentReport;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SeleniumExtras;
using System.Diagnostics;


namespace GenericFramework.GenericMethod
{
    public class GeneralMethods
    {
        public IWebDriver driver;
        public GeneralMethods(IWebDriver dr)
        {
            driver = dr;
        }

        //public static string ExcelPath = GetExcelPath();
        //public static ExcelReaderUsingNPOI xls = new ExcelReaderUsingNPOI(ExcelPath.ToString());
        public string ScenarioName = string.Empty;
        public string TestCaseName = string.Empty;
        public static string browserName = string.Empty;
        public EnumClass.LogStatus status;
        public static List<string> lst_detail;
        static string actualPath = string.Empty;
        static string screenshotPaths = string.Empty;
        

        public void maximiseBrowser()
        {
            driver.Manage().Window.Maximize();
        }

        public void ImplicitWait(int timeout)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(timeout);
        }
        public void explicitWait(By aByElement, int aWaitTimeInSec)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(aWaitTimeInSec));
                wait.Until(ExpectedConditions.ElementIsVisible(aByElement));
            }
            catch (TimeoutException e)
            {
                Console.WriteLine(e.ToString());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
        public void threadWait(int aWaitTimeInSec)
        {
            Thread.Sleep(aWaitTimeInSec);
        }
        public void threadWait()
        {
            Thread.Sleep(Convert.ToInt32(ConfigurationManager.AppSettings["ThreadWait"]));
        }
        public bool WaitUntillElementIsVisible(By aByeValue, int timeOut)
        {
            int iTimer = 0;
            while (iTimer <= timeOut)
            {
                bool status = IsElementVisible(aByeValue);
                if (status)
                    return true;
            }
            return false;
        }
       
        public void browserBackNavigation()
        {
            driver.Navigate().Back();
        }
        public void browserForwardNavigation()
        {
            driver.Navigate().Forward();
        }
        public String getAttributeOfWebelementByLocator(By aByValue, String aAttribute)
        {
            explicitWait(aByValue, 3);
            IWebElement element = driver.FindElement(aByValue);
            return element.GetAttribute(aAttribute);
        }
        public IWebElement getWebElementByLocator(By aBy)
        {
            IWebElement webElement = driver.FindElement(aBy);
            return webElement;
        }
        public string getTextOfWebElementByLocator(By aWebElementID)
        {
            return getWebElementByLocator(aWebElementID).Text;
        }
        public IWebElement getElement(By locatorKey)
        {
            IWebElement e = null;
            try
            {
                e = driver.FindElement(locatorKey);
                e = driver.FindElement(locatorKey);
                e = driver.FindElement(locatorKey);
            }
            catch (Exception)
            {
                //   Assert.Fail("Failure in element extraction " + locatorKey);
            }
            return e;
        }
        public EnumClass.LogStatus ClickOnElementWhenElementFound(IWebElement webElement, string scenarioName)
        {
            try
            {
                webElement.Click();
                return status = EnumClass.LogStatus.Passed;
            }
            catch (Exception e)
            {
                FailedScenario(e.Message, scenarioName);
                return status = EnumClass.LogStatus.Failed;
            }
        }
        public EnumClass.LogStatus SendKeysForElement(IWebElement webElement, String aTestData, string scenarioName)
        {
            try
            {
                webElement.Clear();
                webElement.SendKeys(aTestData);
                ImplicitWait(1);
                return status = EnumClass.LogStatus.Passed;
            }
            catch (ElementNotVisibleException e)
            {
                FailedScenario(e.Message, scenarioName);
                return status = EnumClass.LogStatus.Failed;
            }
            catch (Exception e)
            {
                FailedScenario(e.Message, scenarioName);
                return status = EnumClass.LogStatus.Failed;
            }
        }
        public EnumClass.LogStatus SendKeysForElementWithEnterKey(IWebElement webElement, String aTestData, string scenarioName)
        {
            try
            {
                webElement.SendKeys(aTestData + Keys.Enter);
                return status = EnumClass.LogStatus.Passed;
            }
            catch (ElementNotVisibleException e)
            {
                FailedScenario(e.Message, scenarioName);
                return status = EnumClass.LogStatus.Failed;
            }
            catch (Exception e)
            {
                FailedScenario(e.Message, scenarioName);
                return status = EnumClass.LogStatus.Failed;
            }
        }
        public EnumClass.LogStatus SendKeysForWebElement(By aByValue, String aTestData, string scenarioName)
        {
            try
            {
                driver.FindElement(aByValue).Clear();
                driver.FindElement(aByValue).SendKeys(aTestData);
                return status = EnumClass.LogStatus.Passed;
            }
            catch (ElementNotVisibleException e)
            {
                FailedScenario(e.Message, scenarioName);
                return status = EnumClass.LogStatus.Warning;
            }
            catch (Exception e)
            {
                FailedScenario(e.Message, scenarioName);
                return status = EnumClass.LogStatus.Failed;
            }
        }
        public bool IsElementVisible(By aByValue)
        {
            try
            {
                IWebElement element = driver.FindElement(aByValue);
                if (element.Displayed)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        /// <summary>
        /// Desc:Check element is visible or not
        /// </summary>
        /// <returns></returns>
        public bool IsElementVisible(IWebElement webElement, string scenarioName)
        {
            bool isDisplayed = false;
            try
            {
                isDisplayed = IsElementPresent(webElement);
                return isDisplayed;
            }
            catch (Exception e)
            {
                FailedScenario(e.Message, scenarioName);
                return isDisplayed;
            }
        }

        /// <summary>
        /// Desc:Method is used for Failed Scenario
        /// </summary>
        /// <param name="e"></param>
        public void FailedScenario(string e, string scenarioName)
        {
            status = EnumClass.LogStatus.Failed;
            lst_detail.Add(e + " ~ " + status);
            string screenshotPath = ScreenShotCapture();
            Assert.Fail(e);
        }

        /// <summary>
        /// Desc:Method is used for Ignore Scenario
        /// </summary>
        /// <param name="e"></param>
        public void IgnoreScenario(string e, string scenarioName)
        {
            status = EnumClass.LogStatus.Skipped;
            lst_detail.Add(e + " ~ " + status);
            //string screenShotPath = ScreenShotCapture();
            //ExtentManagerAfterTest(scenarioName, lst_detail);
            Assert.Ignore(e);
        }

        public bool waitUntilElementNotVisible(By aByeValue, int timeOut)
        {

            int iTimer = 0;
            while (iTimer <= timeOut)
            {
                bool status = !(IsElementVisible(aByeValue));
                if (status)
                    return true;
            }
            return false;
        }

        public bool IsElementPresent(IWebElement webElement)
        {
            bool result = false;
            try
            {
                result = webElement.Displayed;
                return result;
            }
            catch (NoSuchElementException)
            {
                return result;
            }
        }

        public String selectValueFromDropdown(IWebElement webElement, string value)
        {
            try
            {
                SelectElement oSelect = new SelectElement(webElement);
                oSelect.SelectByText(value);
                return value;
            }
            catch (NoSuchElementException)
            {
                return null;
            }
        }

        public void mouseHover(By aByValue)
        {
            Actions act = new Actions(driver);
            act.MoveToElement(driver.FindElement(aByValue)).Click();
        }

        public string selectValueFromDropdownByText(IWebElement webElement, string value)
        {
            try
            {
                SelectElement oSelect = new SelectElement(webElement);
                oSelect.SelectByText(value);
                return value;
            }
            catch (NoSuchElementException ex)
            {
                return null;
            }
        }
        public int selectValueByIndex(By aByValue, int index)
        {
            try
            {
                SelectElement oSelect = new SelectElement(driver.FindElement(aByValue));
                oSelect.SelectByIndex(index);
                return index;
            }
            catch (NoSuchElementException)
            {
                return -1;
            }
        }
        public EnumClass.LogStatus AssertAreEqual(By expected, string actual)
        {
            try
            {
                Assert.AreEqual(getTextOfWebElementByLocator(expected), actual);
                return status = EnumClass.LogStatus.Passed;
            }
            catch (Exception)
            {
                return status = EnumClass.LogStatus.Failed;
            }
        }
        public EnumClass.LogStatus AssertIsTrue(By eWebElement)
        {
            try
            {
                Assert.IsTrue(IsElementVisible(eWebElement));
                return status = EnumClass.LogStatus.Passed;
            }
            catch (Exception)
            {
                return status = EnumClass.LogStatus.Failed;
            }
        }
        public EnumClass.LogStatus AssertIsFalse(By eWebElement)
        {
            try
            {
                Assert.IsFalse(IsElementVisible(eWebElement));
                return status = EnumClass.LogStatus.Passed;
            }
            catch (Exception)
            {
                return status = EnumClass.LogStatus.Failed;
            }
        }

        public static EnumClass.LogStatus AssertIgnore()
        {
            try
            {
                //Assert.S("Skipping the test");
                return EnumClass.LogStatus.Skipped;
            }
            catch (Exception)
            {
                return EnumClass.LogStatus.Skipped;
            }
        }
        public void jsClick(By aByValue)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].click();", aByValue);
        }

        /// <summary>
        /// Desc:Method is used to capture the ScreenShots
        /// </summary>
        /// <returns></returns>
        public string ScreenShotCapture()
        {
            try
            {
                string screenshotName = DateTime.Now.ToString().Replace("/", "_").Replace("-", "_").Replace(":", "_").Replace(" ", "_") + ".jpeg";
                string screenshotPath = GetScreenshotPath() + screenshotName;
                ITakesScreenshot screenshotDriver = driver as ITakesScreenshot;
                Screenshot screenshot = screenshotDriver.GetScreenshot();
                screenshotPaths = screenshotPath;
                screenshot.SaveAsFile(screenshotPath, ScreenshotImageFormat.Jpeg);
                screenshotPath = "Screenshots//" + screenshotName;
                return screenshotPath;
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Desc:Method is used to Get Screenshot's Path
        /// </summary>
        /// <returns></returns>
        public static string GetScreenshotPath()
        {
            string screenshotPath = GetActualPath();
            return screenshotPath + @"ResultReport\Screenshots\";
            // return ConfigurationManager.AppSettings["ScreenshotsPath"];
        }
        public IList<IWebElement> getSelectedElements(By xPath)
        {
            IList<IWebElement> selects = driver.FindElements(xPath);
            return selects;
        }
        /// <summary>
        /// Desc:Method is used to get all the elmenets
        /// </summary>
        /// <param name="xPath"></param>
        /// <returns></returns>
        public IList<IWebElement> getSelectedElements(string xPath)
        {
            IList<IWebElement> selects = driver.FindElements(By.XPath(xPath));
            return selects;
        }

        /// <summary>
        /// Desc:Method is used to add data of all the items into the list
        /// </summary>
        /// <param name="_data"></param>
        /// <returns></returns>
        public string MethodToAddDataInList(string _data)
        {
            lst_detail.Add(_data);
            return _data;
        }
        public static string GetActualPath()
        {
            actualPath = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            actualPath = actualPath.Substring(0, actualPath.LastIndexOf("bin"));
            actualPath = new Uri(actualPath).LocalPath;
            return actualPath;
        }
        /// <summary>
        /// Desc:Method is used to set report into zip file
        /// </summary>
        /// <returns></returns>
        public static void createZipFile()
        {
            try
            {
                string reportPath = GetReportFolderPath();
                string zipFilePath = GetZipFolderPath();
                bool exists = System.IO.Directory.Exists(reportPath);
                if (!exists)
                    System.IO.Directory.CreateDirectory(reportPath);
                //else
                //    System.IO.Directory.Delete(zipFilePath+@"\ExtentReport.zip");
                addIntoZip(reportPath, zipFilePath);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static void addIntoZip(string directoryPath, string zipFilePath)
        {
            DirectoryInfo dirZipPath = new DirectoryInfo(zipFilePath);
            ZipFile.CreateFromDirectory(directoryPath, Path.Combine(zipFilePath, "ExtentReport.zip"), CompressionLevel.Optimal, true);
        }
        /// <summary>
        /// Desc:Method is used to Get Report Folder's Path
        /// </summary>
        /// <returns></returns>
        public static string GetReportFolderPath()
        {
            string reportPath = GetActualPath();
            reportPath = reportPath + "ResultReport";
            //reportPath = ConfigurationManager.AppSettings["ReportPath"];
            return reportPath;
        }
        /// <summary>
        /// Desc:Method is used to Get zip Folder's Path
        /// </summary>
        /// <returns></returns>
        public static string GetZipFolderPath()
        {
            string zipFolderPath = GetActualPath();
            zipFolderPath = zipFolderPath + @"ZipFolder";
            return zipFolderPath;
        }
        /// <summary>
        /// Desc:Method is used to get report's path
        /// </summary>
        /// <returns></returns>
        public static string GetReportPath()
        {
            string reportPath = GetActualPath();
            reportPath = reportPath + @"\ResultReport\ExtentReport.html";
            //reportPath = ConfigurationManager.AppSettings["LocalEmailPath"] + //ExtentManagerreportName;
            return reportPath;
        }
        /// <summary>
        /// Desc:Method is used to GetExcel path
        /// </summary>
        /// <returns></returns>
        public string GetExcelPath()
        {
            string excelPath = GetActualPath();
            return excelPath + @"TestData";
        }
        /// <summary>
        /// Desc:Method is used to GetDrivers path
        /// </summary>
        /// <returns></returns>
        public static string GetDriversPath()
        {
            string driverPath = GetActualPath();
            driverPath = driverPath + "Drivers";
            return driverPath;
        }

        /// <summary>
        /// Desc:Method is used to open the reports after execution
        /// </summary>
        public static void OpenReportAfterExecution()
        {
            String htmlExtentReportFile = GetReportPath();
            FileStream extentReport = new FileStream(htmlExtentReportFile, FileMode.Open);
            if (File.Exists(htmlExtentReportFile))
            {
                try
                {
                    var procStartInfo = new System.Diagnostics.ProcessStartInfo("C:\\Program Files (x86)\\Google\\Chrome\\Application\\chrome.exe \""
                             + htmlExtentReportFile + "\"");
                    var proc = new System.Diagnostics.Process { StartInfo = procStartInfo };
                    proc.StartInfo.UseShellExecute = false;
                    proc.Start();
                    proc.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
               
        internal string fileName = "";
        
        /// <summary>
        /// Method Discription  -   Returns text from the file mentioned (file should be in TestData folder in Project)
        /// Method Call         -   GetSetValue()
        /// </summary>
        /// <param name="FileName"></param>
        /// <returns></returns>
        public string GetSetValue(string FileName)
        {
            string newfilepath = AppDomain.CurrentDomain.BaseDirectory;
            string strfinaldir = "TxAutomateFramework";
            DirectoryInfo outputDr = Directory.CreateDirectory(newfilepath.Substring(0, newfilepath.LastIndexOf("TxAutomateFramework") + strfinaldir.Length) + @"\TestData\Outputs\");
            Console.WriteLine("In GetSetValue");
            fileName = FileName;
            string line = "";
            try
            {
                //Pass the file path and file name to the StreamReader constructor
                StreamReader sr = new StreamReader(outputDr.FullName + fileName + ".txt");

                //Read the first line of text
                line = sr.ReadLine();

                //close the file
                sr.Close();
                
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            
            return line;
        }

        /// <summary>
        /// Method Discription  -   Stores text to file mentioned (there should be TestData folder in Project)
        /// Method Call         -   GetSetValue()
        /// </summary>
        /// <param name="FileName"></param>
        /// <param name="Value"></param>
        public void GetSetValue(string FileName, string Value)
        {
            string newfilepath = AppDomain.CurrentDomain.BaseDirectory;
            string strfinaldir = "TxAutomateFramework";
            DirectoryInfo outputDr = Directory.CreateDirectory(newfilepath.Substring(0, newfilepath.LastIndexOf("TxAutomateFramework") + strfinaldir.Length) + @"\TestData\Outputs\");
            Console.WriteLine("In GetSetValue");
            fileName = FileName;
            try
            {            
                //Pass the filepath and filename to the StreamWriter Constructor
                StreamWriter sw = new StreamWriter(outputDr.FullName + fileName + ".txt");

                //Write a line of text
                sw.WriteLine(Value);

                //Close the file
                sw.Close();
            }
            catch (Exception e)
            {
              
                Console.WriteLine("Exception: " + e.Message);
            }         
           

        }

    }
}
