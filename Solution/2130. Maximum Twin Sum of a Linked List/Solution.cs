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
        public int PairSum(ListNode head)
        {
            var stack = new Stack<int>();
            var fast = head;
            var slow = head;
            var max = int.MinValue;
            while (fast.next != null && fast.next.next != null)
            {
                stack.Push(slow.val);
                slow = slow.next;
                fast = fast.next.next;
            }
            stack.Push(slow.val);
            slow = slow.next;
            while (slow != null)
            {
                var v = stack.Pop();
                var value = slow.val + v;
                max = Math.Max(max, value);
                slow = slow.next;
            }
            return max;
        }
    }
}