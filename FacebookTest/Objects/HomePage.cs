using OpenQA.Selenium;
using FacebookTest.Utilities;

namespace FacebookTest.Objects
{
    internal class HomePage
    {
        
        //private IWebElement createStoryField => FindElement(By.XPath("//span[text()='Create story']//ancestor::div[contains(@class,'x78zum5 xdt5ytf xz62fqu')]"));
        //private IWebElement createTextStoryCard => FindElement(By.XPath("//div[text()='Create a text story']//ancestor::div[contains(@class,'x1qjc9v5 x1q0q8m5')]"));
        //private IWebElement startTypingBox => FindElement(By.XPath("//span[text()='Start typing']//parent::div[contains(@class,'xjbqb8w x1iyjqo2')]"));
        //private IWebElement textArea => FindElement(By.XPath("//textarea"));
        //private IWebElement shareStoryButton => FindElement(By.XPath("//span[text()='Share to story']"));
        //private IWebElement yourStoryCard => FindElement(By.XPath("(//span[text()='Your story']/ancestor::div[contains(@class,'x9f619 x1n2onr6 x1ja2u2z x78zum5 xdt5ytf x2lah0s')])[2]/preceding-sibling::*[last()]"));
        //private IWebElement pauseButtonOnStory => FindElement(By.XPath("//div[@aria-label='Pause']"));
        //private IWebElement points => FindElement(By.XPath("(//div[contains(@class,'x1ypdohk xdj266r')]//span)[3]"));
        //private IWebElement deletePhotoButton => FindElement(By.XPath("//span[text()='Delete photo']"));
        //private IWebElement deleteButton => FindElement(By.XPath("//div[@aria-label='Delete']"));
        //private IWebElement closeStoryButton => FindElement(By.XPath("(//div[@aria-label='Close'])[1]"));
        private By PageTitle() => By.XPath("(//a[@href='https://nackademin.se/'])[1]");
        //public void CreateStory()
        //{               
        //    WaitAndClick(createStoryField);
        //    WaitAndClick(createTextStoryCard);
        //    WaitAndClick(startTypingBox);
        //    textArea.SendKeys("Test");
        //    shareStoryButton.Click();
        //}
        //public void DeleteStory()
        //{
        //    WaitAndClick(yourStoryCard);        
        //    WaitAndClick(pauseButtonOnStory);
        //    WaitAndClick(points);
        //    WaitAndClick(deletePhotoButton);
        //    WaitAndClick(deleteButton);
        //    closeStoryButton.Click();
        //}

        public void ClickOnPageTitle()
        {
            PageTitle().WaitAndClickElement();
        }
    }
}
