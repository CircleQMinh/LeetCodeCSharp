using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhVu
{
    public class Solution
    {
        public int FindKthLargest(int[] nums, int k)
        {
            var maxHeap = new PriorityQueue<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                maxHeap.Enqueue(i, -nums[i]);
            }
            var result = 0;
            while (k > 0)
            {
                result = nums[maxHeap.Dequeue()];
                k--;
            }
            return result;
        }
    }
}