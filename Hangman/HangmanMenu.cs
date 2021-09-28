using System;

namespace Hangman
{
    public class HangmanMenu
    {
        private HangmanGame hangmanGame;

        public HangmanMenu()
        {
            hangmanGame = new HangmanGame();
        }

        public void start()
        {
            bool isRunning = true;

            while(isRunning)
            {
                showMenu();
                int input = validMenuInput();

                if (input == 1)
                {
                    hangmanGame.start();
                }
                else
                {
                    isRunning = false;
                }
            }
        }

        private void showMenu()
        {
            Console.WriteLine("1. Start\n2. Exit\n");
        } 

        private int validMenuInput()
        {
            bool isValidNumber = false;
            int input = 0;
            while (!isValidNumber)
            {
                Console.WriteLine("Enter a number\n");
                isValidNumber = Int32.TryParse(Console.ReadLine(), out input);
                if (!isValidNumber)
                {
                    Console.WriteLine("not a valid menu choice");
                }
            }
            return input;
        }
    }
}
