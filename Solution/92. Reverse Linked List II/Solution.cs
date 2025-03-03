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
        public ListNode ReverseBetween(ListNode head, int left, int right)
        {
            if (right - left <= 0)
            {
                return head;
            }
            var current = head;
            var start = head;
            var end = new ListNode();
            var count = 0;

            var index = 0; // convert to 0-index
            left--;
            right--;


            var previous = end;

            while (current != null)
            {
                if (index >= left && index <= right)
                {

                    var newNode = new ListNode(current.val);
                    newNode.next = previous;
                    previous = newNode;
                }
                if (index == right + 1)
                {
                    end = current;
                }
                if (index == left - 1)
                {
                    start = current;
                }

                current = current.next;
                index++;
            }
            count = index;

            current = previous;
            index = 0;
            while (current.next != null)
            {
                if (index == right - left)
                {
                    break;
                }
                index++;
                current = current.next;
            }

            current.next = count - 1 == right ? null : end;
            start.next = previous;

            return left == 0 ? head.next : head;
        }
    }
}