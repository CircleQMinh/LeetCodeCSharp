using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhVu
{
    public class Solution
    {
        public int MinSubArrayLen(int target, int[] nums)
        {
            //return CheckSubArray(target,nums);
            var n = nums.Length;
            var l = 0;
            var r = 0;
            var sum = 0;
            var result = int.MaxValue;
            while (r < n)
            {
                sum += nums[r];
                while (sum >= target)
                {
                    var currentLen = r - l + 1;
                    result = Math.Min(result, currentLen);
                    sum -= nums[l];
                    l++;
                }
                r++;
            }
            return result == int.MaxValue ? 0 : result;
        }
        //    public int MinSubArrayLen(int target, int[] nums)
        // {
        //     return CheckSubArray(target,nums);
        // }

        // public int CheckSubArray(int target, int[] nums, int currentLen = 1)// too slow
        // {
        //     var n = nums.Length;
        //     if (currentLen > nums.Length)
        //     {
        //         return 0;
        //     }

        //     for (var i = 0; i < n-currentLen+1; i++) { 
        //         var arr = new List<int>();
        //         for (var j = i; j < i+currentLen; j++)
        //         {
        //             arr.Add(nums[j]);
        //         }
        //         if (CalculateSumArray(arr) >= target)
        //         {
        //             return currentLen;
        //         }
        //     }
        //     return CheckSubArray(target,nums,currentLen+1);
        // }

        // public int CalculateSumArray(List<int> arr)
        // {
        //     return arr.Sum(x => x);
        // }
    }
}