using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenericFramework.API;
using VersionOne.SDK.APIClient;
using Newtonsoft.Json.Linq;
using GenericFramework.API.VersionOne;
using GenericFramework.GenericMethod;
using System.Data;
using GenericFramework.API.QTest;
using TxAutomateFramework.API;

namespace GenericFramework.API
{
	public class APICommonmethods
	{
		private readonly string _v1InstanceUrl = ConfigurationManager.AppSettings.Get("V1Url");
		private readonly bool _useOAuthEndpoints = bool.Parse(ConfigurationManager.AppSettings.Get("UseOAuthEndpoints"));
		private readonly string _v1AccessToken = ConfigurationManager.AppSettings.Get("V1AccessToken");
		private readonly string _v1Username = ConfigurationManager.AppSettings.Get("V1UserName");
		private readonly string _v1Password = ConfigurationManager.AppSettings.Get("V1Password");
        APIClass instance;

        public IList<string> strList;

        public string TestCaseStatus { set; get; }

        public APICommonmethods( string status)
		{
			TestCaseStatus = status;
		}

        public void CreateIssue(string methodname)
		{
			var services = GetServices();

			var contextId = IntegrationTestsHelper.GetTestProjectOid(_useOAuthEndpoints);
			var issueType = services.Meta.GetAssetType("Issue");
			var newIssue = services.New(issueType, contextId);
			var nameAttribute = issueType.GetAttributeDefinition("Name");
			var name = string.Format("Test Issue {0} Create issue in {1} ", contextId, methodname);
			newIssue.SetAttributeValue(nameAttribute, name);
			services.Save(newIssue);

			Assert.IsNotNull(newIssue.Oid);
		}

        //public void UpdateStatus(string Name)
        //{
            
        //    string projectID = ConfigurationManager.AppSettings["PROJECT_ID"];
        //    instance = new APIClass();
        //    AutomationTestLogResource ATL = new AutomationTestLogResource(ExeStartDate: DateTime.Now.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss.fffZ"), ExeEndDate: DateTime.Now.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss.fffZ"));
        //    ATL.Status = TestCaseStatus;
        //    ATL.Name = Name;
        //    ATL.Note = "Note";
        //    ATL.AutomationContent = Name == "LoginTestMethod" ? "Test Value" : "Test Value2";
        //    string tcName = Name;
        //    ExcelReaderUsingNPOI obj = new ExcelReaderUsingNPOI(@"E:\VisualLease\TX_VisualLease_Automation\TxAutomateFramework\TestData\VisualLease_Data.xlsx");
        //    DataTable dt = obj.GetDataInTable();
        //    string exp = "MethodName='" + Name + "'";

        //   DataRow[] dr= dt.Select(exp);

        //    ATL.AutomationContent = Convert.ToString(dr[0]["AutomationContent"]);
                 
        //    List<AutomationTestLogResource> LATL = new List<AutomationTestLogResource>();
        //    LATL.Add(ATL);
         
        //    AutomationRequest AR = new AutomationRequest(false, Convert.ToString(dr[0]["TestSuite"]), Convert.ToString(dr[0]["Module"]), LATL, null, Convert.ToString(dr[0]["Cycle"])); 
        //    instance.SubmitAutomationTestLogs(long.Parse(projectID), AR, "Automation", Convert.ToInt32(dr[0]["testcaseid"]), null, null);
        //}

        public void UpdateStatus(string Name, string note, string AutomationContent, string testsuite, string parentmodule, string cycle, int testcaseid,string ProjectId,DateTime exeStartdt, DateTime exeEnddt)
        {
            instance = new APIClass();
            string projectID = ProjectId;

            AutomationTestLogResource ATL = new AutomationTestLogResource(ExeStartDate: exeStartdt.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss.fffZ"), ExeEndDate: exeEnddt.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss.fffZ"));
            ATL.Status = TestCaseStatus;
            ATL.Name = Name;
            ATL.Note = note;
            ATL.AutomationContent = AutomationContent;
            List<AutomationTestLogResource> LATL = new List<AutomationTestLogResource>();
            LATL.Add(ATL);
            AutomationRequest AR = new AutomationRequest(false, testsuite, parentmodule, LATL, null, cycle);
            instance.SubmitAutomationTestLogs(long.Parse(projectID), AR, "Automation", testcaseid, null, null);
        }

        public void CreateDefectWithAttachment( string filepath, string methodname)
		{
			
			string file = filepath;
			var services = GetServices();
			string mimeType = MimeType.Resolve(filepath);
			IAttachments attachments = new Attachments(V1Connector
				.WithInstanceUrl(_v1InstanceUrl)
				.WithUserAgentHeader("VL_TX", "1.0")
				.WithAccessToken(_v1AccessToken).UseEndpoint("attachment.img/")
				.Build());

			var contextId = IntegrationTestsHelper.GetTestProjectOid(_useOAuthEndpoints);
			var defectType = services.Meta.GetAssetType("Defect");
			var newDefect = services.New(defectType, contextId);
			var nameAttribute = defectType.GetAttributeDefinition("Name");
			
			var attachmentsAttribute = defectType.GetAttributeDefinition("Attachments");
			var name = string.Format("Test Defect {0} Create defect with attachment in {1}", contextId, methodname);
			newDefect.SetAttributeValue(nameAttribute, name);
			
			services.Save(newDefect);

			services.SaveAttachment(file, newDefect, "Test Attachment on " + newDefect.Oid);

			var query = new Query(newDefect.Oid.Momentless);
			query.Selection.Add(attachmentsAttribute);
			var defect = services.Retrieve(query).Assets[0];

			Assert.AreEqual(1, defect.GetAttribute(attachmentsAttribute).Values.Cast<object>().Count());
		}

	
        private IServices GetServices()
		{
			V1Connector connector;
			if (_useOAuthEndpoints)
			{
				connector = V1Connector
					.WithInstanceUrl(_v1InstanceUrl)
					.WithUserAgentHeader(".NET_SDK_Integration_Test", "1.0")
					.WithAccessToken(_v1AccessToken)
					.UseOAuthEndpoints()
					.Build();
			}
			else
			{
				connector = V1Connector
					.WithInstanceUrl(_v1InstanceUrl)
					.WithUserAgentHeader(".NET_SDK_Integration_Test", "1.0")
					.WithAccessToken(_v1AccessToken)
					.Build();
			}
			IServices services = new Services(connector);

			return services;
		}

       

	}
}
