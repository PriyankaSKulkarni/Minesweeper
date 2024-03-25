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
            char[,] mineField = _mineField.GenerateMineField(mineFieldSize);
            _mineField.SetBombs(mineField, numBombs);

            while (!_gameOver && !_gameWon)
            {
                _mineField.Display(mineField);

                Console.WriteLine("Enter row and column (e.g., 0 1): ");
                string[] input = Console.ReadLine().Split(' ');
                int row = int.Parse(input[0]);
                int col = int.Parse(input[1]);

                if (mineField[row, col] == '*')
                {
                    _gameOver = true;
                    _mineField.Display(mineField);
                    Console.WriteLine("Game Over! You hit a bomb.");
                }
                else
                {
                    _mineField.RevealSquare(mineField, row, col);
                    if (_mineField.CheckWin(mineField, numBombs))
                    {
                        _gameWon = true;
                        Console.WriteLine("Congratulations! You win!");
                    }
                }
            }
        }
    }
}