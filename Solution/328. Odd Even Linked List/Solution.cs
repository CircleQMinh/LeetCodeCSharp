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
        public ListNode OddEvenList(ListNode head)
        {
            if (head == null || head.next == null)
            {
                return head;
            }
            var odd = head;
            var sOdd = odd;
            var even = head.next;
            var sEven = even;

            while (odd != null && even != null && even.next != null)
            {
                odd.next = odd.next.next;
                odd = odd.next;
                even.next = even.next.next;
                even = even.next;
            }
            if (odd != null)
            {
                odd.next = null;
            }

            while (sOdd.next != null)
            {
                sOdd = sOdd.next;
            }
            sOdd.next = sEven;
            return head;
        }
    }
}