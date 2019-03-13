using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericFramework.Enum
{
    public class EnumClass
    {
        public enum BrowserName
        {
            ie,
            firefox,
            chrome,
            opera,
            edge
        }
        public enum SheetNames
        {
            TestCases,
            login,
            searchitems
        }

        public enum LogStatus
        {
            Inconclusive,
            Skipped,
            Passed,
            Warning,
            Failed
        }
        public enum LocatorType
        {
            Id,
            CssSelector,
            Name,
            ClassName,
            Xpath,
            TagName,
            LinkText,
            PartialLinkText
        }

        public enum APIDataSheet
        {
            TestData,
            ResponseData
        }

        public enum APIType
        {
            GET,
            POST,
            PUT,
            DELETE
        }
        public enum FrameworkType
        {
           web,
           mobile
        }
    }
}
