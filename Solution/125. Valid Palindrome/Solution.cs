using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhVu
{
    public class Solution
    {
        public bool IsPalindrome(string s)
        {
            var list = s.Where(q => char.IsLetterOrDigit(q)).Select(q => char.ToLower(q)).ToList();
            var l = 0;
            var r = list.Count - 1;
            while (l < r)
            {
                if (list[l] != list[r])
                {
                    return false;
                }
                l++;
                r--;
            }

            return true;
        }
    }
}