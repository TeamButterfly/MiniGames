using Hangman;
using Slide_Puzzle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API
{
    public class GameManager
    {
        public Dictionary<Guid, HangmanGame> activeHangmanGame = new Dictionary<Guid, HangmanGame>();
        public Dictionary<Guid, SPGame> activeSlidePuzzleGame = new Dictionary<Guid, SPGame>();

        /*
         * Hangman Game 
         */
        public HangmanModel HangmanResetGame(Guid userId)
        {
            if (!activeHangmanGame.ContainsKey(userId))
            {
                activeHangmanGame[userId] = new HangmanGame();
            }
            return activeHangmanGame[userId].ResetGame();
        }

        public HangmanModel HangmanGuessLetter(Guid userId, char letter)
        {
            if (activeHangmanGame.ContainsKey(userId))
            {
                var hangmanGame = activeHangmanGame[userId];
                return hangmanGame.GuessLetter(letter);
            }
            return null;
        }

        public HangmanModel HangmanGuessWord(Guid userId, string word)
        {
            if (activeHangmanGame.ContainsKey(userId))
            {
                var hangmanGame = activeHangmanGame[userId];
                return hangmanGame.GuessWord(word);
            }
            return null;
        }

        /*
         * Slide Puzlle Game 
         */
        public int[] SlidePuzzleResetGame(Guid userId, int size)
        {
            if (!activeSlidePuzzleGame.ContainsKey(userId))
            {
                activeSlidePuzzleGame[userId] = new SPGame();
            }
            return activeSlidePuzzleGame[userId].CreateBoard(size);
        }

        public int[] SlidePuzzleMove(Guid userId, int swapvalue)
        {
            if (activeSlidePuzzleGame.ContainsKey(userId))
            {
                var slidePuzzleGame = activeSlidePuzzleGame[userId];
                return slidePuzzleGame.Move(swapvalue);
            }
            return null;
        }

        public bool SlidePuzzleIsCompleted(Guid userId)
        {
            if (activeSlidePuzzleGame.ContainsKey(userId))
            {
                var slidePuzzleGame = activeSlidePuzzleGame[userId];
                return slidePuzzleGame.IsCompleted();
            }
            return false;
        }
        public int SlidePuzzleGetScore(Guid userId)
        {
            if (activeSlidePuzzleGame.ContainsKey(userId))
            {
                var slidePuzzleGame = activeSlidePuzzleGame[userId];
                return slidePuzzleGame.GetScore();
            }
            return 0;
        }
    }
}
