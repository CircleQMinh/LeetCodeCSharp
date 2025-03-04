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
        public ListNode Partition(ListNode head, int x)
        {
            if (head == null)
            {
                return null;
            }
            ListNode current = head;
            ListNode prev = null;
            var list = new List<int>();

            while (current != null)
            {
                if (current.val < x)
                {
                    if (prev != null)
                    {
                        prev.next = current.next;
                    }
                    else
                    {
                        head = current.next;
                    }
                    list.Add(current.val);
                }
                else
                {
                    prev = current;
                }
                current = current.next;
            }
            ListNode result = new ListNode();
            current = result;
            foreach (var item in list)
            {
                current.next = new ListNode(item);
                current = current.next;
            }
            current.next = head;
            return result.next;
        }
    }
}