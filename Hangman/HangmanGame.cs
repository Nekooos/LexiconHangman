using System;
using System.Text;
using System.Text.RegularExpressions;

namespace Hangman
{
    class HangmanGame
    {
        private HangmanService hangmanService;

        public HangmanGame()
        {
            hangmanService = new HangmanService();
        }

        public void start()
        {
            int wrongGuessCount = 0;
            String answer = hangmanService.randomizeWord().ToLower();
            bool isGuessCorrect = false;
            char[] correctGuesses = new char[answer.Length];
            StringBuilder wrongGuesses = new StringBuilder();
            correctGuesses = hangmanService.fillArrayWithUnderscore(correctGuesses);

            while (!isGuessCorrect)
            {
                Console.WriteLine($"{wrongGuessCount}/10 wrong guesses");
                printArray(correctGuesses);
                String guess = validGuess().ToLower();

                if(guess.Length > 1)
                {
                    isGuessCorrect = CheckCorrectGuess(guess, answer);
                    wrongGuessCount = wrongGuessCount + (isGuessCorrect ? 0 : 1);
                } 
                else
                {
                    if(answer.Contains(guess)) {
                        correctGuesses = hangmanService.insertGuessInArray(correctGuesses, guess, answer);
                    } 
                    else
                    {
                        if(!wrongGuesses.ToString().Contains(guess))
                        {
                            wrongGuesses.Append(guess);
                            wrongGuessCount = wrongGuessCount + 1;
                        }
                    }
                }

                if(wrongGuessCount == 10)
                {
                    Console.WriteLine($"You guessed {wrongGuessCount} times. Try again");
                    isGuessCorrect = true;
                }
            }
        }

        private void printArray(char[] guesses)
        {
            foreach (char letter in guesses)
            {
                Console.Write($"{letter} ");
            }
            Console.WriteLine("\n");
        }

        private bool CheckCorrectGuess(String guess, String answer)
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

        public String validGuess()
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
    }
}
