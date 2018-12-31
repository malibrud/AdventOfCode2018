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
        int nPad;
        public Day12(List<string> rawRecords)
        {
            getInitialState(rawRecords[0]);
            getRules(rawRecords);
            offset = 0;
            N = initState.Length;
        }

        public int computePart1(int gen)
        {
            nPad = gen * 2;
            L = nPad + N + nPad;
            offset = nPad;
            state = new bool[L];
            numericalState = new int[L];
            for (int i = 0; i < N; i++) state[i + offset] = initState[i];
            for (int g = 0; g < gen; g++)
            {
                doGeneration1();
                printGeneration();
            }
            return sumState();
        }
        
        public long computePart2(long gen)
        {
            nPad = 4;
            L = nPad + N + 100;
            offset = nPad;
            state = new bool[L];
            numericalState = new int[L];
            for (int i = 0; i < N; i++) state[i + offset] = initState[i];
            for (long g = 0; g < 500; g++)
            {
                doGeneration2(g);
            }
            long genInc = 96; // determined empriically

            return sumState() + 96L*(gen-500L);
        }

        void doGeneration1()
        {
            boolToNumericalState();
            applyRulesToNumericalState();
        }

        void doGeneration2(long gen)
        {
            boolToNumericalState();
            applyRulesToNumericalState();
            shiftState();
            printGeneration(gen+1);
        }

        void shiftState()
        {
            int i;
            for (i = 0; i < L; i++)
            {
                if (state[i]) break;
            }
            // This shifting algorithm assumes that the pots shift to the right from 
            // generation to generation.
            var shift = i - nPad;
            if (shift > 0)
            {
                for (i = nPad; i < L - shift; i++)
                {
                    state[i] = state[shift + i];
                }
                for (i = L - shift; i < L; i++)
                {
                    state[i] = false;
                }
            }
            else
            {
                for (i = L-1; i >= 0 - shift; i--)
                {
                    state[i] = state[shift + i];
                }
                for (i = 0; i < nPad; i++)
                {
                    state[i] = false;
                }
            }
            offset -= shift;
        }

        void printGeneration(long gen = 0)
        {
            Write($"{gen,6}: ");
            for (int i = 0; i < L; i++)
            {
                var c = state[i] ? '#' : '.';
                Write(c);
            }
            WriteLine($": {sumState()}");
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
