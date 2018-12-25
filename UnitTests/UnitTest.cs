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
            Assert.AreEqual(day4.computePart2(), 4455);
        }

        [TestMethod]
        public void Day05Test()
        {
            var rawRecords = new List<string>()
            {
                "dabAcCaCBAcCcaDA",
            };
            var day = new Day05(rawRecords[0]);
            Assert.AreEqual(day.computePart1(), 10);
            Assert.AreEqual(day.computePart2(), 4);
        }

        [TestMethod]
        public void Day06Test()
        {
            var rawRecords = new List<string>()
            {
                "1, 1",
                "1, 6",
                "8, 3",
                "3, 4",
                "5, 5",
                "8, 9",
            };
            var day = new Day06(rawRecords);
            Assert.AreEqual(day.computePart1(), 17);
            Assert.AreEqual(day.computePart2(32), 16);
        }

        [TestMethod]
        public void Day07Test()
        {
            var rawRecords = new List<string>()
            {
                "Step C must be finished before step A can begin.",
                "Step C must be finished before step F can begin.",
                "Step A must be finished before step B can begin.",
                "Step A must be finished before step D can begin.",
                "Step B must be finished before step E can begin.",
                "Step D must be finished before step E can begin.",
                "Step F must be finished before step E can begin.",
            };
            var day = new Day07(rawRecords);
            Assert.IsTrue(day.computePart1().Equals("CABDFE"));
            day = new Day07(rawRecords);
            Assert.AreEqual(day.computePart2(2, 0), 15);
        }

        [TestMethod]
        public void Day08Test()
        {
            var licenseFile = "2 3 0 3 10 11 12 1 1 0 1 99 2 1 1 2";
            var day = new Day08(licenseFile);
            Assert.AreEqual(day.computePart1(), 138);
            Assert.AreEqual(day.computePart2(), 66);
        }
        
        [TestMethod]
        public void Day09Test()
        {
            var games = new List<string>()
            {
                "9 players; last marble is worth 25 points",
                "10 players; last marble is worth 1618 points",
                "13 players; last marble is worth 7999 points",
                "17 players; last marble is worth 1104 points",
                "21 players; last marble is worth 6111 points",
                "30 players; last marble is worth 5807 points",
            };
            var day = new Day09(games[0]);
            Assert.AreEqual(day.compute (), 32);
            day = new Day09(games[1]);  
            Assert.AreEqual(day.compute (), 8317);
            day = new Day09(games[2]);  
            Assert.AreEqual(day.compute (), 146373);
            day = new Day09(games[3]);  
            Assert.AreEqual(day.compute (), 2764);
            day = new Day09(games[4]);  
            Assert.AreEqual(day.compute (), 54718);
            day = new Day09(games[5]);  
            Assert.AreEqual(day.compute (), 37305);
        }


        [TestMethod]
        public void Day10Test()
        {
            var lights = new List<string>()
            {
                "position=< 9,  1> velocity=< 0,  2>",
                "position=< 7,  0> velocity=<-1,  0>",
                "position=< 3, -2> velocity=<-1,  1>",
                "position=< 6, 10> velocity=<-2, -1>",
                "position=< 2, -4> velocity=< 2,  2>",
                "position=<-6, 10> velocity=< 2, -2>",
                "position=< 1,  8> velocity=< 1, -1>",
                "position=< 1,  7> velocity=< 1,  0>",
                "position=<-3, 11> velocity=< 1, -2>",
                "position=< 7,  6> velocity=<-1, -1>",
                "position=<-2,  3> velocity=< 1,  0>",
                "position=<-4,  3> velocity=< 2,  0>",
                "position=<10, -3> velocity=<-1,  1>",
                "position=< 5, 11> velocity=< 1, -2>",
                "position=< 4,  7> velocity=< 0, -1>",
                "position=< 8, -2> velocity=< 0,  1>",
                "position=<15,  0> velocity=<-2,  0>",
                "position=< 1,  6> velocity=< 1,  0>",
                "position=< 8,  9> velocity=< 0, -1>",
                "position=< 3,  3> velocity=<-1,  1>",
                "position=< 0,  5> velocity=< 0, -1>",
                "position=<-2,  2> velocity=< 2,  0>",
                "position=< 5, -2> velocity=< 1,  2>",
                "position=< 1,  4> velocity=< 2,  1>",
                "position=<-2,  7> velocity=< 2, -2>",
                "position=< 3,  6> velocity=<-1, -1>",
                "position=< 5,  0> velocity=< 1,  0>",
                "position=<-6,  0> velocity=< 2,  0>",
                "position=< 5,  9> velocity=< 1, -2>",
                "position=<14,  7> velocity=<-2,  0>",
                "position=<-3,  6> velocity=< 2, -1>",
            };
            var day = new Day10(lights);
            var (w, h) = day.computePart1();
            Assert.AreEqual(h, 8);
            day = new Day10(lights);
            var t = day.computePart2();
            Assert.AreEqual(t, 3);
        }


        [TestMethod]
        public void Day11Test()
        {
            var serialNumber = "18";
            var day = new Day11(serialNumber);
            string grid = day.computePart1();
            Assert.IsTrue(grid.Equals("33,45"));
        }
    }
}
