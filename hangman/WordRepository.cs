using System;

namespace Hangman
{
    public class WordRepository
    {
        private String[] words = new string[] 
        {
            "båt",
            "ödla",
            "bäver",
            "bensin",
            "apelsin",
            "bokhylla"
        };

        public String[] GetAll()
        {
            return words;
        }
    }
}
