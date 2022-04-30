using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

//TODO: Implementer en liste over forskellige ord (gerne i en fil)
//TODO: Skal kunne gætte på et helt ord
//TODO: Skal man kunne spille multiplayer?

namespace Hangman
{
    public class HangmanGame
    {
        private readonly List<string> Words = new List<string> {
            "ytringsfrihed",
            "jantelov",
            "grimrian",
            "viking",
            "lærer",
            "studerende",
            "fodbold",
            "håndbold",
            "sport",
            "arbejde",
            "surfer",
            "atlet"
        };

        private HangmanModel hangmanModel;

        public HangmanModel ResetGame()
        {
            var rand = new Random();
            var word = Words[rand.Next(Words.Count)];

            hangmanModel = new HangmanModel
            {
                Life = 6,
                Word = word,
                RevealedWord = "",
                Guesses = new List<char>(),
                IsGameWon = false
            };
            hangmanModel.RevealedWord = GetRevealedWord();
            return hangmanModel;
        }

        public HangmanModel GuessLetter(char guess)
        {
            if(hangmanModel.Life == 0 || hangmanModel.IsGameWon)
            {
                return hangmanModel;
            }
            if (hangmanModel.Guesses.Contains(guess))
            {
                return hangmanModel;
            }
            if (!hangmanModel.Word.Contains(guess))
            {
                hangmanModel.Life -= 1;
                if(hangmanModel.Life == 0)
                {
                    hangmanModel.RevealedWord = hangmanModel.Word;
                    return hangmanModel;
                }
            }

            hangmanModel.Guesses.Add(guess);
            hangmanModel.RevealedWord = GetRevealedWord();

            if(hangmanModel.Word == hangmanModel.RevealedWord)
            {
                hangmanModel.IsGameWon = true;
            }

            return hangmanModel;
        }

        public HangmanModel GuessWord(string wordGuessed)
        {
            if (hangmanModel.Life == 0 || hangmanModel.IsGameWon)
            {
                return hangmanModel;
            }
            if (hangmanModel.Word != wordGuessed)
            {
                hangmanModel.Life -= 1;
                if (hangmanModel.Life == 0)
                {
                    hangmanModel.RevealedWord = hangmanModel.Word;
                }
                return hangmanModel;
            }

            hangmanModel.RevealedWord = hangmanModel.Word;
            hangmanModel.IsGameWon = true;
            return hangmanModel;
        }

        private string GetRevealedWord()
        {
            var revealedWord = "";
            foreach (var letter in hangmanModel.Word)
            {
                if (hangmanModel.Guesses.Contains(letter))
                {
                    revealedWord += letter;
                }
                else
                {
                    revealedWord += "_";
                }
            }
            return revealedWord;
        }
    }
}
