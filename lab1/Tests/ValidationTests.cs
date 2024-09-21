using lab1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;


public class ValidationTests
{
    [Theory]
    [InlineData("2", true)]
    [InlineData("3", true)]
    [InlineData("a", false)]
    [InlineData("1000", false)]
    [InlineData("", false)]
    [InlineData("0", false)]
    public void IsValidNumber_ShouldReturnCorrectValidation(string input, bool expected)
    {
        // Act
        var dominoSet = new DominoSet();
        var validation = new Validation();
        bool result = validation.IsValidNumber(input);

        // Assert
        Assert.Equal(expected, result);
    }
}
