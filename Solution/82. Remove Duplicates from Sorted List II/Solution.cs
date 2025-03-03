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
        public ListNode DeleteDuplicates(ListNode head)
        {
            var result = new ListNode();
            var set = new HashSet<int>();
            var valueToDelete = new HashSet<int>();

            var current = head;
            var currentResult = result;

            while (current != null)
            {
                var value = current.val;
                if (!set.Add(value))
                {
                    valueToDelete.Add(value);
                }
                current = current.next;

            }

            current = head;
            while (current != null)
            {
                var value = current.val;
                if (!valueToDelete.Contains(value))
                {
                    currentResult.next = new ListNode(value);
                    currentResult = currentResult.next;
                }
                current = current.next;
            }
            return result.next;
        }
    }
}