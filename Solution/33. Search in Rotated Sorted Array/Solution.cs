using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhVu
{
    public class Solution
    {
        public int Search(int[] nums, int target)
        {
            var original = new int[nums.Length];

            var pivot = 0;
            var index = 0;
            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] < nums[i - 1])
                {
                    pivot = i;
                }
            }
            if (pivot >= 0)
            {
                for (int i = pivot; i < nums.Length; i++)
                {
                    original[index] = nums[i];
                    index++;
                }
                for (int i = 0; i < pivot; i++)
                {
                    original[index] = nums[i];
                    index++;
                }
            }

            var result = BinarySearch(original, target);

            return result > -1 ? (result + pivot) % nums.Length : -1;
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