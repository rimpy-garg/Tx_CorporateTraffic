using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using GenericFramework.GenericMethod;
using static GenericFramework.Enum.EnumClass;
using System.Collections.ObjectModel;
using GenericFramework.Enum;
using GenericFramework.ExtentReport;
using OpenQA.Selenium.Interactions;
using NUnit.Framework;

namespace TxAutomateFramework.PageObjects
{
    public class LeaseGeneralPageObjects
    {        
        IWebDriver webdr;        
        GeneralMethods objmethods;
        Dictionary<string, string> data;
        log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public LeaseGeneralPageObjects()
        {


        }
        public LeaseGeneralPageObjects(IWebDriver dr)
        {
            
            PageFactory.InitElements(dr, this);
            objmethods = new GeneralMethods(dr);
            webdr = dr;
        }

        //Login UserId element
        [FindsBy(How = How.XPath, Using = "//*[contains(@id,'loginuserid')]")]
        public IWebElement LoginID;

        //Menu Item 'LEASE'
        [FindsBy(How = How.XPath, Using = "//*[contains(@id, 'spanMainMenuLease')]")]
        public IWebElement eleLease;

        //Sub Menu Item 'New'
        [FindsBy(How = How.XPath, Using = "//*[@id='divMenu']/ul/li[1]/ul/li[3]/a")]
        public IWebElement newLease;

        //Record ID
        [FindsBy(How = How.XPath, Using = "//*[contains(@id, 'txtLeaseID')]")]
        public IWebElement recordID;

        //Record Type //*[@id="ddlAssetClass"]//*[@id="tdAssetClassFieldCell"]
        [FindsBy(How = How.XPath, Using = "//*[@id='ddlAssetClass']")]
        public IWebElement recordType;

        //Organization
        [FindsBy(How = How.XPath, Using = "//*[@id='tdOrganizationFieldCell']/div")]
        public IWebElement leaseOrganization;

        //Search Organization 
        [FindsBy(How = How.XPath, Using = "//*[@id='inOrganizations']")]
        public IWebElement srchOrganization;              

        //Classification
        [FindsBy(How = How.XPath, Using = "//*[contains(@id, 'uwcClassification')]")]
        public IWebElement Elemtclassification;

        //Owner Type
        [FindsBy(How = How.XPath, Using = "//*[contains(@id, 'ddlOwnerType')]")]
        public IWebElement ownerType;

        //Original Start Date        
        [FindsBy(How = How.XPath, Using = "//table[@id='wdpOrigCommDate']/tbody/tr/td[1]/input")] //"//*[@id='wdpOrigCommDate']/tbody/tr/td[1]/input")] //tbody/tr/td[1]/input")]
        public IWebElement OrgDate;

        //Prop Type        
        [FindsBy(How = How.XPath, Using = "//*[@id='ddlPropType']")]
        public IWebElement propType;

        //Start Date        
        [FindsBy(How = How.XPath, Using = "//*[@id='wdpCommDate']/tbody/tr/td[1]/input")]
        public IWebElement startDate;

        //End Date        
        [FindsBy(How = How.XPath, Using = "//*[@id='wdpExpirationDate']/tbody/tr/td[1]/input")]
        public IWebElement endDate;

        //Street        
        [FindsBy(How = How.XPath, Using = "//*[@id='txtAddress']")]
        public IWebElement street;

        //Town        
        [FindsBy(How = How.XPath, Using = "//*[@id='txtCity']")]
        public IWebElement town;

        //Rent Type
        [FindsBy(How = How.XPath, Using = "//*[contains(@id, 'ddlCalcTypes')]")]
        public IWebElement rentType;

        //State/province        
        [FindsBy(How = How.XPath, Using = "//*[@id='ddlState']")]
        public IWebElement state;

        //Pin code        
        [FindsBy(How = How.XPath, Using = "//*[@id='txtZip']")]
        public IWebElement pinCode;

        //Land Unit
        [FindsBy(How = How.XPath, Using = "//*[@id='uwcGenLandUnits']")]
        public IWebElement landUnit;

