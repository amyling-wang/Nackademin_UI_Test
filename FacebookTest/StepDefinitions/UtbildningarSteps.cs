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
            UtbildningPage.ClickOnDropdownOption(option);
            UtbildningPage.ClickOnSortingDropdownButton(dropdownButton);
        }
        [Then(@"I verify all cards are sorted by education names")]
        public static void ThenIVerifyAllCardsAreSortedByEducationNames()
        {
            Assert.True(UtbildningPage.IsEducationNamesSorted(), "Education names are not sorted");
        }
        [When(@"I click on dropdown button (.*) and choose below mentoned options and verify")]
        public void WhenIClickOnDropdownButtonOmradeAndChooseBelowMentonedOptionsAndVerify(string button, Table table)
        {
            var options = table.Rows.Select(t => t["Option"]).ToList();
            foreach(var option in options)
            {
                UtbildningPage.ClickOnSortingDropdownButton(button);
                UtbildningPage.ClickOnDropdownOption(option);
                SharedPage.ClickOnAcceptAllCookieIfExist();
                Assert.True(SharedPage.GetPageTitleText().Equals(option), $"Page did not redirect to {option} When clickling sorting on option '{option}' in {button}");
                Assert.True(UtbildningPage.IsCategoryNameExistOnCards(option), $"Sorting for {option} in {button} is not working as expected");
                UtbildningPage.ClickOnResetFilters();
            }
        }


    }
}
