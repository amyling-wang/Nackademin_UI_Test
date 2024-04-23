using FacebookTest.Config;
using FacebookTest.Utilities;
using OpenQA.Selenium;
using static System.Net.Mime.MediaTypeNames;

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
        private static By MainText(string text) => By.XPath($"//h1[text()='{text}']");
        private static By MainText() => By.XPath("//h1");


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
        public static bool IsTextOnImageShown(string titleText)
        {
            MainText(titleText).WaitUntilElementIsVisible();
            return MainText(titleText).IsExist();
        }
        public static string GetTextOnMainImage()
        {
            return MainText().GetText();
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
    
