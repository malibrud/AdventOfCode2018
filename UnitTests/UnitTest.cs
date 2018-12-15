﻿using System;
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
        
        [TestMethod]
        public void Day03Part1Test()
        {
            var ids = new List<string>()
            {
                "#1 @ 1,3: 4x4",
                "#2 @ 3,1: 4x4",
                "#3 @ 5,5: 2x2",
            };
            var day3 = new Day03(ids);
            Assert.AreEqual(day3.computePart1(), 4);
            Assert.AreEqual(day3.computePart2(), 3);
        }

        [TestMethod]
        public void Day04Test()
        {
            var rawRecords = new List<string>()
            {
                "[1518-11-01 00:00] Guard #10 begins shift",
                "[1518-11-01 00:05] falls asleep",
                "[1518-11-01 00:25] wakes up",
                "[1518-11-01 00:30] falls asleep",
                "[1518-11-01 00:55] wakes up",
                "[1518-11-01 23:58] Guard #99 begins shift",
                "[1518-11-02 00:40] falls asleep",
                "[1518-11-02 00:50] wakes up",
                "[1518-11-03 00:05] Guard #10 begins shift",
                "[1518-11-03 00:24] falls asleep",
                "[1518-11-03 00:29] wakes up",
                "[1518-11-04 00:02] Guard #99 begins shift",
                "[1518-11-04 00:36] falls asleep",
                "[1518-11-04 00:46] wakes up",
                "[1518-11-05 00:03] Guard #99 begins shift",
                "[1518-11-05 00:45] falls asleep",
                "[1518-11-05 00:55] wakes up",
            };
            var day4 = new Day04(rawRecords);
            Assert.AreEqual(day4.computePart1(), 240);
        }
    }
}
