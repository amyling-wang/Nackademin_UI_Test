using EnvDTE;
using FacebookTest.Config;
using FacebookTest.Support;
using Interop.UIAutomationClient;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;



namespace FacebookTest.Objects
{
    public class LoginPage
    {
        
        IWebDriver driver;
        public LoginPage(IWebDriver driver) 
        {
            this.driver = driver;
        }
        private By acceptCookieButton = By.XPath("//button[contains(@id,'u_0_k')]");
        private By emailField = By.XPath("//input[@id='email']");
        private By passwordField = By.XPath("//input[@id='pass']");
        private By loginButton = By.XPath("//button[@name='login']");
        public void GoToUrl()
        {
            
            driver.Url = ConfigValues.Url;
        }
        public void LogIn()
        {
            GoToUrl();
            driver.WaitAndClick(acceptCookieButton);
            driver.FindElement(emailField).SendKeys(ConfigValues.Username);
            driver.FindElement(passwordField).SendKeys(ConfigValues.Password);
            driver.FindElement(loginButton).Click();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//a[@aria-label='Facebook']")));           

        }
    }
}
