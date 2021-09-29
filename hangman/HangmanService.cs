using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Hangman
{
    public class HangmanService
    {

        private WordRepository wordRepository;

        public HangmanService()
        {
            wordRepository = new WordRepository();
        }

        public String RandomizeWord()
        {
            String[] words = wordRepository.GetAll();
            Random random = new Random();
            return words.ElementAt(random.Next(0, words.Count()-1));
        }

        public char[] FillArrayWithUnderscore(char[] letters)
        {
            return Enumerable.Range(1, letters.Length).Select(i => '_').ToArray();
        }

        public char[] InsertGuessInArray(char[] correctGuesses, String guess, String answer)
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

        public String ValidGuess()
        {
            String input = "";
            bool isValid = false;
            while (!isValid)
            {
                Console.WriteLine("Enter a guess from a-ö or the word");
                input = Console.ReadLine();
                isValid = Regex.IsMatch(input, @"^[a-öA-Ö]+$");

                if (!isValid)
                {
                    Console.WriteLine("Not a valid guess");
                }
            }
            return input;
        }

        public bool CheckCorrectGuess(String guess, String answer)
        {
            if (answer.Equals(guess))
            {
                Console.WriteLine($"Your guess: {guess} was correct! \n");
                return true;
            }
            else
            {
                Console.WriteLine($"Your guess: {guess} was incorrect. \n");
                return false;
            }
        }
    }
}
