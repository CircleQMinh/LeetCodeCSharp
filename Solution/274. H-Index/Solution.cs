using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhVu
{
    public class Solution
    {
        public int HIndex(int[] citations)
        {
            if (citations.Length == 0)
            {
                return 0;
            }
            Array.Sort(citations);

            int i; int h;
            i = citations.Length - 1;
            h = citations.Length;
            var count = 0;

            while (h > 0 && i >= 0)
            {
                if (citations[i] >= h)
                {
                    count++;
                    i--;
                }
                else
                {
                    h--;
                }
                if (count == h)
                {
                    return h;
                }
            }
            return 0;
        }
    }
}