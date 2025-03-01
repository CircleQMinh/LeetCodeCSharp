using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhVu
{
    public class Solution
    {
        public bool ContainsNearbyDuplicate(int[] nums, int k)
        {
            var map = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (!map.ContainsKey(nums[i]))
                {
                    map.Add(nums[i], i);
                }
                else
                {
                    var result = Math.Abs(map[nums[i]] - i);
                    if (result <= k)
                    {
                        return true;
                    }
                    else
                    {
                        map[nums[i]] = i;
                    }
                }

            }
            return false;
        }
    }
}