using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhVu
{
public class Solution {
    public int MinEatingSpeed(int[] piles, int h)
        {
            var results = new List<long>();
            long max = piles.Max();
            long min = 1;
            while (min <= max)
            {
                long mid = min + (max - min) / 2;
                long time = CalTimeToEat(piles, (int)mid);
                if (time == h)
                {
                    min = min+1;
                    results.Add(mid);
                }
                if (time > h)
                {
                    min = mid + 1;
                }
                else
                {
                    max = mid - 1;
                }

            }
            return results.Count > 0 ? (int)results.Min() : (int)min;
        }
        public long CalTimeToEat(int[] piles,int speed)
        {
            long total = 0;
            foreach (var item in piles)
            {
                var n = item % speed;
                if (n > 0)
                {
                    total += item / speed + 1;
                }
                else
                {
                    total += item / speed;
                }
            }
            return total;
        }
}
}