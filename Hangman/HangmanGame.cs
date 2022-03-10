using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//TODO: Implementer en liste over forskellige ord (gerne i en fil)
//TODO: Skal kun kunne gætte på bogstaver

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
                Console.WriteLine(PlayerGuess(guessLetter));
                Console.WriteLine("Spilleren har gættet på: " + playerGuesses);

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
            Console.WriteLine(sb.ToString() + " " + "Lives: " + lives + "\n Wrong guesses: " + wrongLetters);            
        }


        //Is to be expanded when reading word from a file
        public void setGuesswordInitial(string word)
        {
            guessword = new bool[word.Length];
        }


        public Boolean PlayerGuess(string letter)
        {    
            //Converts players guess and word to guess to uppercase
            string upperletter = letter.ToUpper();
            char guessletter = upperletter[0];
            string upperword = word.ToUpper();


            if (playerGuesses != null && playerGuesses.Contains(upperletter))
            {
                Console.WriteLine("You have alreadye guessed on the letter " + guessletter);
                return false;
            }
            else
            {
                playerGuesses = addGuess(guessletter, playerGuesses);
                if (upperword.Contains(guessletter))
                {
                    for (int i = 0; i < word.Length; i++)
                    {
                        if (upperword[i] == guessletter)
                        {
                            guessword[i] = true;
                        }
                    }
                                       
                }

                else
                {
                    wrongLetters = addGuess(guessletter, wrongLetters);

                    lives--;
                }
                return true;
            }
        }


             public string addGuess(char guessLetter, string stringToChange)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(stringToChange);
            sb.Append(guessLetter);
                       
            stringToChange = SortString(sb.ToString());
            
            return stringToChange;
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
