using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringToInteger_atoi_
{
    public class Solution
    {
        public int MyAtoi(string s)
        {
            var numbers = new List<char> { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            var result = "";
            var isNegative = false;
            var ignoreSign = false;
            s = s.Trim();
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i].Equals('-') && result.Length == 0 && !ignoreSign)
                {
                    isNegative = true;
                    ignoreSign = true;
                }
                else if (s[i].Equals('+') && result.Length == 0 && !ignoreSign)
                {
                    isNegative = false;
                    ignoreSign = true;
                }
                else if (numbers.Contains(s[i]))
                {
                    result += s[i];
                }
                else
                {
                    break;
                }
            }
            if (string.IsNullOrEmpty(result))
            {
                result = "0";
            }
            var parseResult = 0;
            var success = int.TryParse(result, out parseResult);

            if (success)
            {
                return isNegative ? -parseResult : parseResult;
            }
            else
            {
                return isNegative ? int.MinValue : int.MaxValue;
            }
        }
    }
}
