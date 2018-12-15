using System;
using System.Collections.Generic;
using System.IO;

namespace AdventOfCode2018
{
    class FileReader
    {
        public static List<int> readDay01(string fileName)
        {
            string line;
            var nums = new List<int>();
            using (var reader = File.OpenText(fileName))
            {
                while((line = reader.ReadLine()) != null)
                {
                    var val = int.Parse(line);
                    nums.Add(val);
                }
            }
            return nums;
        }

        internal static List<string> readDay02(string fileName)
        {
            string line;
            var ids = new List<string>();
            using (var reader = File.OpenText(fileName))
            {
                while ((line = reader.ReadLine()) != null)
                {
                    ids.Add(line);
                }
            }
            return ids;
        }

        internal static List<string> readDay03(string fileName)
        {
            string line;
            var claims = new List<string>();
            using (var reader = File.OpenText(fileName))
            {
                while ((line = reader.ReadLine()) != null)
                {
                    claims.Add(line);
                }
            }
            return claims;
        }

        internal static List<string> readAsciiLines(string fileName)
        {
            string line;
            var lines = new List<string>();
            using (var reader = File.OpenText(fileName))
            {
                while ((line = reader.ReadLine()) != null)
                {
                    lines.Add(line);
                }
            }
            return lines;
        }
    }
}
