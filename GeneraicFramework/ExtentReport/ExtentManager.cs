using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;
using GenericFramework.Enum;
using GenericFramework.GenericMethod;
using GenericFramework.GenericTestCases;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericFramework.ExtentReport
{
    public class ExtentManager
    {
        private static readonly Lazy<ExtentReports> _lazy = new Lazy<ExtentReports>(() => new ExtentReports());

        public static ExtentReports Instance { get { return _lazy.Value; } }
        static string status = string.Empty;
        static string actualPath = string.Empty;
        public static string reportPath = string.Empty;
        public static string reportName = string.Empty;

        static ExtentManager()
        {
            Array.ForEach(Directory.GetFiles(GeneralMethods.GetScreenshotPath()), File.Delete);
            string reportPath = GetReportPath();
            var htmlReporter = new ExtentHtmlReporter(reportPath);
            htmlReporter.Configuration().ChartLocation = ChartLocation.Bottom;
            htmlReporter.Configuration().ChartVisibilityOnOpen = true;
            htmlReporter.Configuration().Theme = Theme.Standard;
            htmlReporter.LoadConfig(GetActualPath() + "ResultReport//extent-config.xml");
            Instance.AddSystemInfo("OS", "Windows");
            Instance.AddSystemInfo("Environment", "QA");
            Instance.AttachReporter(htmlReporter);
        }

        /// <summary>
        /// Desc:Method is used to create the report after the funtions that are called in the test
        /// </summary>
        /// <param name="desc"></param>
        /// <param name="vs"></param>
        /// <param name="screenShotPath"></param>
        public static void AfterTest(string desc, List<string> vs, string screenShotPath = "")
        {
            ExtentTestManager.CreateTest(desc);
            Status logstatus;
            foreach (var item in vs)
            {
                if (item.Contains('~'))
                {
                    status = item.Split('~')[1].Trim().ToString();
                    if (status.Equals(EnumClass.LogStatus.Failed.ToString()))
                    {
                        logstatus = Status.Fail;
                    }
                    else if (status.Equals(EnumClass.LogStatus.Inconclusive.ToString()))
                    {
                        logstatus = Status.Warning;
                    }
                    else if (status.Equals(EnumClass.LogStatus.Skipped.ToString()))
                    {
                        logstatus = Status.Skip;
                    }
                    else
                    {
                        logstatus = Status.Pass;
                    }
                    ExtentTestManager.GetTest().Log(logstatus, item);
                    if (logstatus == Status.Fail)
                    {
                        ExtentTestManager.GetTest().Fail("Screenshot -", MediaEntityBuilder.CreateScreenCaptureFromPath(screenShotPath).Build());
                    }
                }
            }
        }

        private ExtentManager()
        {
        }

        /// <summary>
        /// Desc:Method is used to get report's path
        /// </summary>
        /// <returns></returns>
        public static string GetReportPath()
        {
            reportPath = GetActualPath();
            reportName = DateTime.Now.ToString().Replace("/", "_").Replace("-", "_").Replace(":", "_").Replace(" ", "_") + ".html";
            reportPath = reportPath + @"\ResultReport\ExtentReport.html";
            //reportPath = ConfigurationManager.AppSettings["ReportPath"] + reportName;
            return reportPath;
        }

        private static string GetActualPath()
        {
            actualPath = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            actualPath = actualPath.Substring(0, actualPath.LastIndexOf("bin"));
            actualPath = new Uri(actualPath).LocalPath;
            return actualPath;
        }


    }
}
