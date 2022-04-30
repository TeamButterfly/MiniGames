using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman
{
    public class GameManager
    {
        public Dictionary<Guid, HangmanGame> activeHangmanGame = new Dictionary<Guid, HangmanGame>();

        public HangmanModel HangmanResetGame(Guid userId)
        {
            if (activeHangmanGame.ContainsKey(userId))
            {
                return activeHangmanGame[userId].ResetGame();
            }
            activeHangmanGame[userId] = new HangmanGame();
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
    }
}
