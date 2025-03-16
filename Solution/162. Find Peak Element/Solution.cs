using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhVu
{

    public class Solution
    {
        public int FindPeakElement(int[] nums)
        {
            if (nums.Length == 1)
            {
                return 0;
            }
            int left = 0;
            int right = nums.Length - 1;
            var middle = 0;

            while (left <= right)
            {
                middle = left + (right - left) / 2;
                var leftSideOfMid = middle - 1 >= 0 ? nums[middle - 1] : int.MinValue;
                var rightSideOfMid = middle + 1 < nums.Length ? nums[middle + 1] : int.MinValue;
                if (nums[middle] > rightSideOfMid && nums[middle] > leftSideOfMid)
                {
                    return middle;
                }

                if (nums[middle] < nums[middle + 1])
                {
                    left = middle + 1;
                }
                else
                {
                    right = middle - 1;
                }
            }

            return -1;
        }
    }

    // public class Solution // cleaner version
    // {
    //     public int FindPeakElement(int[] nums)
    //     {
    //         int left = 0, right = nums.Length - 1;

    //         while (left < right)
    //         { // No need for `<=` since we return inside
    //             int middle = left + (right - left) / 2;

    //             if (nums[middle] > nums[middle + 1])
    //             {
    //                 // Move towards the higher value (possible peak)
    //                 right = middle;
    //             }
    //             else
    //             {
    //                 left = middle + 1;
    //             }
    //         }

    //         return left; // At the end, left == right, which is a peak index
    //     }
    // }

}