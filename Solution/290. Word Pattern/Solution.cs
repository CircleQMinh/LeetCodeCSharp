using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhVu
public class Solution
{
    public bool WordPattern(string pattern, string s) // use TryGetValue next time
    {
        var split = s.Split(" ");
        if (split.Length != pattern.Length)
        {
            return false;
        }

        var chars = pattern.Distinct().ToList();
        var words = split.Distinct().ToList();
        if (chars.Count != words.Count)
        {
            return false;
        }

        var map = new Dictionary<char, string>();
        for (int i = 0; i < chars.Count; i++)
        {
            map.Add(chars[i], words[i]);
        }

        for (int i = 0; i < pattern.Length; i++)
        {
            var c = pattern[i];
            if (map[c] != split[i])
            {
                return false;
            }
        }

        return true;
    }
}