        //Country
        [FindsBy(How = How.XPath, Using = "//*[@id='ddlCountry']")]
        public IWebElement country;

        //Save and Open Lease  //*[@id='btnFinish']
        [FindsBy(How = How.Id, Using = "btnFinish")]
        public IWebElement savebutton;

        //Organization Frame 
        [FindsBy(How = How.XPath, Using = "//*[@id='iframeOrganizationSelect']")]
        public IWebElement iFrame;

        //Organization suggestion list
        [FindsBy(How = How.XPath, Using = "//ul[@id='ui-id-1']/child::li']")]
        public IWebElement suggestList;

        //Brand
        [FindsBy(How = How.XPath, Using = "//*[@id='tdBrandFieldCell']/div")]
        public IWebElement brand;

        //Brand List     
        [FindsBy(How = How.XPath, Using = "//*[@id='ctl00_ContentPlaceHolder1_wdtBrands']/ul")]
        public IWebElement brandList;

        //Brand Div        
        [FindsBy(How = How.XPath, Using = "//*[@id='divBrandSelect']")]
        public IWebElement brandDiv;

        //Brand Frame 
        [FindsBy(How = How.XPath, Using = "//*[@id='iframeBrandSelect']")]
        public IWebElement bFrame;  //*[@id="ctl00_ctl00_ctl00_bodyTag"]/div[6]

        //Region        
        [FindsBy(How = How.XPath, Using = "//*[@id='tdRegionFieldCell']/div")]
        public IWebElement eRegion;

        //Region Dialog box        
        [FindsBy(How = How.XPath, Using = "//*[@id='iframeRegionSelect']")]  //*[@id="ctl00_ctl00_ctl00_bodyTag"]/div[5] 
        public IWebElement eRegionDlgBox;

        //region Search box
        //*[@id="inRegions"]
        [FindsBy(How = How.Id, Using = "inRegions")]
        public IWebElement eRegionSrchBox;

        //Group
        [FindsBy(How = How.Id, Using = "ctl00_ctl00_ctl00_cphBaseMain_ContentPlaceHolder1_cphContent_ddlGroup")]
        public IWebElement eGroup;

        //Owner Type
        [FindsBy(How = How.Id, Using = "ctl00_ctl00_ctl00_cphBaseMain_ContentPlaceHolder1_cphContent_ddlOwnerType")]
        public IWebElement eOwnerType;

        //Rentable Area
        [FindsBy(How = How.Id, Using = "uneRentableArea")]
        public IWebElement eRentableArea;

        //Measurement Unit
        [FindsBy(How = How.Id, Using = "uwcGenMeasUnits")]
        public IWebElement eMeasurementUnit;

        //Land Unit
        [FindsBy(How = How.Id, Using = "uwcGenLandUnits")]
        public IWebElement eLandUnit;

        //*[@id="ctl00_ctl00_ctl00_ctl00_bodyTag"]/div[21]

        //Key information section in General tab
        [FindsBy(How = How.Id, Using = "divTab0")]
        public IWebElement eGeneralTabPage;

        //Contacts Tab
        [FindsBy(How = How.XPath, Using = "//*[@id='ui-id-6']")]
        public IWebElement eContactsTab;

        //Financial Tab 
        [FindsBy(How = How.XPath, Using = "//*[@id='ui-id-7']")]
        public IWebElement eFinancialTab;




        //Verify User id displayed after login to application
        public bool verifyUserIdDisplayed()
        {
            
            return objmethods.IsElementVisible(LoginID, System.Reflection.MethodBase.GetCurrentMethod().Name);
        }  

