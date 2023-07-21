
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculatorKata
{
    public class StringCalculator
    {
        private readonly ILogger _logger;
        private readonly IWebService _webService;
        public StringCalculator(ILogger logger, IWebService webService)
        {
            _logger = logger;
            _webService = webService;
        }
        public int Add(string numbers)
        {
            int result = 0;
            if (numbers != "")
            {
                result = numbers.Split(',').Select(int.Parse).Sum();
            }

            _logger.Log("complete");
            return result;

            
            
        }
            
    }

    public interface IWebService
    {
        void NotifyOfLoggerFailure(string message);
    }
    public class WebService : IWebService
    {
        public void NotifyOfLoggerFailure(string message)
        {
            Console.WriteLine(message);
        }
    }
    public class Logger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine(message);
        }
    }
}
