using FacebookTest.Config;
using FacebookTest.Utilities;
using OpenQA.Selenium;

namespace FacebookTest.Objects
{
    internal class SharedPage : Base
    {
        public SharedPage(IWebDriver driver) : base(driver)
        {
        }

        private IWebElement acceptCookieButton => FindElement(By.XPath("//button[contains(@id,'u_0_k')]"));
        private IWebElement emailField => FindElement(By.XPath("//input[@id='email']"));
        private IWebElement passwordField => FindElement(By.XPath("//input[@id='pass']"));
        private IWebElement loginButton => FindElement(By.XPath("//button[@name='login']"));
        private By facebookLogo = By.XPath("//a[@aria-label='Facebook']");
        private IWebElement overlappElement => FindElement(By.XPath("(//div[contains(@class,'x1uvtmcs')])[3]"));
        private IWebElement homeTab(string tabName) => FindElement(By.XPath($"//a[@aria-label='{tabName}']"));
        public void LogIn()
        {
            GoToUrl();
            WaitAndClick(acceptCookieButton);
            emailField.SendKeys(ConfigValues.Username);
            passwordField.SendKeys(ConfigValues.Password);
            loginButton.Click();
            waitUntilElementIsVisible(facebookLogo);

        }
        public void ClickOnTab(string tabName)
        {
            WaitAndClick(overlappElement);
            WaitAndClick(homeTab(tabName));
        }
    }
}
    
