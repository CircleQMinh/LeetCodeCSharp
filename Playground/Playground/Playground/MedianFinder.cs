﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playground
{
    public class MedianFinder
    {
        private PriorityQueue<int, int> minHeap;
        private PriorityQueue<int, int> maxHeap; 

        public MedianFinder()
        {
            minHeap = new PriorityQueue<int, int>(); 
            maxHeap = new PriorityQueue<int, int>(Comparer<int>.Create((a, b) => b - a));
        }

        public void AddNum(int num)
        {
            // Add to Max-Heap first
            maxHeap.Enqueue(num, num);

            // Balance: Move max of Max-Heap to Min-Heap
            var max = maxHeap.Peek();
            minHeap.Enqueue(maxHeap.Dequeue(),max);

            //  If Min-Heap has more elements, move its min to Max-Heap
            if (minHeap.Count > maxHeap.Count)
            {
                var min = minHeap.Peek();
                maxHeap.Enqueue(minHeap.Dequeue(), min);
            }
        }

        public double FindMedian()
        {
            if (maxHeap.Count > minHeap.Count)
            {
                return maxHeap.Peek(); // Odd count, maxHeap has the median
            }
            else
            {
                return (maxHeap.Peek() + minHeap.Peek()) / 2.0; // Even count, avg of two middle elements
            }
        }

        public int FindKthLargest(int[] nums, int k)
        {
            var maxHeap = new PriorityQueue<int, int>();
            for (int i = 0; i < nums.Length; i++) { 
                maxHeap.Enqueue(i, -nums[i]);
            }
            var result = 0;
            while (k > 0) {
                result = nums[maxHeap.Dequeue()];
                k--;
            }
            return result;
        }

      

    }

}
