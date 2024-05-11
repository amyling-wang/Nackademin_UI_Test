using FacebookTest.Utilities;
using OpenQA.Selenium;

namespace FacebookTest.Objects
{
    internal class UtbildningPage
    {
        private static By UtbildningCard => By.XPath("//div[contains(@class,'utbildning_container')]");
        private static By SortingDropdownButton(string button) => By.XPath($"//span[text()='{button}']//parent::button[contains(@class,'toggle-dropdown')]");
        private static By DropdownOption(string option) => By.XPath($"(//label[text()='{option}']//preceding-sibling::input[@type='radio'])[1]");
        private static By EducationNamesOnCards => By.XPath("//div[contains(@class,'utbildning_container')]//span[@class='h4']");
        private static By EducationCategoryOnCards(string category) => By.XPath($"//div[contains(@class,'utbildning_container')]//span[contains(text(),'{category}')]");
        private static By ResetFilterButton => By.XPath("//span[text()='Rensa alla filter']/..");
        public static int GetCountOfCards()
        {
            UtbildningCard.WaitToBecomeEnabled();
            var utbildningCards = UtbildningCard.GetTextFromListOfElements().FindAll(t => !string.IsNullOrEmpty(t)).ToList();
            return utbildningCards.Count;
        }
        public static void ClickOnSortingDropdownButton(string button)
        {
            SortingDropdownButton(button).WaitAndClickElement(button);
        }
        public static void ClickOnDropdownOption(string option)
        {
            DropdownOption(option).WaitToBecomeAvailable();
            DropdownOption(option).MoveToElementAndClick(option);
        }
        public static bool IsEducationNamesSorted()
        {
            var actualTexts = EducationNamesOnCards.GetTextFromListOfElements().FindAll(t => !string.IsNullOrEmpty(t)).ToList();
            var sortedTexts = actualTexts.OrderBy(x => x).ToList();
            return sortedTexts.SequenceEqual(actualTexts);
        }
        public static bool IsCategoryNameExistOnCards(string category)
        {
            EducationCategoryOnCards(category).WaitToBecomeEnabled();
            return EducationCategoryOnCards(category).IsDisplayed();
        }
        public static void ClickOnResetFilters()
        {
            ResetFilterButton.ClickElement();
        }
    }
}
