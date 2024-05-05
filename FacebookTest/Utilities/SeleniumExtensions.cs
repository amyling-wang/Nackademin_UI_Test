using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using FacebookTest.Config;
using OpenQA.Selenium.Interactions;

namespace FacebookTest.Utilities
{
    public static class SeleniumExtensions
    {        
        private static IWebDriver GetDriver()
        {
            return DriverManager.GetDriver();
        }       
        public static IWebElement FindElement(this By locator)
        {
            locator.WaitToBecomeAvailable();
            return GetDriver().FindElement(locator);
        }
        private static WebDriverWait CreateWait()
        {
            ConfigValues config = new();
            return new WebDriverWait(GetDriver(), TimeSpan.FromMilliseconds(config.PageLoadTiemout()));
        }
        public static void WaitAndClick(IWebElement element)
        {
            WebDriverWait wait = new WebDriverWait(GetDriver(), TimeSpan.FromSeconds(10));            
            IWebElement webelement = wait.Until(ExpectedConditions.ElementToBeClickable(element));
            webelement.Click();
        }
        
        public static void WaitUntilElementIsVisible(this By locator, double? timeToWaitInMilliSeconds = null, string locatorDetails = null)
        {
            try
            {
                var wait = CreateSpecificTimeWait(timeToWaitInMilliSeconds);
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(locator));
            }
            catch (Exception e)
            {
                throw new WebDriverTimeoutException($"Locator for {locatorDetails} is not visible on the webpage, exception message {e.Message}");
            }
        }

        public static void WaitToBecomeAvailable(this By locator, string locatorName = null, double? timeToWaitInMilliSeconds = null)
        {
            try
            {
                var wait = CreateSpecificTimeWait(timeToWaitInMilliSeconds);
                wait.Until(ExpectedConditions.ElementExists(locator));
            }
            catch (Exception e)
            {
                if (!string.IsNullOrEmpty(locatorName))
                {
                    throw new WebDriverTimeoutException($"Locator '{locatorName}' is not displayed on the page, Exception : {e.Message}");
                }
                else
                {
                    throw new WebDriverTimeoutException($"Locator is not displayed on the page, Exception : {e.Message}");
                }
            }
        }
    
        public static void WaitToBecomeClickable(this By locator, string locatorName = null)
        {
            locator.WaitToBecomeEnabled();
            try
            {
                var wait = CreateWait();
                wait.Until(ExpectedConditions.ElementToBeClickable(locator));
            }
            catch (Exception e)
            {
                if (!string.IsNullOrEmpty(locatorName))
                {
                    throw new WebDriverTimeoutException($"Locator '{locatorName}' is still not clickable, exception message " + e.Message);
                }
                else
                {
                    throw new WebDriverTimeoutException($"Locator is still not clickable, exception message " + e.Message);
                }
            }
        }
        public static void WaitToBecomeEnabled(this By locator)
        {
            ConfigValues config = new();
            int secondsToWait = config.PageLoadTiemout() / 1000;
            for (int i = 0; i < secondsToWait; i++)
            {
                if (locator.IsExist())
                {
                    break;
                }

                Thread.Sleep(TimeSpan.FromSeconds(1));
                if (i == secondsToWait - 1)
                {
                    throw new ApplicationException($"Element is not enabled after waiting for " + secondsToWait + " seconds");
                }
            }
        }
        public static bool IsExist(this By locator)
        {
            return GetDriver().FindElements(locator).Any();
        }

