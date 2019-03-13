using GenericFramework.Enum;
using GenericFramework.ExtentReport;
using GenericFramework.GenericMethod;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericFramework.DataClasses
{
    public class LaunchPage : GeneralMethods
    {
        public LaunchPage(IWebDriver dr)
           : base(dr)
        {

        }

        public void goToLoginPage()
        {
            
            try
            {
                lst_detail = new List<string>();
                string Url = ConfigurationManager.AppSettings["URL"];
                driver.Url = Url;
                status = EnumClass.LogStatus.Passed;
                MethodToAddDataInList("Go to URL. ~ " + status);
                explicitWait(By.XPath("//a[text()='Register']"), 120);
           //     //ExtentManagerAfterTest(System.Reflection.MethodBase.GetCurrentMethod().Name, lst_detail);

            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
    }
}
