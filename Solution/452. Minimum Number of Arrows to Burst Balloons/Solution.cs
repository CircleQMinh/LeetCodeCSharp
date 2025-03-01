using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhVu
{
    public class Solution
    {
        public int FindMinArrowShots(int[][] points)
        {
            points = points.OrderBy(q => q[0]).ToArray();
            var result = 0;
            var overlap = new List<int[]>();
            overlap.Add(points[0]);
            for (var i = 1; i < points.Length; i++)
            {

                if (!IsAllOverlap(overlap, points[i]))
                {
                    result++;
                    overlap.Clear();
                }
                overlap.Add(points[i]);
            }

            return overlap.Count > 0 ? result + 1 : result;
        }

        public bool IsAllOverlap(List<int[]> currents, int[] newP)
        {
            foreach (var item in currents)
            {
                var oldS = item[0];
                var oldE = item[1];
                var newS = newP[0];
                var newE = newP[1];
                if (!(oldS <= newE && newS <= oldE))
                {
                    return false;
                }
            }
            return true;
        }
    }
}