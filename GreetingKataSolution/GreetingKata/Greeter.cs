using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreetingKata
{
    public class Greeter
    {
        public string Greet( string name,string[]? names = null)
        {
            if (name == null)
            {
                return "Hello, Buddy!";
            }
            string greeting = "Hello, ";
            greeting += name.Length > 0  ? name : "Buddy";
            greeting = name.All(char.IsUpper)  ? greeting.ToUpper()  : greeting;
            if (names != null )
            {
                greeting += names.Length > 1 ? "," : null;
                
                for (int i = 0; i < names.Length-1; i++)
                {
                    greeting += $" {names[i]},";
                }
                greeting +=  $" and {names[names.Length-1]}" ;
               
                
            }

            greeting += name.All(char.IsUpper) || greeting.Contains("and")  ?  "!" :   ".";
            return greeting;
        }
    }
}
