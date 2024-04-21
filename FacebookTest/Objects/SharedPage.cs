using FacebookTest.Config;
using FacebookTest.Utilities;
using OpenQA.Selenium;

namespace FacebookTest.Objects
{
    internal class SharedPage 
    {
        readonly IWebDriver webDriver;
        public SharedPage()
        {
            webDriver = DriverManager.GetDriver();
        }
        //private static By OverlappElement => By.XPath("(//div[contains(@class,'x1uvtmcs')])[3]");
        //private static By HomeTab(string tabName) => By.XPath($"//a[@aria-label='{tabName}']");
        public static By AcceptAllCookieButton() => By.XPath("//button[text()='Tillåt alla']");
        

        //public void ClickOnTab(string tabName)
        //{
        //    OverlappElement.WaitAndClickElement();
        //    HomeTab(tabName).WaitAndClickElement();
        //}
        public void GoToUrl()
        {
            string? url = ConfigValues.Url;
            webDriver.Url = url;
        }
        public void GoToStartSida()
        {
            GoToUrl();
            ClickOnAcceptAllCookieIfExist();
        }
        public static void ClickOnAcceptAllCookieIfExist()
        {
            if (AcceptAllCookieButton().IsExist())
            {
                AcceptAllCookieButton().WaitAndClickElement();
            }
        }

    }
}
    
