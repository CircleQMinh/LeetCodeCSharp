using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhVu
{
    public class Solution
    {
        public string MinWindow(string s, string t)
        {
            if (s.Length < t.Length)
            {
                return "";
            }

            var charInT = new Dictionary<char, int>();
            foreach (char c in t)
            {
                if (!charInT.ContainsKey(c))
                {
                    charInT.Add(c, 0);
                }
                charInT[c]++;
            }

            var left = 0;
            var right = 0;
            var minLen = int.MaxValue;
            var minStart = 0;

            var charInCurrent = new Dictionary<char, int>();
            var numberOfTcharInCurrent = 0;
            var numberOfTchar = charInT.Count;
            while (right < s.Length)
            {
                var cRight = s[right];
                if (!charInCurrent.ContainsKey(cRight))
                {
                    charInCurrent.Add(cRight, 0);
                }
                charInCurrent[cRight]++;
                if (charInT.ContainsKey(cRight) && charInCurrent[cRight] == charInT[cRight])
                {
                    numberOfTcharInCurrent++;
                }

                while (numberOfTcharInCurrent == numberOfTchar) // while the string still have all char from T 
                {
                    if (minLen > right - left + 1) // update min len
                    {
                        minLen = right - left + 1;
                        minStart = left;
                    }
                    // try to remove left most char while the string still have all char from T 
                    var cLeft = s[left];
                    charInCurrent[cLeft]--;
                    if (charInT.ContainsKey(cLeft) && charInT[cLeft] > charInCurrent[cLeft])
                    {
                        numberOfTcharInCurrent--;
                    }
                    left++;

                }
                right++;
            }

            return minLen == int.MaxValue ? "" : s.Substring(minStart, minLen); ;
            //return FindMinWindow(charInT, s, t.Length); // too slow
        }

        //public string FindMinWindow(Dictionary<char,int> charInT, string s,int currentLen)
        //{
        //    if (s.Length-currentLen < 0)
        //    {
        //        return string.Empty;
        //    }
        //    for (int i = 0; i <= s.Length-currentLen; i++)
        //    {
        //        var current = s.Substring(i,currentLen);
        //        if (StringContainAllChar(new Dictionary<char, int>(charInT), current))
        //        {
        //            return current;
        //        }
        //    }
        //    return FindMinWindow(charInT, s, currentLen+1);
        //}

        //public bool StringContainAllChar(Dictionary<char, int> charInT, string current)
        //{
        //    foreach (var item in current)
        //    {
        //        if (charInT.ContainsKey(item))
        //        {
        //            charInT[item]--;
        //        }
        //    }
        //    return charInT.All(q => q.Value == 0);
        //}
    }
}