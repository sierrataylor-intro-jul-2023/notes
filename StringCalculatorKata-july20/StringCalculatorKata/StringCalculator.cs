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
        public int Add(string numbers)
        {
            if (numbers == "")
            {
                return 0;
            }
            var delimiterRegex = new Regex("[^0-9]");
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

            return  delimiterRegex.Split(numbers).Where(n => n !="").Select(int.Parse).Sum();
            //return numbers.Split(delimiterRegex).Select(int.Parse).Sum();



        }
            
    }
}
