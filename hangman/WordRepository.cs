using System;

namespace Hangman
{
    class WordRepository
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
