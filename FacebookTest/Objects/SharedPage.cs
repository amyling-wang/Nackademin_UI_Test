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
        private static By HeaderTitle(string text) => By.XPath($"//span[text()='{text}']");
        private static By MainText() => By.XPath("//h1");
        private static By Button(string buttonText) => By.XPath($"//a[text()='{buttonText}']");


        //public void ClickOnTab(string tabName)
        //{
        //    OverlappElement.WaitAndClickElement();
        //    HomeTab(tabName).WaitAndClickElement();
        //}
        public void ClickOnButton(string text)
        {
            Button(text).MoveToElementAndClick();
        }
        public void GoToUrl()
        {
            string? url = ConfigValues.Url;
            webDriver.Url = url;
        }
        public static bool IsHeaderTitleShown(string titleText)
        {
            HeaderTitle(titleText).WaitUntilElementIsVisible();
            return HeaderTitle(titleText).IsExist();
        }
        public static string GetTextOnMainImage()
        {
            return MainText().GetText();
        }
        public void GoToStartSida()
        {
            GoToUrl();
            //ClickOnAcceptAllCookieIfExist();
        }
        //public static void ClickOnAcceptAllCookieIfExist()
        //{
        //    if (AcceptAllCookieButton().IsExist())
        //    {
        //        AcceptAllCookieButton().WaitAndClickElement();
        //    }
        //}

    }
}
    
