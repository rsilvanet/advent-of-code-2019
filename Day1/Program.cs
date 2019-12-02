using System;
using System.IO;
using System.Linq;

namespace Day1
{
    class Program
    {
        static void Main(string[] args)
        {
            var lines = File.ReadAllLines("input.txt");
            var moduleMassArray = lines.Select(x => int.Parse(x)).ToArray();

            Console.WriteLine("Day 1 - Part 1 = " + Part1(moduleMassArray));
            Console.WriteLine("Day 1 - Part 2 = " + Part2(moduleMassArray));
        }

        static int CalculateFuel(int mass)
        {
            return (mass / 3) - 2;
        }

        static long Part1(int[] moduleMassArray)
        {
            return moduleMassArray.Sum(mass => CalculateFuel(mass));
        }

        static long Part2(int[] moduleMassArray)
        {
            return moduleMassArray.Sum(mass => 
            {
                var totalModuleFuel = 0;
                var currentRoundFuel = CalculateFuel(mass);
                
                while (currentRoundFuel >= 0)
                {
                    totalModuleFuel += currentRoundFuel;
                    currentRoundFuel = CalculateFuel(currentRoundFuel);
                }

                return totalModuleFuel;
            });
        }
    }
}
