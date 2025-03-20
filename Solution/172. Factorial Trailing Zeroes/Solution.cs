using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhVu
{
    public class Solution
    {
        // public int TrailingZeroes(int n)
        // {
        //     var count = 0;
        //     FactorialTrailingZeroes(n, ref count);
        //     return count;
        // }
        // public int FactorialTrailingZeroes(int n, ref int count)
        // {
        //     var val = n;
        //     while (val >= 5 && val % 5 == 0)
        //     {
        //         val /= 5;
        //         count++;
        //     }
        //     return n == 0 ? 1 : n == 1 ? 1 : n * FactorialTrailingZeroes(n - 1, ref count);
        // }

        public int TrailingZeroes(int n)
        {
            int count = 0;
            while (n >= 5)
            {
                n /= 5;
                count += n;
            }
            return count;
        }
    }
}