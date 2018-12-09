using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2018
{
    public class Day02Part1
    {
        public static int compute(List<string> nums)
        {
            var charCounts = new int[26];
            var N = nums.Count;
            int count2 = 0;
            int count3 = 0;
            foreach (var item in nums)
            {
                binChars(item, charCounts);
                count2 += charCounts.Contains(2) ? 1 :0;
                count3 += charCounts.Contains(3) ? 1 :0;
            }
            return count2 * count3;
        }

        static void binChars(string item, int[] bins)
        {
            Array.Clear(bins, 0, 26);
            for (int i = 0; i < item.Length; i++)
            {
                var idx = item[i] - 'a';
                bins[idx]++;
            }
        }
    }
}
