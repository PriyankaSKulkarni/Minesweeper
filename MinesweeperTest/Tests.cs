using Minesweeper.Interfaces;
using Minesweeper.Services;

[TestClass]
public class MinesweeperTests
{
    [TestMethod]
    public void TestGenerateMineField()
    {
        // Arrange
        IMineField mineField = new MineField();
        int size = 5;

        // Act
        char[,] generatedMineField = mineField.GenerateMineField(size);

        // Assert
        Assert.AreEqual(size, generatedMineField.GetLength(0));
        Assert.AreEqual(size, generatedMineField.GetLength(1));
    }

    [TestMethod]
    public void TestSetBombs()
    {
        // Arrange
        IMineField mineField = new MineField();
        int size = 5;
        int numBombs = 5;
        char[,] mineFieldGame = mineField.GenerateMineField(size);

        // Act
        mineField.SetBombs(mineFieldGame, numBombs);

        // Assert
        int bombsCount = 0;
        foreach (char c in mineFieldGame)
        {
            if (c == '*')
            {
                bombsCount++;
            }
        }
        Assert.AreEqual(numBombs, bombsCount);
    }

    [TestMethod]
    public void TestCheckWin_SomeBombsRevealed_ReturnsFalse()
    {
        // Arrange
        IMineField mineField = new MineField();
        int numBombs = 5;

        char[,] generatedMineField = new char[,]
        {
            { '1', '*', '2' },
            { '*', '3', '*' },
            { '4', '*', '5' }
        };        

        // Act
        bool result = mineField.CheckWin(generatedMineField, numBombs);

        // Assert
        Assert.IsFalse(result, "Expected CheckWin to return false when some mines are revealed.");
    }

    [TestMethod]
    public void TestCheckWin_AllSafeSquaresRevealed_ReturnsTrue()
    {
        // Arrange
        IMineField mineField = new MineField();
        int numBombs = 3;

        char[,] generatedMineField = new char[,]
        {
            { '1', '*', '2' },
            { '*', '3', '4' },
            { '5', '*', '6' },
        };

        // Act
        bool result = mineField.CheckWin(generatedMineField, numBombs);

        // Assert
        Assert.IsTrue(result, "Expected CheckWin to return true when all safe squares are revealed.");
    }

}
