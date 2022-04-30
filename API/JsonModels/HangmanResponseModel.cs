namespace API.JsonModels
{
    public class HangmanResponseModel
    {
        public int Life { get; set; }
        public string RevealedWord { get; set; }
        public bool IsGameWon { get; set; }
    }
}
