using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhVu
{
    public class Solution
    {
        public int LadderLength(string beginWord, string endWord, IList<string> wordList)
        {
            if (!wordList.Contains(endWord))
            {
                return 0;
            }

            var n = beginWord.Length;
            var queue = new Queue<string>();
            var set = new HashSet<string>();
            var wordSet = new HashSet<string>(wordList); // improve run time by a lot

            var mutations = new HashSet<char>() { };
            for (int k = 'a'; k <= 'z'; k++)
            {
                mutations.Add((char)k);
            }

            queue.Enqueue(beginWord);
            set.Add(beginWord);

            var count = 1;
            while (queue.Count > 0)
            {

                var size = queue.Count;
                for (int i = 0; i < size; i++)
                {
                    var current = queue.Dequeue();
                    if (current.Equals(endWord))
                    {
                        return count;
                    }
                    for (int j = 0; j < n; j++)
                    {
                        var currentChar = current[j];
                        foreach (char c in mutations)
                        {
                            if (!c.Equals(currentChar))
                            {
                                var newWordArray = current.ToArray();
                                newWordArray[j] = c;
                                var newWord = new string(newWordArray);
                                if (wordSet.Contains(newWord) && !set.Contains(newWord))
                                {
                                    queue.Enqueue(newWord);
                                    set.Add(newWord);
                                }
                            }
                        }
                    }

                }
                count++;
            }

            return 0;
        }
    }
}