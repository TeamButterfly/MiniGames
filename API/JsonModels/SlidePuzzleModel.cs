using System.ComponentModel.DataAnnotations;

namespace API.JsonModels
{
    public class SlidePuzzleResponseModel
    {
        public int[] Board { get; set; }

        public bool IsGameWon { get; set; }
    }
}
