using NUnit.Framework;

namespace TesterProject.StepDefinitions
{
    [Binding]
    public sealed class CalculatorStepDefinitions
    {
        int first_number, second_number, result;

        [Given("the first number is (.*)")]
        public void GivenTheFirstNumberIs(int number)
        {
            first_number = number;
        }

        [Given("the second number is (.*)")]
        public void GivenTheSecondNumberIs(int number)
        {
            second_number = number;
        }

        [When("the two numbers are added")]
        public void WhenTheTwoNumbersAreAdded()
        {
            result = first_number + second_number;
        }

        [Then("the result should be (.*)")]
        public void ThenTheResultShouldBe(int result)
        {
            Assert.AreEqual(result, this.result);
        }
    }
}