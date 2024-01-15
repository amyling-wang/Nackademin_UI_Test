using EnvDTE;
using FacebookTest.Config;
using Interop.UIAutomationClient;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;



namespace FacebookTest.Objects
{
    public class LoginPage
    {
        //private static By EmailField => By.XPath("//input[@id='email']");
        //private static By PasswordField => By.XPath("//input[@id='pass']");
        IWebDriver driver;
        public LoginPage(IWebDriver driver) 
        {
            this.driver = driver;
        }
       
        public void GoToUrl()
        {
            
            driver.Url = ConfigValues.Url;
        }
        public void LogIn()
        {
            GoToUrl();
            driver.FindElement(By.XPath("//button[contains(@id,'u_0_k')]")).Click();
            driver.FindElement(By.XPath("//input[@id='email']")).SendKeys("ling.wang@yh.nackademin.se");
            driver.FindElement(By.XPath("//input[@id='pass']")).SendKeys("Selenium2024#");
            driver.FindElement(By.XPath("//button[@name='login']")).Click();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//a[@aria-label='Facebook']")));
            //IAlert alert = wait.Until(ExpectedConditions.AlertIsPresent());
            //alert.Accept();
            //IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            //js.ExecuteScript("window.alert = function(){};");

        }
    }
}
