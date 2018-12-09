using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace AdventOfCode2018
{
    public class Day01Part1
    {
        public static int compute(List<int> nums)
        {
            var sum = 0;
            foreach (var val in nums)
            {
                sum += val;
            }
            return sum;
        }
    }
}
