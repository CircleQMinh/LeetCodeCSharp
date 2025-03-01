using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhVu
{
    public class Solution
    {
        public int[][] Insert(int[][] intervals, int[] newInterval)
        {
            var result = new List<int[]>();
            var overlap = new List<int[]>();

            foreach (var interval in intervals)
            {
                var oldS = interval[0];
                var oldE = interval[1];
                var newS = newInterval[0];
                var newE = newInterval[1];
                if (oldS <= newE && newS <= oldE)
                {
                    overlap.Add(interval);
                }
                else
                {
                    result.Add(interval);
                }
            }
            overlap.Add(newInterval);
            var maxE = overlap.Max(q => q[1]);
            var minS = overlap.Min(q => q[0]);

            result.Add([minS, maxE]);

            return result.OrderBy(q => q[0]).ToArray();
        }
    }
}