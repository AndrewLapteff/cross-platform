using Xunit;

namespace lab2.Tests
{
    public class OlympiadSchedulerTests
    {
        [Fact]
        public void CalculateOlympiadDays_ValidInput_ShouldReturnCorrectResult()
        {
            // Arrange
            OlympiadScheduler scheduler = new OlympiadScheduler();
            int n = 31; // Number of days in the month
            int k = 3;  // Length of the olympiad
            int w = 7;  // Number of days in the week
            int dw = 2; // Number of rest days in the week
            int s = 1;  // Starting day of the week
            int[] weeklyRestDays = { 6, 7 }; // Weekend days
            int dm = 2; // Number of holidays
            int[] monthlyRestDays = { 10, 20 }; // Holiday days

            // Act
            int result = scheduler.CalculateOlympiadDays(n, k, w, dw, s, weeklyRestDays, dm, monthlyRestDays);

            // Assert
            Assert.Equal(10, result);
        }

        [Fact]
        public void CalculateOlympiadDays_NoRestDays_ShouldReturnFullAvailableDays()
        {
            // Arrange
            OlympiadScheduler scheduler = new OlympiadScheduler();
            int n = 31;
            int k = 5;
            int w = 7;
            int dw = 0;  // No rest days
            int s = 1;
            int[] weeklyRestDays = { };
            int dm = 0;  // No holidays
            int[] monthlyRestDays = { };

            // Act
            int result = scheduler.CalculateOlympiadDays(n, k, w, dw, s, weeklyRestDays, dm, monthlyRestDays);

            // Assert
            Assert.Equal(27, result);
        }

        [Fact]
        public void CalculateOlympiadDays_AllDaysAreHolidays_ShouldReturnZero()
        {
            // Arrange
            OlympiadScheduler scheduler = new OlympiadScheduler();
            int n = 10;
            int k = 3;
            int w = 7;
            int dw = 7;  // All days of the week are rest days
            int s = 1;
            int[] weeklyRestDays = { 1, 2, 3, 4, 5, 6, 7 };
            int dm = 0;
            int[] monthlyRestDays = { };

            // Act
            int result = scheduler.CalculateOlympiadDays(n, k, w, dw, s, weeklyRestDays, dm, monthlyRestDays);

            // Assert
            Assert.Equal(0, result);
        }

        [Fact]
        public void CalculateOlympiadDays_HolidayAtStart_ShouldReturnCorrectResult()
        {
            // Arrange
            OlympiadScheduler scheduler = new OlympiadScheduler();
            int n = 15;
            int k = 3;
            int w = 7;
            int dw = 2;
            int s = 2;
            int[] weeklyRestDays = { 1, 7 };
            int dm = 1;
            int[] monthlyRestDays = { 1 };

            // Act
            int result = scheduler.CalculateOlympiadDays(n, k, w, dw, s, weeklyRestDays, dm, monthlyRestDays);

            // Assert
            Assert.Equal(5, result);
        }

        [Fact]
        public void CalculateOlympiadDays_OnlySinglePeriod_ShouldReturnOne()
        {
            // Arrange
            OlympiadScheduler scheduler = new OlympiadScheduler();
            int n = 7;
            int k = 3;
            int w = 7;
            int dw = 1;
            int s = 1;
            int[] weeklyRestDays = { 7 };
            int dm = 1;
            int[] monthlyRestDays = { 5 };

            // Act
            int result = scheduler.CalculateOlympiadDays(n, k, w, dw, s, weeklyRestDays, dm, monthlyRestDays);

            // Assert
            Assert.Equal(2, result);
        }
    }
}