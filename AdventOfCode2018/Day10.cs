using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Console;

namespace AdventOfCode2018
{
    public class Day10
    {
        int N;
        Point[] lights;
        public Day10(List<string> rawRecords)
        {
            N = rawRecords.Count;
            lights = new Point[N];
            var reg = new Regex(@"position=< *(\-*\d+), +(\-*\d+)> velocity=< *(\-*\d+), +(\-*\d+)>");
            for (int i = 0; i < N; i++)
            {
                var m = reg.Match(rawRecords[i]);
                var g = m.Groups;
                lights[i] = new Point();
                lights[i].p.x = Int32.Parse(g[1].Value);
                lights[i].p.y = Int32.Parse(g[2].Value);
                lights[i].v.x = Int32.Parse(g[3].Value);
                lights[i].v.y = Int32.Parse(g[4].Value);
            }
        }

        public (int w, int h) computePart1()
        {
            var dim = getDimensions();
            var lowestHeight = dim.h;
            while (true)
            {
                stepForward();
                dim = getDimensions();
                if (dim.h > lowestHeight) break;
                else lowestHeight = dim.h;
            }
            stepBackward();
            dim = getDimensions();
            shiftSolution();
            displaySolution();
            return dim;
        }
        
        public int computePart2()
        {
            var dim = getDimensions();
            var lowestHeight = dim.h;
            int t = 0;
            while (true)
            {
                stepForward();
                dim = getDimensions();
                if (dim.h > lowestHeight) break;
                else lowestHeight = dim.h;
                t++;
            }
            return t;
        }

        void shiftSolution()
        {
            var (x0, y0) = getXYmin();
            for (int i = 0; i < N; i++)
            {
                lights[i].p.x -= x0;
                lights[i].p.y -= y0;
            }
        }

        (int, int) getXYmin()
        {
            var xmin = lights[0].p.x;
            var ymin = lights[0].p.y;
            for (int i = 0; i < N; i++)
            {
                if (lights[i].p.x < xmin) xmin = lights[i].p.x;
                if (lights[i].p.y < ymin) ymin = lights[i].p.y;
            }
            return (xmin, ymin);
        }


        void displaySolution()
        {
            var dim = getDimensions();
            var arr = new char[dim.h, dim.w];
            for (int y = 0; y < dim.h; y++)
            {
                for (int x = 0; x < dim.w; x++)
                {
                    arr[y, x] = ' ';
                }
            }
            for (int i = 0; i < N; i++)
            {
                arr[lights[i].p.y, lights[i].p.x] = '#';
            }
            for (int y = 0; y < dim.h; y++)
            {
                for (int x = 0; x < dim.w; x++)
                {
                    Write(arr[y, x]);
                }
                WriteLine();
            }
        }
        void stepForward()
        {
            foreach (var p in lights)
            {
                p.stepForward();
            }
        }

        void stepBackward()
        {
            foreach (var p in lights)
            {
                p.stepBack();
            }
        }

        (int w, int h) getDimensions()
        {
            var xMin = lights[0].p.x;
            var xMax = lights[0].p.x;
            var yMin = lights[0].p.y;
            var yMax = lights[0].p.y;
            for (int i = 0; i < N; i++)
            {
                var l = lights[i];
                if (l.p.x < xMin) xMin = l.p.x;
                if (l.p.x > xMax) xMax = l.p.x;
                if (l.p.y < yMin) yMin = l.p.y;
                if (l.p.y > yMax) yMax = l.p.y;
            }
            return (xMax - xMin + 1, yMax - yMin + 1);
        }
    }


    public class Point
    {
        public (int x, int y) p;
        public (int x, int y) v;

        public void stepForward()
        {
            p.x += v.x;
            p.y += v.y;
        }

        public void stepBack()
        {
            p.x -= v.x;
            p.y -= v.y;
        }
    }
}
