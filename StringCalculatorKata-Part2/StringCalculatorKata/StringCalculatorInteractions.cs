using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculatorKata
{
    public class StringCalculatorInteractions
    {
        [Theory]
        [InlineData("3,4,5", "complete")]
        public void ResultsAreLogged(string numbers, string expectedToBeLogged)
        {

        }

        [Fact]
        public void WebServiceOnLogFailure()
        {
            var loggerStub = new Mock<ILogger>();
            var mockWebService = new Mock<IWebService>();
            var calc = new StringCalculator(loggerStub.Object, mockWebService.Object);
            loggerStub.Setup(m => m.Log(It.IsAny<string>())).Throws
        }
    }
}
