using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReverseInteger
{
    public class Solution
    {
        public int Reverse(int x)
        {
            var isNegative = x < 0;
            //long convert = x;
            //if (isNegative)
            //{
            //    convert = Math.Abs((long)x);
            //}
            //var stringConvert = ReverseString(convert.ToString());
            //long r = long.Parse(stringConvert);
            //if (r > int.MaxValue)
            //{
            //    return 0;
            //}
            //return isNegative ? (int)(r - (2 * r)) : (int)r;

            string r = "";
            if (x == int.MinValue)
            {
                return 0;
            }
            x = isNegative ? -x : x;
            while (x >= 10)
            {
                var t = x % 10;
                r = r += t;
                x = x / 10;
            }
            r += x;
            var result = 0;
            var success = int.TryParse(r, out result);
            return success ? isNegative ? -result : result : 0;
        }
        public static string ReverseString(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }
}
