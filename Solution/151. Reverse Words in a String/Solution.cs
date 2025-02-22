using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhVu
{
    // public class Solution
    // {
    //     public string ReverseWords(string s)
    //     {
    //         var result = "";
    //         var current = "";
    //         var n = s.Length;
    //         var count = 0;
    //         var i = n - 1;
    //         while (i >= 0)
    //         {
    //             if (!s[i].Equals(' '))
    //             {
    //                 count++;
    //                 current += s[i];
    //             }
    //             if ((s[i].Equals(' ') && count > 0) || i == 0)
    //             {
    //                 current = string.Join(string.Empty, current.Reverse());
    //                 current += " ";
    //                 result += current;
    //                 current = "";
    //                 count = 0;
    //             }

    //             i--;
    //         }
    //         return result.Trim();
    //     }
    // }
    public class Solution
    {
        public string ReverseWords(string s)
        {
            var result = "";
            s = s.Trim();
            var split = s.Split(' ');
            for (int i = split.Length - 1; i >= 0; i--)
            {
                if (!string.IsNullOrEmpty(split[i]))
                {
                    result += split[i];
                    result += " ";
                }
            }
            return result.Trim();
        }
    }
}