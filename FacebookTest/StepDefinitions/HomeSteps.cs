using FacebookTest.Objects;

namespace FacebookTest.StepDefinitions
{
    [Binding]
    internal class HomeSteps
    {
        LoginPage loginPage;
        public HomeSteps(LoginPage loginPage)
        {
            this.loginPage = loginPage;
        }
        [Given(@"I sign in to Facebook")]
        public void GivenISignInToFacebook()
        {
            loginPage.LogIn();
        }

    }
}
