using FacebookTest.Config;
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
            if (ConfigValues.Browser.Equals("Chrome"))
            {
                return new ChromeDriver();
                
            }
            else if (ConfigValues.Browser.Equals("Edge"))
            {
                return new EdgeDriver();
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

    }
}
