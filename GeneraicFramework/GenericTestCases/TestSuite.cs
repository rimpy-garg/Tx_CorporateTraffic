using GenericFramework.ExtentReport;
using GenericFramework.GenericMethod;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using OpenQA.Selenium;
using System.Diagnostics;

namespace GenericFramework.GenericTestCases
{    
    [TestFixture]
    [Parallelizable(ParallelScope.Fixtures)]
    public class TestSuite
    {
        public IWebDriver driver;
        ExtentManager extent;
        public string tcname;
        GeneralMethods gms;
       
        log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
		public TestSuite()
		{
            
		}
                
        public void DriverScript()
        {
            try
            {                
                gms = new  GeneralMethods(driver);
                string newfilepath = AppDomain.CurrentDomain.BaseDirectory;
                string strfinaldir = "TX_VisualLease_Automation";
                string strfinaldir1 = "TxAutomateFramework";

                DirectoryInfo inputDr = new DirectoryInfo(newfilepath.Substring(0, newfilepath.LastIndexOf("TxAutomateFramework") + strfinaldir1.Length) + @"\TestData\Inputs");
                DirectoryInfo outputDr = Directory.CreateDirectory(newfilepath.Substring(0, newfilepath.LastIndexOf("TxAutomateFramework") + strfinaldir1.Length) + @"\TestData\Outputs");
                DirectoryInfo inputDr1 = new DirectoryInfo(newfilepath.Substring(0, newfilepath.LastIndexOf("TX_VisualLease_Automation") + strfinaldir.Length) + @"\packages\NUnit.ConsoleRunner.3.9.0\tools");
                //DirectoryInfo inputDr1 = new DirectoryInfo(@"C:\ProgramData\chocolatey\lib\nunit-console-runner\tools\");
                DirectoryInfo inputDr2 = new DirectoryInfo(newfilepath+@"\TxAutomateFramework.dll");

                //Get all the files from Input folder and copy to Output folder
                foreach (FileInfo fl in inputDr.GetFiles())
                {
                    fl.CopyTo(outputDr.FullName + @"\" + fl.Name, true);
                   log.Info("Copying" + outputDr.FullName + @"\" + fl.Name + " file to output folder");
                    Console.WriteLine("Copied the file in output folder");
                }

                //Create xls object to read data from TestSuite file
                gms.GetSetValue("Outputs_TestSuite_Path", outputDr.FullName);
                ExcelReaderUsingNPOI xls = new ExcelReaderUsingNPOI(outputDr.FullName + @"\TestSuite.xlsx");
                Console.WriteLine("Reading the data from Output file");
                string sheetName = "TestPlan";
                int rows = xls.getRowCount(sheetName);
                log.Info("reading data from " + outputDr.FullName + @"\TestSuite.xlsx");
                string testcase = "";
                for (int i = 2; i <= rows; i++) //Loop for all modules
                {
                    string run = xls.getCellData(sheetName, 1, i);
                    if (run == "Y") //if module 'Y'
                    {
                        string tcsheet = xls.getCellData(sheetName, 2, i);
                        log.Info("reading data from " + tcsheet);
                        int tcrows = xls.getRowCount(tcsheet);
                        for (int j = 2; j <= tcrows; j++) //Loop for all test cases in 'module' sheet
                        {
                           string tcrun = xls.getCellData(tcsheet, 0, j); //Get test case run flag 
                           tcname = xls.getCellData(tcsheet, 2, j);
                           if (tcrun == "Y")
                           {
                                if (testcase != "")
                                    testcase = testcase + " || " + "cat==" + tcname;
                                else
                                    testcase = "cat==" + tcname;
                           }
                        }
                    }
                }
                
                //Run all the scenarios through nunit console
                ConsoleRunner(inputDr1.ToString(), inputDr2.ToString(), testcase);
            }

            catch (Exception ex)
            {
                Assert.Fail("Failed to read the data from TestSuite file" + ex);
            }
        }
        
        public void ConsoleRunner(string toolsDir, string dllDir, string tagName)
        {
            try
            {
                Console.WriteLine("In Console Runner");
                ProcessStartInfo start = new ProcessStartInfo(@"C:\Windows\System32\cmd.exe");
                start.UseShellExecute = false;
                start.WorkingDirectory = toolsDir;
                start.FileName = "cmd.exe";
                start.Arguments = @"/k nunit3-console.exe " + dllDir + " --where \"" + tagName + "\"";
                Process cmd = new Process();
                cmd.StartInfo = start;
                cmd.Start();
                Console.WriteLine("After Console Runner");
            }
            catch(Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

       

    }
}
