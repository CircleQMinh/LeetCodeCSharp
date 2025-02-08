using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhVu
{
    public class Solution {
        public int SearchInsert(int[] nums, int target) {
            var result = -1;
            int left = 0;
            int right = nums.Length - 1; 
            while (left <= right) {
                int middle = left + (right - left) / 2;
                if (nums[middle] == target)
                {
                    result = middle;
                    return result;
                }
                if (nums[middle] < target) { 
                    left = middle + 1;
                }
                if (nums[middle] > target) { 
                    right = middle - 1;
                }

            }
            result = left;

            return result;
        }
    }
}