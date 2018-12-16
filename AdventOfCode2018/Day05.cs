using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2018
{
    public class Day05
    {
        string polymer;
        public Day05(string _p)
        {
            polymer = _p;
        }

        public int computePart1()
        {
            var react = new Stack<char>();
            for (int i = 0; i < polymer.Length; i++)
            {
                react.Push(polymer[i]);
                reduce(react);
            }
            return react.Count();
        }

        public int computePart2()
        {
            var min = polymer.Length;
            for (char unit = 'a'; unit <= 'z'; unit++)
            {
                var length = reduceIgnoring(unit);
                if (length < min) min = length;
            }
            return min;
        }

        int reduceIgnoring(char unit)
        {
            var react = new Stack<char>();
            var u = Char.ToLower(unit);
            var U = Char.ToUpper(unit);
            for (int i = 0; i < polymer.Length; i++)
            {
                var c = polymer[i];
                if (c == u || c == U) continue;
                react.Push(polymer[i]);
                reduce(react);
            }
            return react.Count();
        }

        void reduce(Stack<char> react)
        {
            if (react.Count < 2) return;
            int N = react.Count();
            var c1 = react.ElementAt(0);
            var c2 = react.ElementAt(1);
            if (cancel(c1, c2))
            {
                react.Pop();
                react.Pop();
            }
        }
        bool cancel(char c1, char c2)
        {
            return Math.Abs(c1 - c2) == 32;
        }
    }
}
