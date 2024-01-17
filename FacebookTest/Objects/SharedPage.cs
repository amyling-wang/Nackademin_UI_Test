using FacebookTest.Utilities;
using OpenQA.Selenium;

namespace FacebookTest.Objects
{
    internal class SharedPage : Base
    {
        public SharedPage(IWebDriver driver) : base(driver)
        {
        }      
        private IWebElement overlappElement => FindElement(By.XPath("//div[contains(text(),'To allow or block browser notifications')]//ancestor::div[contains(@class,'x1uvtmcs')]"));
        private IWebElement homeTab(string tabName) => FindElement(By.XPath($"//a[@aria-label='{tabName}']"));
             
        public void ClickOnTab(string tabName)
        {
            WaitAndClick(overlappElement);
            WaitAndClick(homeTab(tabName));
        }
    }
}
    
