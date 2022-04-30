using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman
{
    public class HangmanModel
    {
        public int Life { get; set; }
        public string Word { get; set; }
        public string RevealedWord { get; set; }
        public List<char> Guesses { get; set; }
        public bool IsGameWon { get; set; }
    }
}
