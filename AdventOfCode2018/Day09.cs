using System;
using System.Linq;

namespace AdventOfCode2018
{
    public class Day09
    {
        int nPlayers;
        int lastMarble;
        CircNode current;
        public Day09(string rawInput)
        {
            var asciiVals = rawInput.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            nPlayers = Int32.Parse(asciiVals[0]);
            lastMarble = Int32.Parse(asciiVals[6]);
            current = new CircNode();
        }
                
        public long compute()
        {
            var players = new long[nPlayers];
            for (int m = 1; m <= lastMarble; m++)
            {
                var pIdx = m % nPlayers;
                if (m % 23 == 0)
                {
                    moveCCW(7);
                    players[pIdx] = checked(players[pIdx] + m + current.val);
                    removeCurrent();
                }
                else
                {
                    moveCW(1);
                    insertToRight(m);
                }
            }
            return players.Max();
        }

        void moveCW(int n)
        {
            for (int i = 0; i < n; i++) current = current.next;
        }

        void moveCCW(int n)
        {
            for (int i = 0; i < n; i++) current = current.prev;
        }

        void insertToRight(int m)
        {
            var node = new CircNode();
            var cw = current.next;
            var ccw = current;
            cw.prev = node;
            ccw.next = node;
            node.next = cw;
            node.prev = ccw;
            node.val = m;
            current = node;
        }
        void removeCurrent()
        {
            var cw = current.next;
            var ccw = current.prev;
            ccw.next = cw;
            cw.prev = ccw;
            current = cw;
        }
    }

    class CircNode
    {
        public CircNode prev, next;
        public int val;

        public CircNode()
        {
            prev = next = this;
            val = 0;
        }
    }
}
