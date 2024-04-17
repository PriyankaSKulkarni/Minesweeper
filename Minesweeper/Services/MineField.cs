using Minesweeper.Interfaces;

namespace Minesweeper.Services
{
    public class MineField : IMineField
    {
        private char[,] _squares;
        public int Size { get; private set; }

        public MineField(int size)
        {
            Size = size;
            _squares = GenerateMineField();
        }

        public char[,] GenerateMineField()
        {
            char[,] mineField = new char[Size, Size];
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    mineField[i, j] = '?';
                }
            }
            return mineField;
        }

        public void SetBombs(int numBombs)
        {
            Random rand = new Random();
            int count = 0;
            int mineFieldSize = _squares.GetLength(0);

            while (count < numBombs)
            {
                int row = rand.Next(mineFieldSize);
                int col = rand.Next(mineFieldSize);

                if (_squares[row, col] != '*')
                {
                    _squares[row, col] = '*';
                    count++;
                }
            }
        }

        public bool IsBomb(int row, int col)
        {
            return _squares[row, col] == '*';
        }

        public void Display()
        {
            int mineFieldSize = _squares.GetLength(0);
            Console.WriteLine("  " + string.Join(" ", new string[mineFieldSize]));
            for (int i = 0; i < mineFieldSize; i++)
            {
                Console.Write(i + " ");
                for (int j = 0; j < mineFieldSize; j++)
                {
                    if (_squares[i, j] == '?' || _squares[i, j] == '*')
                    {
                        Console.Write("? ");
                    }
                    else
                    {
                        Console.Write(_squares[i, j] + " ");
                    }
                }
                Console.WriteLine();
            }
        }

        public void RevealSquare(int row, int col)
        {
            int mineFieldSize = _squares.GetLength(0);
            if (row < 0 || row >= mineFieldSize || col < 0 || col >= mineFieldSize || _squares[row, col] != '?')
            {
                return;
            }

            int bombs = CountAdjacentBombs(row, col);
            if (bombs == 0)
            {
                _squares[row, col] = ' ';
                RevealAdjacent(row, col);
            }
            else
            {
                _squares[row, col] = char.Parse(bombs.ToString());
            }
        }

        public bool CheckWin(int numBombs)
        {
            int mineFieldSize = _squares.GetLength(0);
            int revealedCount = 0;

            for (int i = 0; i < mineFieldSize; i++)
            {
                for (int j = 0; j < mineFieldSize; j++)
                {
                    if (char.IsDigit(_squares[i, j]) || _squares[i, j] == ' ')
                    {
                        revealedCount++;
                    }
                }
            }

            return revealedCount == (mineFieldSize * mineFieldSize - numBombs);
        }

        private void RevealAdjacent(int row, int col)
        {
            int mineFieldSize = _squares.GetLength(0);
            for (int i = row - 1; i <= row + 1; i++)
            {
                if (i >= 0 && i < mineFieldSize)
                {
                    for (int j = col - 1; j <= col + 1; j++)
                    {
                        if (j >= 0 && j < mineFieldSize)
                        {
                            RevealSquare(i, j);
                        }
                    }
                }                
            }
        }

        private int CountAdjacentBombs(int row, int col)
        {
            int count = 0;
            int mineFieldSize = _squares.GetLength(0);

            for (int i = row - 1; i <= row + 1; i++)
            {
                for (int j = col - 1; j <= col + 1; j++)
                {
                    if (i >= 0 && i < mineFieldSize && j >= 0 && j < mineFieldSize && _squares[i, j] == '*')
                    {
                        count++;
                    }
                }
            }

            return count;
        }

    }
}