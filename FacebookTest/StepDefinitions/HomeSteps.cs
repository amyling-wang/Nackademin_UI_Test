using FacebookTest.Objects;
using FacebookTest.Utilities;
using Xunit;

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
        //[Then(@"I create a story")]
        //public void CreateAStory()
        //{
        //    _homePage.CreateStory();
        //}
        //[Then(@"I delete the story if present")]
        //public void DeleteTheStory()
        //{
        //    _homePage.DeleteStory();
        //}

        [When(@"I click on page title Nackademin")]
        public void WhenIClickOnPageTitleNackademin()
        {
            _homePage.ClickOnPageTitle();
        }
        [Then(@"I should see image with text '(.*)'")]
        public void ThenIShouldSeeImageWithText(string text)
        {
            Assert.True(HomePage.IsMainImageShown(), "Main image is not shown on Nackademins Home page");
            Assert.True(HomePage.IsTextOnImageShown(text), "Text on image is not shown on Nackademins Home page");
            
        }
        [Then(@"I click on the button (.*)")]
        public static void ThenIClickOnTheButtonHittaUtbildning(string buttonText)
        {
            HomePage.ClickOnHittaUtbildningButton(buttonText);
        }
        [Then(@"I should see page with title (.*)")]
        public static void ThenIShouldSeePageWithTitleUtbildningarOnAChildWindow(string titleText)
        {
            DriverManager.SwitchDriverToChildWindow();
            Assert.True(UtbildningPage.IsTitleTextShown(titleText), "Title is not shown on Utbildnings page when clicking on Utbildnings button on Home page");
            DriverManager.SwitchDriverToParentWindow();
        }



    }
}
