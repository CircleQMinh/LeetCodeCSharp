using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhVu
{
    public class Solution
    {
        public IList<IList<int>> KSmallestPairs(int[] nums1, int[] nums2, int k)
        {
            var result = new List<IList<int>>();
            if (nums1.Length == 0 || nums2.Length == 0 || k == 0) return result;

            var minHeap = new PriorityQueue<(int i, int j), int>();

            // Initialize the heap with the first k pairs (nums1[i], nums2[0])
            for (int i = 0; i < Math.Min(nums1.Length, k); i++)
            {
                minHeap.Enqueue((i, 0), nums1[i] + nums2[0]);
            }

            while (k > 0 && minHeap.Count > 0)
            {
                var (i, j) = minHeap.Dequeue();
                result.Add(new List<int> { nums1[i], nums2[j] });
                k--;

                // Push the next element in the row (nums1[i], nums2[j+1]) if available
                if (j + 1 < nums2.Length)
                {
                    minHeap.Enqueue((i, j + 1), nums1[i] + nums2[j + 1]);
                }
            }

            return result;
        }
    }

}