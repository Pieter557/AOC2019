using System;
using System.Collections.Generic;

namespace AOC2019
{
    internal class Day5
    {
        static string input = "3,225,1,225,6,6,1100,1,238,225,104,0,1101,34,7,225,101,17,169,224,1001,224,-92,224,4,224,1002,223,8,223,1001,224,6,224,1,224,223,223,1102,46,28,225,1102,66,83,225,2,174,143,224,1001,224,-3280,224,4,224,1002,223,8,223,1001,224,2,224,1,224,223,223,1101,19,83,224,101,-102,224,224,4,224,102,8,223,223,101,5,224,224,1,223,224,223,1001,114,17,224,1001,224,-63,224,4,224,1002,223,8,223,1001,224,3,224,1,223,224,223,1102,60,46,225,1101,7,44,225,1002,40,64,224,1001,224,-1792,224,4,224,102,8,223,223,101,4,224,224,1,223,224,223,1101,80,27,225,1,118,44,224,101,-127,224,224,4,224,102,8,223,223,101,5,224,224,1,223,224,223,1102,75,82,225,1101,40,41,225,1102,22,61,224,1001,224,-1342,224,4,224,102,8,223,223,1001,224,6,224,1,223,224,223,102,73,14,224,1001,224,-511,224,4,224,1002,223,8,223,101,5,224,224,1,224,223,223,4,223,99,0,0,0,677,0,0,0,0,0,0,0,0,0,0,0,1105,0,99999,1105,227,247,1105,1,99999,1005,227,99999,1005,0,256,1105,1,99999,1106,227,99999,1106,0,265,1105,1,99999,1006,0,99999,1006,227,274,1105,1,99999,1105,1,280,1105,1,99999,1,225,225,225,1101,294,0,0,105,1,0,1105,1,99999,1106,0,300,1105,1,99999,1,225,225,225,1101,314,0,0,106,0,0,1105,1,99999,1008,677,677,224,1002,223,2,223,1006,224,329,1001,223,1,223,1007,226,226,224,1002,223,2,223,1005,224,344,101,1,223,223,1008,226,226,224,1002,223,2,223,1006,224,359,101,1,223,223,8,226,677,224,102,2,223,223,1006,224,374,101,1,223,223,1107,677,226,224,1002,223,2,223,1005,224,389,101,1,223,223,1008,677,226,224,102,2,223,223,1006,224,404,1001,223,1,223,1108,677,677,224,102,2,223,223,1005,224,419,1001,223,1,223,1107,677,677,224,102,2,223,223,1006,224,434,1001,223,1,223,1108,226,677,224,1002,223,2,223,1006,224,449,101,1,223,223,8,677,226,224,1002,223,2,223,1005,224,464,101,1,223,223,108,226,677,224,102,2,223,223,1005,224,479,1001,223,1,223,1107,226,677,224,102,2,223,223,1005,224,494,101,1,223,223,108,677,677,224,1002,223,2,223,1005,224,509,1001,223,1,223,7,677,226,224,1002,223,2,223,1006,224,524,101,1,223,223,1007,677,677,224,1002,223,2,223,1006,224,539,1001,223,1,223,107,226,226,224,102,2,223,223,1006,224,554,101,1,223,223,107,677,677,224,102,2,223,223,1006,224,569,1001,223,1,223,1007,226,677,224,1002,223,2,223,1006,224,584,101,1,223,223,108,226,226,224,102,2,223,223,1006,224,599,1001,223,1,223,7,226,226,224,102,2,223,223,1006,224,614,1001,223,1,223,8,226,226,224,1002,223,2,223,1006,224,629,1001,223,1,223,7,226,677,224,1002,223,2,223,1005,224,644,101,1,223,223,1108,677,226,224,102,2,223,223,1006,224,659,101,1,223,223,107,226,677,224,102,2,223,223,1006,224,674,1001,223,1,223,4,223,99,226";
        //static string input = "1,1,1,4,99,5,6,0,99";

        static int shipID;

        internal static void Part1()
        {
            shipID = 1;
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
            //list[1] = verb;
            //list[2] = noun;
            for (int i = 0; i < list.Count - 3;)
            {
                string instruction = list[i].ToString();
                string paddedInstruction = instruction.PadLeft(5, '0');

                int opcode = int.Parse(paddedInstruction.Substring(paddedInstruction.Length - 2));
                bool parameter1 = Convert.ToBoolean(Convert.ToInt32(paddedInstruction.Substring(2, 1)));
                bool parameter2 = Convert.ToBoolean(Convert.ToInt32(paddedInstruction.Substring(1, 1)));
                bool parameter3 = Convert.ToBoolean(Convert.ToInt32(paddedInstruction.Substring(0, 1)));



                switch (opcode)
                {
                    case 1:
                        list[list[i+3]] = (parameter1 ? list[i+1]  : list[list[i+1]]) + (parameter2 ? list[i+2] : list[list[i+2]]);
                        if (list[i].ToString() == instruction)
                        {
                            i += 4;

                        }                        
                        break;
                    case 2:
                        list[list[i + 3]] = (parameter1 ? list[i + 1] : list[list[i + 1]]) * (parameter2 ? list[i + 2] : list[list[i + 2]]);
                        if (list[i].ToString() == instruction)
                        {
                            i += 4;

                        }
                        break;
                    case 3:
                        list[list[i+1]] = shipID;
                        if (list[i].ToString() == instruction)
                        {
                            i += 2;

                        }
                        break;
                    case 4:
                        int output = list[list[i + 1]];
                        Console.WriteLine(output);
                        if (list[i].ToString() == instruction)
                        {
                            i += 2;

                        }
                        break;
                    case 5:
                        if((parameter1 ? list[i + 1] : list[list[i + 1]]) != 0)
                        {
                            i = (parameter2 ? list[i + 2] : list[list[i + 2]]);
                        }
                        if (list[i].ToString() == instruction)
                        {
                            i += 3;

                        }
                        break;
                    case 6:
                        if ((parameter1 ? list[i + 1] : list[list[i + 1]]) == 0)
                        {
                            i = (parameter2 ? list[i + 2] : list[list[i + 2]]);
                        }
                        if (list[i].ToString() == instruction)
                        {
                            i += 3;

                        }
                        break;
                    case 7:
                        if ((parameter1 ? list[i + 1] : list[list[i + 1]]) < (parameter2 ? list[i + 2] : list[list[i + 2]]))
                        {
                            if (parameter3)
                            {
                                list[i + 3] = 1;
                            } else
                            {
                                list[list[i + 3]] = 1;
                            }
                        } else
                        {
                            if (parameter3)
                            {
                                list[i + 3] = 0;
                            }
                            else
                            {
                                list[list[i + 3]] = 0;
                            }
                        }
                        if (list[i].ToString() == instruction)
                        {
                            i += 4;

                        }
                        break;
                    case 8:
                        if ((parameter1 ? list[i + 1] : list[list[i + 1]]) == (parameter2 ? list[i + 2] : list[list[i + 2]]))
                        {
                            if (parameter3)
                            {
                                list[i + 3] = 1;
                            }
                            else
                            {
                                list[list[i + 3]] = 1;
                            }
                        }
                        else
                        {
                            if (parameter3)
                            {
                                list[i + 3] = 0;
                            }
                            else
                            {
                                list[list[i + 3]] = 0;
                            }
                        }
                        if (list[i].ToString() == instruction)
                        {
                            i += 4;

                        }
                        break;

                    case 99:
                        return list[0];
                }
            }
            return list[0];
        }

        internal static void Part2()
        {
            shipID = 5;
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

    }
}