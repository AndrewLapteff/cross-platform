using lab1;
using Xunit;

public class CalculatePointsTests
{
    [Theory]
    [InlineData(2, 12)]
    [InlineData(3, 30)]
    public void CalculateTotalPoints_ShouldReturnCorrectPoints(int input, int expected)
    {
        // Act
        var dominoSet = new DominoCounter();
        int result = dominoSet.CalculateTotalDominoPoints(input);

        // Assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(2, 13)]
    [InlineData(3, 300)]
    public void CalculateTotalPoints_ShouldReturnIncorrectPoints(int input, int expected)
    {
        // Act
        var dominoSet = new DominoCounter();
        int result = dominoSet.CalculateTotalDominoPoints(input);

        // Assert
        Assert.NotEqual(expected, result);
    }
}
