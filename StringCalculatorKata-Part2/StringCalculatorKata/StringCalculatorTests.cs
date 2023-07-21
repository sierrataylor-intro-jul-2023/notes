using Moq;
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
            var loggerMock = new Mock<ILogger>();
            var calculator = new StringCalculator(loggerMock.Object);
            var result = calculator.Add("");
            Assert.Equal(0, result);
        }

        [Theory]
        [InlineData("1", 1)]
        [InlineData("2", 2)]
        [InlineData("108", 108)]
        public void SingleDigits(string numbers, int expected)
        {
            var loggerMock = new Mock<ILogger>();
            var calculator = new StringCalculator(loggerMock.Object);
            var result = calculator.Add(numbers);
            Assert.Equal(expected, result);
        }

 
    }
}
