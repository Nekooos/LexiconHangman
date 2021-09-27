using System;
using System.Linq;

namespace Hangman
{
    class HangmanService
    {

        private WordRepository wordRepository;

        public HangmanService()
        {
            wordRepository = new WordRepository();
        }

        public String randomizeWord()
        {
            String[] words = wordRepository.GetAll();
            Random random = new Random();
            return words.ElementAt(random.Next(0, words.Count()-1));
        }

        public char[] fillArrayWithUnderscore(char[] letters)
        {
            for(int i = 0; i < letters.Length; i++)
            {
                letters[i] = '_';
            }
            return letters;
        }

        public char[] insertGuessInArray(char[] correctGuesses, String guess, String answer)
        {
            char charGuess = char.Parse(guess);

            for (int i = 0; i < answer.Length; i++)
            {
                if(answer.ElementAt(i).Equals(charGuess))
                {
                    correctGuesses[i] = charGuess;
                }
            }
            return correctGuesses;
        }
    }
}
