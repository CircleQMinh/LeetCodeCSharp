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

    public class Solution
    {
        public ListNode MergeTwoLists(ListNode list1, ListNode list2)
        {
            //var list = new List<int>();
            //while (list1 !=null )
            //{
            //    list.Add(list1.val);
            //    list1 = list1.next;
            //}
            //while (list2 != null )
            //{
            //    list.Add(list2.val);
            //    list2 = list2.next;
            //}
            //if (list.Count == 0)
            //{
            //    return null;
            //}


            //list = list.OrderByDescending(q => q).ToList();
            //var result = new ListNode(list[0]);
            //for (int i = 1; i < list.Count; i++)
            //{
            //    var t = new ListNode(list[i], result);
            //    result = t;
            //}


            //return result;
            var r = new ListNode();
            var result = r;

            while (list1 != null && list2 != null)
            {
                if (list1.val < list2.val)
                {
                    result.next = list1;
                    list1 = list1.next;
                }
                else
                {
                    result.next = list2;
                    list2 = list2.next;
                }
                result = result.next;
            }

            if (list1 != null)
            {
                result.next = list1;
                list1 = list1.next;
            }
            if (list2 != null)
            {
                result.next = list2;
                list2 = list2.next;
            }

            return r.next;
        }
    }
}
