using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhVu
{
    public class Solution
    {
        public int[][] Merge(int[][] intervals)
        {
            var result = new List<int[]>();
            intervals = intervals.OrderBy(q => q[0]).ToArray(); // most important
            result.Add(intervals[0]);

            for (int i = 1; i < intervals.Length; i++)
            {

                var prevS = result[result.Count - 1][0];
                var prevE = result[result.Count - 1][1];
                var currS = intervals[i][0];
                var currE = intervals[i][1];

                if (prevS <= currS && currE <= prevE)
                {
                    result[result.Count - 1][0] = prevS;
                    result[result.Count - 1][1] = prevE;
                    continue;
                }
                if (currS <= prevE && prevE <= currE)
                {
                    result[result.Count - 1][0] = Math.Min(currS, prevS);
                    result[result.Count - 1][1] = currE;

                    continue;
                }
                if (currS <= prevS && prevS <= currE)
                {
                    result[result.Count - 1][0] = currS;
                    result[result.Count - 1][1] = Math.Max(currE, prevE);

                    continue;
                }
                if (currS <= prevS && prevE <= currE)
                {
                    result[result.Count - 1][0] = currS;
                    result[result.Count - 1][1] = currE;

                    continue;
                }

                result.Add(intervals[i]);

            }

            return result.ToArray();
        }
    }
}