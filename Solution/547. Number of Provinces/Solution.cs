using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhVu
{
    public class Solution
    {
        public int FindCircleNum(int[][] isConnected)
        {
            var n = isConnected.Length;
            var count = 0;

            for (int i = 0; i < n; i++)
            {

                for (int j = 0; j < n; j++)
                {
                    if (isConnected[i][j] == 1)
                    {
                        count++;
                        isConnected[i][j] = 0;
                        isConnected[j][i] = 0;
                        FindAndMarkBelongToProvine(isConnected, j);
                    }
                }
            }
            return count;
        }

        public void FindAndMarkBelongToProvine(int[][] isConnected, int currentCity)
        {

            var queue = new Queue<int>();
            queue.Enqueue(currentCity);
            while (queue.Count > 0)
            {
                var current = queue.Dequeue();
                for (int k = 0; k < isConnected.Length; k++)
                {
                    if (isConnected[current][k] == 1)
                    {
                        isConnected[current][k] = 0;
                        queue.Enqueue(k);
                    }
                }
            }

        }
    }
}