using OpenQA.Selenium;

namespace FacebookTest.Utilities
{
    public class Report
    {
        public static string dir = AppDomain.CurrentDomain.BaseDirectory;
        public static string testResultPath = dir.Replace("bin\\Debug\\net6.0", "TestResults");

        public static string addScreenshot(IWebDriver driver, ScenarioContext scenarioContext)
        {
            ITakesScreenshot takesScreenshot = (ITakesScreenshot)driver;
            //DateTime dateTime = DateTime.Now;
            //string dateTimeString = dateTime.ToString().Replace("/", "-").Replace(":", "-");
            Screenshot screenshot = takesScreenshot.GetScreenshot();
            string screenshotLocation = Path.Combine(testResultPath, scenarioContext.ScenarioInfo.Title + ".png");
            if (File.Exists(screenshotLocation))
            {
                File.Delete(screenshotLocation);
            }
            screenshot.SaveAsFile(screenshotLocation);
            return screenshotLocation;
        }
    }
}
