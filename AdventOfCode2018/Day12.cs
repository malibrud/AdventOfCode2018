using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Console;

namespace AdventOfCode2018
{
    public class Day12
    {
        bool[] initState;
        int offset;
        bool[] rules;
        bool[] state;
        int[] numericalState;
        int N;
        int L;
        public Day12(List<string> rawRecords)
        {
            getInitialState(rawRecords[0]);
            getRules(rawRecords);
            offset = 0;
            N = initState.Length;
        }

        public int computePart1(int gen)
        {
            var nPad = gen * 2;
            L = nPad + N + nPad;
            offset = nPad;
            state = new bool[L];
            numericalState = new int[L];
            for (int i = 0; i < N; i++) state[i + offset] = initState[i];
            for (int g = 0; g < gen; g++)
            {
                doGeneration();
                printGeneration();
            }
            return sumState();
        }

        void doGeneration()
        {
            boolToNumericalState();
            applyRulesToNumericalState();
        }

        void printGeneration()
        {
            for (int i = 0; i < L; i++)
            {
                var c = state[i] ? '#' : '.';
                Write(c);
            }
            WriteLine();
        }

        void boolToNumericalState()
        {
            for (int i = 2; i < L-2; i++)
            {
                int val = 0;
                if (state[i - 2]) val += 16;
                if (state[i - 1]) val += 8;
                if (state[i + 0]) val += 4;
                if (state[i + 1]) val += 2;
                if (state[i + 2]) val += 1;
                numericalState[i] = val;
            }
        }

        void applyRulesToNumericalState()
        {
            for (int i = 0; i < L; i++) state[i] = rules[numericalState[i]];
        }

        int sumState()
        {
            int sum = 0;
            for (int i = 0; i < L; i++)
            {
                if (state[i]) sum += (i - offset);
            }
            return sum;
        }

        void getInitialState(string line)
        {
            var reg = new Regex(@"initial state: ([#\.]+)");
            var initStateStr = reg.Match(line).Groups[1].Value;
            initState = new bool[initStateStr.Length];
            for (int i = 0; i < initState.Length; i++)
            {
                initState[i] = initStateStr[i] == '#';
            }
        }

        void getRules(List<string> recs)
        {
            rules = new bool[32];
            var reg = new Regex(@"([#\.]+) => ([#\.])");
            for (int i = 2; i < recs.Count; i++)
            {
                var g = reg.Match(recs[i]).Groups;
                var inputStr = g[1].Value;
                var outputStr = g[2].Value[0];
                var idx = strToIdx(inputStr);
                rules[idx] = outputStr == '#';
            }
        }

        int strToIdx(string input)
        {
            int val = 0;
            if (input[0] == '#') val += 16;
            if (input[1] == '#') val += 8;
            if (input[2] == '#') val += 4;
            if (input[3] == '#') val += 2;
            if (input[4] == '#') val += 1;
            return val;
        }
    }
}
