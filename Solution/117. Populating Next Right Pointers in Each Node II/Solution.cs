using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhVu
{
    public class Node
    {
        public int val;
        public Node left;
        public Node right;
        public Node next;

        public Node(int _val)
        {
            val = _val;
            next = null;
            left = null;
            right = null;
            next = null;
        }
    }

    public class Solution
    {
        public Node Connect(Node root)
        {
            if (root == null)
            {
                return root;
            }
            var queue = new Queue<Node>();
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                var count = queue.Count;
                Node prev = null;
                for (int i = 0; i < count; i++)
                {
                    var node = queue.Dequeue();
                    if (prev != null)
                    {
                        prev.next = node;
                    }
                    prev = node;

                    if (node.left != null)
                    {
                        queue.Enqueue(node.left);
                    }
                    if (node.right != null)
                    {
                        queue.Enqueue(node.right);
                    }

                }
            }
            return root;
        }
    }
}