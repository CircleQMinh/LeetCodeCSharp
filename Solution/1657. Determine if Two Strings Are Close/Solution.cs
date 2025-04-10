using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhVu
{
    public class Solution
    {
        public bool CloseStrings(string word1, string word2)
        {
            if (word1.Length != word2.Length)
            {
                return false;
            }

            var dic1 = new Dictionary<char, int>();
            foreach (var item in word1)
            {
                if (!dic1.ContainsKey(item))
                {
                    dic1.Add(item, 0);
                }
                dic1[item]++;
            }

            var dic2 = new Dictionary<char, int>();
            foreach (var item in word2)
            {
                if (!dic2.ContainsKey(item))
                {
                    dic2.Add(item, 0);
                }
                dic2[item]++;
            }
            if (dic1.Count != dic2.Count)
            {
                return false;
            }

            var sameKey = dic1.Keys.All(q => dic2.ContainsKey(q));
            if (!sameKey)
            {
                return false;
            }

            var s1 = dic1.Select(q => q.Value).OrderBy(q => q).ToArray();
            var s2 = dic2.Select(q => q.Value).OrderBy(q => q).ToArray();

            for (int i = 0; i < s1.Length; i++)
            {
                if (s1[i] != s2[i])
                {
                    return false;
                }
            }
            return true;
        }
    }
}