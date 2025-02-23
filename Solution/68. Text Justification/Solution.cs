using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhVu
{
    public class Solution
    {
        public IList<string> FullJustify(string[] words, int maxWidth)
        {
            var result = new List<string>();
            var currentWords = new List<string>();

            foreach (var word in words)
            {
                var len = word.Length;
                if (!(maxWidth - len - currentWords.Count - currentWords.Sum(q => q.Length) >= 0))
                {
                    result.Add(Justify(currentWords, maxWidth));
                    currentWords.Clear();
                }
                currentWords.Add(word);
            }
            if (currentWords.Count > 0)
            {
                result.Add(JustifyLastLine(currentWords, maxWidth));
            }
            return result;
        }
        public string Justify(List<string> words, int maxWidth)
        {
            var result = string.Join(" ", words);
            var n = words.Count;
            var totalWordLen = result.Length;
            var emptySpaces = maxWidth - totalWordLen;
            while (emptySpaces > 0)
            {
                for (var i = 0; i < n && emptySpaces > 0; i++)
                {
                    var value = words[i];
                    if (value.Equals(words[n - 1]) && n > 1)
                    {
                        continue;
                    }
                    words[i] = words[i] + " ";
                    emptySpaces--;
                }
            }
            result = string.Join(" ", words);

            return result;
        }
        public string JustifyLastLine(List<string> words, int maxWidth)
        {
            var result = string.Join(" ", words);
            var totalWordLen = result.Length;
            var emptySpaces = maxWidth - totalWordLen;

            for (var i = 0; i < emptySpaces; i++)
            {
                result += " ";
            }
            return result;
        }
    }
}