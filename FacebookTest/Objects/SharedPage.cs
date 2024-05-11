using FacebookTest.Config;
using FacebookTest.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

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
        private static By LinkInTopMenuSection(string linkText) => By.XPath($"//ul[@id='primary-menu']//li[contains(@class,'menu-item')]/a[contains(text(),'{linkText}')]");


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
        public static string GetPageTitleText()
        {
            MainText().WaitToBecomeEnabled();
            var text = MainText().GetText();
            return MainText().GetText();
        }
        public void GoToStartSida()
        {
            GoToUrl();
            ClickOnAcceptAllCookieIfExist();
        }
        public static void ClickOnAcceptAllCookieIfExist()
        {
            if (AcceptAllCookieButton().IsExist() && AcceptAllCookieButton().IsDisplayed())
            {
                AcceptAllCookieButton().WaitAndClickElement();
            }
        }
        public static void ClickOnLinkInTopMenuSection(string linkText)
        {
            LinkInTopMenuSection(linkText).WaitToBecomeClickable();
            LinkInTopMenuSection(linkText).ClickElement();
        }
    }
}
    
