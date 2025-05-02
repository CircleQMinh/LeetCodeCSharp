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
        public ListNode ReverseList(ListNode head)
        {
            if (head == null)
            {
                return head;
            }
            var stack = new Stack<ListNode>();
            var current = head;
            while (current != null)
            {
                stack.Push(current);
                current = current.next;
            }

            var result = stack.Pop();
            current = result;

            while (stack.Count > 0)
            {
                var next = stack.Pop();
                current.next = next;
                current = current.next;
            }
            current.next = null;
            return result;
        }
    }
}