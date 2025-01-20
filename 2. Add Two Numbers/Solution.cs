using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddTwoNumbers
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

    public static class Solution
    {
        public static ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            var result = new ListNode();
            var list = new List<int>();
            bool remember = false;
            while (true)
            {
                if (l1 == null && l2 == null)
                {
                    if (remember)
                    {
                        list.Add(1);
                    }
                    break;
                }
                if (l1 == null)
                {
                    l1 = new ListNode(0,null);
                }
                if (l2 == null) {
                    l2 = new ListNode(0, null);
                }

                var num1 = l1 == null ? 0 : l1.val;
                var num2 = l2 == null ? 0 :l2.val;


                var num3 = remember ? num1 + num2 + 1 : num1 + num2;
                remember = false ;

                if (num3 > 9)
                {
                    remember = true;
                    num3 = num3 % 10;
                }

                list.Add(num3);

                ListNode? listNode;
                listNode = l1.next ?? null;
                l1 = listNode;
                listNode = l2.next ?? null;
                l2 = listNode;
            }
            list.Reverse();
            for (int i = 0; i < list.Count; i++)
            {
                var next = new ListNode(list[i], i == 0 ? null : result);

                result = next;
            }
            return result;
        }
        // try recursion next time
    }
}
