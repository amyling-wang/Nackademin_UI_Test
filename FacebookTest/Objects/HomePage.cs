using OpenQA.Selenium;
using FacebookTest.Utilities;

namespace FacebookTest.Objects
{
    internal class HomePage : SharedPage
    {
        private static By HomePageLink(string section) => By.XPath($"//{section}//a[@href='https://nackademin.se/']");
        private static By MainImage() => By.XPath("//div[contains(@class,'img_container')]/img[contains(@class,'hero_background_image')]");
        private static By ImgInMultipleCartsSection(string titleText) => By.XPath($"//div[text()='{titleText}']/preceding-sibling::div/img");
        private static By TitleUnderCart(string titleText) => By.XPath($"//div[text()='{titleText}']");
        private static By InformationTextUnderCart(string titleText) => By.XPath($"//div[text()='{titleText}']/following-sibling::div");
        private static By LäsMerLink(string titleText) => By.XPath($"//div[text()='{titleText}']/following-sibling::a");
        private static By ImgInSingleCartSection(string titleText) => By.XPath($"//h2[text()='{titleText}']//ancestor::div[contains(@class,'half text_content')]/following-sibling::div//img");
        private static By SectionTitle(string titleText) => By.XPath($"//h2[text()='{titleText}']");
        private static By InformationTextForCartInSingleCartSection(string titleText) => By.XPath($"//h2[text()='{titleText}']/../following-sibling::div/p");
        private static By LinkUnderCartInSingelCartSection(string titleText, string buttonText) => By.XPath($"//h2[text()='{titleText}']/../following-sibling::div/a[text()='{buttonText}']");
        private static By TitleAboveCart(string titleUnderCart, string titleAboveCart) => By.XPath($"//h2[text()='{titleUnderCart}']/../preceding-sibling::p[text()='{titleAboveCart}']");
        private static By ArticlesForInspirations => By.XPath("//div[text()='Inspiration']//following-sibling::div[2]/div[contains(@class,'w-full')]");
        private static By InformationTextForSection(string sectionName) => By.XPath($"//h2[text()='{sectionName}']/../following-sibling::div/p");
        private static By CommonQuestions => By.XPath("//div[contains(@class,'faq_content')]");
        private static By AnswerToRandomQuestion => By.XPath("//div[contains(@class,'faq_answer')]/p");
        //private static By NewsLetterSectionTitle(string sectionName) => By.XPath($"//h2[text()='{sectionName}']");
        private static By EmailFieldInNewsLetterSection(string sectionName, string field) => By.XPath($"//h2[text()='{sectionName}']//ancestor::div[contains(@class,'newsletter_block')]//input[@placeholder='{field}']");
        private static By MessageForSendingMailAddress(string messageSubtext) => By.XPath($"//div[contains(@class,'newsletter_block')]//*[contains(text(),'{messageSubtext}')]");
        private static By PrenumereraButtonInNewsLetterSection => By.XPath("//div[contains(@class,'newsletter_block')]//input[@Value='Prenumerera']");
        private static By LinkInSidfooterSection(string linkText) => By.XPath($"//div[contains(@class,'column_links')]//a[text()='{linkText}']");
        private static By EmailFieldInSiteFooterSection => By.XPath("//footer[@id='site-footer']//input[@placeholder='Din e-postadress']");
        private static By PrenumereraButtonInSiteFooter => By.XPath("//footer[@id='site-footer']//input[@value='Prenumerera']");
        private static By ArrowButtonInMenySection(string link) => By.XPath($"//a[contains(text(),'{link}')]/button");
        private static By LinkUnderArrowInMenySection(string link) => By.XPath($"//li[contains(@class,'menu_item')]/a[contains(text(),'{link}')]");
        public static bool IsMessageWithSubtextExist(string subtext)
        {
            MessageForSendingMailAddress(subtext).WaitUntilElementIsVisible();
            return MessageForSendingMailAddress(subtext).IsExist();
        }
        //public static bool IsNewsLetterSectionTitleShown(string sectionName)
        //{
        //    NewsLetterSectionTitle(sectionName).MoveToElement();
        //    return NewsLetterSectionTitle(sectionName).IsExist();
        //}
        public static bool IsAnswerToRandomQuestionShown()
        {
            return AnswerToRandomQuestion.IsExist();
        }
        public static bool IsInformationTextShownForSection(string sectionName)
        {
            return InformationTextForSection(sectionName).IsExist();
        }
        public static int GetCountOfInspirationArticles()
        {
            return ArticlesForInspirations.GetCountOfElements();
        }
        public static bool IsImgInSingleCartSectionShown(string title)
        {
            return ImgInSingleCartSection(title).IsExist();
        }
        public static bool IsTitleAboveCartShown(string titleUnderCart, string titleAboveCart)
        {
            return TitleAboveCart(titleUnderCart, titleAboveCart).IsExist();
        }
        public static bool IsTitleForCartInSingleCartSectionShown(string title)
        {
            return SectionTitle(title).IsExist();
        }
        public static bool IsInformationTextForCartInSingleCartSectionShown(string title)
        {
            return InformationTextForCartInSingleCartSection(title).IsExist();
        }
        public static bool IsCartImgShownInMultipleCartSection(string titleText)
        {
            return ImgInMultipleCartsSection(titleText).IsExist();
        }
        public static bool IsTitleUnderCartShownInMultipleCartSection(string titleText)
        {
            return TitleUnderCart(titleText).IsExist();
        }
        public static bool IsInformationTextShownUnderCartInMultipleCartSection(string titleText)
        {
            return InformationTextUnderCart(titleText).IsExist();
        }
        public static bool IsMainImageShown()
        {
            return MainImage().IsExist();
        }       
        public static void ClickOnLäsMerButtonUnderCart(string titleText)
        {
            LäsMerLink(titleText).MoveToElementAndClick();
        }
        public static void ClickOnButtonInNewsLetterSection()
        {
            PrenumereraButtonInNewsLetterSection.MoveToElement();
            PrenumereraButtonInNewsLetterSection.ClickUsingJavaScriptExecutor();
        }
        public static void ClickOnButtonInSiteFooterSection()
        {
            PrenumereraButtonInSiteFooter.MoveToElement();
            PrenumereraButtonInSiteFooter.ClickUsingJavaScriptExecutor();
        }
        public static void ClickOnHomeLink(string section)
        {
            HomePageLink(section).WaitToBecomeAvailable();
            HomePageLink(section).MoveToElementAndClick();
        }
        public static void ClickOnButtonUnderCartInSingleCartSection(string title, string buttonText)
        {
            LinkUnderCartInSingelCartSection(title, buttonText).MoveToElementAndClick();
        }
        public static void ClickOnRandomQuestion()
        {
            CommonQuestions.MoveToElementAndClick();
        }
        public static void EnterEmailInField(string email, string field, string sectionName)
        {
            EmailFieldInNewsLetterSection(sectionName, field).SendKeysAndWait(email);
        }
        public static void ClickOnLinkInSidfooter(string linkText)
        {
            LinkInSidfooterSection(linkText).MoveToElementAndClick(linkText);
        }
        public static void EnterEmailInFieldInSiteFooterSection(string email)
        {
            EmailFieldInSiteFooterSection.SendKeysAndWait(email);
        }
        public static void ClickOnArrowButtonInMenySection(string link)
        {
            ArrowButtonInMenySection(link).WaitToBecomeClickable();
            Thread.Sleep(TimeSpan.FromSeconds(2));
            ArrowButtonInMenySection(link).ClickElement();
        }
        public static void ClickOnLinkUnderArrowInMenySection(string link, string category)
        {
            if (!LinkUnderArrowInMenySection(link).IsDisplayed())
            {
                ClickOnArrowButtonInMenySection(category);
            }
            LinkUnderArrowInMenySection(link).WaitAndClickElement(link);
        }
    }  
}
