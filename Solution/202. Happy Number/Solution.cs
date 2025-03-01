using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhVu
{
    public class Solution
    {
        public bool IsHappy(int n)
        {
            var map = new HashSet<int>();
            var sum = 0;
            while (true)
            {
                while (n > 9)
                {
                    var digit = n % 10;
                    n = n / 10;
                    sum += digit * digit;
                }
                sum += n * n;
                if (sum == 1)
                {
                    return true;
                }

                var success = map.Add(sum);
                if (!success)
                {
                    return false;
                }
                n = sum;
                sum = 0;
            }
        }
    }
}