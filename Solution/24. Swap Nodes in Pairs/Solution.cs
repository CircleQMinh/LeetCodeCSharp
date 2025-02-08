using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhVu
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
    public class Solution
    {
        public ListNode SwapPairs(ListNode head)
        {
            var result = new ListNode(0,head);
            var previous = result;
            var current = previous.next;
            while(current != null){
                if(current.next == null){
                    break;
                }
                previous.next = current.next;
                current.next = previous.next.next;
                previous.next.next = current;

                previous = current;
                current = current.next;
            }
            return result.next;
        }
    }
}