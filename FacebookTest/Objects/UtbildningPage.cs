using FacebookTest.Utilities;
using OpenQA.Selenium;

namespace FacebookTest.Objects
{
    internal class UtbildningPage
    {
        //same locator as TextOnImage in HomePage
        private static By PageTitle(string text) => By.XPath($"//h1[text()='{text}']");
        public static bool IsTitleTextShown(string text)
        {
            return PageTitle(text).IsExist();
        }
    }
}
