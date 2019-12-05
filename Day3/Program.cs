using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day3
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = File.ReadLines("input.txt").ToArray();
            var wire1 = input[0].Split(',');
            var wire2 = input[1].Split(',');

            Console.WriteLine("Day 3 - Part 1 = " + Part1(wire1, wire2));
            Console.WriteLine("Day 3 - Part 2 = " + Part2(wire1, wire2));
        }

        static IList<CustomPoint> TrackPath(string[] wire)
        {
            var path = new List<CustomPoint>();

            foreach (var command in wire)
            {
                var direction = command[0];
                var number = int.Parse(command.Substring(1));

                for (int i = 1; i <= number; i++)
                {
                    var lastPoint = path.LastOrDefault();
                    
                    if (lastPoint == default(CustomPoint))
                    {
                        lastPoint = new CustomPoint(0, 0, 0);
                    }

                    var lastX = lastPoint.X;
                    var lastY = lastPoint.Y;

                    if (direction == 'R') lastX++;
                    else if (direction == 'L') lastX--;
                    else if (direction == 'U') lastY++;
                    else if (direction == 'D') lastY--;

                    path.Add(new CustomPoint(lastX, lastY, lastPoint.Distance + 1));
                }
            }

            return path;
        }

        static long Part1(string[] wire1, string[] wire2)
        {
            var path1 = TrackPath(wire1);
            var path2 = TrackPath(wire2);
            var intersections = path1.Intersect(path2);
            
            return intersections.Min(p => Math.Abs(p.X) + Math.Abs(p.Y));
        }

        static long Part2(string[] wire1, string[] wire2)
        {
            var path1 = TrackPath(wire1);
            var path2 = TrackPath(wire2);
            var intersections = path1.Intersect(path2);
            var lowerCombinedDistance = long.MaxValue;

            foreach (var intersection in intersections)
            {
                var pointW1 = path1.First(p => p.Equals(intersection));
                var pointW2 = path2.First(p => p.Equals(intersection));
                var combinedDistance = pointW1.Distance + pointW2.Distance;

                if (combinedDistance < lowerCombinedDistance)
                {
                    lowerCombinedDistance = combinedDistance;
                }
            }

            return lowerCombinedDistance;
        }

        class CustomPoint
        {
            public CustomPoint(int x, int y, long distance)
            {
                X = x;
                Y = y;
                Distance = distance;
            }

            public int X { get; set; }  
            public int Y { get; set; }
            public long Distance { get; set; }

            public override bool Equals(object obj)
            {
                var obj2 = ((CustomPoint)obj);
                var isEquals = obj2.X == this.X && obj2.Y == this.Y;
                return isEquals;
            }

            public override int GetHashCode()
            {
                var hashCode = 0;
                hashCode = this.X.GetHashCode();
                hashCode = this.Y.GetHashCode();
                return hashCode;
            }

            public override string ToString()
            {
                return base.ToString();
            }
        }
    }
}