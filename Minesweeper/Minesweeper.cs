using Minesweeper.Interfaces;
using Minesweeper.Services;

namespace Minesweeper
{
    class Minesweeper
    {
        public static void Main()
        {
            Console.WriteLine("Enter size of mine field: ");
            int mineFieldSize = GetValidIntegerInput("Enter size of mine field (must be a positive integer): ");

            Console.WriteLine("Enter how many bombs you want to set: ");
            int numBombs = GetValidIntegerInput("Enter how many bombs you want to set (must be a positive integer): ");

            IMineField mineField = new MineField(mineFieldSize);
            IMinesweeperService game = new MinesweeperService(mineField);
            game.StartGame(mineFieldSize, numBombs);

            Console.ReadLine();
        }

        private static int GetValidIntegerInput(string message)
        {
            int input;
            bool isValidInput = false;

            do
            {
                Console.WriteLine(message);
                string userInput = Console.ReadLine();

                isValidInput = int.TryParse(userInput, out input) && input > 0;

                if (!isValidInput)
                {
                    Console.WriteLine("Invalid input. Please enter a positive integer.");
                }
            } while (!isValidInput);

            return input;
        }
    }
}


