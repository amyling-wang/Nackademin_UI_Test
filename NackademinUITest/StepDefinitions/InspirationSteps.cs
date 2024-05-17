using NackademinUITest.Objects;
using Xunit;

namespace NackademinUITest.StepDefinitions
{
    [Binding]
    internal class InspirationSteps
    {
        [Then(@"I should see (.*) cards on the page by default")]
        public static void ThenIShouldSeeCardsOnThePageByDefault(int cardCount)
        {
            var actualCount = InspirationPage.GetCountOfCards();
            Assert.True(actualCount == cardCount, $"Expected count for cards in Inspiration page is {cardCount}, but it is shown {actualCount}");
        }
        [Then(@"I verify all cards are sorted by names")]
        public static void ThenIVerifyAllCardsAreSortedByNames()
        {
            Assert.True(InspirationPage.IsEducationNamesSorted(), "Cards did not get sorted after clicking on 'Utbildningsnamn' in dropdown for 'Sortera'");
        }
        [When(@"I click on button for (.*)")]
        public void ClickOnButtonForSortera(string button)
        {
            InspirationPage.ClickOnDropdownButton(button);
        }

    }
}
