using FacebookTest.Config;
using FacebookTest.Utilities;
using OpenQA.Selenium;

namespace FacebookTest.Objects
{
    internal class SharedPage
    {
            
        private By OverlappElement => By.XPath("(//div[contains(@class,'x1uvtmcs')])[3]");
        private By HomeTab(string tabName) => By.XPath($"//a[@aria-label='{tabName}']");
        private By AcceptAllCookieButton() => By.XPath("//a[contains(text(),'Acceptera alla')]");


        public void ClickOnTab(string tabName)
        {
            OverlappElement.WaitAndClickElement();
            HomeTab(tabName).WaitAndClickElement();
        }
        public void GoToUrl()
        {
            string url = ConfigValues.Url;
            Base.GetDriver().Url = url;
        }
        public void GoToStartSida()
        {
            GoToUrl();          
            AcceptAllCookieButton().WaitAndClickElement();
        }
    }
}
    
