﻿namespace API.JsonModels
{
    public class HangmanResponseModel
    {
        public int Life { get; set; }
        public bool IsLetterGuessed { get; set; }
        public bool IsGameWon { get; set; }
        public bool IsGameLost { get; set; }

        public string word { get; set; }

        public string guessletter { get; set; }

    }
}
