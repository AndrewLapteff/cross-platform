using Xunit;

namespace lab3.Tests
{
    public class GridTests
    {
        [Fact]
        public void SinglePart_NoLines_ShouldReturn1()
        {
            int[,] grid = {
            { 0, 0 },
            { 0, 0 }
        };

            Grid gridObj = new Grid(grid);
            int result = gridObj.CountParts();

            Assert.Equal(1, result);
        }

        [Fact]
        public void MultipleParts_WithSingleLine_ShouldReturn2()
        {
            int[,] grid = {
            { 0, 1 },
            { 0, 0 }
        };

            Grid gridObj = new Grid(grid);
            int result = gridObj.CountParts();

            Assert.Equal(1, result);
        }

        [Fact]
        public void ComplexGrid_WithMultipleLines_ShouldReturn4()
        {
            int[,] grid = {
            { 1, 0, 1 },
            { 0, 1, 0 },
            { 1, 0, 1 }
        };

            Grid gridObj = new Grid(grid);
            int result = gridObj.CountParts();

            Assert.Equal(4, result);
        }

        [Fact]
        public void SingleRow_MultipleParts_ShouldReturn3()
        {
            int[,] grid = {
            { 0, 1, 0, 1, 0 }
        };

            Grid gridObj = new Grid(grid);
            int result = gridObj.CountParts();

            Assert.Equal(3, result);
        }

        [Fact]
        public void EmptyGrid_NoParts_ShouldReturn0()
        {
            int[,] grid = { };

            Grid gridObj = new Grid(grid);
            int result = gridObj.CountParts();

            Assert.Equal(0, result);
        }
    }
}
