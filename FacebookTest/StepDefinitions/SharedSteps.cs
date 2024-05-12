using FacebookTest.Objects;
using Xunit;

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
        [When(@"I click on (.*) in main menu section")]
        public static void ClickOnUtbildningarInMainMenuSection(string linkText)
        {
            SharedPage.ClickOnLinkInTopMenuSection(linkText);
            //SharedPage.ClickOnAcceptAllCookieIfExist();
        }
        [Then(@"I should see page with title (.*)")]
        public static void VerifyPageTitle(string pageTitle)
        {
            SharedPage.ClickOnAcceptAllCookieIfExist();
            Assert.True(SharedPage.GetPageTitleText().Equals(pageTitle), $"Expected page title is {pageTitle}, but it is shown {SharedPage.GetPageTitleText()}");

        }
        [Then(@"I should see news letter section title on the page")]
        public static void ThenIShouldSeeNewsLetterSectionTitleOnThePage()
        {
            Assert.True(SharedPage.IsNewsLetterSectionTitleShown(), "News letter section title is not shown on the page");
        }

    }
}
