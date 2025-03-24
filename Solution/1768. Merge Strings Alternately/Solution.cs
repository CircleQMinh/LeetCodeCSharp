using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhVu
{
    public class Solution
    {
        public string MergeAlternately(string word1, string word2)
        {
            var result = "";
            var i = 0;
            var j = 0;
            while (i < word1.Length && j < word2.Length)
            {
                if (j < i)
                {
                    result += word2[j];
                    j++;
                }
                else
                {
                    result += word1[i];
                    i++;
                }

            }
            while (i < word1.Length)
            {
                result += word1[i];
                i++;
            }
            while (j < word2.Length)
            {
                result += word2[j];
                j++;
            }
            return result;
        }
    }
}