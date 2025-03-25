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
        public ListNode DeleteMiddle(ListNode head)
        {
            if (head.next == null)
            {
                return null;
            }

            var slow = head;
            var fast = head;
            var prev = head;

            while (fast.next != null && fast.next.next != null)
            {
                prev = slow;
                slow = slow.next;
                fast = fast.next.next;
            }
            if (fast.next != null) //even
            {
                prev = slow;
                slow = slow.next;
            }
            prev.next = slow.next;
            return head;
        }
    }
}