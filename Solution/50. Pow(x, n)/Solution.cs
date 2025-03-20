using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhVu
{
    public class Solution
    {
        public double MyPow(double x, int n)
        {
            if (n == 0)
            {
                return 1;
            }
            if (x == 0)
            {
                return 0;
            }
            long exp = n;
            if (exp < 0)
            {
                x = 1 / x;
                exp = -exp;
            }

            double result = 1;
            while (exp > 0)
            {
                if ((exp & 1) == 1) // If exponent is odd, multiply by current x
                {
                    result *= x;
                }
                x *= x;
                exp >>= 1; // Divide exponent by 2
            }

            return result;

        }
    }
}