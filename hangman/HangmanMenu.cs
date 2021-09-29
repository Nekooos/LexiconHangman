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

        public void Start()
        {
            bool isRunning = true;

            while(isRunning)
            {
                ShowMenu();
                int input = ValidMenuInput();

                if (input == 1)
                {
                    hangmanGame.Start();
                }
                else
                {
                    isRunning = false;
                }
            }
        }

        private void ShowMenu()
        {
            Console.WriteLine("1. Start\n2. Exit\n");
        } 

        private int ValidMenuInput()
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
