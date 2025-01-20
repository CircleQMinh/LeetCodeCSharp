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
        public ListNode MergeKLists(ListNode[] lists)
        {
            var result = new ListNode();
            var current = result;
            var currentIndex = 0;
            var currentSmallest = 0;
            while (!IsAllNull(lists))
            {
                currentSmallest = int.MaxValue;
                for (int i = 0; i < lists.Length; i++)
                {
                    var item = lists[i];
                    if (item != null && item.val < currentSmallest)
                    {

                        currentIndex = i;
                        currentSmallest = item.val;
                    }
                }
                current.next = lists[currentIndex];
                current = current.next;
                lists[currentIndex] = lists[currentIndex].next;
            }
            return result.next;
        }
        public static bool IsAllNull(ListNode[] lists)
        {
            foreach (var item in lists)
            {
                if (item != null)
                {
                    return false;
                }
            }
            return true;
        }
    }
}