using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playground
{
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }
    //public class Node
    //{
    //    public int val;
    //    public Node next;
    //    public Node random;

    //    public Node(int _val)
    //    {
    //        val = _val;
    //        next = null;
    //        random = null;
    //    }
    //}

    //public class Node
    //{
    //    public int val;
    //    public Node left;
    //    public Node right;
    //    public Node next;

    //    public Node(int _val)
    //    {
    //        val = _val;
    //        next = null;
    //        left = null;
    //        right = null;
    //        next = null;
    //    }
    //}
    public class Node
    {
        public int val;
        public IList<Node> neighbors;

        public Node()
        {
            val = 0;
            neighbors = new List<Node>();
        }

        public Node(int _val)
        {
            val = _val;
            neighbors = new List<Node>();
        }

        public Node(int _val, List<Node> _neighbors)
        {
            val = _val;
            neighbors = _neighbors;
        }
    }

    public class DoublyLinkedList
    {
        public int val;
        public int key;
        public DoublyLinkedList prev;
        public DoublyLinkedList next;

        public DoublyLinkedList(int key, int val)
        {
            this.val = val;
            this.key = key;
            this.prev = null;
            this.next = null;
        }
    }
}
