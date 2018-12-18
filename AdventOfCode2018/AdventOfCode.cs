using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace AdventOfCode2018
{
    class AdventOfCode
    {
        static void Main(string[] args)
        {
            int day = 6;
            switch(day)
            {
                case 01:
                    day01();
                    break;
                case 02:
                    day02();
                    break;
                case 03:
                    day03();
                    break;
                case 04:
                    day04();
                    break;
                case 05:
                    day05();
                    break;
                case 06:
                    day06();
                    break;
            }
            ReadKey();
        }

        static void day01()
        {
            var nums = FileReader.readDay01("Input_Day01.txt");

            int answerD01P1 = Day01Part1.compute(nums);
            WriteLine($"Day 01, Part 1: {answerD01P1}");

            int answerD01P2 = Day01Part2.compute(nums);
            WriteLine($"Day 01, Part 2: {answerD01P2}");
        }

        static void day02()
        {
            var nums = FileReader.readDay02("Input_Day02.txt");

            int answerD02P1 = Day02Part1.compute(nums);
            WriteLine($"Day 02, Part 1: {answerD02P1}");

            var answerD02P2 = Day02Part2.compute(nums);
            WriteLine($"Day 02, Part 2: {answerD02P2}");
        }

        static void day03()
        {
            var claims = FileReader.readDay03("Input_Day03.txt");

            var day3 = new Day03(claims);
            int answerD03P1 = day3.computePart1();
            WriteLine($"Day 03, Part 1: {answerD03P1}");

            int answerD03P2 = day3.computePart2();
            WriteLine($"Day 03, Part 2: {answerD03P2}");
        }

        static void day04()
        {
            var records = FileReader.readAsciiLines("Input_Day04.txt");

            var day4 = new Day04(records);
            WriteLine($"Day 04, Part 1: {day4.computePart1()}");
            WriteLine($"Day 04, Part 2: {day4.computePart2()}");
        }

        static void day05()
        {
            var polymer = FileReader.readAsciiLines("Input_Day05.txt");

            var day5 = new Day05(polymer[0]);
            WriteLine($"Day 05, Part 1: {day5.computePart1()}");
            WriteLine($"Day 05, Part 2: {day5.computePart2()}");
        }
        static void day06()
        {
            var coords = FileReader.readAsciiLines("Input_Day06.txt");

            var day = new Day06(coords);
            WriteLine($"Day 06, Part 1: {day.computePart1()}");
            WriteLine($"Day 06, Part 2: {day.computePart2(10_000)}");
        }
    }
}
