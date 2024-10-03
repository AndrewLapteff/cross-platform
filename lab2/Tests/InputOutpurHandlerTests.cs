using Xunit;
using System.IO;
using System;

namespace lab2.Tests 
{
    public class InputOutputHandlerTests
    {
        [Fact]
        public void ReadInput_ValidInputFile_ShouldReturnCorrectData()
        {
            // Arrange
            string inputFilePath = "test_input.txt";
            File.WriteAllText(inputFilePath, "31 3 7 2 1 6 7 2 10 20");

            InputOutputHandler ioHandler = new InputOutputHandler();

            // Act
            var (n, k, w, dw, s, weeklyRestDays, dm, monthlyRestDays) = ioHandler.ReadInput(inputFilePath);

            // Assert
            Assert.Equal(31, n);
            Assert.Equal(3, k);
            Assert.Equal(7, w);
            Assert.Equal(2, dw);
            Assert.Equal(1, s);
            Assert.Equal(new int[] { 6, 7 }, weeklyRestDays);
            Assert.Equal(2, dm);
            Assert.Equal(new int[] { 10, 20 }, monthlyRestDays);

            // Cleanup
            File.Delete(inputFilePath);
        }

        [Fact]
        public void WriteOutput_ValidOutput_ShouldWriteToFile()
        {
            // Arrange
            string outputFilePath = "test_output.txt";
            InputOutputHandler ioHandler = new InputOutputHandler();
            int result = 5;

            // Act
            ioHandler.WriteOutput(outputFilePath, result);

            // Assert
            string writtenData = File.ReadAllText(outputFilePath);
            Assert.Equal("5", writtenData);

            // Cleanup
            File.Delete(outputFilePath);
        }

        [Fact]
        public void ReadInput_InsufficientData_ShouldThrowException()
        {
            // Arrange
            string inputFilePath = "test_input_invalid.txt";
            File.WriteAllText(inputFilePath, "31 3");

            InputOutputHandler ioHandler = new InputOutputHandler();

            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() => ioHandler.ReadInput(inputFilePath));
            Assert.Equal("Некорректные данные во входном файле.", exception.Message);

            // Cleanup
            File.Delete(inputFilePath);
        }

        [Fact]
        public void ReadInput_InvalidHolidayData_ShouldThrowException()
        {
            // Arrange
            string inputFilePath = "test_input_invalid_holiday.txt";
            File.WriteAllText(inputFilePath, "31 3 7 2 1 6 7 5 40");

            InputOutputHandler ioHandler = new InputOutputHandler();

            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() => ioHandler.ReadInput(inputFilePath));
            Assert.Equal("Некорректные данные для праздничных дней.", exception.Message);

            // Cleanup
            File.Delete(inputFilePath);
        }

        [Fact]
        public void ReadInput_InvalidRestDays_ShouldThrowException()
        {
            // Arrange
            string inputFilePath = "test_input_invalid_rest.txt";
            File.WriteAllText(inputFilePath, "31 3 7 2 1 10 11");

            InputOutputHandler ioHandler = new InputOutputHandler();

            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() => ioHandler.ReadInput(inputFilePath));
            Assert.Equal("Некорректные данные для праздничных дней.", exception.Message);

            // Cleanup
            File.Delete(inputFilePath);
        }
    }
}