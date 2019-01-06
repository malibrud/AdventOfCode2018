using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2018
{
    public class Day14
    {
        byte[] recipies;
        int N;
        int nBefore;
        public Day14()
        {
        }

        public string computePart1(int _nBefore)
        {
            nBefore = _nBefore;
            N = nBefore + 10 + 2;
            recipies = new byte[N];
            recipies[0] = 3;
            recipies[1] = 7;
            var end = 2;
            var elf1 = 0;
            var elf2 = 1;
            while (true)
            {
                var sum = recipies[elf1] + recipies[elf2];
                var r1 = sum / 10;
                var r2 = sum % 10;
                if (r1 != 0) recipies[end++] = (byte)r1;
                recipies[end++] = (byte)r2;
                elf1 = (elf1 + recipies[elf1] + 1) % end;
                elf2 = (elf2 + recipies[elf2] + 1) % end;
                if (end >= nBefore + 10) break;
            }
            var tenRecipies = "";
            for (int i = 0; i < 10; i++)
            {
                tenRecipies += recipies[nBefore + i];
            }
            return tenRecipies;
        }

        public string computePart2(string stringPattern)
        {
            var _nBefore = Int32.Parse(stringPattern);
            int L = stringPattern.Length;
            computePart1(_nBefore*100);
            var pattern = new byte[L];
            int i;
            for (i = 0; i < L; i++)
            {
                pattern[i] = (byte)(stringPattern[i] - '0');
            }
            for (i = 0; i < N-L; i++)
            {
                int j;
                for (j = 0; j < L; j++)
                {
                    if (recipies[i + j] != pattern[j]) break;
                }
                if (j == L) return i.ToString();
            }
            return "no match";
        }
    }
}
