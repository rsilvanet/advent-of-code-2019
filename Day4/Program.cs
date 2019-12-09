using System;
using System.Linq;

namespace Day4
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputMin = 138307;
            var inputMax = 654504;

            Console.WriteLine("Day 4 - Part 1 = " + Part1(inputMin, inputMax));
            Console.WriteLine("Day 4 - Part 2 = " + Part2(inputMin, inputMax));
        }

        static bool MatchRulesPart1(int number)
        {
            var numbersNeverDecreases = true;
            var hasAdjacentSameNumbers = false;
            
            char? lastChar = null;

            foreach (var item in number.ToString())
            {
                if (lastChar.HasValue)
                {
                    if (item < lastChar)
                    {
                        numbersNeverDecreases = false;
                    }

                    if (item == lastChar)
                    {
                        hasAdjacentSameNumbers = true;
                    }
                }

                lastChar = item;
            }

            return numbersNeverDecreases && hasAdjacentSameNumbers;
        }

        static bool MatchRulesPart2(int number)
        {
            var numbersNeverDecreases = true;
            var numberAsString = number.ToString();

            char? lastChar = null;

            foreach (var item in numberAsString)
            {
                if (lastChar.HasValue)
                {
                    if (item < lastChar)
                    {
                        numbersNeverDecreases = false;
                    }
                }

                lastChar = item;
            }

            var hasAdjacentSameNumbers = numberAsString
                .ToCharArray()
                .GroupBy(x => x)
                .Any(x => x.Count() == 2);

            return numbersNeverDecreases && hasAdjacentSameNumbers;
        }

        static int Part1(int inputMin, int inputMax)
        {
            var possiblePasswordCount = 0;

            for (int i = inputMin; i <= inputMax; i++)
            {
                if (MatchRulesPart1(i))
                {
                    possiblePasswordCount++;
                }
            }

            return possiblePasswordCount;
        }

        static int Part2(int inputMin, int inputMax)
        {
            var possiblePasswordCount = 0;

            for (int i = inputMin; i <= inputMax; i++)
            {
                if (MatchRulesPart2(i))
                {
                    possiblePasswordCount++;
                }
            }

            return possiblePasswordCount;
        }
    }
}
