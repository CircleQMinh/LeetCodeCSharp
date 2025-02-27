using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhVu
{
    public class Solution
    {
        public bool CanConstruct(string ransomNote, string magazine)
        {

            var set = new Dictionary<char, int>();

            foreach (var item in magazine)
            {
                if (!set.ContainsKey(item))
                {
                    set.Add(item, 0);
                }
                set[item] = set[item] + 1;

            }
            foreach (var item in ransomNote)
            {
                if (!set.ContainsKey(item) || set[item] == 0)
                {
                    return false;
                }
                set[item] = set[item] - 1;

            }

            return true;
        }
    }
}