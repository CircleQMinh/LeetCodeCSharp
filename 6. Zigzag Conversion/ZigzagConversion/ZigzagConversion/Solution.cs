using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZigzagConversion
{
    public static class Solution
    {
        public static string Convert(string s, int numRows)
        {
            var result = "";
            var leng = s.Length;
            var row = 0;
            var cycle = 2 * (numRows - 1);
            if (numRows == 1 || s.Length <= numRows) {
                return s;
            }
            while (row < numRows) {

                var index = row;
                var period = 2 * row; // increase between 2 number in same row
                while (index < leng) { 
                    result += s[index];
                    if (period != cycle)
                    {
                        period = cycle - period; // alternate between two period, 1st and last only have 1 period
                    }
                    index += period;
                }
                row++;
            }

            return result;
        }

    }
}
