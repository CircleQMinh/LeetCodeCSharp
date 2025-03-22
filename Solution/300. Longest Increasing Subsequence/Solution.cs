using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhVu
{
    public class Solution
    {
        public int LengthOfLIS(int[] nums)
        {
            var n = nums.Length;
            var max = 1;
            var dp = new int[n];
            Array.Fill(dp, 1);
            for (int i = 1; i < n; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (nums[i] > nums[j])
                    {
                        dp[i] = Math.Max(dp[j] + 1, dp[i]);
                        max = Math.Max(max, dp[i]);
                    }
                }
            }
            return max;
        }
    }
}