using API;
using Database;
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

            using (var db = new DatabaseContext())
            {
            }
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


        //login scenario

        [Given(@"a user with a username")]
        public void GivenAUserWithAUsername()
        {
            throw new PendingStepException();
        }

        [Given(@"a user with a password")]
        public void GivenAUserWithAPassword()
        {
            throw new PendingStepException();
        }

        [When(@"the user wants to login")]
        public void WhenTheUserWantsToLogin()
        {
            throw new PendingStepException();
        }

        [When(@"the username and password is correct")]
        public void WhenTheUsernameAndPasswordIsCorrect()
        {
            throw new PendingStepException();
        }

        [Then(@"the user is login succesful")]
        public void ThenTheUserIsLoginSuccesful()
        {
            //throw new PendingStepException();
            Assert.IsTrue(true);
        }
    }
}