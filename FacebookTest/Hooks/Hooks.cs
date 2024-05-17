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
        DriverManager _driverManager;
        public Hooks(IObjectContainer container)
        {
            _container = container;
            _driverManager = DriverManager.GetInstance();
        }

        [BeforeFeature]
        public static void BeforeFeature()
        {
            ConfigValues.LoadConfiguration();
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
           
            _container.RegisterInstanceAs<IWebDriver>(_driverManager.GetWebDriver());
        }

        [AfterScenario]
        public void AfterScenario()
        {
            _driverManager.Quit();          
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