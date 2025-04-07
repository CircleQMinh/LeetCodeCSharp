using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhVu
{
    public class Solution
    {
        public IList<bool> KidsWithCandies(int[] candies, int extraCandies)
        {
            var result = new List<bool>();
            var max = candies.Max();
            for (int i = 0; i < candies.Length; i++)
            {
                result.Add(candies[i] + extraCandies >= max);
            }
            return result;
        }
    }
}