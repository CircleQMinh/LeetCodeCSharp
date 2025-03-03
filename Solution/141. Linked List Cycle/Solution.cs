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
     *     public ListNode(int x) {
     *         val = x;
     *         next = null;
     *     }
     * }
     */
    public class Solution
    {
        public bool HasCycle(ListNode head)
        {
            var set = new HashSet<ListNode>();

            while (head != null)
            {
                var success = set.Add(head);
                if (!success)
                {
                    return true;
                }
                head = head.next;
            }
            return false;
        }
    }
}