using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LongestPalindromicSubstring
{
    public static class Solution
   {
        public static string LongestPalindrome(string s)
        {
            for (int length = s.Length; length > 0; length--)
            {
                for (int i = 0; i <= s.Length - length; i++)
                {
                    var cur = s.Substring(i, length);
                    if (IsPalindrome(cur))
                    {
                        return cur;
                    }
                }
            }
            return "" + s[0];
        }
        public static bool IsPalindrome(string s)
        {
            int left = 0;
            int right = s.Length - 1;

            while (left < right)
            {
                if (s[left] != s[right])
                {
                    return false;
                }

                left++;
                right--;
            }
            return true;
        }
        // Try this next time
        //public static string ExpandString(string s,int start,int end) {
        //    if (start >= 0 && end < s.Length) { 
        //        var cur = s.Substring(start, end -start);
        //        if (IsPalindrome(cur))
        //        {
        //            var ex = ExpandString(s, start - 1, end + 1);
        //            return ex.Length > cur.Length ? ex : cur;
        //        }
        //        else
        //        {
        //            return "";
        //        }
        //    }
        //    return "";
        //}

    }
}