        public static bool IsDisplayed(this By locator)
        {
            return locator.FindElement().Displayed;
        }
        private static WebDriverWait CreateSpecificTimeWait(double? timeToWaitInMilliSeconds = null)
        {
            if (timeToWaitInMilliSeconds == null)
            {
                ConfigValues config = new();
                timeToWaitInMilliSeconds = config.PageLoadTiemout();
            }
            return new WebDriverWait(GetDriver(), TimeSpan.FromMilliseconds((double)timeToWaitInMilliSeconds));
        }
        public static void WaitAndClickElement(this By locator, string locatorDetails = null)
        {
            locator.WaitUntilElementIsVisible(locatorDetails : locatorDetails);
            locator.WaitToBecomeClickable(locatorDetails);

            ClickElement(locator, locatorDetails);
        }
        public static void ClickElement(this By locator, string locatorDetails = null)
        {
            locator.WaitToBecomeAvailable(locatorDetails);
            var jsDriver = (IJavaScriptExecutor)GetDriver();
            var element = locator.FindElement();
            string highlightJavascript = @"arguments[0].style.cssText = ""border-width: 2px; border-style: solid; border-color: green"";";
            jsDriver.ExecuteScript(highlightJavascript, new object[] { element });

            try
            {
                locator.FindElement().Click();
            }
            catch (Exception e)
            {
                if (locatorDetails is not null)
                {
                    throw new ApplicationException($"Exception occured while clicking on element, {locatorDetails} " + e.Message);
                }
                else
                {
                    throw new ApplicationException($"Exception occured while clicking on element, " + e.Message);
                }
            }
        }
        public static void MoveToElementAndClick(this By locator, string locatorDetails = null)
        {
            locator.MoveToElement();
            locator.WaitAndClickElement(locatorDetails);
        }
        public static void MoveToElement(this By locator, string locatorDetails = null, bool isScrollIntoView = true)
        {
            locator.WaitToBecomeAvailable();
            string scriptToExecute = @"arguments[0].scrollIntoView({block:'center'});";

            try
            {
                if (isScrollIntoView)
                {
                    ((IJavaScriptExecutor)GetDriver()).ExecuteScript(scriptToExecute, locator.FindElement());
                }
            }
            catch (Exception)
            {
                if (locatorDetails is not null)
                {
                    throw new ApplicationException($"Exception occured while moving to an element '{locatorDetails}' using javascript");
                }
                else
                {
                    throw new ApplicationException($"Exception occured while moving to an element using javascript");
                }
            }


            Actions actions = new(GetDriver());
            actions.MoveToElement(locator.FindElement());

            actions.Perform();
        }

        public static void ClickUsingJavaScriptExecutor(this By locator, string locatorDetails = null)
        {
            locator.WaitToBecomeAvailable(locatorDetails);
            var jsDriver = (IJavaScriptExecutor)GetDriver(); 
            var element = locator.FindElement();
            string highlightJavascript = @"arguments[0].style.cssText = ""border-width: 2px; border-style: solid; border-color: red"";";
            jsDriver.ExecuteScript(highlightJavascript, new object[] { element });
            try
            {
                ((IJavaScriptExecutor)GetDriver()).ExecuteScript("arguments[0].click();", element);
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Exception occured while clicking {locatorDetails} using javascript, exception message " + ex.Message);
            }

        }
        public static void SendKeys(this By locator, string text)
        {
            locator.WaitToBecomeAvailable();
            locator.FindElement().SendKeys(text);
        }
        public static void Clear(this By locator)
        {
            locator.WaitToBecomeAvailable();
            locator.WaitUntilElementIsVisible();
            locator.WaitToBecomeEnabled();
            locator.FindElement().Clear();            
        }
        public static void ClearThenSendKeysAndWait(this By locator, string text)
        {
            locator.Clear();
            locator.SendKeys(text);
        }
        public static string GetAttributeValue(this By locator, string attributeName)
        {
            locator.WaitToBecomeAvailable();
            string attributeValue;
            try
            {
                attributeValue = locator.FindElement().GetAttribute(attributeName);
            }
            catch (StaleElementReferenceException)
            {
                Thread.Sleep(TimeSpan.FromSeconds(1));
                attributeValue = locator.FindElement().GetAttribute(attributeName);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Unable to get attribute value for attribute '" + attributeName + "', exception occured " + ex.Message);
            }
            return attributeValue;
        }
        public static string GetText(this By locator)
        {
            return locator.FindElement().Text.Trim();
        }

        public static int GetCountOfElements(this By locator)
        {
            return GetDriver().FindElements(locator).Count;
        }
        public static void SendKeysAndWait(this By locator, string text)
        {
            locator.WaitToBecomeAvailable();
            locator.WaitToBecomeEnabled();
            locator.WaitToBecomeClickable();
            locator.FindElement().SendKeys(text);
        }

    }
}
