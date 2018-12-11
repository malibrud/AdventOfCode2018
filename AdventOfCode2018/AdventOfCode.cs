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
            int day = 2;
            switch(day)
            {
                case 01:
                    day01();
                    break;
                case 02:
                    day02();
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
        
    }
}
