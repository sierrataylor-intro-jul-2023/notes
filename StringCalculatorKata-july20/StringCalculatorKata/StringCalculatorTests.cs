using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculatorKata
{
    public class StringCalculatorTests
    {
        [Fact] public void EmptyStringReturnsZero()
        {
            var calculator = new StringCalculator();
            var result = calculator.Add("");
            Assert.Equal(0, result);
        }

        [Theory]
        [InlineData("1", 1)]
        [InlineData("2", 2)]
        [InlineData("108", 108)]
        public void SingleDigits(string numbers, int expected)
        {
            var calculator = new StringCalculator();
            var result = calculator.Add(numbers);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("1,2", 3)]
        [InlineData("3,3", 6)]
        [InlineData("10,2", 12)]
        [InlineData("8,2", 10)]
        [InlineData("15,20", 35)]
        public void TwoDigits(string numbers, int expected)
        {
            var calculator = new StringCalculator();
            var result = calculator.Add(numbers);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("1,2", 3)]
        [InlineData("3,3", 6)]
        [InlineData("10,2", 12)]
        [InlineData("8,2,5", 15)]
        [InlineData("15,2,18", 35)]
        public void ArbitraryNumbers(string numbers, int expected)
        {
            var calculator = new StringCalculator();
            var result = calculator.Add(numbers);
            Assert.Equal(expected, result);
        }

        [Theory(Skip = "Not ready yet")]
        [InlineData("1\n2", 3)]
        [InlineData("3,3", 6)]
        [InlineData("10,2", 12)]
        [InlineData("8,2", 10)]
        [InlineData("15\n20", 35)]
        public void NewLineSeparators(string numbers, int expected)
        {
            var calculator = new StringCalculator();
            var result = calculator.Add(numbers);
            Assert.Equal(expected, result);
        }
    }
}
