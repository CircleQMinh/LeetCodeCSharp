using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhVu
{
    public class Solution
    {
        public string RemoveStars(string s)
        {
            var n = s.Length;
            var result = "";
            var count = 0;
            for (int i = n - 1; i >= 0; i--)
            {
                var c = s[i];
                if (c.Equals('*'))
                {
                    count++;
                }
                else
                {
                    if (count == 0)
                    {
                        result += c;
                    }
                    else
                    {
                        count--;
                    }
                }
            }

            char[] r = result.ToCharArray();
            Array.Reverse(r);
            return new string(r);
        }
    }
}