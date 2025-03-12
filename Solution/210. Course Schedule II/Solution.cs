using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhVu
{
    public class Solution
    {
        public int[] FindOrder(int numCourses, int[][] prerequisites)
        {
            var dictionary = new Dictionary<int, List<int>>();
            for (int i = 0; i < numCourses; i++)
            {
                dictionary.Add(i, new List<int>());
            }
            foreach (var item in prerequisites)
            {
                var need = item[0];
                var pre = item[1];
                dictionary[need].Add(pre);
            }
            var result = new List<int>();
            if (!IsCyclic(dictionary))
            {
                while (dictionary.Any(q => q.Value.Count == 0 && !result.Contains(q.Key)))
                {
                    var course = dictionary.FirstOrDefault(q => q.Value.Count == 0 && !result.Contains(q.Key));
                    foreach (var item in dictionary)
                    {
                        item.Value.Remove(course.Key);
                    }
                    result.Add(course.Key);
                }
                if (result.Count == dictionary.Count)
                {
                    return result.ToArray();
                }
                return new int[dictionary.Count];

            }
            return result.ToArray();
        }
        // Function to detect cycle in a directed graph
        public static bool IsCyclic(Dictionary<int, List<int>> adj)
        {
            int V = adj.Count;
            // Stores in-degree of each vertex
            int[] inDegree = new int[V];
            // Queue to store vertices with 0 in-degree
            Queue<int> q = new Queue<int>();
            int visited = 0; // Count of visited vertices

            // Calculate in-degree of each vertex
            for (int u = 0; u < V; u++)
            {
                foreach (int v in adj[u])
                {
                    inDegree[v]++;
                }
            }

            // Enqueue vertices with 0 in-degree
            for (int u = 0; u < V; u++)
            {
                if (inDegree[u] == 0)
                {
                    q.Enqueue(u);
                }
            }

            // BFS traversal
            while (q.Count > 0)
            {
                int u = q.Dequeue();
                visited++;
                // Reduce in-degree of adjacent vertices
                foreach (int v in adj[u])
                {
                    inDegree[v]--;
                    // If in-degree becomes 0, enqueue it
                    if (inDegree[v] == 0)
                    {
                        q.Enqueue(v);
                    }
                }
            }

            // If not all vertices are visited, cycle
            return visited != V;
        }
    }
}