using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhVu
{
    public class Solution
    {
        public bool IsSubsequence(string s, string t)
        {
            var currentIndex = 0;
            for (var i = 0; i < t.Length && currentIndex < s.Length; i++)
            {
                if (s[currentIndex].Equals(t[i]))
                {
                    currentIndex++;
                }
            }
            return currentIndex == s.Length;
        }
    }    {
        
    }
}