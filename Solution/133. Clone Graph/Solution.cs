using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhVu
{
    /*
    // Definition for a Node.
    public class Node {
        public int val;
        public IList<Node> neighbors;

        public Node() {
            val = 0;
            neighbors = new List<Node>();
        }

        public Node(int _val) {
            val = _val;
            neighbors = new List<Node>();
        }

        public Node(int _val, List<Node> _neighbors) {
            val = _val;
            neighbors = _neighbors;
        }
    }
    */

    public class Solution
    {
        public Node CloneGraph(Node node)
        {
            if (node == null)
            {
                return null;
            }
            if (node.neighbors.Count == 0)
            {
                return new Node(node.val);
            }
            var set = new Dictionary<int, List<Node>>();
            CreateNodeToNeighborsMap(node, set);
            var created = new Dictionary<int, Node>();

            foreach (var item in set)
            {
                Node currentNode;
                if (!created.ContainsKey(item.Key))
                {
                    currentNode = new Node(item.Key);
                    created.Add(item.Key, currentNode);
                }
                else
                {
                    currentNode = created[item.Key];
                }

                foreach (var nb in item.Value)
                {
                    Node newNb;
                    if (!created.ContainsKey(nb.val))
                    {
                        newNb = new Node(nb.val);
                        created.Add(nb.val, newNb);
                    }
                    else
                    {
                        newNb = created[nb.val];
                    }
                    currentNode.neighbors.Add(newNb);
                }
            }
            return created[1];
        }

        public void CreateNodeToNeighborsMap(Node node, Dictionary<int, List<Node>> set)
        {
            var queue = new Queue<Node>();
            queue.Enqueue(node);
            while (queue.Count > 0)
            {
                var current = queue.Dequeue();
                if (!set.ContainsKey(current.val))
                {
                    set.Add(current.val, current.neighbors.ToList());
                }
                foreach (var item in current.neighbors)
                {
                    if (item != null && !set.ContainsKey(item.val))
                    {
                        queue.Enqueue(item);
                    }
                }

            }
        }
    }
}