using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode2018
{
    public class Day04
    {
        Record[] records;
        Dictionary<int, Guard> guards;
        int N;
        public Day04(List<string> rawRecords)
        {
            N = rawRecords.Count;
            records = parseRecords(rawRecords);
            records = records.OrderBy(c => c.timeStamp).ToArray();
            binRecords();
        }

        public int computePart1()
        {
            (int maxId, int maxTime) = getMaxTotalSleep();
            var maxMin = guards[maxId].getMostFrequentNapTime();
            return maxId * maxMin;
        }

        (int id, int t) getMaxTotalSleep()
        {
            int maxId = 0;
            int maxTime = 0;
            foreach (var g in guards)
            {
                var t = g.Value.getTotalSleepTime();
                if (t > maxTime)
                {
                    maxTime = t;
                    maxId = g.Key;
                }
            }
            return (maxId, maxTime);
        }

        private void binRecords()
        {
            int i = 0;
            guards = new Dictionary<int, Guard>();
            while (i < N)
            {
                var r = records[i++];
                Debug.Assert(r.action == Action.beginsShift);
                var id = r.guardID;
                if (!guards.ContainsKey(id)) guards[id] = new Guard();
                while (i < N && records[i].action != Action.beginsShift)
                {
                    var r1 = records[i++];
                    var r2 = records[i++];
                    guards[id].addNap(r1, r2);
                }
            }
        }

        Record[] parseRecords(List<string> rawRecs)
        {
            var recs = new Record[N];
            Regex r = new Regex(@"\[(.+)\] ([A-Za-z]+) ([\#A-Za-z0-9]+)");
            for (int i = 0; i < N; i++)
            {
                var m = r.Match(rawRecs[i]);
                var g = m.Groups;
                var rec = new Record();
                rec.timeStamp = g[1].Value;
                var word1 = g[2].Value;
                var word2 = g[3].Value;
                rec.action = getAction(word1);
                if (rec.action == Action.beginsShift)
                {
                    word2 = word2.Substring(1);
                    rec.guardID = Int32.Parse(word2);
                }
                var dayTime = rec.timeStamp.Split();
                rec.date = dayTime[0];
                (rec.hour, rec.minute) = getHourMinute(dayTime[1]);

                recs[i] = rec;
            }
            return recs;
        }

        private (int, int) getHourMinute(string timeStamp)
        {
            int h, m;
            var arr = timeStamp.Split(":".ToCharArray());
            h = Int32.Parse(arr[0]);
            m = Int32.Parse(arr[1]);
            return (h, m);
        }

        Action getAction(string word1)
        {
            switch (word1)
            {
                case "Guard":
                    return Action.beginsShift;
                case "falls":
                    return Action.fallsAsleep;
                case "wakes":
                    return Action.wakesUp;
            }
            return Action.invalid;
        }
    }

    class Record
    {
        public int guardID;
        public string timeStamp;
        public string date;
        public int hour;
        public int minute;
        public Action action;
    }
    enum Action
    {
        beginsShift,
        fallsAsleep,
        wakesUp,
        invalid
    }

    class Guard
    {
        public Dictionary<string, Day> days;
        public Guard()
        {
            days = new Dictionary<string, Day>();
        }

        public void addNap(Record r1, Record r2)
        {
            var d = r1.date;
            if (!days.ContainsKey(d)) days[d] = new Day();
            days[d].addNap(r1, r2);
        }

        public int getTotalSleepTime()
        {
            var time = 0;
            foreach (var day in days)
            {
                foreach (var nap in day.Value.naps)
                {
                    time += nap.wakesUp.m - nap.fallsAsleep.m;
                }
            }
            return time;
        }

        public int getMostFrequentNapTime()
        {
            var minutes = new int[60];
            foreach (var day in days)
            {
                foreach (var nap in day.Value.naps)
                {
                    int s = nap.fallsAsleep.m;
                    int f = nap.wakesUp.m;
                    for (int i = s; i < f; i++) minutes[i]++;
                }
            }
            var max = minutes.Max();
            var idx = Array.IndexOf(minutes, max);
            return idx;
        }
    }

    class Day
    {
        public List<Nap> naps;
        public Day()
        {
            naps = new List<Nap>();
        }
        public void addNap(Record r1, Record r2)
        {
            var n = new Nap();
            n.fallsAsleep = (r1.hour, r1.minute);
            n.wakesUp = (r2.hour, r2.minute);
            naps.Add(n);
        }
    }

    class Nap
    {
        public (int h, int m) fallsAsleep;
        public (int h, int m) wakesUp;
    }
}
