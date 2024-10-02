using System.Collections.Generic;
using Xunit;

namespace lab2.Tests
{
    public class OlympiadSchedulerTests
    {
        [Fact]
        public void Test_ExampleCase()
        {
            int n = 31, k = 3, w = 7, dw = 1, s = 7;
            List<int> weeklyRestDays = new List<int> { 7 };
            int dm = 2;
            List<int> monthlyRestDays = new List<int> { 1, 9 };

            int result = OlympiadScheduler.CalculateOlympiadDays(n, k, w, dw, s, weeklyRestDays, dm, monthlyRestDays);
            Assert.Equal(15, result);
        }

        [Fact]
        public void Test_NoRestDays()
        {
            int n = 30, k = 5, w = 7, dw = 0, s = 1;
            List<int> weeklyRestDays = new List<int>();
            int dm = 0;
            List<int> monthlyRestDays = new List<int>();

            int result = OlympiadScheduler.CalculateOlympiadDays(n, k, w, dw, s, weeklyRestDays, dm, monthlyRestDays);
            Assert.Equal(26, result);
        }

        [Fact]
        public void Test_AllDaysUnavailable()
        {
            int n = 10, k = 2, w = 7, dw = 2, s = 1;
            List<int> weeklyRestDays = new List<int> { 1, 7 };
            int dm = 5;
            List<int> monthlyRestDays = new List<int> { 2, 3, 4, 5, 6 };

            int result = OlympiadScheduler.CalculateOlympiadDays(n, k, w, dw, s, weeklyRestDays, dm, monthlyRestDays);
            Assert.Equal(0, result);
        }

        [Fact]
        public void Test_LongOlympiad()
        {
            int n = 30, k = 30, w = 7, dw = 1, s = 1;
            List<int> weeklyRestDays = new List<int> { 7 };
            int dm = 0;
            List<int> monthlyRestDays = new List<int>();

            int result = OlympiadScheduler.CalculateOlympiadDays(n, k, w, dw, s, weeklyRestDays, dm, monthlyRestDays);
            Assert.Equal(0, result);
        }

        [Fact]
        public void Test_ValidatorFails()
        {
            int n = 31, k = 32, w = 7, dw = 1, s = 7;
            List<int> weeklyRestDays = new List<int> { 7 };
            int dm = 2;
            List<int> monthlyRestDays = new List<int> { 1, 9 };

            Assert.Throws<System.ArgumentException>(() =>
                InputValidator.ValidateInput(n, k, w, dw, s, weeklyRestDays, dm, monthlyRestDays)
            );
        }
    }
}
