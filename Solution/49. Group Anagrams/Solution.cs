using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhVu
{
    public class Solution
    {
        public IList<IList<string>> GroupAnagrams(string[] strs)
        {
            var result = new List<IList<string>>();
            var dict = new Dictionary<string, List<string>>();

            foreach (var str in strs)
            {
                var sortedStr = SortStringByChar(str);
                if (!dict.ContainsKey(sortedStr))
                {
                    dict.Add(sortedStr, new List<string>());
                }
                dict[sortedStr].Add(str);
            }
            foreach (var key in dict.Keys)
            {
                var hashset = dict[key];
                result.Add(hashset);
            }
            return result;
        }

        public string SortStringByChar(string str)
        {
            var chars = str.ToList();
            chars = chars.Order().ToList();
            var result = "";
            foreach (var item in chars)
            {
                result += item;
            }
            return result;
        }
    }
}