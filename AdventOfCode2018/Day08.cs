using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2018
{
    public class Day08
    {
        int[] numbers;
        int N;
        public Day08(string rawInput)
        {
            var asciiVals = rawInput.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            N = asciiVals.Length;
            numbers = new int[N];
            for (int i = 0; i < N; i++)
            {
                numbers[i] = Int32.Parse(asciiVals[i]);
            }
        }

        public int computePart1()
        {
            var (idx, sum) = processNodeAt(0, 0);
            return sum;
        }

        (int idx, int sum) processNodeAt(int idx, int sum)
        {
            var nChild = numbers[idx++];
            var nMeta = numbers[idx++];
            for (int i = 0; i < nChild; i++)
            {
                (idx, sum) = processNodeAt(idx, sum);
            }
            for (int i = 0; i < nMeta; i++)
            {
                sum += numbers[idx++];
            }
            return (idx, sum);
        }
    }
}
