using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace AdventOfCode2018
{
    public class Day01Part2
    {
        public static int compute(List<int> nums)
        {
            List<int> values = new List<int>();
            var N = nums.Count;
            int sum = 0;
            values.Add(sum);
            int i = 0;
            while(true)
            {
                sum += nums[i%N];
                if (values.Contains(sum)) break;
                else values.Add(sum);
                i++;
            }
            return sum;
        }
    }
}
