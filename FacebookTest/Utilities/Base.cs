using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using FacebookTest.Config;

namespace FacebookTest.Utilities
{
    public class Base
    {
        IWebDriver driver;
        public Base(IWebDriver driver)
        {
            this.driver = driver;
        }
        public IWebElement FindElement(By by)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
                wait.Until(ExpectedConditions.ElementIsVisible(by));
                return driver.FindElement(by);
            }
            catch
            {
                return null;
            }


        }
        public void WaitAndClick(IWebElement element)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));            
            IWebElement webelement = wait.Until(ExpectedConditions.ElementToBeClickable(element));
            webelement.Click();
        }
        public void GoToUrl()
        {

            driver.Url = ConfigValues.Url;
        }
        public void WaitUntilElementIsVisible(By by)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            wait.Until(ExpectedConditions.ElementIsVisible(by));
        }
    }
}
