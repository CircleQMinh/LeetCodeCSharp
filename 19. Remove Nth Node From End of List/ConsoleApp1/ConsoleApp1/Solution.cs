using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }

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
        //Try two pointer next time
        public ListNode RemoveNthFromEnd(ListNode head, int n)
        {
            var list = new List<int>();
            while (head.next != null)
            {
                list.Add(head.val);
                head = head.next;
            }
            list.Add(head.val);
            if (list.Count < 2)
            {
                return null;
            }
            list.RemoveAt(list.Count - n);

            var result = new ListNode(list[list.Count - 1]);

            for (int i = list.Count - 2; i >= 0; i--)
            {
                var cur = result;
                result = new ListNode(list[i], cur);
            }


            return result;
        }
    }
}
