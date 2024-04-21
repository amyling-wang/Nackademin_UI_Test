using FacebookTest.Utilities;
using OpenQA.Selenium;

namespace FacebookTest.Objects
{
    internal class FörFöretagPage
    {
        private static By PageTitle(string text) => By.XPath($"//h1/span[text()='{text}']");
        public static bool IsPageTitleForFörFöretagShown(string text)
        {
            return PageTitle(text).IsExist();
        }
    }
}
