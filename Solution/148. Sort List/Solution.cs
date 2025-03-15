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
        public ListNode SortList(ListNode head)
        {
            if (head == null || head.next == null)
                return head;

            ListNode current = null;
            var slow = head;
            var fast = head;

            while (fast != null && fast.next != null)
            {
                current = slow;
                slow = slow.next;
                fast = fast.next.next;
            }

            current.next = null;
            var l = SortList(head);
            var r = SortList(slow);
            var result = Merge(l, r);
            return result;

        }

        public ListNode Merge(ListNode l, ListNode r)
        {
            var result = new ListNode();
            var current = result;

            while (l != null && r != null)
            {
                if (l.val < r.val)
                {
                    current.next = new ListNode(l.val);
                    current = current.next;
                    l = l.next;
                }
                else
                {
                    current.next = new ListNode(r.val);
                    current = current.next;
                    r = r.next;
                }
            }

            while (l != null)
            {
                current.next = new ListNode(l.val);
                current = current.next;
                l = l.next;
            }
            while (r != null)
            {
                current.next = new ListNode(r.val);
                current = current.next;
                r = r.next;
            }
            return result.next;
        }
    }
}