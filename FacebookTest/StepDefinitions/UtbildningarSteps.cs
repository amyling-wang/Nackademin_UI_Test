using FacebookTest.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace NackademinUITest.StepDefinitions
{
    [Binding]
    internal class UtbildningarSteps
    {
        [Then(@"I should see some cards on the page")]
        public static void ThenIShouldSeeCardsOnThePage()
        {
            Assert.True(UtbildningPage.IsUtbildningCardsExists(), $"Expected count of utbildning cards is {count}, but it is shown {actualCount} cards on the page");
        }
        [When(@"I click on dropdown button for (.*)")]
        public static void ClickOnDropdownButtonFor(string dropdownButton)
        {
            
        }

    }
}
