using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhVu
{
    public class Solution
    {
        public string ReverseVowels(string s)
        {
            var l = 0;
            var r = s.Length - 1;
            var arr = s.ToCharArray();
            var vowels = new HashSet<char>()
            {
                'a','i','e','o','u',
                'A','I','E','O','U',
            };
            while (l < r)
            {
                if (vowels.Contains(arr[l]) && vowels.Contains(arr[r]))
                {
                    var t = arr[l];
                    arr[l] = arr[r];
                    arr[r] = t;
                    l++;
                    r--;
                }
                if (!vowels.Contains(arr[l]))
                {
                    l++;
                }
                if (!vowels.Contains(arr[r]))
                {
                    r--;
                }

            }

            return new string(arr);
        }

        
    }
}