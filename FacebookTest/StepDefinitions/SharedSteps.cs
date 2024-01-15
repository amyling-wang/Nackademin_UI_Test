using FacebookTest.Objects;

namespace FacebookTest.StepDefinitions
{
    [Binding]
    internal class SharedSteps
    {
        SharedPage sharedPage;
        public SharedSteps(SharedPage sharedPage)
        {
            this.sharedPage = sharedPage;
        }
        [Given(@"I sign in to Facebook")]
        public void GivenISignInToFacebook()
        {
            sharedPage.LogIn();
        }
        [When(@"I click on (.*) tab")]
        public void WhenIClickOnHomeTab(string tabName)
        {
            sharedPage.ClickOnTab(tabName);
        }
    }
}
