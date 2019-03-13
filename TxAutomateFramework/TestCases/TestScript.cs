using NUnit.Framework;
using System;
using GenericFramework.GenericTestCases;


namespace TxAutomateFramework.TestCases
{
    
    [TestFixture]
    [Parallelizable(ParallelScope.Fixtures)
        ]
    public class TestSript
    {

       log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        
        [Test]
        public void RunScript()
        {
			TestSuite obj = new TestSuite();
            try
            {
				obj.DriverScript();

			}
            catch (Exception ex)
            {
                Assert.Fail("Driver script not executed"+ ex.Message);
            }
        }        

    }
}
