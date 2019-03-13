using GenericFramework.Enum;
using GenericFramework.GenericMethod;
using GenericFramework.GenericTestCases;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TxAutomateFramework.PageObjects
{
    public class LoginPage
    {
        GeneralMethods objmethod;
        BaseTest bt;
        log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public LoginPage(IWebDriver dr)
        {
            PageFactory.InitElements(dr, this);
            objmethod = new GeneralMethods(dr);
            bt = new BaseTest(dr);
            GeneralMethods.lst_detail = new List<string>();
        }
        #region elements

        [FindsBy(How = How.Id, Using = "profile_name")]
        public IWebElement profileName;

        [FindsBy(How = How.Id, Using = "password")]
        public IWebElement password;

        [FindsBy(How = How.Id, Using = "login_button")]
        public IWebElement loginButton;

        [FindsBy(How = How.XPath, Using = "//div[@id='welcome_message']/h2[contains(text(),'Welcome')]")]
        public IWebElement WelcomeMessage;

        #endregion

        public void EnterProfileName(string strProfileName)
        {
            try
            {

                objmethod.SendKeysForElement(profileName, strProfileName, System.Reflection.MethodBase.GetCurrentMethod().Name);
                objmethod.status = EnumClass.LogStatus.Passed;
                objmethod.MethodToAddDataInList("Entered profile name as " + strProfileName + ". ~ " + objmethod.status);
            }
            catch (Exception ex)
            {
                objmethod.status = EnumClass.LogStatus.Failed;
                objmethod.MethodToAddDataInList("Entered profile name is failed. ~ " + objmethod.status + ex);
            }
        }

        public void EnterPassword(string Userpassword)
        {
            try
            {
                //objmethod.lst_detail = new List<string>();
                objmethod.SendKeysForElement(password, Userpassword, System.Reflection.MethodBase.GetCurrentMethod().Name);
                objmethod.status = EnumClass.LogStatus.Passed;
                objmethod.MethodToAddDataInList("Entered Password as ********* . ~ " + objmethod.status);
            }
            catch (Exception ex)
            {
                objmethod.status = EnumClass.LogStatus.Failed;
                objmethod.MethodToAddDataInList("Entered Password is failed. ~ " + objmethod.status + ex);
            }
        }

        public void ClickLoginButton()
        {
            try
            {
                //  objmethod.lst_detail = new List<string>();
                objmethod.threadWait(10);
                objmethod.ClickOnElementWhenElementFound(loginButton, System.Reflection.MethodBase.GetCurrentMethod().Name);
                objmethod.status = EnumClass.LogStatus.Passed;
                objmethod.MethodToAddDataInList("Click Login Button. ~ " + objmethod.status);
            }
            catch (Exception ex)
            {
                objmethod.status = EnumClass.LogStatus.Failed;
                objmethod.MethodToAddDataInList("Register Link not clicked. ~ " + objmethod.status + ex);
            }
        }

        public void verifyLogin()
        {
            try
            {
               // objmethod.lst_detail = new List<string>();
                bool flag = objmethod.IsElementPresent(WelcomeMessage);
                if (flag == true)
                {
                    objmethod.status = EnumClass.LogStatus.Passed;
                    objmethod.MethodToAddDataInList("Login is Successed. ~ " + objmethod.status);
                }
                else
                {
                    objmethod.status = EnumClass.LogStatus.Failed;
                    objmethod.MethodToAddDataInList("Login is not Successed. ~ " + objmethod.status);
                }
            }
            catch (Exception ex)
            {
                objmethod.status = EnumClass.LogStatus.Failed;
                objmethod.MethodToAddDataInList("Login is not Successed. ~ " + objmethod.status + ex);
            }
        }

    }
}
