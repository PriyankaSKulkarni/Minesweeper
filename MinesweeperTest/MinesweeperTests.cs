using Minesweeper.Interfaces;
using Minesweeper.Services;

[TestClass]
public class MinesweeperTests
{
    [TestMethod]
    public void TestGenerateMineField()
    {
        // Arrange
        int size = 5;
        IMineField mineField = new MineField(size);        

        // Act
        char[,] generatedMineField = mineField.GenerateMineField();

        // Assert
        Assert.AreEqual(size, generatedMineField.GetLength(0));
        Assert.AreEqual(size, generatedMineField.GetLength(1));
    }

    [TestMethod]
    public void TestSetBombs()
    {
        // Arrange
        int size = 5;
        IMineField mineField = new MineField(size);
        
        int numBombs = 5;
        char[,] mineFieldGame = mineField.GenerateMineField();

        // Act
        mineField.SetBombs(numBombs);

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

    //[TestMethod]
    //public void TestCheckWin_SomeBombsRevealed_ReturnsFalse()
    //{
    //    // Arrange
    //    int size = 5;
    //    IMineField mineField = new MineField(size);
    //    int numBombs = 5;

    //    char[,] generatedMineField = new char[,]
    //    {
    //        { '1', '*', '2' },
    //        { '*', '3', '*' },
    //        { '4', '*', '5' }
    //    };        

    //    // Act
    //    bool result = mineField.CheckWin(generatedMineField, numBombs);

    //    // Assert
    //    Assert.IsFalse(result, "Expected CheckWin to return false when some mines are revealed.");
    //}

    //[TestMethod]
    //public void TestCheckWin_AllSafeSquaresRevealed_ReturnsTrue()
    //{
    //    // Arrange
    //    IMineField mineField = new MineField();
    //    int numBombs = 3;

    //    char[,] generatedMineField = new char[,]
    //    {
    //        { '1', '*', '2' },
    //        { '*', '3', '4' },
    //        { '5', '*', '6' },
    //    };

    //    // Act
    //    bool result = mineField.CheckWin(generatedMineField, numBombs);

    //    // Assert
    //    Assert.IsTrue(result, "Expected CheckWin to return true when all safe squares are revealed.");
    //}

}
