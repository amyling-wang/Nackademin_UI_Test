using FacebookTest.Objects;

namespace FacebookTest.StepDefinitions
{
    [Binding]
    internal class HomeSteps
    {
        HomePage _homePage;
        public HomeSteps(HomePage homePage)
        {
            _homePage = homePage;
        }       
        [Then(@"I create a story")]
        public void ThenICreateAStory()
        {
            _homePage.CreateStory();
        }
        [Then(@"I delete the story if present")]
        public void ThenIDeleteTheStory()
        {
            _homePage.DeleteStory();
        }




    }
}
