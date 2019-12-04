using System;
using System.Collections.Generic;
using System.Linq;

namespace AOC2019
{
    internal class Day4
    {
        static int start = 137683;
        static int stop = 596253;

        internal static void Part1()
        {
            int validPasswords = 0;
            for (int i = start; i < stop; i++)
            {
                int a = i / 100000;
                int b = (i - a * 100000) / 10000;
                int c = (i - a * 100000 - b * 10000) / 1000;
                int d = (i - a * 100000 - b * 10000 - c * 1000) / 100;
                int e = (i - a * 100000 - b * 10000 - c * 1000 - d * 100) / 10;
                int f = (i - a * 100000 - b * 10000 - c * 1000 - d * 100 - e * 10) / 1;

                if ( a <= b && b <= c && c <= d && d <= e && e <=f) // Check never decreases
                { 
                    if ( a == b || b == c || c == d || d == e || e == f) // double number
                    {
                        validPasswords++;
                    }
                }
            }
            Console.WriteLine(validPasswords);
        }

        internal static void Part2()
        {
                        int validPasswords = 0;
            for (int i = start; i < stop; i++)
            {
                List<int> digits = i.ToString().ToList().Select(Convert.ToInt32).ToList();


                if ( digits[0] <= digits[1] && digits[1] <= digits[2] && digits[2] <= digits[3] && digits[3] <= digits[4] && digits[4] <= digits[5]) // Check never decreases
                {
                    var counts = digits.GroupBy(d => d).Select(f => new { digit = f, count = f.Count() });
                    if(counts.Any(c => c.count == 2))
                    {
                        validPasswords++;
                    }
                }
            }
            Console.WriteLine(validPasswords);
        }
    }
}