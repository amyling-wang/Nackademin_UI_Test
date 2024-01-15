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
        public void CreateAStory()
        {
            _homePage.CreateStory();
        }
        [Then(@"I delete the story if present")]
        public void DeleteTheStory()
        {
            _homePage.DeleteStory();
        }




    }
}
