using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using AdventOfCode2018;

namespace UnitTests
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void Day01Part2Test()
        {
            var nums = new List<int>() {+1, -1 };
            Assert.AreEqual(Day01Part2.compute(nums), 0);

            nums = new List<int>() { +3, +3, +4, -2, -4 };
            Assert.AreEqual(Day01Part2.compute(nums), 10);

            nums = new List<int>() { -6, +3, +8, +5, -6 };
            Assert.AreEqual(Day01Part2.compute(nums), 5);

            nums = new List<int>() { +7, +7, -2, -7, -4 };
            Assert.AreEqual(Day01Part2.compute(nums), 14);
        }

        [TestMethod]
        public void Day02Part1Test()
        {
            var ids = new List<string>()
            {
                "abcdef",
                "bababc",
                "abbcde",
                "abcccd",
                "aabcdd",
                "abcdee",
                "ababab"
            };
            Assert.AreEqual(Day02Part1.compute(ids), 12);
        }

        [TestMethod]
        public void Day02Part2Test()
        {
            var ids = new List<string>()
            {
                "abcde",
                "fghij",
                "klmno",
                "pqrst",
                "fguij",
                "axcye",
                "wvxyz",
            };
            Assert.IsTrue(Day02Part2.compute(ids).Equals("fgij"));
        }
    }
}
