using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhVu
{
    public class Solution
    {
        public int MySqrt(int x)
        {
            long left = 0;
            long right = Math.Max(x / 2, 1);
            while (left <= right)
            {
                long middle = left + (right - left) / 2;
                var val = middle * middle;
                if (middle * middle == x)
                {
                    return (int)middle;
                }

                if (middle * middle < x)
                {
                    left = middle + 1;
                }
                else
                {
                    right = middle - 1;
                }
            }
            while (left >= 1)
            {
                if (left * left < x)
                {
                    return (int)left;
                }
                left--;
            }
            return (int)left;
        }
    }
}