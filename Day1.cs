using System;
using System.IO;

namespace AOC2019
{
    internal class Day1
    {
        internal static void Part1()
        {
            FileInfo inputfile = new FileInfo(Program.dir + "Day1.txt");
            var stream = inputfile.OpenText();
            int fuel = 0;
            while (!stream.EndOfStream)
            {
                var input = int.Parse(stream.ReadLine());
                fuel += FindFuel(input);
            }
            Console.WriteLine(fuel);
        }

        internal static void Part2()
        {
            FileInfo inputfile = new FileInfo(Program.dir + "Day1.txt");
            var stream = inputfile.OpenText();
            int fuel = 0;
            while (!stream.EndOfStream)
            {
                var input = int.Parse(stream.ReadLine());
                fuel += FindFuelPart2(input);
            }
            Console.WriteLine(fuel);
        }

        internal static int FindFuel(int mass)
        {
            return Convert.ToInt32(Math.Floor((double)mass / 3)) - 2;
        }
        internal static int FindFuelPart2(int mass)
        {
            int addedFuel = Convert.ToInt32(Math.Floor((double)mass / 3)) - 2; ;

            int fuel = addedFuel;
            while(FindFuel(fuel) > 0)
            {
                addedFuel += FindFuel(fuel);
                fuel = FindFuel(fuel);
            }


            return addedFuel;
        }
    }
}