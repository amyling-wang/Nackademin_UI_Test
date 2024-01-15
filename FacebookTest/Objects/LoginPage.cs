using FacebookTest.Config;
using FacebookTest.Utilities;
using OpenQA.Selenium;

namespace FacebookTest.Objects
{
    public class LoginPage : Base
    {
        public LoginPage(IWebDriver driver) : base(driver)
        {
        }

        //IWebDriver driver;
        //public LoginPage(IWebDriver driver) 
        //{
        //    this.driver = driver;
        //}
        private IWebElement acceptCookieButton => FindElement(By.XPath("//button[contains(@id,'u_0_k')]"));
        private IWebElement emailField => FindElement(By.XPath("//input[@id='email']"));
        private IWebElement passwordField => FindElement(By.XPath("//input[@id='pass']"));
        private IWebElement loginButton => FindElement(By.XPath("//button[@name='login']"));
        private By facebookLogo = By.XPath("//a[@aria-label='Facebook']");
       
        public void LogIn()
        {
            GoToUrl();
            WaitAndClick(acceptCookieButton);
            emailField.SendKeys(ConfigValues.Username);
            passwordField.SendKeys(ConfigValues.Password);
            loginButton.Click();
            waitUntilElementIsVisible(facebookLogo);          

        }
    }
}
