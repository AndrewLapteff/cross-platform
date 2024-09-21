using crossplatform;
using Xunit;

public class CalculatePointsTests
{
    [Theory]
    [InlineData(2, 12)]
    [InlineData(3, 30)]
    public void CalculateTotalPoints_ShouldReturnCorrectPoints(int input, int expected)
    {
        // Act
        var dominoSet = new DominoSet();
        int result = dominoSet.CalculateTotalPoints(input);

        // Assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(2, 13)]
    [InlineData(3, 300)]
    public void CalculateTotalPoints_ShouldReturnIncorrectPoints(int input, int expected)
    {
        // Act
        var dominoSet = new DominoSet();
        int result = dominoSet.CalculateTotalPoints(input);

        // Assert
        Assert.NotEqual(expected, result);
    }
}
