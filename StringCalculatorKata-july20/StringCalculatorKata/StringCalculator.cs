using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace StringCalculatorKata
{
    public class StringCalculator
    {
        private static List<string> _delimeters = new() { ",", "\n" };

        public int Add(string numbers)
        {
            if (numbers == "") return 0;

            var processedNumbers = ProcessCustomDelimeter(numbers);
            //meaningfully failing
            //if (numbers.Contains(','))
            //{
            //    return numbers.Split(',').Select(int.Parse).Sum();
            //} else if(numbers.Contains('\n')) {
            //    return numbers.Split('\n').Select(int.Parse).Sum();
            //} else if (numbers.Contains('X'))
            //{
            //    return numbers.Split('X').Select(int.Parse).Sum();
            //}

            return processedNumbers.Split(_delimeters.ToArray(), StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .Sum();
        }

        private static string ProcessCustomDelimeter(string numbers)
        {
            if (NoCustomDelimeters(numbers))
            {
                return numbers;
            }
            else
            {
                var newLineAt = numbers.IndexOf('\n');
                var delimeter = numbers.Substring(2, newLineAt - 2);
                _delimeters.Add(delimeter);
                numbers = numbers.Substring(newLineAt + 1);
                return numbers;
            }

            bool NoCustomDelimeters(string numbers) => !numbers.StartsWith("//");
        }


    }