        //Click on New lease item
        public void clickOnNewLease()
        {
            try
            {
                objmethods.lst_detail = new List<string>();
                //Click on Lease menu item
                objmethods.ClickOnElementWhenElementFound(eleLease, System.Reflection.MethodBase.GetCurrentMethod().Name);

                //Click on Submenu item 'New'
                objmethods.ClickOnElementWhenElementFound(newLease, System.Reflection.MethodBase.GetCurrentMethod().Name);

                //Verify record id displayed
                objmethods.IsElementPresent(recordID);
                objmethods.status = EnumClass.LogStatus.Passed;
                objmethods.MethodToAddDataInList("Navigate to New Lease. ~ " + objmethods.status);
                //ExtentManagerAfterTest(System.Reflection.MethodBase.GetCurrentMethod().Name, objmethods.lst_detail);
            }
            catch (Exception ex)
            {
                objmethods.status = EnumClass.LogStatus.Failed;
                objmethods.MethodToAddDataInList("Navigate to New Lease. ~ " + objmethods.status + ex);
                //ExtentManagerAfterTest(System.Reflection.MethodBase.GetCurrentMethod().Name, objmethods.lst_detail);
            }

        }        

        //Enter Data for Record ID
        public void EnterRecordID()
        {
            try
            {
                objmethods.lst_detail = new List<string>();
                string recID = System.DateTime.Now.ToString("yyyyddMMHHmmss").ToString();
                objmethods.GetSetValue("Record_ID", recID);
                //string abc = objmethods.GetSetValue("Record_ID");
                objmethods.SendKeysForElement(recordID, recID, System.Reflection.MethodBase.GetCurrentMethod().Name);
                objmethods.status = EnumClass.LogStatus.Passed;
                objmethods.MethodToAddDataInList("Enter Record ID. ~ " + objmethods.status);
                //ExtentManagerAfterTest(System.Reflection.MethodBase.GetCurrentMethod().Name, objmethods.lst_detail);
            }
            catch (Exception ex)
            {
                objmethods.status = EnumClass.LogStatus.Failed;
                objmethods.MethodToAddDataInList("Enter Record ID. ~ " + objmethods.status + ex);
                //ExtentManagerAfterTest(System.Reflection.MethodBase.GetCurrentMethod().Name, objmethods.lst_detail);
                Assert.Fail(ex.Message);
            }
        }

        //Select Record Type
        public void SelectRecordType(string strRcrdType)
        {
            try
            {
                objmethods.lst_detail = new List<string>();
                objmethods.selectValueFromDropdownByText(recordType, strRcrdType);
                objmethods.status = EnumClass.LogStatus.Passed;
                objmethods.MethodToAddDataInList("Select Record Type. ~ " + objmethods.status);
                //ExtentManagerAfterTest(System.Reflection.MethodBase.GetCurrentMethod().Name, objmethods.lst_detail);
            }
            catch (Exception ex)
            {
                objmethods.status = EnumClass.LogStatus.Failed;
                objmethods.MethodToAddDataInList("Select Record Type. ~ " + objmethods.status + ex);
                //ExtentManagerAfterTest(System.Reflection.MethodBase.GetCurrentMethod().Name, objmethods.lst_detail);
                Assert.Fail(ex.Message);
            }
        }

        //Classification
        public void SelectClassification(string strClassification)
        {
            try
            {
                objmethods.lst_detail = new List<string>();
                objmethods.selectValueFromDropdownByText(Elemtclassification, strClassification);
                objmethods.status = EnumClass.LogStatus.Passed;
                objmethods.MethodToAddDataInList("Select Classification. ~ " + objmethods.status);
                //ExtentManagerAfterTest(System.Reflection.MethodBase.GetCurrentMethod().Name, objmethods.lst_detail);
            }
            catch (Exception ex)
            {
                objmethods.status = EnumClass.LogStatus.Failed;
                objmethods.MethodToAddDataInList("Select Classification. ~ " + objmethods.status + ex);
                //ExtentManagerAfterTest(System.Reflection.MethodBase.GetCurrentMethod().Name, objmethods.lst_detail);
                Assert.Fail(ex.Message);
            }
        }

