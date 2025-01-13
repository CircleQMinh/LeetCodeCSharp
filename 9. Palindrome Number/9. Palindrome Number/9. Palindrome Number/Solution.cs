using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9._Palindrome_Number
{
    public class Solution
    {
        public bool IsPalindrome(int x)
        {
            var original = x;
            if (x < 0)
            {
                return false;
            }
            var r = 0;
            while (x >= 10)
            {
                var t = x % 10;
                r = r * 10 + t;
                x = x / 10;
            }
            r = r * 10 + x;
            return r.Equals(original);
        }
    }
}
