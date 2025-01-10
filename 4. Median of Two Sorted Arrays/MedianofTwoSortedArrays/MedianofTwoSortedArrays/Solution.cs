using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedianofTwoSortedArrays
{
    public static class Solution
    {
        public static double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            double result = 0;
            var lenght = nums1.Length + nums2.Length;
            var merge = new int[lenght];
            merge = nums1.Concat(nums2).ToArray();
            merge = merge.OrderBy(x => x).ToArray();
            if (lenght % 2 == 0)
            {
                result = (merge[(lenght / 2) - 1] + merge[lenght / 2]) / 2.00;
                return result;
            }
            else
            {
                result = merge[lenght / 2];
                return result;
            }
        }
    }
}
