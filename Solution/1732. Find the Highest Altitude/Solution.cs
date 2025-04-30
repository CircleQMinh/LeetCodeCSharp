using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhVu
{
    public class Solution
    {
        public int LargestAltitude(int[] gain)
        {
            var att = 0;
            var max = 0;
            foreach (var i in gain)
            {
                att += i;
                max = Math.Max(max, att);
            }
            return max;
        }
    }
}