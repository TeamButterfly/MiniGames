using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TicTacToe;

namespace API.JsonModels
{
    public class TicTacToeResponseModel
    {
        public List<List<TicTacToeEnum>> Board { get; set; }
        public TicTacToeEnum Winner { get; set; }
    }
}
