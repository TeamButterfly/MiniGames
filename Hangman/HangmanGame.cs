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
        string word;
        string wrongLetters;
        string playerGuesses;
        bool[] guessword;
        bool isRunning = false;
        int lives = 8; 
        bool isGameWon = false;


        List<String> words = new List<string> {
            "Ytringsfrihed",
            "Jantelov",
            "Grimrian",
            "Viking",
            "Lærer",
            "Studerende",
            "Fodbold",
            "Håndbold",
            "Sport",
            "Arbejde",
            "Surfer",
            "Atlet"
        };


        //For running in console
        public void play()
        {
            //Initializes the word to guess and sets the propper length of the guessing array
            start();

            //Runs game
            while (isRunning)
            {
                playRound();
            }
        }

        //Starts a game

        public void start()
        {
            setGuesswordInitial();
            isRunning = true;
        }

        public void playRound()
        {
            
            //Prints the word with the player guesses   
            printGuessword();

            //Takes first letter in the user input
            string guessLetter = Console.ReadLine();

            //Update with the user guess
            Console.Clear();
            PlayerGuess(guessLetter);
            Console.WriteLine("Player has made following guesses: " + playerGuesses);
            isGameOver();
        }

        public void printGuessword()
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < word.Length; i++)
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
            Console.WriteLine(sb.ToString() + " " + "Lives: " + lives + "\n Wrong guesses: " + wrongLetters);            
        }

        public string getRandomWord()
        {
            int listLenght = words.Count-1;
            Random random = new Random();
                      
            return words[random.Next(0, listLenght)];
        }


        //Is to be expanded when reading word from a file
        public void setGuesswordInitial()
        {            
            word = getRandomWord();
            guessword = new bool[word.Length];
        }


        public Boolean PlayerGuess(string letter)
        {

            //Converts players guess and word to guess to uppercase

            isGameOver();

            if (!string.IsNullOrEmpty(letter) && isRunning)
            {
                string upperletter = letter.ToUpper();

                char guessletter = upperletter[0];
                string upperword = word.ToUpper();

                if (Regex.IsMatch(upperletter, @"^[a-åA-å]+$"))
                {
                    if (playerGuesses != null && playerGuesses.Contains(upperletter))
                    {
                        Console.WriteLine("You have already guessed on the letter " + guessletter);
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

                    }
                    return true;
                }
                else
                {
                    Console.WriteLine("Is not a letter");
                    return false;
                }
            }
            else
            {
                Console.WriteLine("U must enter a guess");
                return false;
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
            if (lives <= 0)
            {
                /**
                Console.Clear();
                Console.WriteLine(gameLostMessage());
                **/
                Stop();
                return;
            }
            for (int i = 0; i < guessword.Length; i++)
            {
                if (guessword[i] == false)
                {
                  return;                    
                }
            }

            //Only reaches here if game is won

            
            Stop();
            /**
            Console.Clear();
            Console.Write("Game is Won");
            **/
            isGameWon = true;
        }

        private String gameLostMessage()
        {
            String gameOverMessage = "U have lost the game";
            Stop();
            return gameOverMessage;
            
        }

        private void guessWord()
        {
            //TODO:Fix
        }

        public void Stop()
        {
            isRunning = false;
        }

        public int getlives()
        {
            return lives;
        }

        public string getword()
        {
            return word;
        }

        public string getwrongguesses()
        {
            return wrongLetters;
        }

        public string getplayerguesses()
        {
            return playerGuesses;
        }

        public bool getIsGameRunning()
        {
            return isRunning;
        }

        public bool getisGameWon()
        {
            return isGameWon;
        }
    }

}
