using FacebookTest.Config;
using FacebookTest.Utilities;
using OpenQA.Selenium;

namespace FacebookTest.Objects
{
    internal class LogIn : Base
    {
        public LogIn(IWebDriver driver) : base(driver)
        {
        }

        private IWebElement acceptCookieButton => FindElement(By.XPath("//button[contains(@id,'u_0_k')]"));
        private IWebElement emailField => FindElement(By.XPath("//input[@id='email']"));
        private IWebElement passwordField => FindElement(By.XPath("//input[@id='pass']"));
        private IWebElement loginButton => FindElement(By.XPath("//button[@name='login']"));
        private By facebookLogo = By.XPath("//a[@aria-label='Facebook']");
        public void Login()
        {
            GoToUrl();
            ClickOnAcceptionCookiesButton();
            EnterUserName();
            EnterPassword();
            ClickOnLoginButton();
            WaitForFaceBookLogoToBeVisible();

        }  
        public void ClickOnAcceptionCookiesButton()
        {
            WaitAndClick(acceptCookieButton);
        }
        public void EnterUserName()
        {
            emailField.SendKeys(ConfigValues.Username);
        }
        public void EnterPassword()
        {
            passwordField.SendKeys(ConfigValues.Password);
        }
        public void ClickOnLoginButton()
        {
            loginButton.Click();
        }
        public void WaitForFaceBookLogoToBeVisible()
        {
            WaitUntilElementIsVisible(facebookLogo);
        }
    }
}
    
