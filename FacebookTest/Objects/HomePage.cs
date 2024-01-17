using OpenQA.Selenium;
using FacebookTest.Utilities;

namespace FacebookTest.Objects
{
    internal class HomePage : Base
    {
        public HomePage(IWebDriver driver) : base(driver)
        {
        }
        private IWebElement CreateStoryField => FindElement(By.XPath("//span[text()='Create story']//ancestor::div[contains(@class,'x78zum5 xdt5ytf xz62fqu')]"));
        private IWebElement CreateTextStoryCard => FindElement(By.XPath("//div[text()='Create a text story']//ancestor::div[contains(@class,'x1qjc9v5 x1q0q8m5')]"));
        private IWebElement StartTypingBox => FindElement(By.XPath("//span[text()='Start typing']//parent::div[contains(@class,'xjbqb8w x1iyjqo2')]"));
        private IWebElement TextArea => FindElement(By.XPath("//textarea"));
        private IWebElement ShareStoryButton => FindElement(By.XPath("//span[text()='Share to story']"));
        private IWebElement YourStoryCard => FindElement(By.XPath("(//span[text()='Your story']/ancestor::div[contains(@class,'x9f619 x1n2onr6 x1ja2u2z x78zum5 xdt5ytf x2lah0s')])[2]/preceding-sibling::*[last()]"));
        private IWebElement PauseButtonOnStory => FindElement(By.XPath("//div[@aria-label='Pause']"));
        private IWebElement Points => FindElement(By.XPath("(//div[contains(@class,'x1ypdohk xdj266r')]//span)[3]"));
        private IWebElement DeletePhotoButton => FindElement(By.XPath("//span[text()='Delete photo']"));
        private IWebElement DeleteButton => FindElement(By.XPath("//div[@aria-label='Delete']"));
        private IWebElement CloseStoryButton => FindElement(By.XPath("(//div[@aria-label='Close'])[1]"));
        private IWebElement SideMenus(string menuName) => FindElement(By.XPath($"//ul//span[text()='{menuName}']"));
        public void CreateStory()
        {               
            WaitAndClick(CreateStoryField);
            WaitAndClick(CreateTextStoryCard);
            WaitAndClick(StartTypingBox);
            TextArea.SendKeys("Test");
            ShareStoryButton.Click();
        }
        public void DeleteStory()
        {
            if(YourStoryCard != null) 
            {
                WaitAndClick(YourStoryCard);
                WaitAndClick(PauseButtonOnStory);
                WaitAndClick(Points);
                WaitAndClick(DeletePhotoButton);
                WaitAndClick(DeleteButton);
                CloseStoryButton.Click();
            }            
        }
        public IWebElement GetSideMeny(string menuName)
        {
            IWebElement menuLocator = SideMenus(menuName);
            return menuLocator;
        }

    }
}
