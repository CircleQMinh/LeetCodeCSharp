using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhVu
{
    public class Solution
    {
        public IList<string> SummaryRanges(int[] nums)
        {
            if (nums.Length == 0)
            {
                return new List<string>();
            }
            var result = new List<string>();
            var previous = 0;
            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] - nums[i - 1] != 1)
                {
                    result.Add(ContructString(nums[previous], nums[i - 1]));
                    previous = i;
                }

            }
            result.Add(ContructString(nums[previous], nums[nums.Length - 1]));
            return result;
        }

        public string ContructString(int a, int b)
        {
            if (a == b)
            {
                return $"{a}";
            }
            return $"{a}->{b}";
        }
    }
}