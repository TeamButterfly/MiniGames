using Hangman;
using Slide_Puzzle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe;

namespace API
{
    public class GameManager
    {
        public Dictionary<Guid, HangmanGame> activeHangmanGames = new Dictionary<Guid, HangmanGame>();
        public Dictionary<Guid, SPGame> activeSlidePuzzleGames = new Dictionary<Guid, SPGame>();
        public Dictionary<Guid, TicTacToeGame> activeTicTacToeGames = new Dictionary<Guid, TicTacToeGame>();

        /*
         * Hangman Game 
         */
        public HangmanModel HangmanResetGame(Guid userId)
        {
            if (!activeHangmanGames.ContainsKey(userId))
            {
                activeHangmanGames[userId] = new HangmanGame();
            }
            return activeHangmanGames[userId].ResetGame();
        }

        public HangmanModel HangmanGuessLetter(Guid userId, char letter)
        {
            if (activeHangmanGames.ContainsKey(userId))
            {
                var hangmanGame = activeHangmanGames[userId];
                return hangmanGame.GuessLetter(letter);
            }
            return null;
        }

        public HangmanModel HangmanGuessWord(Guid userId, string word)
        {
            if (activeHangmanGames.ContainsKey(userId))
            {
                var hangmanGame = activeHangmanGames[userId];
                return hangmanGame.GuessWord(word);
            }
            return null;
        }

        /*
         * Slide Puzzle Game 
         */
        public int[] SlidePuzzleResetGame(Guid userId, int size)
        {
            if (!activeSlidePuzzleGames.ContainsKey(userId))
            {
                activeSlidePuzzleGames[userId] = new SPGame();
            }
            return activeSlidePuzzleGames[userId].CreateBoard(size);
        }

        public int[] SlidePuzzleMove(Guid userId, int swapvalue)
        {
            if (activeSlidePuzzleGames.ContainsKey(userId))
            {
                var slidePuzzleGame = activeSlidePuzzleGames[userId];
                return slidePuzzleGame.Move(swapvalue);
            }
            return null;
        }

        public bool SlidePuzzleIsCompleted(Guid userId)
        {
            if (activeSlidePuzzleGames.ContainsKey(userId))
            {
                var slidePuzzleGame = activeSlidePuzzleGames[userId];
                return slidePuzzleGame.IsCompleted();
            }
            return false;
        }
        public int SlidePuzzleGetScore(Guid userId)
        {
            if (activeSlidePuzzleGames.ContainsKey(userId))
            {
                var slidePuzzleGame = activeSlidePuzzleGames[userId];
                return slidePuzzleGame.GetScore();
            }
            return 0;
        }

        /*
         * Tic Tac Toe Game 
         */
        public TicTacToeModel TicTacToeResetGame(Guid userId, int squares)
        {
            if (!activeTicTacToeGames.ContainsKey(userId))
            {
                activeTicTacToeGames[userId] = new TicTacToeGame();
            }
            return activeTicTacToeGames[userId].ResetGame(squares);
        }

        public TicTacToeModel TicTacToeSetField(Guid userId, int row, int col)
        {
            if (activeTicTacToeGames.ContainsKey(userId))
            {
                var ticTacToeGame = activeTicTacToeGames[userId];
                return ticTacToeGame.SetField(row, col);
            }
            return null;
        }
    }
}
