using System.ComponentModel.DataAnnotations;

namespace API.JsonModels
{
    public class SlidePuzzleModel
    {
        public int[,] Board { get; set; }
       
        [Required(ErrorMessage = "Brugernavnet er påkrævet")]
        public string Username { get; set; }
        
    }
}
