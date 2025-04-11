using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhVu
{
    public class Solution
    {
        public long TotalCost(int[] costs, int k, int candidates)
        {
            var n = costs.Length;
            var left = 0;
            var right = n - 1;
            long totalCost = 0;
            var first = new PriorityQueue<int, int>();
            var last = new PriorityQueue<int, int>();

            for (int i = 0; i < candidates && i < n; i++)
            {

                first.Enqueue(costs[left], costs[left]);
                left++;
            }
            for (int i = 0; i < candidates && left <= right; i++)
            {
                last.Enqueue(costs[right], costs[right]);
                right--;
            }

            for (int i = 0; i < k; i++)
            {
                if (first.Count > 0 && (last.Count == 0 || first.Peek() <= last.Peek()))
                {
                    totalCost += first.Dequeue();
                    if (left <= right)
                    {
                        first.Enqueue(costs[left], costs[left]);
                        left++;
                    }
                }
                else
                {
                    totalCost += last.Dequeue();
                    if (left <= right)
                    {
                        last.Enqueue(costs[right], costs[right]);
                        right--;
                    }
                }
            }

            return totalCost;
        }
    }
}