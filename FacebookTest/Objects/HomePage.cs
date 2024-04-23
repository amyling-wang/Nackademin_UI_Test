using OpenQA.Selenium;
using FacebookTest.Utilities;

namespace FacebookTest.Objects
{
    internal class HomePage
    {
        private static By PageTitle() => By.XPath("(//a[@href='https://nackademin.se/'])[1]");
        private static By MainImage() => By.XPath("//div[contains(@class,'img_container')]/img[contains(@class,'hero_background_image')]");
        
        private static By HittaUtbildningButton(string buttonText) => By.XPath($"//a[text()='{buttonText}']");
        private static By ImgInMultipleCartsSection(string titleText) => By.XPath($"//div[text()='{titleText}']/preceding-sibling::div/img");
        private static By TitleUnderCart(string titleText) => By.XPath($"//div[text()='{titleText}']");
        private static By InformationTextUnderCart(string titleText) => By.XPath($"//div[text()='{titleText}']/following-sibling::div");
        private static By LäsMerLink(string titleText) => By.XPath($"//div[text()='{titleText}']/following-sibling::a");
        private static By ImgInSingleCartSection(string titleText) => By.XPath($"//h2[text()='{titleText}']//ancestor::div[contains(@class,'half text_content')]/following-sibling::div//img");
        private static By TitleForCartInSingleCartSection(string titleText) => By.XPath($"//h2[text()='{titleText}']");
        private static By InformationTextForCartInSingleCartSection(string titleText) => By.XPath($"//h2[text()='{titleText}']/../following-sibling::div/p");
        private static By LinkUnderCartInSingelCartSection(string titleText, string buttonText) => By.XPath($"//h2[text()='{titleText}']/../following-sibling::div/a[text()='{buttonText}']");
        private static By TitleAboveCart(string titleUnderCart, string titleAboveCart) => By.XPath($"//h2[text()='{titleUnderCart}']/../preceding-sibling::p[text()='{titleAboveCart}']");
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
            return TitleForCartInSingleCartSection(title).IsExist();
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
        public static void ClickOnHittaUtbildningButton(string text)
        {
            HittaUtbildningButton(text).ClickElement();
        }
        public static void ClickOnPageTitle()
        {
            PageTitle().WaitAndClickElement();           
        }
        public static void ClickOnButtonUnderCartInSingleCartSection(string title, string buttonText)
        {
            LinkUnderCartInSingelCartSection(title, buttonText).MoveToElementAndClick();
        }
    }
}
