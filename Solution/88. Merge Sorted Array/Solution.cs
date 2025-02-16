using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhVu
{
    public class Solution
    {
        public void Merge(int[] nums1, int m, int[] nums2, int n)
        {
            var i = 0;
            var j = 0;
            for (int k = m; k < m + n; k++)
            {
                nums1[k] = int.MaxValue;
            }
            while (j < n)
            {
                if (nums1[i] > nums2[j])
                {
                    for (int k = m + n - 1; k > i; k--)
                    {
                        nums1[k] = nums1[k - 1];
                    }
                    nums1[i] = nums2[j];
                    j++;
                }
                i++;
            }
        }
    }
}