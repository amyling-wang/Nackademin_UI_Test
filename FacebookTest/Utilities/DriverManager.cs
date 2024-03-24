using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace FacebookTest.Utilities
{
    public class DriverManager
    {
        private IWebDriver driver;
        private static DriverManager? instance;
        public DriverManager() 
        {
            driver = new ChromeDriver();
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
        public void Quit()
        {
            driver.Quit();
            instance = null;
        }

    }
}
