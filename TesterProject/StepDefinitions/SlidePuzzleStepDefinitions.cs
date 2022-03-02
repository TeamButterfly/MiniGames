using System;
using TechTalk.SpecFlow;

namespace TesterProject.StepDefinitions
{
    [Binding]
    public class SlidePuzzleStepDefinitions
    {
        [Given(@"a game is started")]
        public void GivenAGameIsStarted()
        {
            throw new PendingStepException();
        }

        [Given(@"a user wants to move a square to the ""([^""]*)""")]
        public void GivenAUserWantsToMoveASquareToThe(string left)
        {
            throw new PendingStepException();
        }

        [Given(@"the square to the ""([^""]*)"" is empty")]
        public void GivenTheSquareToTheIsEmpty(string left)
        {
            throw new PendingStepException();
        }

        [When(@"the square is moved to the ""([^""]*)""")]
        public void WhenTheSquareIsMovedToThe(string left)
        {
            throw new PendingStepException();
        }

        [Then(@"the move is successed")]
        public void ThenTheMoveIsSuccessed()
        {
            throw new PendingStepException();
        }
    }
}
