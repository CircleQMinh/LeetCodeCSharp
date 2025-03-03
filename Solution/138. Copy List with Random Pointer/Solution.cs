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
        public Node next;
        public Node random;

        public Node(int _val) {
            val = _val;
            next = null;
            random = null;
        }
    }
    */

    public class Solution
    {
        public Node CopyRandomList(Node head)
        {
            var set = new Dictionary<Node, Node>();

            var current = head;
            while (current != null)
            {
                var newNode = new Node(current.val);
                set.Add(current, newNode);
                current = current.next;
            }

            var newNodeHead = new Node(0);
            var result = newNodeHead;

            current = head;
            while (current != null)
            {
                var copy = set[current];
                newNodeHead.next = copy;
                newNodeHead.next.next = current.next == null ? null : set[current.next];
                newNodeHead.next.random = current.random == null ? null : set[current.random];
                if (newNodeHead.next != null)
                {
                    newNodeHead = newNodeHead.next;
                }
                current = current.next;
            }

            return result.next;
        }
    }
    public class Node
    {
        public int val;
        public Node next;
        public Node random;

        public Node(int _val)
        {
            val = _val;
            next = null;
            random = null;
        }
    }
}