using Minesweeper.Interfaces;

namespace Minesweeper.Services
{
    public class MineField : IMineField
    {
        public char[,] GenerateMineField(int size)
        {
            char[,] mineField = new char[size, size];
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    mineField[i, j] = '?';
                }
            }
            return mineField;
        }

        public void SetBombs(char[,] mineField, int numBombs)
        {
            Random rand = new Random();
            int count = 0;
            int mineFieldSize = mineField.GetLength(0);

            while (count < numBombs)
            {
                int row = rand.Next(mineFieldSize);
                int col = rand.Next(mineFieldSize);

                if (mineField[row, col] != '*')
                {
                    mineField[row, col] = '*';
                    count++;
                }
            }
        }

        public void Display(char[,] mineField)
        {
            int mineFieldSize = mineField.GetLength(0);
            Console.WriteLine("  " + string.Join(" ", new string[mineFieldSize]));
            for (int i = 0; i < mineFieldSize; i++)
            {
                Console.Write(i + " ");
                for (int j = 0; j < mineFieldSize; j++)
                {
                    if (mineField[i, j] == '?' || mineField[i, j] == '*')
                    {
                        Console.Write("? ");
                    }
                    else
                    {
                        Console.Write(mineField[i, j] + " ");
                    }
                }
                Console.WriteLine();
            }
        }

        public void RevealSquare(char[,] mineField, int row, int col)
        {
            int mineFieldSize = mineField.GetLength(0);
            if (row < 0 || row >= mineFieldSize || col < 0 || col >= mineFieldSize || mineField[row, col] != '?')
            {
                return;
            }

            int bombs = CountAdjacentBombs(mineField, row, col);
            if (bombs == 0)
            {
                mineField[row, col] = ' ';
                RevealAdjacent(mineField, row, col);
            }
            else
            {
                mineField[row, col] = char.Parse(bombs.ToString());
            }
        }

        public bool CheckWin(char[,] mineField, int numBombs)
        {
            int mineFieldSize = mineField.GetLength(0);
            int revealedCount = 0;

            for (int i = 0; i < mineFieldSize; i++)
            {
                for (int j = 0; j < mineFieldSize; j++)
                {
                    if (char.IsDigit(mineField[i, j]) || mineField[i, j] == ' ')
                    {
                        revealedCount++;
                    }
                }
            }

            return revealedCount == (mineFieldSize * mineFieldSize - numBombs);
        }

        private void RevealAdjacent(char[,] mineField, int row, int col)
        {
            int mineFieldSize = mineField.GetLength(0);
            for (int i = row - 1; i <= row + 1; i++)
            {
                for (int j = col - 1; j <= col + 1; j++)
                {
                    if (i >= 0 && i < mineFieldSize && j >= 0 && j < mineFieldSize)
                    {
                        RevealSquare(mineField, i, j);
                    }
                }
            }
        }

        private int CountAdjacentBombs(char[,] mineField, int row, int col)
        {
            int count = 0;
            int mineFieldSize = mineField.GetLength(0);

            for (int i = row - 1; i <= row + 1; i++)
            {
                for (int j = col - 1; j <= col + 1; j++)
                {
                    if (i >= 0 && i < mineFieldSize && j >= 0 && j < mineFieldSize && mineField[i, j] == '*')
                    {
                        count++;
                    }
                }
            }

            return count;
        }

    }
}