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
        public ListNode RotateRight(ListNode head, int k)
        {
            if (head == null)
            {
                return null;
            }
            var end = new ListNode();
            var previous = new ListNode();
            var current = head;
            var n = 0;

            while (current != null)
            {
                n++;
                end = current;
                current = current.next;
            }
            k = k % n;
            if (k == 0)
            {
                return head;
            }
            end.next = head; //create a Circular Linked List 



            current = head;
            for (var i = 0; i < Math.Abs(k - n); i++)
            {
                previous = current;
                current = current.next;
            }
            previous.next = null; // not a Circular Linked List anymore

            return current;
        }
    }
}