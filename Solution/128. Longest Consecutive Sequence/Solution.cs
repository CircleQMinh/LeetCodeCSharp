using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhVu
{
    public class Solution
    {
        public int LongestConsecutive(int[] nums)
        {
            if (nums.Length == 0)
            {
                return 0;
            }
            var map = new HashSet<int>(nums);
            var result = 0;
            foreach (int i in map)
            {
                if (!map.Contains(i - 1)) // only check if the current num is smallest
                {
                    var count = 1;
                    var value = i;
                    while (map.Contains(value + 1))
                    {
                        count++;
                        value++;
                    }
                    result = Math.Max(result, count);
                }
            }
            return result;
        }
    }
}