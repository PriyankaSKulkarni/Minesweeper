using Minesweeper.Interfaces;

namespace Minesweeper.Services
{
    public class MinesweeperService : IMinesweeperService
    {
        private readonly IMineField _mineField;
        private bool _gameOver;
        private bool _gameWon;

        public MinesweeperService(IMineField mineField)
        {
            _mineField = mineField;
        }

        public void StartGame(int mineFieldSize, int numBombs)
        {
            _mineField.SetBombs( numBombs);

            while (!_gameOver && !_gameWon)
            {
                _mineField.Display();

                int row = 0;
                int col = 0;
                bool validInput = false;
                do
                {
                    Console.WriteLine("Enter row and column (e.g., 0 1): ");
                    string[] input = Console.ReadLine().Split(' ');

                    if (input.Length != 2 || !int.TryParse(input[0], out row) || !int.TryParse(input[1], out col))
                    {
                        Console.WriteLine("Invalid input. Please enter row and column indices separated by space.");
                        continue;
                    }

                    if (row < 0 || row >= mineFieldSize || col < 0 || col >= mineFieldSize)
                    {
                        Console.WriteLine("Invalid input. Row and column indices must be within the range of the minefield size.");
                        continue;
                    }

                    validInput = true;
                } while (!validInput);

                if (_mineField.IsBomb(row,col))
                {
                    _gameOver = true;
                    _mineField.Display();
                    Console.WriteLine("Game Over! You hit a bomb.");
                }
                else
                {
                    _mineField.RevealSquare(row, col);
                    if (_mineField.CheckWin(numBombs))
                    {
                        _gameWon = true;
                        Console.WriteLine("Congratulations! You win!");
                    }
                }
            }
        }
    }
}