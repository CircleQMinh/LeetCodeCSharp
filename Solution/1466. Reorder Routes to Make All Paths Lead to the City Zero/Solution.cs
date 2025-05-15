using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhVu
{
public class Solution {
    public int MinReorder(int n, int[][] connections) {
         var count = 0;
            var queue = new Queue<int>();
            var visited = new HashSet<int>();
            var adj = new Dictionary<int, List<(int city,bool rev)>>();

            foreach (var item in connections)
            {
                var from = item[0];
                var to = item[1];
                if (!adj.ContainsKey(from))
                {
                    adj.Add(from, new List<(int city, bool rev)>());
                }
                adj[from].Add((to,false));
                if (!adj.ContainsKey(to))
                {
                    adj.Add(to, new List<(int city, bool rev)>());

                }
                adj[to].Add((from, true));
            }


            queue.Enqueue(0);
            while(queue.Count > 0)
            {
                var current = queue.Dequeue();
                visited.Add(current);
                foreach (var item in adj[current])
                {
                    if (!item.rev && !visited.Contains(item.city))
                    {
                        count++;
                    }
                    if (!visited.Contains(item.city))
                    {
                        queue.Enqueue(item.city);
                    }
                }
            }
            return count;
    }
}
}