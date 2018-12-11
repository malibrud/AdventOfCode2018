using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2018
{
    public class Day02Part2
    {
        public static string compute(List<string> ids)
        {
            var N = ids.Count;
            var L = ids[0].Length;
            var diffIdx = 0;
            var correctId = "";
            for (int i = 0; i < N; i++)
            {
                var s1 = ids[i];
                for (int j = i+1; j < N; j++)
                {
                    var s2 = ids[j];
                    var diffCount = 0;
                    for (int k = 0; k < L; k++)
                    {
                        if (s1[k] != s2[k])
                        {
                            diffCount++;
                            diffIdx = k;
                        }
                    }
                    if (diffCount == 1)
                    {
                        correctId = s1;
                        goto AFTER_LOOPS;
                    }
                }
            }
            AFTER_LOOPS:
            var answer = correctId.Remove(diffIdx, 1);
            return answer;
        }
        
    }
}
