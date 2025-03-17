using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhVu
{
    public class Solution
    {
        public string AddBinary(string a, string b)
        {
            var n = Math.Max(a.Length, b.Length);
            var overflow = false;
            var result = "";
            for (int i = 0; i < n; i++)
            {
                var indexA = a.Length - 1 - i;
                var indexB = b.Length - 1 - i;
                var valA = indexA >= 0 ? a[indexA] : '0';
                var valB = indexB >= 0 ? b[indexB] : '0';

                if (valA == '1' && valB == '1')
                {
                    result = overflow ? result + '1' : result + '0';
                    overflow = true;
                }
                else if (valA == '0' && valB == '0')
                {
                    result = overflow ? result + '1' : result + '0';
                    overflow = false;
                }
                else
                {
                    result = overflow ? result + '0' : result + '1';
                    overflow = overflow ? overflow : false;
                }

            }
            if (overflow)
            {
                result += "1";
            }


            char[] charArray = result.ToCharArray();
            Array.Reverse(charArray);
            result = new string(charArray);
            return result;
        }
    }
}