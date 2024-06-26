﻿using FacebookTest.Config;
using FacebookTest.Objects;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Safari;

namespace FacebookTest.Utilities
{
    public class DriverManager
    {
        private IWebDriver driver;
        private static DriverManager? instance;
        public DriverManager() 
        {
            driver = DriverToUse();
            driver.Manage().Window.Maximize();            
        }
        public static DriverManager GetInstance()
        {
            instance ??= new DriverManager();
            return instance;
        }
        public IWebDriver GetWebDriver() { return driver; }

        public void MaximizeWindow()
        {
            driver.Manage().Window.Maximize();
        }
        public static IWebDriver GetDriver()
        {
            return GetInstance().GetWebDriver();
        }
        public static void SwitchDriverToChildWindow()
        {
            GetDriver().SwitchTo().Window(GetDriver().WindowHandles[1]);
        }
        public static void SwitchDriverToParentWindow()
        {
            GetDriver().SwitchTo().Window(GetDriver().WindowHandles[0]);
            SharedPage.ClickOnAcceptAllCookieIfExist();
        }
        public static void CloseWindow()
        {
            GetDriver().Close();
        }
        public void Quit()
        {
            driver.Quit();
            instance = null;
        }
        private IWebDriver DriverToUse()
        {          
            if (string.IsNullOrEmpty(ConfigValues.Browser)|| ConfigValues.Browser.Equals("Chrome"))
            {
                ChromeOptions options = new();
                options.AddArgument("--no-sandbox");
                options.AddUserProfilePreference("safebrowsing.enabled", true);
                options.SetLoggingPreference(LogType.Browser, LogLevel.Severe);
                options.AddArgument("--start-maximized");
                options.AddArgument("--ignore-ssl-errors=yes");
                options.AddArgument("--ignore-certificate-errors");
                options.AddArgument("--disable-extensions");
                options.AddArgument("--disable-popup-blocking");
                options.AddArgument("--force-device-scale-factor=1");
                options.AddArgument("--enable-automation");
                options.AddArgument("--window-size=1920,1080");
                if (ConfigValues.IsBrowserHeadless.ToString().ToLower() == "true")
                {
                    options.AddArgument("--headless=new");
                }
                options.AddArgument("disable-gpu");
                options.AddArgument("--incognito");
                options.AddArgument("--disable-dev-shm-usage");
                return new ChromeDriver(options);               
            }
            else if (ConfigValues.Browser.Equals("Edge"))
            {
                EdgeOptions options = new();
                options.AddArgument("--no-sandbox");
                options.AddUserProfilePreference("safebrowsing.enabled", true);
                options.SetLoggingPreference(LogType.Browser, LogLevel.Severe);
                options.AddArgument("--start-maximized");
                options.AddArgument("--ignore-ssl-errors=yes");
                options.AddArgument("--ignore-certificate-errors");
                options.AddArgument("--disable-extensions");
                options.AddArgument("--disable-popup-blocking");
                options.AddArgument("--force-device-scale-factor=1");
                options.AddArgument("--enable-automation");
                options.AddArgument("--window-size=1920,1080");
                if (ConfigValues.IsBrowserHeadless.ToString().ToLower() == "true")
                {
                    options.AddArgument("--headless=new");
                }
                options.AddArgument("disable-gpu");
                options.AddArgument("--incognito");
                options.AddArgument("--disable-dev-shm-usage");
                return new EdgeDriver(options);
            }
            else if (ConfigValues.Browser.Equals("Safari"))
            {
                SafariOptions options = new();
                return new SafariDriver();
            }
            else
            {
                ChromeOptions options = new();
                options.AddArguments("headless");
                //options.AddUserProfilePreference("profile.default_content_setting_values.cookies", 2);
                options.AddArguments("window-size=1920,1080");
                options.AddArguments("--no-sandbox");
                options.AddArguments("--disable-gpu");
                options.AddArguments("--no-first-run");
                options.AddArguments("--no-default-browser-check");
                options.AddArguments("--ignore-certificate-errors");
                options.AddArguments("--start-maximized");
                return new ChromeDriver(options);
            }       
        }
        public static void NavigateBack()
        {
            GetDriver().Navigate().Back();
            SharedPage.ClickOnAcceptAllCookieIfExist();
        }
    }
}
