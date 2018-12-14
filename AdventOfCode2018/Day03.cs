using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2018
{
    public class Day03
    {
        Claim[] claimArr;
        int N;
        int H;
        int W;
        byte[,] fabric;

        public Day03(List<string> claims)
        {
            claimArr = parseClaims(claims);
            N = claimArr.Length;
            H = getHeight();
            W = getWidth();
            fabric = new byte[W, H];
            for (int i = 0; i < N; i++)
            {
                tagClaim(claimArr[i]);
            }
        }

        public int computePart1()
        {
            var count = 0;
            for (int i = 0; i < W; i++)
            {
                for (int j = 0; j < H; j++)
                {
                    if (fabric[i, j] >= 2) count++;
                }
            }
            return count;
        }

        public int computePart2()
        {
            for (int i = 0; i < N; i++)
            {
                if (isExclusiveClaim(claimArr[i])) return claimArr[i].id;
            }
            return 0;
        }

        private bool isExclusiveClaim(Claim c)
        {
            for (int i = c.x; i < c.x + c.w; i++)
            {
                for (int j = c.y; j < c.y + c.h; j++)
                {
                    if (fabric[i, j] >= 2) return false;
                }
            }
            return true;
        }

        void tagClaim(Claim c)
        {
            for (int i = c.x; i < c.x + c.w; i++)
            {
                for (int j = c.y; j < c.y + c.h; j++)
                {
                    fabric[i, j]++;
                }
            }
        }


        private int getHeight()
        {
            int max = 0;
            for (int i = 0; i < claimArr.Length; i++)
            {
                int v = claimArr[i].y + claimArr[i].h;
                if (v > max) max = v;
            }
            return max + 1;
        }

        private int getWidth()
        {
            int max = 0;
            for (int i = 0; i < claimArr.Length; i++)
            {
                int h = claimArr[i].x + claimArr[i].w;
                if (h > max) max = h;
            }
            return max + 1;
        }

        Claim[] parseClaims(List<string> claims)
        {
            var claimArr = new Claim[claims.Count];
            for (int i = 0; i < claimArr.Length; i++)
            {
                claimArr[i] = processClaim(claims[i]);
            }
            return claimArr;
        }

        private Claim processClaim(string v)
        {
            var delims = "#@,:x ".ToCharArray();
            var claimParts = v.Split(delims, StringSplitOptions.RemoveEmptyEntries);
            var claim = new Claim();
            claim.id = Int32.Parse(claimParts[0]);
            claim.x = Int32.Parse(claimParts[1]);
            claim.y = Int32.Parse(claimParts[2]);
            claim.w = Int32.Parse(claimParts[3]);
            claim.h = Int32.Parse(claimParts[4]);
            return claim;
        }
    }

    class Claim
    {
        public int id;
        public int x, y;
        public int w, h;
    }
}
