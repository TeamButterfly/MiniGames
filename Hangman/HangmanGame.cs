using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//TODO: Implementer en liste over forskellige ord (gerne i en fil)
//TODO: Logik så der ikke kan gættes på det samme bogstav

namespace Hangman
{
    internal class HangmanGame
    {
        string word = "Ytringsfrihed";
        string wrongLetters;
        string playerGuesses;
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
            Console.WriteLine(sb.ToString() + " " + "Lives: " + lives + wrongLetters);            
        }


        //Is to be expanded when reading word from a file
        public void setGuesswordInitial(string word)
        {
            guessword = new bool[word.Length];
        }


        public void PlayerGuess(string letter)
        {    
            //Converts players guess and word to guess to uppercase
            string upperletter = letter.ToUpper();
            char guessletter = upperletter[0];
            string upperword = word.ToUpper();

            if (playerGuesses.Contains(upperletter))
            {
                Console.WriteLine("You have alreadye guessed on the letter " + guessletter);

                if (upperword.Contains(guessletter))
                {
                    for (int i = 0; i < word.Length; i++)
                    {
                        if (upperword[i] == guessletter)
                        {
                            guessword[i] = true;
                        }
                    }

                    addGuess(guessletter, playerGuesses);                    
                }

                else
                {
                    addGuess(guessletter, wrongLetters);
                    lives--;                   
                }                               
            }                      
        }


             public void addGuess(char wrongletter, string stringToChange)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(wrongLetters);
            sb.Append(wrongletter);
                       
            stringToChange = SortString(sb.ToString());                      
        }

        static string SortString(string input)
        {
            char[] characters = input.ToArray();
            Array.Sort(characters);
            return new string(characters);
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
