namespace Minesweeper.Interfaces
{
    public interface IMineField
    {
        char[,] GenerateMineField();
        void SetBombs(int numBombs);
        bool IsBomb(int row, int col);
        void Display();
        void RevealSquare(int row, int col);
        bool CheckWin(int numBombs);
    }
}

