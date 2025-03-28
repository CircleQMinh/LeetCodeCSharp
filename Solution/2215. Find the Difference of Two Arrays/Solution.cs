using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhVu
{
    public class Solution
    {
        public IList<IList<int>> FindDifference(int[] nums1, int[] nums2)
        {
            var ans1 = new HashSet<int>();
            var ans2 = new HashSet<int>();
            var set = new HashSet<int>();
            foreach (var i in nums1)
            {
                if (set.Add(i))
                {
                    ans1.Add(i);
                }
            }
            foreach (var i in nums2)
            {
                if (set.Add(i))
                {
                    ans2.Add(i);
                }
                else
                {
                    ans1.Remove(i);
                }

            }
            return new List<IList<int>>() { ans1.ToList(), ans2.ToList() };
        }
    }
}