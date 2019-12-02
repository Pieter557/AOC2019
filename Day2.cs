using System;
using System.Collections.Generic;

namespace AOC2019
{
    internal class Day2
    {
        static string input = "1,0,0,3,1,1,2,3,1,3,4,3,1,5,0,3,2,6,1,19,1,5,19,23,2,9,23,27,1,6,27,31,1,31,9,35,2,35,10,39,1,5,39,43,2,43,9,47,1,5,47,51,1,51,5,55,1,55,9,59,2,59,13,63,1,63,9,67,1,9,67,71,2,71,10,75,1,75,6,79,2,10,79,83,1,5,83,87,2,87,10,91,1,91,5,95,1,6,95,99,2,99,13,103,1,103,6,107,1,107,5,111,2,6,111,115,1,115,13,119,1,119,2,123,1,5,123,0,99,2,0,14,0";
        //static string input = "1,1,1,4,99,5,6,0,99";
        internal static void Part1()
        {
            var stringList = input.Split(',');
            var list = new List<int>(stringList.Length);
            for (int i = 0; i < stringList.Length; i++)
            {
                list.Add(Convert.ToInt32(stringList[i]));
            }

            //FIRE yikes
            int verb = 12;
            int noun = 2;

            Console.WriteLine(runProgram(list, verb, noun));
        }

        private static int runProgram(List<int> list, int verb, int noun)
        {
            list[1] = verb;
            list[2] = noun;
            for (int i = 0; i < list.Count - 3; i++)
            {
                int opcode = list[i++];

                int number1 = list[i++];
                int number2 = list[i++];
                int number3 = list[i];

                switch (opcode)
                {
                    case 1:
                        list[number3] = list[number1] + list[number2];
                        break;
                    case 2:
                        list[number3] = list[number1] * list[number2];
                        break;
                    case 99:
                        return list[0];
                }
            }
            return list[0];
        }

        internal static void Part2()
        {
            var stringList = input.Split(',');
            var list = new List<int>(stringList.Length);
            for (int j = 0; j < stringList.Length; j++)
            {
                list.Add(Convert.ToInt32(stringList[j]));
            }
            int desiredResult = 19690720;



            for (int verb = 0; verb < 100; verb++)
            {
                for (int noun = 0; noun < 100; noun++)
                {
                    int result = runProgram(new List<int>(list), verb, noun);
                    Console.WriteLine("Result = " + result + "\tVerb: " + verb + "\tNoun: " + noun);
                    if (result == desiredResult)
                    {
                        Console.WriteLine(100 * verb + noun);
                        return;
                    }
                }
            }
        }
    }
}