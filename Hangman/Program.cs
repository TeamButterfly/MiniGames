using System;

namespace Hangman
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HangmanGame game = new HangmanGame();
            game.play();
        }
    }
}
