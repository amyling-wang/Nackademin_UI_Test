using FacebookTest.Objects;
using FacebookTest.Utilities;
using OpenQA.Selenium.Support.Events;
using SeleniumExtras.PageObjects;
using System.Security.Policy;
using Xunit;
using static System.Collections.Specialized.BitVector32;
using static System.Net.Mime.MediaTypeNames;

namespace FacebookTest.StepDefinitions
{
    [Binding]
    internal class HomeSteps
    {
        HomePage _homePage;
        public HomeSteps()
        {
            _homePage = new HomePage();
        }
        [When(@"I click on link navigates to Home page in page (.*)")]
        public void WhenIClickOnPageTitleNackademin(string section)
        {
            HomePage.ClickOnHomeLink(section);
            //SharedPage.ClickOnAcceptAllCookieIfExist();
        }
        [Then(@"I should see image with text '(.*)'")]
        public static void ThenIShouldSeeImageWithText(string text)
        {
            Assert.True(HomePage.IsMainImageShown(), "Main image is not shown on Nackademins Home page");
            Assert.True(SharedPage.GetPageTitleText().Equals(text), $"Expected text on image is {text}, but it is shown {SharedPage.GetPageTitleText()} on Nackademins Home page");
            
        }
        [When(@"I click on the button (.*)")]
        public void ClickOnButton(string buttonText)
        {
            _homePage.ClickOnButton(buttonText);
        }
        [Then(@"I should be navigated to (.*)")]
        public static void ThenIShouldSeePageWithTitleUtbildningarOnAChildWindow(string pageName)
        {
            VerifyLandingPageInChildWindow(pageName);
        }
        public static void VerifyLandingPageInChildWindow(string pageName)
        {
            DriverManager.SwitchDriverToChildWindow();
            SharedPage.ClickOnAcceptAllCookieIfExist();
            Assert.True(SharedPage.IsHeaderTitleShown(pageName), "Title is not shown on Utbildnings page when clicking on Utbildnings button on Home page");
            DriverManager.CloseWindow();
            DriverManager.SwitchDriverToParentWindow();
        }
        [Then(@"I verify below mentiond cards and related links for them on (.*) page")]
        public static void ThenIVerifyBelowMentiondCartsAndRelatedLinksForThem(string pageType, Table table)
        {
            var cartNames = table.Rows.Select(r => r["Cart name"]).ToList();
            foreach (var cartName in cartNames)
            {
                Assert.True(HomePage.IsCartImgShownInMultipleCartSection(cartName), $"Img for cart '{cartName}' is not shown on Home page");
                Assert.True(HomePage.IsTitleUnderCartShownInMultipleCartSection(cartName), $"Title under cart '{cartName}' is not shown on Home page");
                Assert.True(HomePage.IsInformationTextShownUnderCartInMultipleCartSection(cartName), $"Information text under cart '{cartName}' is not shown on Home page");
                HomePage.ClickOnLäsMerButtonUnderCart(cartName);
                var pageTitle = cartName;
                if(!pageTitle.Equals("För Företag") && !pageType.Equals("Antagning"))
                {
                    if (pageTitle.Equals("Kurser"))
                    {
                        pageTitle = "Kurs";
                    }
                    Assert.True(SharedPage.IsHeaderTitleShown(pageTitle), $"Title text '{pageTitle}' is not shown on '{pageTitle}' page");
                    DriverManager.NavigateBack();
                    SharedPage.ClickOnAcceptAllCookieIfExist();
                }
                else
                {
                    if(cartName.Equals("Urval & antagningsprov"))
                    {
                        VerifyLandingPageInChildWindow("Urval och antagningsprov");
                    }
                    else if(cartName.Equals("Inför din studiestart"))
                    {
                        VerifyLandingPageInChildWindow("Inför studiestart");
                    }
                    else
                    {
                        VerifyLandingPageInChildWindow(cartName);
                    }
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
                Assert.True(HomePage.IsSectionWithTitleShown(sectionTitles[i]), $"Did not find any title '{sectionTitles[i]}' under cart");
                Assert.True(HomePage.IsInformationTextForCartInSingleCartSectionShown(sectionTitles[i]), $"Information under cart for '{sectionTitles[i]} is not shown");
                Assert.True(HomePage.IsTitleAboveCartShown(sectionTitles[i], sectionCategories[i]), $"Title above cart for '{sectionTitles[i]} is not shown");
                HomePage.ClickOnButtonUnderCartInSingleCartSection(sectionTitles[i], sectionLinks[i]);
                DriverManager.SwitchDriverToChildWindow();
                SharedPage.ClickOnAcceptAllCookieIfExist();
                //var buttonTextArray = sectionLinks[i].Split(' ').Select(t => t.ToLower()).ToArray();
                var mainTextForPage = SharedPage.GetPageTitleText();
                switch (sectionLinks[i])
                {
                    case "Om oss":
                        Assert.True(mainTextForPage.Equals("Om Nackademin"), $"Title on landed page does not contain button text '{sectionLinks[i]}");
                        break;
                    case "Utforska våra event":
                        Assert.True(mainTextForPage.Equals("Event"), $"Title on landed page does not contain button text '{sectionLinks[i]}");
                        break;
                    default:
                        var sectionCategory = sectionCategories[i].ToLower();
                        sectionCategory = char.ToUpper(sectionCategory[0]) + sectionCategory[1..];
                        Assert.True(SharedPage.IsHeaderTitleShown(sectionCategory), $"Title on landed page does not contain button text '{sectionLinks[i]}");
                        break;
                }               
                DriverManager.CloseWindow();
                DriverManager.SwitchDriverToParentWindow();
            }
        }
        [Then(@"I should see (.*) articles by default under section with title (.*)")]
        public static void ThenIShouldSeeArtiklarByDefaultUnderSectionWithTitleInspiration(int countOfArticles, string sectionTitle)
        {
            var actualCount = HomePage.GetCountOfInspirationArticles(sectionTitle);
            Assert.True(actualCount == countOfArticles, $"Expected count for article is {countOfArticles}, but it is {actualCount}");
        }
        [Then(@"I should see section with title (.*)")]
        public static void ThenIShouldSeeSectionWithTitleFragorOchSvar(string sectionName)
        {
            Assert.True(HomePage.IsSectionWithTitleShown(sectionName), $"Section with name {sectionName} is not shown on Home page");
        }
        [Then(@"I should see information text for section (.*)")]
        public static void ThenIShouldSeeInformationTextForSectionFragorOchSvar(string sectionName)
        {
            Assert.True(HomePage.IsInformationTextShownForSection(), $"Information text for section '{sectionName}' is not present on Home page");
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
            if(sectionName.Equals("site footer"))
            {
                HomePage.EnterEmailInFieldInSiteFooterSection(email);
            }
            else
            {
                HomePage.EnterEmailInField(email, fieldName, sectionName);
            }
        }
        [Then(@"I should see the message contains (.*) in section (.*)")]
        public static void VerifyMessage(string messageSubtext, string sectionName)
        {
            //This step might need to be updated if message shows up in site footer section
            Assert.True(HomePage.IsMessageWithSubtextExist(messageSubtext), $"Did not get any message that contains subtext '{messageSubtext}' in section '{sectionName}' on Home page after entering a email address");
        }
        [When(@"I click on button Prenumerera in section for (.*)")]
        public static void ClickOnPrenumereraButton(string sectionName)
        {
            if(sectionName.Equals("site footer"))
            {
                HomePage.ClickOnButtonInSiteFooterSection();
            }
            else
            {
                HomePage.ClickOnButtonInNewsLetterSection();
            }
        }
        [Then(@"I verify below mentioned links in site footer section")]
        public void ThenIVerifyBelowMentionedLinksInSiteFooterSection(Table table)
        {
            var links = table.Rows.Select(r => r["Link name"]).ToList();
            var pageNames = table.Rows.Select(r => r["Landing page"]).ToList();
            for (int i = 0; i < links.Count; i++)
            {
                HomePage.ClickOnLinkInSidfooter(links[i]);
                VerifyLandingPageInChildWindow(pageNames[i]);
                SharedPage.ClickOnAcceptAllCookieIfExist();
            }
        }


        [Then(@"I verify below mentioned links in meny section under (.*)")]
        public static void ThenIVerifyBelowMentiondLinksInSidfooterSection(string category, Table table)
        {
            var links = table.Rows.Select(r => r["Link name"]).ToList();
            var pageNames = table.Rows.Select(r => r["Landing page"]).ToList();
            for (int i = 0; i < links.Count; i++)
            {
                HomePage.ClickOnLinkUnderArrowInMenySection(links[i], category);
                SharedPage.ClickOnAcceptAllCookieIfExist();
                Assert.True(SharedPage.IsHeaderTitleShown(pageNames[i]), $"Title text '{pageNames[i]}' is not shown on '{pageNames[i]}' page");
                DriverManager.NavigateBack();
                SharedPage.ClickOnAcceptAllCookieIfExist();
            }
        }
        [Then(@"I click on button beside (.*) in meny section")]
        public static void ThenIClickOnButtonBesideUtbildingarInMenySection(string link)
        {
            HomePage.ClickOnArrowButtonInMenySection(link);
        }

    }
}
