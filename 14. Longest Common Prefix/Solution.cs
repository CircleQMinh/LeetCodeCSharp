using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14._Longest_Common_Prefix
{
    public class Solution
    {
        public string LongestCommonPrefix(string[] strs)
        {
            var cur = "";
            var leng = 999;
            var shortest = "";
            foreach (var item in strs)
            {
                if (item.Length < leng)
                {
                    leng = item.Length;
                    shortest = item;
                }
            }

            for (int i = 0; i < shortest.Length; i++)
            {
                foreach (var item in strs)
                {
                    if (!item[i].Equals(shortest[i]))
                    {
                        return cur;
                    }
                }
                cur += shortest[i];
            }
            return cur;
        }
    }
}
