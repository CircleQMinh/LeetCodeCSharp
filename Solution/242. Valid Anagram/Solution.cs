using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhVu
{
    public class Solution
    {
        public bool IsAnagram(string s, string t)
        {
            if (s.Length != t.Length)
            {
                return false;
            }
            var map = new Dictionary<char, int>();
            foreach (char c in s)
            {
                if (!map.ContainsKey(c))
                {
                    map.Add(c, 0);
                }
                map[c]++;
            }

            foreach (char c in t)
            {
                if (!map.ContainsKey(c) || map[c] == 0)
                {
                    return false;
                }
                else
                {
                    map[c]--;
                }
            }
            return true;
        }
    }