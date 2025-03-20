using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhVu
{
    public class Solution
    {
        //public int ClimbStairs(int n)
        //{
        //    if (n == 1)
        //    {
        //        return 1;
        //    }
        //    if (n == 2)
        //    {
        //        return 2;
        //    }
        //    return ClimbStairs(n - 1) + ClimbStairs(n - 2);
        //}
        public int ClimbStairs(int n)
        {
            if (n == 1)
            {
                return 1;
            }
            if (n == 2)
            {
                return 2;
            }
            var prev1 = 1;
            var prev2 = 2;
            for (var i = 3; i <= n; i++)
            {
                var val = prev1 + prev2;
                prev1 = prev2;
                prev2 = val;
            }
            return prev2;
        }
    }
}