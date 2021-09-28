using System;
using System.Text;

namespace Hangman
{
    public class HangmanGame
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
                PrintArray(correctGuesses);
                String guess = hangmanService.ValidGuess().ToLower();

                if(guess.Length > 1)
                {
                    isGuessCorrect = hangmanService.CheckCorrectGuess(guess, answer);
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

        private void PrintArray(char[] guesses)
        {
            foreach (char letter in guesses)
            {
                Console.Write($"{letter} ");
            }
            Console.WriteLine("\n");
        }

    }
}