        //Select Brand
        public void SelectBrand(string strBrand)
        {
            try
            {                
                objmethods.lst_detail = new List<string>();                
                //Click on Brand text box
                objmethods.ClickOnElementWhenElementFound(brand, System.Reflection.MethodBase.GetCurrentMethod().Name);
                objmethods.threadWait(1000);                
                webdr.SwitchTo().Frame(bFrame);
                //Select brand
                string[] stritem = strBrand.Split('#');
                IList<IWebElement> rList = webdr.FindElements(By.XPath("//*[@id='ctl00_ContentPlaceHolder1_wdtBrands']/ul/child::li"));
                int i = 0;
                foreach (var li in rList)
                {
                    i = i + 1;
                    if (li.Text.Contains(stritem[0]))
                    {
                        
                        if (stritem.Length > 1)
                        {
                            for (int a = 0; a < stritem.Length; a++)
                            {
                                string newItem = "Expand" + " " + stritem[a];
                                IList<IWebElement> iNo = webdr.FindElements(By.XPath("//*[(@title='"+newItem+"')]"));
                                if (iNo.Count > 0)
                                {
                                    iNo[0].Click();
                                }
                                else
                                {
                                    IList<IWebElement> item = webdr.FindElements(By.XPath("//*[@id='ctl00_ContentPlaceHolder1_wdtBrands']/ul/li["+i+"]/ul/child::li"));
                                    foreach(var li1 in item)
                                    {
                                        if(li1.Text.Contains(stritem[a]))
                                        {
                                            IWebElement eleLi = webdr.FindElement(By.XPath("//a[text()='" + stritem[a] + "']"));
                                            Actions builder = new Actions(webdr);
                                            builder.DoubleClick(eleLi).Perform();
                                            break;                                           
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            IWebElement ele = webdr.FindElement(By.XPath("//a[text()='"+stritem[0]+"']"));                            
                            Actions builder = new Actions(webdr);
                            builder.DoubleClick(ele).Perform();                          
                            break;
                        }
                                                
                    }
                }
                webdr.SwitchTo().DefaultContent();
                objmethods.threadWait(1000);
                objmethods.status = EnumClass.LogStatus.Passed;
                objmethods.MethodToAddDataInList("Select Brand. ~ " + objmethods.status);
                //ExtentManagerAfterTest(System.Reflection.MethodBase.GetCurrentMethod().Name, objmethods.lst_detail);
            }
            catch (Exception ex)
            {
                objmethods.status = EnumClass.LogStatus.Failed;
                objmethods.MethodToAddDataInList("Select Brand. ~ " + objmethods.status + ex);
                //ExtentManagerAfterTest(System.Reflection.MethodBase.GetCurrentMethod().Name, objmethods.lst_detail);
                Assert.Fail(ex.Message);
            }
        }  

        //Original Start Date
        public void EnterOriginalStartDate()
        {
            try
            {
                objmethods.lst_detail = new List<string>();
                string todayDt = DateTime.Now.ToString("MM/dd/yyyy");
                DateTime dt = Convert.ToDateTime(todayDt).AddDays(2);
                string orgDt = dt.ToString("MM/dd/yyyy");
                objmethods.SendKeysForElement(OrgDate, orgDt, System.Reflection.MethodBase.GetCurrentMethod().Name);
                objmethods.status = EnumClass.LogStatus.Passed;
                objmethods.MethodToAddDataInList("Enter Original Start Date. ~ " + objmethods.status);
                //ExtentManagerAfterTest(System.Reflection.MethodBase.GetCurrentMethod().Name, objmethods.lst_detail);
            }
            catch(Exception ex)
            {
                objmethods.status = EnumClass.LogStatus.Failed;
                objmethods.MethodToAddDataInList("Enter Original Start Date. ~ " + objmethods.status + ex);
                //ExtentManagerAfterTest(System.Reflection.MethodBase.GetCurrentMethod().Name, objmethods.lst_detail);
                Assert.Fail(ex.Message);
            }
        }

        //Select Property Type
        public void SelectPropertyType(string strPropType)
        {
            try
            {
                objmethods.lst_detail = new List<string>();

                objmethods.selectValueFromDropdownByText(propType, strPropType);

                objmethods.status = EnumClass.LogStatus.Passed;
                objmethods.MethodToAddDataInList("Select Property Type. ~ " + objmethods.status);
                //ExtentManagerAfterTest(System.Reflection.MethodBase.GetCurrentMethod().Name, objmethods.lst_detail);
            }
            catch(Exception ex)
            {
                objmethods.status = EnumClass.LogStatus.Failed;
                objmethods.MethodToAddDataInList("Select Property Type. ~ " + objmethods.status + ex);
                //ExtentManagerAfterTest(System.Reflection.MethodBase.GetCurrentMethod().Name, objmethods.lst_detail);
                Assert.Fail(ex.Message);
            }
        }

        //Enter Start Date
        public void EnterStartDate()
        {
            try
            {
                objmethods.lst_detail = new List<string>();

                string todayDt = DateTime.Now.ToString("MM/dd/yyyy");
                DateTime dt = Convert.ToDateTime(todayDt).AddDays(2);
                string orgDt = dt.ToString("MM/dd/yyyy");
                objmethods.SendKeysForElement(startDate, orgDt, System.Reflection.MethodBase.GetCurrentMethod().Name);

                objmethods.status = EnumClass.LogStatus.Passed;
                objmethods.MethodToAddDataInList("Enter Start Date. ~ " + objmethods.status);
                //ExtentManagerAfterTest(System.Reflection.MethodBase.GetCurrentMethod().Name, objmethods.lst_detail);
            }
            catch(Exception ex)
            {
                objmethods.status = EnumClass.LogStatus.Failed;
                objmethods.MethodToAddDataInList("Enter Start Date. ~ " + objmethods.status + ex);
                //ExtentManagerAfterTest(System.Reflection.MethodBase.GetCurrentMethod().Name, objmethods.lst_detail);
                Assert.Fail(ex.Message);
            }
        }

        //Enter Street
        public void EnterAddress(string StrStreetName, string strTown, string strState, string strPIN, string strCountry)
        {
            try
            {
                objmethods.lst_detail = new List<string>();

                objmethods.SendKeysForElement(street, StrStreetName, System.Reflection.MethodBase.GetCurrentMethod().Name);
                objmethods.SendKeysForElement(town, strTown, System.Reflection.MethodBase.GetCurrentMethod().Name);
                objmethods.SendKeysForElement(state, strState, System.Reflection.MethodBase.GetCurrentMethod().Name);
                objmethods.SendKeysForElement(pinCode, strPIN, System.Reflection.MethodBase.GetCurrentMethod().Name);
                objmethods.SendKeysForElement(country, strCountry, System.Reflection.MethodBase.GetCurrentMethod().Name);

                objmethods.status = EnumClass.LogStatus.Passed;
                objmethods.MethodToAddDataInList("Enter Address : StreetName, Town, State, PIN and Country. ~ " + objmethods.status);
                //ExtentManagerAfterTest(System.Reflection.MethodBase.GetCurrentMethod().Name, objmethods.lst_detail);
            }
            catch (Exception ex)
            {
                objmethods.status = EnumClass.LogStatus.Failed;
                objmethods.MethodToAddDataInList("Enter Address : StreetName, Town, State, PIN and Country. ~ " + objmethods.status + ex);
                //ExtentManagerAfterTest(System.Reflection.MethodBase.GetCurrentMethod().Name, objmethods.lst_detail);
                Assert.Fail(ex.Message);
            }
        }

        //Select Organization
        public void SelectOrganization(string strOrganization)
        {
            try
            {
                objmethods.lst_detail = new List<string>();

                objmethods.ClickOnElementWhenElementFound(leaseOrganization, System.Reflection.MethodBase.GetCurrentMethod().Name);
                objmethods.threadWait(1000);
                webdr.SwitchTo().Frame(iFrame);
                objmethods.ClickOnElementWhenElementFound(srchOrganization, System.Reflection.MethodBase.GetCurrentMethod().Name);
                objmethods.SendKeysForElementWithEnterKey(srchOrganization, strOrganization, System.Reflection.MethodBase.GetCurrentMethod().Name);
                objmethods.threadWait(1000);
                IList<IWebElement> elements = webdr.FindElements(By.XPath("//ul[@id='ui-id-1']/child::li"));
                foreach (var ele in elements)
                {
                    if (ele.Text.Equals(strOrganization))
                    {
                        ele.Click();
                        break;
                    }
                }
                webdr.SwitchTo().DefaultContent();
                objmethods.threadWait(1000);
                objmethods.status = EnumClass.LogStatus.Passed;
                objmethods.MethodToAddDataInList("Select Organization. ~ " + objmethods.status);
                //ExtentManagerAfterTest(System.Reflection.MethodBase.GetCurrentMethod().Name, objmethods.lst_detail);
            }
            catch (Exception ex)
            {
                objmethods.status = EnumClass.LogStatus.Failed;
                objmethods.MethodToAddDataInList("Select Organization. ~ " + objmethods.status + ex);
                //ExtentManagerAfterTest(System.Reflection.MethodBase.GetCurrentMethod().Name, objmethods.lst_detail);
                Assert.Fail(ex.Message);
            }

        }

        //Select Region
        public void SelectRegion(string strRegion)
        {
            try
            {               
                objmethods.lst_detail = new List<string>();
                objmethods.ClickOnElementWhenElementFound(eRegion, System.Reflection.MethodBase.GetCurrentMethod().Name);
                objmethods.threadWait(1000);
                webdr.SwitchTo().Frame(eRegionDlgBox);
                objmethods.ClickOnElementWhenElementFound(eRegionSrchBox, System.Reflection.MethodBase.GetCurrentMethod().Name);
                objmethods.SendKeysForElementWithEnterKey(eRegionSrchBox, strRegion, System.Reflection.MethodBase.GetCurrentMethod().Name);
                objmethods.threadWait(1000);
                IList<IWebElement> elements = webdr.FindElements(By.XPath("//ul[@id='ui-id-1']/child::li"));
                foreach (var ele in elements)
                {
                    if (ele.Text.Equals(strRegion))
                    {
                        ele.Click();
                        break;
                    }
                }
                webdr.SwitchTo().DefaultContent();
                objmethods.threadWait(1000);
                objmethods.status = EnumClass.LogStatus.Passed;
                objmethods.MethodToAddDataInList("Select Region. ~ " + objmethods.status);
                //ExtentManagerAfterTest(System.Reflection.MethodBase.GetCurrentMethod().Name, objmethods.lst_detail);
            }
            catch (Exception ex)
            {
                objmethods.status = EnumClass.LogStatus.Failed;
                objmethods.MethodToAddDataInList("Select Region. ~ " + objmethods.status + ex);
                //ExtentManagerAfterTest(System.Reflection.MethodBase.GetCurrentMethod().Name, objmethods.lst_detail);
                Assert.Fail(ex.Message);
            }
        }

        //Select Group
        public void SelectGroup(string strGrpName)
        {
            try
            {
                objmethods.lst_detail = new List<string>();

                objmethods.selectValueFromDropdownByText(eGroup, strGrpName);

                objmethods.status = EnumClass.LogStatus.Passed;
                objmethods.MethodToAddDataInList("Select Group Name. ~ " + objmethods.status);
                //ExtentManagerAfterTest(System.Reflection.MethodBase.GetCurrentMethod().Name, objmethods.lst_detail);
            }
            catch (Exception ex)
            {
                objmethods.status = EnumClass.LogStatus.Failed;
                objmethods.MethodToAddDataInList("Select Group Name. ~ " + objmethods.status + ex);
                //ExtentManagerAfterTest(System.Reflection.MethodBase.GetCurrentMethod().Name, objmethods.lst_detail);
                Assert.Fail(ex.Message);
            }
        }

        //Select Owner Type
        public void SelectOwnerType(string strOwnerType)
        {
            try
            {
                objmethods.lst_detail = new List<string>();

                objmethods.selectValueFromDropdownByText(eOwnerType, strOwnerType);

                objmethods.status = EnumClass.LogStatus.Passed;
                objmethods.MethodToAddDataInList("Select Owner Type. ~ " + objmethods.status);
                //ExtentManagerAfterTest(System.Reflection.MethodBase.GetCurrentMethod().Name, objmethods.lst_detail);
            }
            catch (Exception ex)
            {
                objmethods.status = EnumClass.LogStatus.Failed;
                objmethods.MethodToAddDataInList("Select Owner Type. ~ " + objmethods.status + ex);
                //ExtentManagerAfterTest(System.Reflection.MethodBase.GetCurrentMethod().Name, objmethods.lst_detail);
                Assert.Fail(ex.Message);
            }
        }

        //Enter End Date
        public void EnterEndDate()
        {
            try
            {
                objmethods.lst_detail = new List<string>();

                string todayDt = DateTime.Now.ToString("MM/dd/yyyy");
                DateTime dt = Convert.ToDateTime(todayDt).AddYears(5);
                string orgDt = dt.ToString("MM/dd/yyyy");
                objmethods.GetSetValue("LEASE_END_DATE", orgDt);
                objmethods.SendKeysForElement(endDate, orgDt, System.Reflection.MethodBase.GetCurrentMethod().Name);

                objmethods.status = EnumClass.LogStatus.Passed;
                objmethods.MethodToAddDataInList("Enter End Date. ~ " + objmethods.status);
                //ExtentManagerAfterTest(System.Reflection.MethodBase.GetCurrentMethod().Name, objmethods.lst_detail);
            }
            catch (Exception ex)
            {
                objmethods.status = EnumClass.LogStatus.Failed;
                objmethods.MethodToAddDataInList("Enter End Date. ~ " + objmethods.status + ex);
                //ExtentManagerAfterTest(System.Reflection.MethodBase.GetCurrentMethod().Name, objmethods.lst_detail);
                Assert.Fail(ex.Message);
            }
        }

        //Select Rent Type
        public void SelectRentType(string strRentType)
        {
            try
            {
                objmethods.lst_detail = new List<string>();

                objmethods.selectValueFromDropdownByText(rentType, strRentType);

                objmethods.status = EnumClass.LogStatus.Passed;
                objmethods.MethodToAddDataInList("Select Rent Type. ~ " + objmethods.status);
                //ExtentManagerAfterTest(System.Reflection.MethodBase.GetCurrentMethod().Name, objmethods.lst_detail);
            }
            catch (Exception ex)
            {
                objmethods.status = EnumClass.LogStatus.Failed;
                objmethods.MethodToAddDataInList("Select Rent Type. ~ " + objmethods.status + ex);
                //ExtentManagerAfterTest(System.Reflection.MethodBase.GetCurrentMethod().Name, objmethods.lst_detail);
                Assert.Fail(ex.Message);
            }
        }

        //Enter Rentable Area
        public void EnterRentableArea(string strArea)
        {
            try
            {
                objmethods.lst_detail = new List<string>();

                objmethods.SendKeysForElement(eRentableArea, strArea, System.Reflection.MethodBase.GetCurrentMethod().Name);

                objmethods.status = EnumClass.LogStatus.Passed;
                objmethods.MethodToAddDataInList("Enter Rentable Area. ~ " + objmethods.status);
                //ExtentManagerAfterTest(System.Reflection.MethodBase.GetCurrentMethod().Name, objmethods.lst_detail);
            }
            catch (Exception ex)
            {
                objmethods.status = EnumClass.LogStatus.Failed;
                objmethods.MethodToAddDataInList("Enter Rentable Area. ~ " + objmethods.status + ex);
                //ExtentManagerAfterTest(System.Reflection.MethodBase.GetCurrentMethod().Name, objmethods.lst_detail);
                Assert.Fail(ex.Message);
            }
        }

        //Select Measurement Area
        public void SelectMeasurementArea(string strMesrmtArea)
        {
            try
            {
                objmethods.lst_detail = new List<string>();

                objmethods.selectValueFromDropdownByText(eMeasurementUnit, strMesrmtArea);

                objmethods.status = EnumClass.LogStatus.Passed;
                objmethods.MethodToAddDataInList("Enter Measurement Area. ~ " + objmethods.status);
                //ExtentManagerAfterTest(System.Reflection.MethodBase.GetCurrentMethod().Name, objmethods.lst_detail);
            }
            catch (Exception ex)
            {
                objmethods.status = EnumClass.LogStatus.Failed;
                objmethods.MethodToAddDataInList("Enter Measurement Area. ~ " + objmethods.status + ex);
                //ExtentManagerAfterTest(System.Reflection.MethodBase.GetCurrentMethod().Name, objmethods.lst_detail);
                Assert.Fail(ex.Message);
            }
        }

        //Select Land Unit
        public void SelectLandUnit(string strLandUnit)
        {
            try
            {
                objmethods.lst_detail = new List<string>();

                objmethods.selectValueFromDropdownByText(eLandUnit, strLandUnit);

                objmethods.status = EnumClass.LogStatus.Passed;
                objmethods.MethodToAddDataInList("Select Land Unit. ~ " + objmethods.status);
                //ExtentManagerAfterTest(System.Reflection.MethodBase.GetCurrentMethod().Name, objmethods.lst_detail);
            }
            catch (Exception ex)
            {
                objmethods.status = EnumClass.LogStatus.Failed;
                objmethods.MethodToAddDataInList("Select Land Unit. ~ " + objmethods.status + ex);
                //ExtentManagerAfterTest(System.Reflection.MethodBase.GetCurrentMethod().Name, objmethods.lst_detail);
                Assert.Fail(ex.Message);
            }
        }

        //Click on 'Save and Create Lease' button
        public void ClickSaveCreateLease()
        {
            try
            {
                objmethods.lst_detail = new List<string>();

                objmethods.ClickOnElementWhenElementFound(savebutton, System.Reflection.MethodBase.GetCurrentMethod().Name);

                objmethods.status = EnumClass.LogStatus.Passed;
                objmethods.MethodToAddDataInList("Click on Save and Create Lease button. ~ " + objmethods.status);
                //ExtentManagerAfterTest(System.Reflection.MethodBase.GetCurrentMethod().Name, objmethods.lst_detail);
            }
            catch (Exception ex)
            {
                objmethods.status = EnumClass.LogStatus.Failed;
                objmethods.MethodToAddDataInList("Click on Save and Create Lease button. ~ " + objmethods.status + ex);
                //ExtentManagerAfterTest(System.Reflection.MethodBase.GetCurrentMethod().Name, objmethods.lst_detail);
                Assert.Fail(ex.Message);
            }
        }

        //Verify Lease Default Page displayed
        public void VerifyLeaseDafaultPageDisplayed()
        {
          if(objmethods.IsElementPresent(eGeneralTabPage))
            {
                log.Info("Lease default page displayed");
            }
          else
            {
                log.Info("Lease default page not displayed");
                Assert.Fail("Lease default page not displayed");
            }

        }

        //Click on 'Contacts' tab
        public void ClickOnContactsTab()
        {
            try
            {
                eContactsTab.Click();
                log.Info("Contacts tab clicked");
            }
            catch(Exception ex)
            {
                log.Info("Contacts tab not clicked");
                Assert.Fail("Contacts tab not cliecked" + ex);

            }

        }

        public void ClickOnFinancialsTab()
        {
            try
            {
                eFinancialTab.Click();
                objmethods.threadWait(1000);
                log.Info("Financials tab clicked");
            }
            catch (Exception ex)
            {
                log.Info("Financials tab not clicked");
                Assert.Fail("Financials tab not cliecked" + ex);

            }
        }


    }
}
