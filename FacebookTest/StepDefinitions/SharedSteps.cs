using FacebookTest.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacebookTest.StepDefinitions
{
    [Binding]
    internal class SharedSteps
    {
        LoginPage loginPage;
        HomePage homePage;
        public SharedSteps(LoginPage loginPage, HomePage homePage)
        {
            this.loginPage = loginPage;
            this.homePage = homePage;
        }
        [Given(@"I sign in to Facebook")]
        public void GivenISignInToFacebook()
        {
            loginPage.LogIn();
        }
        [When(@"I click on (.*) tab")]
        public void WhenIClickOnHomeTab(string tabName)
        {
            homePage.ClickOnTab(tabName);
        }
    }
}
