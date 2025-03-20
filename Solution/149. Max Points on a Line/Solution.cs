using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhVu
{
    public class Solution
    {
        public int MaxPoints(int[][] points)
        {
            var dic = new Dictionary<string, int>();
            var max = 0;
            for (int i = 0; i < points.Length; i++)
            {
                for (int j = i + 1; j < points.Length; j++)
                {
                    var pointA = points[i];
                    var pointB = points[j];

                    var slopeX = (pointA[0] - pointB[0]);
                    var slopeY = (pointA[1] - pointB[1]);
                    var slope = "";
                    var gcd = GCD(slopeX, slopeY);
                    if (gcd > 1)
                    {
                        slopeX /= gcd;
                        slopeY /= gcd;
                    }
                    if (slopeY == 0)
                    {
                        slope = $"IFN";
                    }
                    else if (slopeX == 0)
                    {
                        slope = "0";
                    }
                    else
                    {
                        if (slopeY < 0)
                        {
                            slopeY = -slopeY;
                            slopeX = -slopeX;
                        }
                        slope = $"{slopeX}-{slopeY}";

                    }
                    if (!dic.ContainsKey(slope))
                    {
                        dic.Add(slope, 0);
                    }
                    dic[slope]++;
                }
                var currentMax = dic.Count > 0 ? dic.Max(q => q.Value) : 0;
                max = Math.Max(max, currentMax);
                dic.Clear();
            }

            return max + 1;
        }
        public int GCD(int x, int y)
        {
            var n = Math.Min(Math.Abs(x), Math.Abs(y));
            while (n > 0)
            {
                if (x % n == 0 && y % n == 0)
                {
                    return n;
                }
                n--;
            }
            return 0;
        }
    }
}