using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2018
{
    public class Day11
    {
        int[,] grid;
        int SN;
        const int N = 300;
        public Day11(string sn)
        {
            SN = Int32.Parse(sn);
            grid = new int[N+1, N+1];
            computePowerLevels();
        }

        void computePowerLevels()
        {
            for (int y = 1; y <= N; y++)
            {
                for (int x = 1; x <= N; x++)
                {
                    var rackID = x + 10;
                    var power = rackID * y;
                    power += SN;
                    power *= rackID;
                    var hundredsDigit = (power / 100) % 10;
                    grid[y, x] = hundredsDigit - 5;
                }
            }
        }

        public string computePart1()
        {
            int maxX = 1, maxY = 1;
            int maxPower = grid[1, 1];
            for (int y = 1; y <= N-2; y++)
            {
                for (int x = 1; x <= N-2; x++)
                {
                    int power = computeSubgridPower(x, y);
                    if (power > maxPower)
                    {
                        maxPower = power;
                        maxX = x;
                        maxY = y;
                    }
                }
            }
            return $"{maxX},{maxY}";
        }

        private int computeSubgridPower(int x, int y)
        {
            int sum = 0;
            for (int iy = y; iy < y + 3; iy++)
            {
                for (int ix = x; ix < x+3; ix++)
                {
                    sum += grid[iy, ix];
                }
            }
            return sum;
        }
    }
}
