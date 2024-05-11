using FacebookTest.Objects;
using Xunit;

namespace NackademinUITest.StepDefinitions
{
    [Binding]
    internal class UtbildningarSteps
    {
        [Then(@"I should see (.*) cards on the page")]
        public static void ThenIShouldSeeCardsOnThePage(int countOfCards)
        {
            var autualCount = UtbildningPage.GetCountOfCards();
            Assert.True(autualCount == countOfCards, $"Expeted cards count is {countOfCards} , but it is shown {autualCount} on the Utbildningar page");
        }
        [When(@"I click on dropdown button for (.*)")]
        public static void ClickOnDropdownButtonFor(string dropdownButton)
        {
            UtbildningPage.ClickOnSortingDropdownButton(dropdownButton);
        }
        [Then(@"I choose option (.*) in dropdown for (.*)")]
        public void ThenIChooseOptionUtbildningsnamn(string option, string dropdownButton)
        {
            UtbildningPage.ClickOnDropdownOption(option, dropdownButton);
        }
        [Then(@"I verify all cards are sorted by education names")]
        public static void ThenIVerifyAllCardsAreSortedByEducationNames()
        {
            Assert.True(UtbildningPage.IsEducationNamesSorted(), "Education names are not sorted");
        }

    }
}
