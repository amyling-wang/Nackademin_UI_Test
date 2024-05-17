using FacebookTest.Objects;
using Microsoft.VisualStudio.Shell.Interop;
using Xunit;

namespace NackademinUITest.StepDefinitions
{
    [Binding]
    internal class FörFöretagSteps
    {
        [Then(@"I should see image for section (.*)")]
        public void VerifyImageForSection(string section)
        {
            Assert.True(HomePage.IsImgInSingleCartSectionShown(section), $"Image in section {section} does not exist");
        }
        [Then(@"I should see some company logo in the section")]
        public static void VerifyCompanyLogo()
        {
            Assert.True(FörFöretagPage.IsCompanyLogsShown(), "No company logos shown in section 'Samarbetspartners'");
        }
        [Then(@"I veriy (.*) button is shown in the section")]
        public static void VeriyVisaFlerButton(string button)
        {
            Assert.True(SharedPage.IsButtonShown(button), $"{button} is not shown in section 'Samarbetspartners'");
        }
        [Then(@"I fill (.*) in (.*) field")]
        public static void SendTextInField(string text, string filed)
        {
            FörFöretagPage.SendTextInField(filed, text);
        }
        [Then(@"I should see a message contains (.*) in the section")]
        public void ThenIShouldSeeAMessageContainsProblemInTheSection(string message)
        {
            var actualMessage = "";
            if (message.Equals("problem"))
            {
                actualMessage = FörFöretagPage.GetErrorMessage();                
            }
            else
            {
                actualMessage = HomePage.GetTextOfSuccessMessage();
            }
            Assert.True(actualMessage.Contains(message), $"Message does not contain {message}");
        }
        [When(@"I click on button Skicka")]
        public static void ClickOnButtonSkicka()
        {
            FörFöretagPage.ClickOnSkickaButton();
        }
    }
}
