using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenericFramework.Enum;
using GenericFramework.ExtentReport;
using GenericFramework.GenericMethod;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;

namespace TxAutomateFramework.Drivers
{
	public class WebDriver
	{
		private IWebDriver _currentWebDriver;

		public IWebDriver Current()
		{
			
				if (_currentWebDriver != null)
					return _currentWebDriver;
				string driverPath = GeneralMethods.GetDriversPath();
				switch (BrowserConfig)
				{
					case "IE":
						//_currentWebDriver = new InternetExplorerDriver(new InternetExplorerOptions() { IgnoreZoomLevel = true }) { Url = SeleniumBaseUrl };
						var options = new InternetExplorerOptions();
						options.IntroduceInstabilityByIgnoringProtectedModeSettings = true;
						_currentWebDriver = new InternetExplorerDriver(driverPath);
						break;
					case "Chrome":
						ChromeOptions optionsc = new ChromeOptions();
						optionsc.AddArguments("--start-maximized");
						optionsc.AddArguments("disable-infobars");
						_currentWebDriver = new ChromeDriver(driverPath, optionsc);
						
						break;
					case "Firefox":
						FirefoxProfileManager Manager = new FirefoxProfileManager();
						FirefoxProfile profile = Manager.GetProfile("Default");
						FirefoxDriverService Services = FirefoxDriverService.CreateDefaultService(driverPath);
						FirefoxOptions option = new FirefoxOptions();
						option.Profile = profile;
						_currentWebDriver = new FirefoxDriver(Services, option, TimeSpan.FromSeconds(60));
						_currentWebDriver.Manage().Window.Maximize();
						
						break;
					default:
						throw new NotSupportedException($"{BrowserConfig} is not a supported browser");
				}
           
                return _currentWebDriver;
			
		}

		private WebDriverWait _wait;
		public WebDriverWait Wait
		{
			get
			{
				if (_wait == null)
				{
					this._wait = new WebDriverWait(Current(), TimeSpan.FromSeconds(10));
				}
				return _wait;
			}
		}

		public string BrowserConfig => ConfigurationManager.AppSettings["browser"];

      
		protected string SeleniumBaseUrl => ConfigurationManager.AppSettings["seleniumBaseUrl"];

		public void Quit()
		{
			_currentWebDriver?.Quit();
		}

        
    }
}
