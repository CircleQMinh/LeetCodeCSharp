using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhVu
{
  public class Solution
{
    public bool IsIsomorphic(string s, string t)
    {
        if (s.Length != t.Length)
        {
            return false;
        }

        var charS = s.Distinct().ToList();
        var charT = t.Distinct().ToList();

        if (charS.Count != charT.Count)
        {
            return false;
        }

        var map = new Dictionary<char, char>();
        for (int i = 0; i < charS.Count; i++)
        {
            map.Add(charS[i], charT[i]);
        }

        for (int i = 0; i < s.Length; i++)
        {
            if (map[s[i]] != t[i])
            {
                return false;
            }
        }
        return true;
    }
}
}