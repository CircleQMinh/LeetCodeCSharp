using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Solution
{
    public class Solution
    {
        public bool CanVisitAllRooms(IList<IList<int>> rooms)
        {
            var n = rooms.Count;
            var queue = new Queue<int>();
            var visited = new HashSet<int>();
            visited.Add(0);
            var keys = rooms[0];
            foreach (var i in keys)
            {
                queue.Enqueue(i);
            }
            while (queue.Count > 0)
            {
                var key = queue.Dequeue();
                if (!visited.Contains(key))
                {
                    visited.Add(key);
                    foreach (var i in rooms[key])
                    {
                        queue.Enqueue(i);
                    }
                }
            }

            return visited.Count == n;
        }
    }
}