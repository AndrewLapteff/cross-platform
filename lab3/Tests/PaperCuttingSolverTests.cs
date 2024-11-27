using System;
using Xunit;
using System.Reflection;

public class PaperCuttingSolverMemoryTests
{
    private int InvokeCountParts(int[,] matrix)
    {
        Type solverType = typeof(PaperCuttingSolver);
        MethodInfo countPartsMethod = solverType.GetMethod("CountParts", BindingFlags.NonPublic | BindingFlags.Static);

        return (int)countPartsMethod.Invoke(null, new object[] { matrix.GetLength(0), matrix.GetLength(1), matrix });
    }

    [Fact]
    public void TestSimpleCase_TwoPartsExpected()
    {
        // Arrange
        int[,] matrix = new int[,]
        {
            {0, 0, 1, 0},
            {0, 0, 1, 0},
            {0, 1, 0, 0},
            {1, 0, 0, 1}
        };

        // Act
        int result = InvokeCountParts(matrix);

        // Assert
        Assert.Equal(2, result);
    }

    [Fact]
    public void TestAllCellsCut_SinglePartExpected()
    {
        // Arrange
        int[,] matrix = new int[,]
        {
            {1, 1, 1},
            {1, 1, 1},
            {1, 1, 1}
        };

        // Act
        int result = InvokeCountParts(matrix);

        // Assert
        Assert.Equal(0, result);
    }

    [Fact]
    public void TestNoCuts_SinglePartExpected()
    {
        // Arrange
        int[,] matrix = new int[,]
        {
            {0, 0},
            {0, 0}
        };

        // Act
        int result = InvokeCountParts(matrix);

        // Assert
        Assert.Equal(1, result);
    }

    [Fact]
    public void TestLargeCutGrid_MultipleParts()
    {
        // Arrange
        int[,] matrix = new int[,]
        {
            {1, 0, 1, 0, 1},
            {0, 1, 0, 1, 0},
            {1, 0, 1, 0, 1},
            {0, 1, 0, 1, 0},
            {1, 0, 1, 0, 1}
        };

        // Act
        int result = InvokeCountParts(matrix);

        // Assert
        Assert.Equal(12, result);
    }

    [Fact]
    public void TestSingleCellGrid_OnePart()
    {
        // Arrange
        int[,] matrix = new int[,]
        {
            {0}
        };

        // Act
        int result = InvokeCountParts(matrix);

        // Assert
        Assert.Equal(1, result);
    }

    [Fact]
    public void TestComplexCutPattern_EightParts()
    {
        // Arrange
        int[,] matrix = new int[,]
        {
            {1, 0, 1, 0},
            {0, 1, 0, 1},
            {1, 0, 1, 0},
            {0, 1, 0, 1}
        };

        // Act
        int result = InvokeCountParts(matrix);

        // Assert
        Assert.Equal(8, result);
    }
}