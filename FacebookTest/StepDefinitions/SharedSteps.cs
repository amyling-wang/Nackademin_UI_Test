using FacebookTest.Objects;

namespace FacebookTest.StepDefinitions
{
    [Binding]
    internal class SharedSteps
    {
        SharedPage sharedPage;
        LogIn loginPage;
        public SharedSteps(SharedPage sharedPage, LogIn loginPage)
        {
            this.sharedPage = sharedPage;
            this.loginPage = loginPage;
        }
        [Given(@"I sign in to Facebook")]
        public void GivenISignInToFacebook()
        {
            loginPage.Login();
        }
        [When(@"I click on (.*) tab")]
        public void WhenIClickOnHomeTab(string tabName)
        {
            sharedPage.ClickOnTab(tabName);
        }
    }
}
