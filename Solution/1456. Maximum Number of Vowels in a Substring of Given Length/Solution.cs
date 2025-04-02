using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhVu
{
    public class Solution
    {
        public int MaxVowels(string s, int k)
        {
            var n = s.Length;
            var vowels = new HashSet<char>() { 'a', 'e', 'i', 'o', 'u' };
            var current = 0;
            var max = 0;
            var left = 1;
            var right = k;
            for (int i = 0; i < k; i++)
            {
                if (vowels.Contains(s[i]))
                {
                    current++;
                }
            }
            max = Math.Max(max, current);
            while (right <= n - 1)
            {
                if (vowels.Contains(s[left - 1]))
                {
                    current--;
                }
                if (vowels.Contains(s[right]))
                {
                    current++;
                }
                left++;
                right++;
                max = Math.Max(max, current);
            }

            return max;
        }
    }
}