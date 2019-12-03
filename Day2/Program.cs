using System;
using System.IO;
using System.Linq;

namespace Day2
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = File.ReadAllText("input.txt");
            var numbers = input.Split(',').Select(x => int.Parse(x)).ToArray();

            Console.WriteLine("Day 2 - Part 1 = " + Part1(numbers));
            Console.WriteLine("Day 2 - Part 2 = " + Part2(numbers));
        }

        static int[] Compute(int[] numbers, int noun, int verb)
        {
            var resultNumbers = new int[numbers.Length];
            var originalNumbers = new int[numbers.Length];
            
            Array.Copy(numbers, originalNumbers, numbers.Length);

            numbers[1] = noun;
            numbers[2] = verb;

            for (int i = 0; i < numbers.Length; i += 4)
            {
                var inputIndex1 = numbers[i + 1];
                var inputIndex2 = numbers[i + 2];
                var outputIndex = numbers[i + 3];

                if (numbers[i] == 1)
                {
                    numbers[outputIndex] = numbers[inputIndex1] + numbers[inputIndex2];
                }
                else if (numbers[i] == 2)
                {
                    numbers[outputIndex] = numbers[inputIndex1] * numbers[inputIndex2];
                }
                else if (numbers[i] == 99)
                {
                    break;
                }
            }

            Array.Copy(numbers, resultNumbers, numbers.Length);
            Array.Copy(originalNumbers, numbers, numbers.Length);

            return resultNumbers;
        }

        static string PadZero(int number)
        {
            return number.ToString().PadLeft(2, '0');
        }

        static long Part1(int[] numbers)
        {
            return Compute(numbers, 12, 2)[0];
        }

        static string Part2(int[] numbers)
        {
            for (int noun = 0; noun < 100; noun++)
            {
                for (int verb = 0; verb < 100; verb++)
                {
                    if (Compute(numbers, noun, verb)[0] == 19690720)
                    {
                        return PadZero(noun) + PadZero(verb);
                    }
                }
            }

            return "error";
        }
    }
}
