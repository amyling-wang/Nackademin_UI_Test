using OpenQA.Selenium;

using FacebookTest.Support;

namespace FacebookTest.Objects
{
    internal class HomePage
    {
        IWebDriver driver;      
        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
           // PageFactory.InitElements(driver, this);
        }
        private By createStoryField = By.XPath("//span[text()='Create story']//ancestor::div[contains(@class,'x78zum5 xdt5ytf xz62fqu')]");
        private By createTextStoryCard = By.XPath("//div[text()='Create a text story']//ancestor::div[contains(@class,'x1qjc9v5 x1q0q8m5')]");
        private By startTypingBox = By.XPath("//span[text()='Start typing']//parent::div[contains(@class,'xjbqb8w x1iyjqo2')]");
        private By textArea = By.XPath("//textarea");
        private By shareStoryButton = By.XPath("//span[text()='Share to story']");
        private By yourStoryCard = By.XPath("(//span[text()='Your story']/ancestor::div[contains(@class,'x9f619 x1n2onr6 x1ja2u2z x78zum5 xdt5ytf x2lah0s')])[2]/preceding-sibling::*[last()]");
        private By pauseButtonOnStory = By.XPath("//div[@aria-label='Pause']");
        private By points = By.XPath("(//div[contains(@class,'x1ypdohk xdj266r')]//span)[3]");
        private By deletePhotoButton = By.XPath("//span[text()='Delete photo']");
        private By deleteButton = By.XPath("//div[@aria-label='Delete']");
        private By overlappElement = By.XPath("(//div[contains(@class,'x1uvtmcs')])[3]");
        private By homeTab(string tabName) => By.XPath($"//a[@aria-label='{tabName}']");
        //private string tabXPath(string tabName) => $"//a[@aria-label='{tabName}']";
        //[FindsBy(How = How.XPath)]
        //private IWebElement tabs;     

        public void ClickOnTab(string tabName)
        {
            //driver.FindElement(By.XPath("(//div[contains(@class,'x1uvtmcs')])[2]")).Click();
            //driver.FindElement(By.XPath($"//a[@aria-label='{tabName}']")).Click();
            driver.WaitAndClick(overlappElement);
            driver.WaitAndClick(homeTab(tabName));
        }
        public void CreateStory()
        {         
            driver.WaitAndClick(createStoryField);
            driver.WaitAndClick(createTextStoryCard);
            driver.WaitAndClick(startTypingBox);
            driver.FindElement(textArea).SendKeys("Test");
            driver.FindElement(shareStoryButton).Click();
        }
        public void DeleteStory()
        {
            driver.WaitAndClick(yourStoryCard);        
            driver.WaitAndClick(pauseButtonOnStory);
            driver.WaitAndClick(points);
            driver.WaitAndClick(deletePhotoButton);
            driver.WaitAndClick(deleteButton);
            driver.FindElement(By.XPath("(//div[@aria-label='Close'])[1]")).Click();
        }


    }
}
