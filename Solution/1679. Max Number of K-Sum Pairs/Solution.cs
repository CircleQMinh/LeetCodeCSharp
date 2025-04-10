using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhVu
{
    public class Solution
    {
        public int MaxOperations(int[] nums, int k)
        {
            var n = nums.Length;
            var set = new Dictionary<int, int>();
            var count = 0;
            for (int i = 0; i < n; i++)
            {
                var find = k - nums[i];
                if (set.ContainsKey(find) && set[find] > 0)
                {
                    count++;
                    set[find]--;
                }
                else
                {
                    if (!set.ContainsKey(nums[i]))
                    {
                        set.Add(nums[i], 0);
                    }
                    set[nums[i]]++;
                }
            }
            return count;
        }
    }
}