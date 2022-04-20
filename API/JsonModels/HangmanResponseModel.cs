namespace API.JsonModels
{
    public class HangmanResponseModel
    {
        public int Life { get; set; }
        public bool IsLetterGuessed { get; set; }
        public bool IsGameRunning { get; set; }

        public string word { get; set; }

        public string guessletter { get; set; }

        public string wrongguesses { get; set; }

        public string playerguesses { get; set; }
    }
}
