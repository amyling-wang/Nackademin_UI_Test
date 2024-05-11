using FacebookTest.Utilities;
using OpenQA.Selenium;

namespace FacebookTest.Objects
{
    internal class UtbildningPage
    {
        private static By UtbildningCard => By.XPath("//div[contains(@class,'utbildning_container')]");
        private static By SortingDropdownButton(string button) => By.XPath($"//span[text()='{button}']//parent::button[contains(@class,'toggle-dropdown')]");
        private static By DropdownOption(string option) => By.XPath($"//label[text()='{option}']//preceding-sibling::input[@name='filter']");
        private static By EducationNamesOnCards => By.XPath("//div[contains(@class,'utbildning_container')]//span[@class='h4']");
        public static bool IsUtbildningCardsExists()
        {
            UtbildningCard.WaitToBecomeEnabled();
            return UtbildningCard.IsExist();
        }
        public static void ClickOnSortingDropdownButton(string button)
        {
            SortingDropdownButton(button).WaitAndClickElement(button);
        }
        public static void ClickOnDropdownOption(string option)
        {
            DropdownOption(option).WaitAndClickElement(option);
        }
        public static bool IsEducationNamesSorted()
        {
            EducationNamesOnCards.GetText();
        }
    }
}
