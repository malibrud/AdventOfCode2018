using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2018
{
    public class Day03Part1
    {
        public static int computeClaims(List<string> claims)
        {
            var claimArr = parseClaims(claims);
            var N = claimArr.Length;
            int H = getHeight(claimArr);
            int W = getWidth(claimArr);
            var fabric = new byte[W, H];
            for (int i = 0; i < N; i++)
            {
                tagClaim(claimArr[i]);
            }
            return countMultipleClaims();

            ////////////////////////////////////
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

            int countMultipleClaims()
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
        }


        private static int getHeight(Claim[] claimArr)
        {
            int max = 0;
            for (int i = 0; i < claimArr.Length; i++)
            {
                int v = claimArr[i].y + claimArr[i].h;
                if (v > max) max = v;
            }
            return max + 1;
        }

        private static int getWidth(Claim[] claimArr)
        {
            int max = 0;
            for (int i = 0; i < claimArr.Length; i++)
            {
                int h = claimArr[i].x + claimArr[i].w;
                if (h > max) max = h;
            }
            return max + 1;
        }

        static Claim[] parseClaims(List<string> claims)
        {
            var claimArr = new Claim[claims.Count];
            for (int i = 0; i < claimArr.Length; i++)
            {
                claimArr[i] = processClaim(claims[i]);
            }
            return claimArr;
        }

        static private Claim processClaim(string v)
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
