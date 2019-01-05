using System;
using System.Collections.Generic;
using static System.Diagnostics.Debug;
using static System.Console;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace AdventOfCode2018
{
    public class Day13
    {
        char[,] map;
        List<Cart> carts = new List<Cart>();
        int R, C;
        public Day13(List<string> rawRecords)
        {
            readMap(rawRecords);
            getCarts();
        }

        void readMap(List<string> recs)
        {
            R = recs.Count;
            C = recs[0].Length;
            map = new char[R, C];
            for (int r = 0; r < R; r++)
            {
                for (int c = 0; c < C; c++)
                {
                    map[r, c] = recs[r][c];
                }
            }
        }

        void getCarts()
        {
            var label = 'A';
            for (int r = 0; r < R; r++)
            {
                for (int c = 0; c < C; c++)
                {
                    var p = map[r, c];
                    if ("^v<>".Contains(p))
                    {
                        var cart = new Cart();
                        cart.r = r;
                        cart.c = c;
                        cart.dir = p;
                        cart.label = label++;
                        carts.Add(cart);
                    }
                    if ("<>".Contains(p)) map[r, c] = '-';
                    if ("^v".Contains(p)) map[r, c] = '|';
                }
            }
        }

        public string computePart1()
        {
            var tick = 0;
            var crashRow = 0;
            var crashCol = 0;
            //printMap(tick);
            while (true)
            {
                tick++;
                foreach (var cart in carts)
                {
                    advanceCart(cart);
                    if (isCrashed(cart, out int idx))
                    {
                        (crashRow, crashCol) = (cart.r, cart.c);
                        goto outside;
                    }
                }
                //printMap(tick);
            }
            outside:
            return $"{crashCol},{crashRow}";
        }

        public string computePart2()
        {
            var tick = 0;
            var crashRow = 0;
            var crashCol = 0;
            var removeList = new List<Cart>();
            //printMap(tick);
            while (true)
            {
                tick++;
                foreach (var cart in carts)
                {
                    advanceCart(cart);
                    if (isCrashed(cart, out int idx))
                    {
                        //Console.WriteLine($"Tick: {tick}");
                        if (!removeList.Contains(cart)) removeList.Add(cart);
                        if (!removeList.Contains(carts[idx])) removeList.Add(carts[idx]);
                        printMap(tick);
                    } 
                }
                foreach (var cart in removeList)
                {
                    carts.Remove(cart);
                }
                removeList.Clear();
                if (carts.Count == 1)
                {
                    (crashRow, crashCol) = (carts[0].r, carts[0].c);
                    break;
                }
            }
            return $"{crashCol},{crashRow}";
        }
        void printMap(int t)
        {
            char[,] mapc = new char[R,C];
            Array.Copy(map, mapc, R * C);
            foreach (var cart in carts)
            {
                mapc[cart.r, cart.c] = cart.label;
            }
            Console.WriteLine($"Tick: {t}, N = {carts.Count}");
            for (int r = 0; r < R; r++)
            {
                for (int c = 0; c < C; c++)
                {
                    Console.Write(mapc[r, c]);
                }
                Console.WriteLine("");
            }
        }

        bool isCrashed(Cart cart, out int idx)
        {
            idx = 0;
            foreach (var other in carts)
            {
                if (other != cart && other.r == cart.r && other.c == cart.c)
                {
                    Console.WriteLine($"Crash: {cart.label} & {other.label}");
                    return true;
                }
                idx++;
            }
            return false;
        }

        void advanceCart(Cart cart)
        {
            var (r, c, d) = (cart.r, cart.c, cart.dir);
            var p = map[r, c];
            if (@"\/".Contains(p)) doTurn(cart);
            else if (p == '+') doIntersection(cart);
            else doStraight(cart);
        }

        void doTurn(Cart cart)
        {
            var (r, c, d) = (cart.r, cart.c, cart.dir);
            var p = map[r, c];
            int dr = 0, dc = 0;
            switch (p)
            {
                case '/':
                    switch (d)
                    {
                        case '^':
                            (dr, dc, d) = (0, 1, '>');
                            break;
                        case '>':
                            (dr, dc, d) = (-1, 0, '^');
                            break;
                        case 'v':
                            (dr, dc, d) = (0, -1, '<');
                            break;
                        case '<':
                            (dr, dc, d) = (1, 0, 'v');
                            break;
                        default:
                            Assert(false);
                            break;
                    }
                    break;
                case '\\':
                    switch (d)
                    {
                        case '^':
                            (dr, dc, d) = (0, -1, '<');
                            break;
                        case '>':
                            (dr, dc, d) = (1, 0, 'v');
                            break;
                        case 'v':
                            (dr, dc, d) = (0, 1, '>');
                            break;
                        case '<':
                            (dr, dc, d) = (-1, 0, '^');
                            break;
                        default:
                            Assert(false);
                            break;
                    }
                    break;
                default:
                    Assert(false);
                    break;
            }
            cart.r += dr;
            cart.c += dc;
            cart.dir = d;
        }

        void doIntersection(Cart cart)
        {
            var (r, c, d) = (cart.r, cart.c, cart.dir);
            var p = map[r, c];
            int dr = 0, dc = 0;
            switch (d)
            {
                case '^':
                    dr = -1;
                    break;
                case '>':
                    dc = 1;
                    break;
                case 'v':
                    dr = 1;
                    break;
                case '<':
                    dc = -1;
                    break;
                default:
                    Assert(false);
                    break;
            }
            // Rotate vector accoring to turn
            switch (Cart.turnCycle[cart.turn])
            {
                case 'L':
                    (dr, dc) = (-dc, dr);
                    d = Cart.getNextLeft(d);
                    break;
                case 'S':
                    (dr, dc) = (dr, dc); // no op
                    break;
                case 'R':
                    (dr, dc) = (dc, -dr);
                    d = Cart.getNextRight(d);
                    break;
                default:
                    Assert(false);
                    break;
            }
            cart.r += dr;
            cart.c += dc;
            cart.turn = (cart.turn + 1) % 3;
            cart.dir = d;
        }

        void doStraight(Cart cart)
        {
            var (r, c, d) = (cart.r, cart.c, cart.dir);
            var p = map[r, c];
            int dr = 0, dc = 0;
            switch (p)
            {
                case '|':
                    switch (d)
                    {
                        case '^':
                            dr = -1;
                            break;
                        case 'v':
                            dr = 1;
                            break;
                        default:
                            Assert(false);
                            break;
                    }
                    break;
                case '-':
                    switch (d)
                    {
                        case '<':
                            dc = -1;
                            break;
                        case '>':
                            dc = 1;
                            break;
                        default:
                            Assert(false);
                            break;
                    }
                    break;
                default:
                    Assert(false);
                    break;
            }
            cart.r += dr;
            cart.c += dc;
        }
    }

    class Cart
    {
        public int r, c;
        public char dir;
        public int turn = 0;
        public char label;
        public static char[] turnCycle = new char[] {'L', 'S', 'R'};
        public static char[] leftCycle = new char[] { '^', '<', 'v', '>' };
        public static char getNextLeft(char d)
        {
            int i;
            for (i = 0; i < 4; i++)
            {
                if (leftCycle[i] == d) break;
            }
            return leftCycle[(i + 1) % 4];
        }

        public static char getNextRight(char d)
        {
            int i;
            for (i = 0; i < 4; i++)
            {
                if (leftCycle[i] == d) break;
            }
            return leftCycle[(i + 3) % 4];
        }
    }
}
