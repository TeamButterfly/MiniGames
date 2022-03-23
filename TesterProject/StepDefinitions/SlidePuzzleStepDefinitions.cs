using System;
using TechTalk.SpecFlow;

namespace TesterProject.StepDefinitions
{
    [Binding]
    public class SlidePuzzleStepDefinitions
    {
        [Given(@"a user wants to move a tile to the ""([^""]*)""")]
        public void GivenAUserWantsToMoveATileToThe(string left)
        {
            throw new PendingStepException();
        }

        [Given(@"the tile to the ""([^""]*)"" is empty")]
        public void GivenTheTileToTheIsEmpty(string left)
        {
            throw new PendingStepException();
        }

        [When(@"the tile is moved to the ""([^""]*)""")]
        public void WhenTheTileIsMovedToThe(string left)
        {
            throw new PendingStepException();
        }

        [Given(@"a player wants to create a game")]
        public void GivenAPlayerWantsToCreateAGame()
        {
            throw new PendingStepException();
        }

        [When(@"the player gives a game size ""([^""]*)""")]
        public void WhenThePlayerGivesAGameSize(string p0)
        {
            throw new PendingStepException();
        }

        [When(@"the game size is legal")]
        public void WhenTheGameSizeIsLegal()
        {
            throw new PendingStepException();
        }

        [Then(@"the game is created")]
        public void ThenTheGameIsCreated()
        {
            throw new PendingStepException();
        }

        [When(@"the game size is illegal")]
        public void WhenTheGameSizeIsIllegal()
        {
            throw new PendingStepException();
        }

        [Then(@"the game is not created")]
        public void ThenTheGameIsNotCreated()
        {
            throw new PendingStepException();
        }

        [Given(@"a game is created with a game size ""([^""]*)""")]
        public void GivenAGameIsCreatedWithAGameSize(string p0)
        {
            throw new PendingStepException();
        }

        [When(@"the tiles is in nummerical order from smallest to biggest")]
        public void WhenTheTilesIsInNummericalOrderFromSmallestToBiggest()
        {
            throw new PendingStepException();
        }

        [When(@"the position of the empty tile ís in the end")]
        public void WhenThePositionOfTheEmptyTileIsInTheEnd()
        {
            throw new PendingStepException();
        }

        [Then(@"the game is completed")]
        public void ThenTheGameIsCompleted()
        {
            throw new PendingStepException();
        }

        [When(@"the tiles isn't in nummerical order from smallest to biggest")]
        public void WhenTheTilesIsntInNummericalOrderFromSmallestToBiggest()
        {
            throw new PendingStepException();
        }

        [Then(@"the game isn't completed")]
        public void ThenTheGameIsntCompleted()
        {
            throw new PendingStepException();
        }

        [Then(@"the user can still make a move")]
        public void ThenTheUserCanStillMakeAMove()
        {
            throw new PendingStepException();
        }

        [When(@"there is ""([^""]*)"" tiles with numbers inside")]
        public void WhenThereIsTilesWithNumbersInside(string p0)
        {
            throw new PendingStepException();
        }

        [When(@"the tiles with these numbers is (.*) to ""([^""]*)""")]
        public void WhenTheTilesWithTheseNumbersIsTo(int p0, string p1)
        {
            throw new PendingStepException();
        }

        [Then(@"the game is displayed to the player")]
        public void ThenTheGameIsDisplayedToThePlayer()
        {
            throw new PendingStepException();
        }
    }
}
