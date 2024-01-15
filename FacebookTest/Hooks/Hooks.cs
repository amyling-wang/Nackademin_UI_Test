using BoDi;
using FacebookTest.Config;
using FacebookTest.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using Xunit.Sdk;

namespace FacebookTest.Hooks
{
    [Binding]
    public sealed class Hooks 
    {
        private readonly IObjectContainer _container;
        public Hooks(IObjectContainer container)
        {
            _container = container;
        }

        [BeforeFeature]
        public static void BeforeFeature()
        {
            ConfigValues.LoadConfiguration();
        }

        //[AfterFeature]
        //public static void AfterFeature()
        //{
           
        //}
        [BeforeScenario]
        public void BeforeScenario()
        {
            IWebDriver driver = new EdgeDriver();
            driver.Manage().Window.Maximize();
            _container.RegisterInstanceAs<IWebDriver>(driver);
        }

        //[BeforeScenario(Order = 1)]
        //public static void FirstBeforeScenario()
        //{
        //    // Example of ordering the execution of hooks
        //    // See https://docs.specflow.org/projects/specflow/en/latest/Bindings/Hooks.html?highlight=order#hook-execution-order

        //    //TODO: implement logic that has to run before executing each scenario
        //}

        [AfterScenario]
        public void AfterScenario()
        {
            var driver = _container.Resolve<IWebDriver>();
            if (driver != null)
            {
                driver.Quit();
            }
        }
        [AfterStep]
        public void AfterStep(ScenarioContext scenarioContext)
        {
            string stepType = scenarioContext.StepContext.StepInfo.StepDefinitionType.ToString();
            string stepName = scenarioContext.StepContext.StepInfo.Text;
            var driver = _container.Resolve<IWebDriver>();
            var exception = scenarioContext.TestError;
            if (scenarioContext.TestError != null && !exception.Message.Contains("Skippping test"))
            {
                Report.addScreenshot(driver, scenarioContext);
                throw new XunitException(exception.Message + "/n" + exception.StackTrace);
                
            }
        }
    }
}