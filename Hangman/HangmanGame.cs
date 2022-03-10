using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//TODO: Der bliver trukket 2 liv fra hver gang der gættes forkert
//TODO: Implementer en liste over forskellige ord (gerne i en fil)
//TODO: Logik så der ikke kan gættes på det samme bogstav
//TODO: Logik så der kan gættes på et helt ord
//TODO: Skal ikke være forskel på store og små bogstaver

namespace Hangman
{
    internal class HangmanGame
    {
        string word = "Ytringsfrihed";
        bool[] guessword;
        Boolean isRunning = true;
        int lives = 6;



        public void play()
        {
            //Initializes the word to guess and sets the propper length of the guessing array
            setGuesswordInitial(word);

            //Runs game
            while (isRunning)
            {
                Console.WriteLine(word);
                printGuessword();

                string guessLetter = Console.ReadLine();                
                Console.WriteLine(playerGuess(guessLetter));
                isGameOver();
            }
        }

        public void printGuessword()
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < word.Length; i++)
            {
                if (guessword[i] != null)
                {
                    if (guessword[i] == false)
                    {
                        sb.Append(" - ");
                    }
                    else
                    {
                        sb.Append(" " + word[i] + " ");
                    }
                }

            }
            Console.WriteLine(sb.ToString() + " " + "Lives: " + lives);
        }


        public void setGuesswordInitial(string word)
        {
            guessword = new bool[word.Length];
        }


        public Boolean playerGuess(string letter)
        {           
            string upperletter = letter.ToUpper();
            char guessletter = upperletter[0];
            string upperword = word.ToUpper();
            
            Console.WriteLine(upperword + guessletter);
                  

            if (upperword.Contains(guessletter))
            {
                for (int i = 0; i < word.Length; i++)
                {
                    if (upperword[i] == guessletter)
                    {
                        guessword[i] = true;
                    }                                   
                }

                return true;
            }

            else
            {
                lives--;
                return false;
            }

        }


        public void isGameOver()
        {
            for (int i = 0; i < guessword.Length; i++)
            {
                if (guessword[i] == false)
                {
                    if (lives > 0)
                    {
                        return;
                    }
                }
            }
            isRunning = false;
            Console.Write("Game is over");
        }
    }

}
