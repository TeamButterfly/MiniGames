using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace TicTacToe
{
    public enum TicTacToeEnum
    {
        None = 0, Cross = 1, Circle = 2
    }

    public class TicTacToeModel
    {
        public List<List<TicTacToeEnum>> Board { get; set; }
        public TicTacToeEnum Winner { get; set; }
    }
}
