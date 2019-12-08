using System.IO;
using System.Collections.Generic;
using System.Linq;
using System;

namespace AOC2019
{
    internal class Day6
    {
        internal static List<Planet> Planets;
        internal static void Part1()
        {
            FileInfo inputfile = new FileInfo(Program.dir + "Day6.txt");
            var stream = inputfile.OpenText();
            Planets = new List<Planet>();
            while (!stream.EndOfStream)
            {
                var input = stream.ReadLine().Split(')');

                // Check if first Planet exists in list
                if(!Planets.Any(p => p.Name == input[0]))
                {
                    Planets.Add(new Planet(input[0]));
                }
                // Check if second Planet exists in list
                if (!Planets.Any(p => p.Name == input[1]))
                {
                    Planets.Add(new Planet(input[1]));
                }

                // set second planet as in orbit of first planet
                Planets.First(p => p.Name == input[0]).Orbits.Add(Planets.First(p => p.Name == input[1]));
                // Set first planet as parentplanet of second planet
                Planets.First(p => p.Name == input[1]).Parent = Planets.First(p => p.Name == input[0]);
            }
            Planet COM = Planets.First(p => p.Name == "COM");

            int orbits = 0;
            foreach (Planet p in Planets)
            {
                orbits += p.getDirectOrbits();
            }
            Console.WriteLine(orbits - Planets.Count);



        }

        internal static void Part2()
        {
            Planet You = Planets.First(p => p.Name == "YOU");
            Planet SAN = Planets.First(p => p.Name == "SAN");

            int shortestPath = Planets.Count;



        }



    }
    internal class Planet
    {
        public Planet()
        {
        }

        public Planet(string name)
        {
            Name = name;
            Parent = null;
            Orbits = new List<Planet>();
        }

        public string Name { get; set; }
        public Planet Parent { get; set; }
        public List<Planet> Orbits { get; set; }

        public int getDirectOrbits()
        {
            int directOrbits = 1;
            foreach (Planet p in Orbits)
            {
                directOrbits += p.getDirectOrbits();
            }
            return directOrbits;
        }
        
    }
}