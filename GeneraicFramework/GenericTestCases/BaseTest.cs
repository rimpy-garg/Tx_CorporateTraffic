using GenericFramework.Enum;
using GenericFramework.ExtentReport;
using GenericFramework.GenericMethod;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System;
using System.Collections.Generic;
using System.IO;

namespace GenericFramework.GenericTestCases
{
    public class BaseTest
    {
        public IWebDriver driver;
        GeneralMethods generalMethods;
        
        public BaseTest()
		{
		}

        public BaseTest(IWebDriver driver)
        {
            generalMethods = new GeneralMethods(driver);
            
        }
           
        /// <summary>
        /// Desc:Method is used for browser initialization
        /// </summary>
        /// <param name="data"></param>
        /// <param name="testCaseName"></param>
        /// <returns></returns>
        public IWebDriver BrowserInitialization(string browser, string testCaseName)
        {
            try
            {
                GeneralMethods.lst_detail = new List<string>();
                string BrowserName = browser;
                BrowserName = BrowserName.ToLower();
                string driverPath = GeneralMethods.GetDriversPath();                
                
                if (BrowserName == EnumClass.BrowserName.ie.ToString())
                {
                    var options = new InternetExplorerOptions();
                    options.IntroduceInstabilityByIgnoringProtectedModeSettings = true;
                    driver = new InternetExplorerDriver(driverPath);
                }
                else if (BrowserName == EnumClass.BrowserName.firefox.ToString())
                {
                    FirefoxProfileManager Manager = new FirefoxProfileManager();
                    FirefoxProfile profile = Manager.GetProfile("Default");
                    FirefoxDriverService Services = FirefoxDriverService.CreateDefaultService(driverPath);
                    FirefoxOptions option = new FirefoxOptions();
                    option.Profile = profile;
                    driver = new FirefoxDriver(Services, option, TimeSpan.FromSeconds(60));
                    driver.Manage().Window.Maximize();
                }
                else if (BrowserName == EnumClass.BrowserName.chrome.ToString())
                {
                    ChromeOptions options = new ChromeOptions();
                    options.AddArguments("--start-maximized");
                    options.AddArguments("disable-infobars");
                    driver = new ChromeDriver(driverPath, options);
                }
                else
                {
                    driver = new ChromeDriver(driverPath);
                }                
               
                generalMethods.status = EnumClass.LogStatus.Passed;
                generalMethods.MethodToAddDataInList("Initialization of Browser. ~ " + generalMethods.status);
                //ExtentManagerAfterTest(System.Reflection.MethodBase.GetCurrentMethod().Name, generalMethods.lst_detail, MakeScreenshotAfterStep());
                return driver;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public string MakeScreenshotAfterStep()
        {
            string path = generalMethods.GetExcelPath();
            //var takesScreenshot = driver as ITakesScreenshot;
            //string screenshotFilePath = "";
            //string fileNameBase = string.Format("Error_Rpt_{0}", DateTime.Now.ToString("yyyyMMdd_HHmmss"));

            //var artifactDirectory = Path.Combine(@"C:\Users\sbusireddy\TX_VisualLease_Automation\TxAutomateFramework\ResultReport", "Screenshots");

            //if (!Directory.Exists(artifactDirectory))
            //    Directory.CreateDirectory(artifactDirectory);
            //if (takesScreenshot != null)
            //{
            //    var screenshot = takesScreenshot.GetScreenshot();
            //    screenshotFilePath = Path.Combine(artifactDirectory, fileNameBase + "_screenshot.png");

            //    screenshot.SaveAsFile(screenshotFilePath, ScreenshotImageFormat.Png);

            //}
            return null;
        }

    }
}
