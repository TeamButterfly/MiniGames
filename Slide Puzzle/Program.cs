using System;
using System.Collections;

namespace Slide_Puzzle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            game.setup();
            game.solution();
        }
    }
}
