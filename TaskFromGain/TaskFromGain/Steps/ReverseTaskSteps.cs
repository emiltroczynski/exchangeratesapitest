using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TaskFromGain.ReverseTask;
using TechTalk.SpecFlow;

namespace TaskFromGain.Steps
{
    [Binding]
    class ReverseTaskSteps
    {
        private string textToReverse;
        private string reversedText;

        [Given(@"I have entered ""(.*)"" into the reverse")]
        public void GivenIHaveEnteredIntoTheReverse(string originalText)
        {
            textToReverse = originalText;
        }

        [When(@"I execute Reverse")]
        public void WhenIExecuteReverse()
        {
            reversedText = Utils.Reverse(textToReverse);
        }

        [Then(@"the result should be ""(.*)""")]
        public void ThenTheResultShouldBe(string expectedText)
        {
            Assert.AreEqual(expectedText, reversedText, "Returned text is not valid");
        }

    }
}
