
using FacebookTest.Utilities;
using OpenQA.Selenium;

namespace NackademinUITest.Objects
{
    internal class InspirationPage
    {
        private static By InspirationCards => By.XPath("//div[contains(@class,'inspiration_listing_container')]/div[contains(@class,'items-center')]");
        private static By CardTitle => By.XPath("//div[contains(@class,'h5')]");
        private static By SortingDropdown(string button) => By.XPath($"//span[text()='{button}']//ancestor::div[contains(@class,'sort_select_container')]");
        internal static int GetCountOfCards()
        {
            InspirationCards.WaitToBecomeEnabled();
            var inspirationCards = InspirationCards.GetTextFromListOfElements().FindAll(t => !string.IsNullOrEmpty(t)).ToList();
            return inspirationCards.Count;
        }
        public static bool IsEducationNamesSorted()
        {
            Thread.Sleep(TimeSpan.FromSeconds(2));
            var actualTexts = CardTitle.GetTextFromListOfElements().FindAll(t => !string.IsNullOrEmpty(t)).ToList();
            var sortedTexts = actualTexts.OrderBy(x => x).ToList();
            return sortedTexts.SequenceEqual(actualTexts);
        }
        public static void ClickOnDropdownButton(string button)
        {
            SortingDropdown(button).ClickElement(button);
        }
    }
}
