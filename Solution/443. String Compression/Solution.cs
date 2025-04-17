using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhVu
{
    public class Solution
    {
        public int Compress(char[] chars)
        {
            var s = "";
            var i = 0;
            var n = chars.Length;
            while (i < n)
            {
                var current = chars[i];
                var currentCount = 1;
                while (i + 1 < n && chars[i + 1] == current)
                {
                    currentCount++;
                    i++;

                }
                s += current;
                s += currentCount > 1 ? currentCount : "";
                i++;
            }
            for (int j = 0; j < s.Length; j++)
            {
                chars[j] = s[j];
            }

            return s.Length;
        }
    }
}