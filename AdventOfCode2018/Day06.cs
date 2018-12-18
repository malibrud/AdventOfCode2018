using System;
using System.Collections.Generic;
using System.Linq;
using static System.Math;

namespace AdventOfCode2018
{
    public class Day06
    {
        (int x, int y)[] coords;
        int N;
        int xMin, yMin, xMax, yMax;
        Grid grid;

        public Day06(List<string> rawRecords)
        {
            N = rawRecords.Count;
            coords = new (int, int)[N];
            for (int i = 0; i < N; i++)
            {
                var fields = rawRecords[i].Split(" ,".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                var x = Int32.Parse(fields[0]);
                var y = Int32.Parse(fields[1]);
                coords[i] = (x, y);
            }
            getExtents();
            grid = new Grid(xMin, yMin, xMax, yMax);
        }

        public int computePart1()
        {
            labelGrid();
            var infCoords = getInfiniteAreaCoordinates();
            var area = getMaxArea(infCoords);
            return area;
        }

        public int computePart2(int threshold)
        {
            int count = 0;
            for (int x = xMin; x <= xMax; x++)
            {
                for (int y = yMin; y <= yMax; y++)
                {
                    var d = 0;
                    for (int i = 0; i < N; i++)
                    {
                        d += dist((x, y), coords[i]);
                    }
                    if (d < threshold) count++;
                }
            }
            return count;
        }

        void labelGrid()
        {
            for (int x = xMin; x <= xMax; x++)
            {
                for (int y = yMin; y <= yMax; y++)
                {
                    int min = xMax - xMin + yMax - yMin + 4;
                    int minCount = 0;
                    sbyte minCoord = -1;
                    for (sbyte i = 0; i < N; i++)
                    {
                        var d = dist((x, y), coords[i]);
                        if (d == min) minCount++;
                        else if (d < min)
                        {
                            min = d;
                            minCount = 1;
                            minCoord = i;
                        }
                    }
                    if (minCount == 1) grid.set((x, y), minCoord);
                    else grid.set((x, y), -1);
                }
            }
        }

        List<sbyte> getInfiniteAreaCoordinates()
        {
            var infs = new List<sbyte>();
            // Run along top and bottom edges.
            for (int x = xMin; x <= xMax; x++)
            {
                sbyte coord;
                coord = grid.get((x, yMin));
                if (coord != -1)
                {
                    if (!infs.Contains(coord)) infs.Add(coord);
                }
                coord = grid.get((x, yMax));
                if (coord != -1)
                {
                    if (!infs.Contains(coord)) infs.Add(coord);
                }
            }

            // Run along left and right edges.
            for (int y = yMin; y <= yMax; y++)
            {
                sbyte coord;
                coord = grid.get((xMin, y));
                if (coord != -1 && !infs.Contains(coord)) infs.Add(coord);
                coord = grid.get((xMax, y));
                if (coord != -1 && !infs.Contains(coord)) infs.Add(coord);
            }
            return infs;
        }

        int getMaxArea(List<sbyte> infs)
        {
            var areas = new int[N];
            for (int x = xMin; x <= xMax; x++)
            {
                for (int y = yMin; y <= yMax; y++)
                {
                    var coord = grid.get((x, y));
                    if (coord != -1 && !infs.Contains(coord)) areas[coord]++;
                }
            }
            return areas.Max();
        }

        int dist((int x, int y) p1, (int x, int y) p2)
        {
            return Abs(p1.x - p2.x) + Abs(p1.y - p2.y);
        }

        void getExtents()
        {
            (xMin, yMin) = coords[0];
            (xMax, yMax) = coords[0];
            foreach (var c in coords)
            {
                if (c.x > xMax) xMax = c.x;
                if (c.y > yMax) yMax = c.y;
                if (c.x < xMin) xMin = c.x;
                if (c.y < yMin) yMin = c.y;
            }
        }
    }

    class Grid
    {
        sbyte[,] grid;
        int xMin, yMin, xMax, yMax;

        public Grid(int _xMin, int _yMin, int _xMax, int _yMax)
        {
            xMin = _xMin;
            yMin = _yMin;
            xMax = _xMax;
            yMax = _yMax;
            var X = xMax - xMin + 1;
            var Y = yMax - yMin + 1;

            grid = new sbyte[X,Y];
        }
        public void set((int x, int y) c, sbyte val)
        {
            int x = c.x - xMin;
            int y = c.y - yMin;
            grid[x, y] = val;
        }
        public sbyte get((int x, int y) c)
        {
            int x = c.x - xMin;
            int y = c.y - yMin;
            return grid[x, y];
        }
    }
}
