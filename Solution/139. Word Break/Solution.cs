using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhVu
{
    public class Solution
    {
        public bool WordBreak(string s, IList<string> wordDict)
        {
            var wordSet = wordDict.ToHashSet();
            var memo = new Dictionary<string, bool>();
            return CheckWordBreak(s, wordSet, memo);
        }

        public bool CheckWordBreak(string s, HashSet<string> set, Dictionary<string, bool> memo)
        {
            if (s.Length == 0)
            {
                return true;
            }
            if (memo.ContainsKey(s))
            {
                return memo[s];
            }
            for (var i = 1; i <= s.Length; i++)
            {
                var left = s.Substring(0, i);
                var right = s.Substring(i);
                if (set.Contains(left))
                {
                    memo[left] = true;
                    if (CheckWordBreak(right, set, memo))
                    {
                        return true;
                    }
                }
            }
            memo[s] = false;
            return false;
        }

        //public bool WordBreak(string s, IList<string> wordDict)
        //{
        //    if (s.All(q=>q.Equals('_')))
        //    {
        //        return true;
        //    }
        //    foreach (var word in wordDict) {

        //        if (s.Contains(word))
        //        {
        //            var temp = s;
        //            s = ReplaceFirst(s,word, "_");
        //            if (WordBreak(s,wordDict))
        //            {
        //                return true;
        //            }
        //            s = temp;
        //        }
        //    }
        //    return false;
        //}

        //public static string ReplaceFirst(string s, string oldString, string newString)
        //{
        //    var regex = new Regex(Regex.Escape(oldString));
        //    var result = regex.Replace(s, newString, 1);
        //    return result;
        //}
    }
}