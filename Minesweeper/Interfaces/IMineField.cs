namespace Minesweeper.Interfaces
{
    public interface IMineField
    {
        char[,] GenerateMineField(int size);
        void SetBombs(char[,] mineField, int numBombs);
        void Display(char[,] mineField);
        void RevealSquare(char[,] mineField, int row, int col);
        bool CheckWin(char[,] mineField, int numBombs);
    }
}

