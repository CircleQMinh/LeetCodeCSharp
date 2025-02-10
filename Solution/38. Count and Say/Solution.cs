using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhVu
{
    public class Solution {
        public string CountAndSay(int n) {
            if (n == 1)
            {
                return "1";
            }
            else
            {
                var s = CountAndSay(n - 1);
                return ConvertToPair(s);
            }
        }
        public string ConvertToPair(string s)
        {
            var result = "";
            var resultList = new List<(int count, char c)>();
            var currentChar = 'x';
            var currentCount = 0;

            for (int i = 0; i< s.Length; i++)
            {
                if(currentChar != s[i])
                {
                    if (!(currentChar == 'x'))
                    {
                        resultList.Add((currentCount, s[i-1]));
                    }
                    currentChar = s[i];
                    currentCount = 0;
                }

                currentChar = s[i];
                currentCount++;
            }
            resultList.Add((currentCount, s[s.Length - 1]));
            
            for (int i = 0;i< resultList.Count; i++)
            {
                result += $"{resultList[i].count}{resultList[i].c}";
            }

            return result;
        }
    }
}