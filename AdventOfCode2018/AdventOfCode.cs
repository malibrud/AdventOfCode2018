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
            int day = 12;
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
                case 07:
                    day07();
                    break;
                case 08:
                    day08();
                    break;
                case 09:
                    day09();
                    break;
                case 10:
                    day10();
                    break;
                case 11:
                    day11();
                    break;
                case 12:
                    day12();
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

        static void day07()
        {
            var instructions = FileReader.readAsciiLines("Input_Day07.txt");

            var day = new Day07(instructions);
            WriteLine($"Day 07, Part 1: {day.computePart1()}");
            day = new Day07(instructions);
            WriteLine($"Day 07, Part 2: {day.computePart2(5, 60)}");
        }

        static void day08()
        {
            var instructions = FileReader.readAsciiLines("Input_Day08.txt");

            var day = new Day08(instructions[0]);
            WriteLine($"Day 08, Part 1: {day.computePart1()}");
            WriteLine($"Day 08, Part 2: {day.computePart2()}");
        }

        static void day09()
        {
            var instructions = FileReader.readAsciiLines("Input_Day09.txt");

            var day = new Day09(instructions[0]);
            WriteLine($"Day 09, Part 1: {day.compute()}");
            day = new Day09(instructions[1]);
            WriteLine($"Day 09, Part 2: {day.compute()}");
        }

        static void day10()
        {
            var lights = FileReader.readAsciiLines("Input_Day10.txt");

            var day = new Day10(lights);
            WriteLine($"Day 10, Part 1: {day.computePart1()}");
            day = new Day10(lights);
            WriteLine($"Day 10, Part 2: {day.computePart2()}");
        }
        
        static void day11()
        {
            var serialNumber = FileReader.readAsciiLines("Input_Day11.txt");

            var day = new Day11(serialNumber[0]);
            WriteLine($"Day 11, Part 1: {day.computePart1()}");
            WriteLine($"Day 11, Part 2: {day.computePart2()}");
        }

        static void day12()
        {
            var input = FileReader.readAsciiLines("Input_Day12.txt");

            var day = new Day12(input);
            WriteLine($"Day 12, Part 1: {day.computePart1(20)}");
            day = new Day12(input);
            WriteLine($"Day 12, Part 2: {day.computePart2(50_000_000_000L)}");
        }
    }
}
