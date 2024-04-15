using FacebookTest.Objects;
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
        [Then(@"I verify below mentioned side menus are shown on the page")]
        public void VerifySideMenusVisibilityOnHome(Table table)
        {
            var menus = table.Rows.Select(r => r["Side meny"]).ToList();
            foreach (var menu in menus)
            {
                Assert.True(_homePage.GetSideMeny(menu) is not null, $"Menu with name '{menu}' does not exist on the page");
            }
        }




    }
}
