using FacebookTest.Utilities;
using OpenQA.Selenium;

namespace FacebookTest.Objects
{
    internal class FörFöretagPage
    {
        private static By PageTitle(string text) => By.XPath($"//h1/span[text()='{text}']");
        private static By CompanyLogo => By.XPath("//div[contains(@class,'logo_container')]/img");
        private static By Field(string placeholder) => By.XPath($"//*[@placeholder='{placeholder}']");
        private static By SkickaButton => By.XPath("//input[@value='Skicka']");
        private static By ErrorMessage => By.XPath("//h2[contains(@class,'gform_submission_error')]");
        public static bool IsCompanyLogsShown()
        {
            CompanyLogo.WaitForPresenceOfAllElements();
            return CompanyLogo.IsDisplayed();
        }
        public static bool IsPageTitleForFörFöretagShown(string text)
        {
            return PageTitle(text).IsExist();
        }
        public static void SendTextInField(string filedName, string text)
        {
            Field(filedName).MoveToElement(filedName);
            Field(filedName).SendKeysAndWait(text);
        }
        public static void ClickOnSkickaButton()
        {
            SkickaButton.MoveToElementAndClick();
        }
        public static string GetErrorMessage()
        {
            ErrorMessage.WaitToBecomeEnabled();
            return ErrorMessage.GetText();
        }
    }
}
