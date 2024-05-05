using FacebookTest.Config;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Safari;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

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
                options.AddArguments("headless");
                //options.AddUserProfilePreference("profile.default_content_setting_values.cookies", 2);
                options.AddArguments("window-size=1920,1080"); // Adjust window size as needed
                options.AddArguments("--no-sandbox");
                options.AddArguments("--disable-gpu");
                options.AddArguments("--no-first-run");
                options.AddArguments("--no-default-browser-check");
                options.AddArguments("--ignore-certificate-errors");
                options.AddArguments("--start-maximized");
                return new ChromeDriver(options);               
            }
            else if (ConfigValues.Browser.Equals("Edge"))
            {
                EdgeOptions options = new();
                options.AddUserProfilePreference("profile.default_content_setting_values.cookies", 2);
                return new EdgeDriver(options);
            }
            else if (ConfigValues.Browser.Equals("Safari"))
            {
                return new SafariDriver();
            }
            else
            {
                return new ChromeDriver();
            }       
        }
        public static void NavigateBack()
        {
            GetDriver().Navigate().Back();
        }
    }
}
