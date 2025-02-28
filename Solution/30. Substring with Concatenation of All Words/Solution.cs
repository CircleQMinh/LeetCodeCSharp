using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhVu
{
    public class Solution
    {
        public IList<int> FindSubstring(string s, string[] words)
        {
            var result = new List<int>();
            //var concatenatedString = new HashSet<string>();
            //GenerateConcatenatedStrings(words, new List<int>(), concatenatedString); // too slow
            //foreach (var item in concatenatedString) {
            //    var index = s.IndexOf(item);
            //    if (index >= 0)
            //    {
            //        result.Add(index);
            //    }
            //}

            var sLen = s.Length;
            var wordLen = words[0].Length;
            var wordCount = words.Length;

            if (sLen < wordLen * wordCount)
            {
                return result;
            }

            var numberOfWords = new Dictionary<string, int>();
            foreach (var word in words)
            {
                if (!numberOfWords.ContainsKey(word))
                {
                    numberOfWords.Add(word, 0);
                }
                numberOfWords[word]++;
            }
            var numberOfAppearWords = new Dictionary<string, int>();
            for (int i = 0; i < wordLen; i++)
            {
                var left = i;
                var right = i;
                while (right + wordLen <= sLen)
                {
                    var currentWord = s.Substring(right, wordLen);
                    right += wordLen;
                    if (numberOfWords.ContainsKey(currentWord))
                    {
                        if (!numberOfAppearWords.ContainsKey(currentWord))
                        {
                            numberOfAppearWords.Add(currentWord, 0);
                        }
                        numberOfAppearWords[currentWord]++;

                        // if a word appear too many times  remove 1 word from the start of current subtring (s[left] to s[right]) until false
                        while (numberOfAppearWords[currentWord] > numberOfWords[currentWord])
                        {
                            var wordToRemove = s.Substring(left, wordLen);
                            left += wordLen;
                            numberOfAppearWords[wordToRemove]--;
                        }
                        // if found a substring(s[left] to s[right] using all word in words add start index to result)
                        if (right - left == wordLen * wordCount)
                        {
                            result.Add(left);
                        }
                    }
                    else
                    {
                        // reset the dictionary use to check
                        numberOfAppearWords.Clear();
                        //skip current word, move to next one
                        left = right;
                    }

                }
                numberOfAppearWords.Clear();
            }


            return result;
        }

        //public void GenerateConcatenatedStrings(string[] words,List<int> current, HashSet<string> strings)
        //{
        //    if (current.Count == words.Length)
        //    {
        //        var stringToAdd = "";
        //        foreach (var item in current) { 
        //            stringToAdd += words[item];  
        //        }
        //        strings.Add(stringToAdd);
        //    }

        //    for (int i = 0; i < words.Length; i++) {
        //        if (!current.Contains(i))
        //        {
        //            current.Add(i);
        //            GenerateConcatenatedStrings(words, current, strings);
        //            current.RemoveAt(current.Count - 1);
        //        }
        //    }
        //}
    }
}