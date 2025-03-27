using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhVu
{
    public class Solution
    {
        public string GcdOfStrings(string str1, string str2)
        {
            var result = "";
            var shorter = str1.Length < str2.Length ? str1 : str2;

            while (shorter.Length > 0)
            {
                var t1 = str1.Replace(shorter, "");
                var t2 = str2.Replace(shorter, "");

                if (string.IsNullOrEmpty(t1) && string.IsNullOrEmpty(t2))
                {
                    return shorter;
                }
                shorter = shorter.Remove(shorter.Length - 1);
            }

            return result;
        }
    }
}