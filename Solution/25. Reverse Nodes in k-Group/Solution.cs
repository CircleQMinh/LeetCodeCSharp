using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhVu
{
    /**
     * Definition for singly-linked list.
     * public class ListNode {
     *     public int val;
     *     public ListNode next;
     *     public ListNode(int val=0, ListNode next=null) {
     *         this.val = val;
     *         this.next = next;
     *     }
     * }
     */
    public class Solution
    {
        public ListNode ReverseKGroup(ListNode head, int k)
        {
            var current = head;
            var part = new ListNode();
            var currentPart = part;
            var count = 0;
            var queue = new Queue<ListNode>();

            while (current != null)
            {
                currentPart.next = new ListNode(current.val);
                currentPart = currentPart.next;
                count++;
                if (k == count)
                {
                    queue.Enqueue(Reverse(part.next));
                    part = new ListNode();
                    currentPart = part;
                    count = 0;
                }
                current = current.next;

            }
            part = part.next;
            if (part != null)
            {
                queue.Enqueue(part);
            }

            part = new ListNode();
            currentPart = part;
            while (queue.Count > 0)
            {
                var node = queue.Dequeue();
                currentPart.next = node;
                while (currentPart.next != null)
                {
                    currentPart = currentPart.next;
                }
            }

            return part.next;
        }

        public ListNode Reverse(ListNode head)
        {
            if (head == null)
            {
                return head;
            }
            var result = new ListNode();
            var current = result;
            var stack = new Stack<ListNode>();
            while (head != null)
            {
                stack.Push(head);
                head = head.next;
            }
            while (stack.Count > 0)
            {
                var node = stack.Pop();
                current.next = new ListNode(node.val);
                current = current.next;
            }

            return result.next;
        }
    }
}