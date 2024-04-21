using FacebookTest.Objects;
using FacebookTest.Utilities;

namespace FacebookTest.StepDefinitions
{
    [Binding]
    internal class SharedSteps
    {
        SharedPage sharedPage;
        public SharedSteps(SharedPage sharedPage)
        {
            this.sharedPage = sharedPage;
           // this.loginPage = loginPage;
        }
        //[Given(@"I sign in to Facebook")]
        //public void GivenISignInToFacebook()
        //{
        //    loginPage.Login();
        //}
        //[When(@"I click on (.*) tab")]
        //public void WhenIClickOnHomeTab(string tabName)
        //{
        //    sharedPage.ClickOnTab(tabName);
        //}

        [Given(@"I navigate to Nackademin")]
        public void NavigateToNackademin()
        {
            sharedPage.GoToStartSida();
        }        
    }
}
