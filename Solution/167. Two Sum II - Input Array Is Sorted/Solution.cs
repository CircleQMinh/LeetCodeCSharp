using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhVu
{
    public class Solution
    {
        public int[] TwoSum(int[] numbers, int target)
        {
            var n = numbers.Length;
            var l = 0;
            var r = n - 1;
            while (l < r)
            {
                var sum = numbers[l] + numbers[r];
                if (sum > target)
                {
                    r--;
                }
                else if (sum < target)
                {
                    l++;
                }
                else
                {
                    return [l + 1, r + 1];
                }
            }
            return [l + 1, r + 1];
        }
    }
}