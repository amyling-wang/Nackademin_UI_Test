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
        [When(@"I click on page title Nackademin")]
        public void WhenIClickOnPageTitleNackademin()
        {
            HomePage.ClickOnPageTitle();
            SharedPage.ClickOnAcceptAllCookieIfExist();
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
            DriverManager.CloseWindow();
            DriverManager.SwitchDriverToParentWindow();
        }
        [Then(@"I verify below mentiond carts and related links for them")]
        public static void ThenIVerifyBelowMentiondCartsAndRelatedLinksForThem(Table table)
        {
            var cartNames = table.Rows.Select(r => r["Cart name"]).ToList();
            foreach (var cartName in cartNames)
            {
                Assert.True(HomePage.IsCartImgShown(cartName), $"Img for cart '{cartName}' is not shown on Home page");
                Assert.True(HomePage.IsTitleUnderCartShown(cartName), $"Title under cart '{cartName}' is not shown on Home page");
                Assert.True(HomePage.IsInformationTextShownUnderCart(cartName), $"Information text under cart '{cartName}' is not shown on Home page");
                HomePage.ClickOnLäsMerLinkUnderCart(cartName);
                var pageTitle = cartName;
                if(!pageTitle.Equals("För Företag"))
                {
                    if (pageTitle.Equals("Kurser"))
                    {
                        pageTitle = "Kurs";
                    }
                    UtbildningPage.IsTitleTextShown(pageTitle);
                    HomePage.ClickOnPageTitle();
                    SharedPage.ClickOnAcceptAllCookieIfExist();
                }
                else
                {
                    DriverManager.SwitchDriverToChildWindow();
                    Assert.True(FörFöretagPage.IsPageTitleForFörFöretagShown("För företag"), $"Title text '{pageTitle}' is not shown on 'För företag' page");
                    DriverManager.CloseWindow();
                    DriverManager.SwitchDriverToParentWindow();
                }
            }
        }
        [Then(@"I Verify below sections on the page")]
        public static void ThenIVerifyBelowSectionsOnThePage(Table table)
        {
            var sectionTitles = table.Rows.Select(r => r["Section title"]).ToList();
            var sectionCategories = table.Rows.Select(r => r["Section category"]).ToList();
            var sectionLinks = table.Rows.Select(r => r["Section link"]).ToList();
        }

    }
}
