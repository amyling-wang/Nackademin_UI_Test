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
            Assert.True(SharedPage.IsTextOnImageShown(text), "Text on image is not shown on Nackademins Home page");
            
        }
        [When(@"I click on the button (.*)")]
        public static void ThenIClickOnTheButtonHittaUtbildning(string buttonText)
        {
            HomePage.ClickOnHittaUtbildningButton(buttonText);
        }
        [Then(@"I should see page with title (.*)")]
        public static void ThenIShouldSeePageWithTitleUtbildningarOnAChildWindow(string titleText)
        {
            DriverManager.SwitchDriverToChildWindow();
            Assert.True(SharedPage.IsTextOnImageShown(titleText), "Title is not shown on Utbildnings page when clicking on Utbildnings button on Home page");
            DriverManager.CloseWindow();
            DriverManager.SwitchDriverToParentWindow();
        }
        [Then(@"I verify below mentiond cards and related links for them")]
        public static void ThenIVerifyBelowMentiondCartsAndRelatedLinksForThem(Table table)
        {
            var cartNames = table.Rows.Select(r => r["Cart name"]).ToList();
            foreach (var cartName in cartNames)
            {
                Assert.True(HomePage.IsCartImgShownInMultipleCartSection(cartName), $"Img for cart '{cartName}' is not shown on Home page");
                Assert.True(HomePage.IsTitleUnderCartShownInMultipleCartSection(cartName), $"Title under cart '{cartName}' is not shown on Home page");
                Assert.True(HomePage.IsInformationTextShownUnderCartInMultipleCartSection(cartName), $"Information text under cart '{cartName}' is not shown on Home page");
                HomePage.ClickOnLäsMerButtonUnderCart(cartName);
                var pageTitle = cartName;
                if(!pageTitle.Equals("För Företag"))
                {
                    if (pageTitle.Equals("Kurser"))
                    {
                        pageTitle = "Kurs";
                    }
                    SharedPage.IsTextOnImageShown(pageTitle);
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
            for(var i = 0; i < sectionTitles.Count; i++)
            {
                Assert.True(HomePage.IsImgInSingleCartSectionShown(sectionTitles[i]), $"Image for '{sectionTitles[i]}' is not shown");
                Assert.True(HomePage.IsTitleForCartInSingleCartSectionShown(sectionTitles[i]), $"Did not find any title '{sectionTitles[i]}' under cart");
                Assert.True(HomePage.IsInformationTextForCartInSingleCartSectionShown(sectionTitles[i]), $"Information under cart for '{sectionTitles[i]} is not shown");
                Assert.True(HomePage.IsTitleAboveCartShown(sectionTitles[i], sectionCategories[i]), $"Title above cart for '{sectionTitles[i]} is not shown");
                HomePage.ClickOnButtonUnderCartInSingleCartSection(sectionTitles[i], sectionLinks[i]);
                DriverManager.SwitchDriverToChildWindow();
                SharedPage.ClickOnAcceptAllCookieIfExist();
                //var buttonTextArray = sectionLinks[i].Split(' ').Select(t => t.ToLower()).ToArray();
                var mainTextForPage = SharedPage.GetTextOnMainImage();
                if (sectionLinks[i].Equals("Antagning"))
                {
                    Assert.True(mainTextForPage.Equals("Välkommen till Nackademins antagning!"), $"Title on landed page does not contain button text '{sectionLinks[i]}");
                }
                else if (sectionLinks[i].Equals("Om oss"))
                {
                    Assert.True(mainTextForPage.Equals("Om Nackademin"), $"Title on landed page does not contain button text '{sectionLinks[i]}");
                }
                else
                {
                    Assert.True(mainTextForPage.Contains("Nå ditt drömjobb"), $"Title on landed page does not contain button text '{sectionLinks[i]}");
                }
                DriverManager.CloseWindow();
                DriverManager.SwitchDriverToParentWindow();
            }
        }
        [Then(@"I should see (.*) articles by default under section with title Inspiration")]
        public static void ThenIShouldSeeArtiklarByDefaultUnderSectionWithTitleInspiration(int countOfArticles)
        {
            var actualCount = HomePage.GetCountOfInspirationArticles();
            Assert.True(actualCount == countOfArticles, $"Expected count for article is {countOfArticles}, but it is {actualCount}");
        }
        [Then(@"I should see section with title (.*)")]
        public static void ThenIShouldSeeSectionWithTitleFragorOchSvar(string sectionName)
        {
            Assert.True(HomePage.IsTitleForCartInSingleCartSectionShown(sectionName), $"Section with name {sectionName} is not shown on Home page");
        }
        [Then(@"I should see information text for section (.*)")]
        public static void ThenIShouldSeeInformationTextForSectionFragorOchSvar(string sectionName)
        {
            Assert.True(HomePage.IsInformationTextShownForSection(sectionName), $"Information text for section '{sectionName}' is not present on Home page");
        }
        [When(@"I click on any question")]
        public static void WhenIClickOnAnyQuestion()
        {
            HomePage.ClickOnRandomQuestion();
        }
        [Then(@"I should see related content under it")]
        public void ThenIShouldSeeRelatedContentUnderIt()
        {
            Assert.True(HomePage.IsAnswerToRandomQuestionShown(), "Answer is not shown when clicking on a random question");
        }
        //[Then(@"I should see title (.*) for newsletter section")]
        //public static void ThenIShouldSeeFaVartNyhetsbrevOnHomePage(string sectionName)
        //{
        //    Assert.True(HomePage.IsNewsLetterSectionTitleShown(sectionName), "News letter section title is not shown");
        //}
        [Then(@"I enter (.*) in (.*) field in section (.*)")]
        public void EnterEmailAddressInField(string email, string fieldName, string sectionName)
        {
            HomePage.EnterEmailInField(email, fieldName, sectionName);
        }
        [Then(@"I should see the message contains (.*) in section (.*)")]
        public static void VerifyMessage(string messageSubtext, string sectionName)
        {
            Assert.True(HomePage.IsMessageWithSubtextExist(sectionName, messageSubtext), $"Did not get any message that contains subtext '{messageSubtext}' in section '{sectionName}' on Home page after entering a email address");
        }
        [When(@"I click on button (.*) in section for (.*)")]
        public void ClickOnPrenumereraButton(string buttonText, string sectionName)
        {
            HomePage.ClickOnButtonForSection(buttonText, sectionName);
        }

    }
}
