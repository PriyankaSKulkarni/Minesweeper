using Minesweeper.Interfaces;
using Minesweeper.Services;

namespace Minesweeper
{
    class Minesweeper
    {
        public static void Main()
        {
            Console.WriteLine("Enter size of mine field: ");
            int mineFieldSize = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter how many bombs you want to set: ");
            int numBombs = int.Parse(Console.ReadLine());

            IMineField mineField = new MineField();
            IMinesweeperService game = new MinesweeperService(mineField);
            game.StartGame(mineFieldSize, numBombs);

            Console.ReadLine();
        }
    }
}


