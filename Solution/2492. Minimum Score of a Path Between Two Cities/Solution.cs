using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhVu
{
    public class IntNode
    {
        public int val;
        public IList<IntNode> neighbors;

        public IntNode()
        {
            val = 0;
            neighbors = new List<IntNode>();
        }

        public IntNode(int _val)
        {
            val = _val;
            neighbors = new List<IntNode>();
        }

        public IntNode(int _val, List<IntNode> _neighbors)
        {
            val = _val;
            neighbors = _neighbors;
        }
    }
    public class Solution
    {
        public int MinScore(int n, int[][] roads)
        {
            var set = new Dictionary<int, IntNode>();
            var costs = new Dictionary<(int, int), int>();
            foreach (var item in roads)
            {
                var cost = item[2];
                var first = item[0];
                var second = item[1];

                costs.Add((first, second), cost);
                costs.Add((second, first), cost);
                var firstN = set.ContainsKey(first) ? set[first] : new IntNode(first);
                var secondN = set.ContainsKey(second) ? set[second] : new IntNode(second);

                firstN.neighbors.Add(secondN);
                secondN.neighbors.Add(firstN);

                if (!set.ContainsKey(first))
                {
                    set.Add(first, firstN);
                }
                if (!set.ContainsKey(second))
                {
                    set.Add(second, secondN);
                }
            }

            var visited = new HashSet<IntNode>();
            var minCost = int.MaxValue;
            var queue = new Queue<IntNode>();
            queue.Enqueue(set[1]);
            while (queue.Count > 0)
            {
                var node = queue.Dequeue();
                visited.Add(node);
                foreach (var item in node.neighbors)
                {
                    var c = costs[(node.val, item.val)];
                    if (c < minCost)
                    {
                        minCost = c;
                    }
                    if (!visited.Contains(item))
                    {
                        queue.Enqueue(item);
                    }
                }
            }

            return minCost;
        }
    }
}