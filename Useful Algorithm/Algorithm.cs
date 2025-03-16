using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UsefulAlgorithm
{
    public class Algorithm
    {
        public int MaxSubArray(int[] nums)  // Kadane’s Algorithm
        {
            var max = int.MinValue;
            var current = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                current += nums[i];
                max = Math.Max(max, current);
                current = Math.Max(0, current);
            }
            return max;
        }

        public int BinarySearch(int[] array, int target)
        {
            int left = 0;
            int right = array.Length - 1;

            while (left <= right)
            {
                int middle = left + (right - left) / 2;

                if (array[middle] == target)
                {
                    return middle;
                }

                if (array[middle] < target)
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
}