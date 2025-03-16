using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhVu
{
    public class Solution
    {
        public int FindMaximizedCapital(int k, int w, int[] profits, int[] capital)
        {
            var n = profits.Length;
            var result = new List<int>();
            var projects = new List<int>();
            for (int i = 0; i < n; i++)
            {
                projects.Add(i);
            }
            projects = projects.OrderBy(q => capital[q]).ToList();

            var index = 0; // Use to move and add project sort by capital
            var maxHeap = new PriorityQueue<int, int>();
            while (k > 0)
            {
                while (index < n && capital[projects[index]] <= w)
                {
                    int project = projects[index++];
                    maxHeap.Enqueue(project, -profits[project]); // Negate to simulate Max-Heap
                }

                if (maxHeap.Count > 0)
                {
                    var project = maxHeap.Dequeue();
                    w = w + profits[project];
                    k--;
                }
                else
                {
                    break;
                }
            }

            return w;
        }
    }
}