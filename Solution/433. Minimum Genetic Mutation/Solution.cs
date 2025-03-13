using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhVu
{
    public class Solution
    {
        public int MinMutation(string startGene, string endGene, string[] bank)
        {
            if (!bank.Contains(endGene))
            {
                return -1;
            }
            var n = startGene.Length;
            var queue = new Queue<string>();
            var map = new Dictionary<string, int>();
            var mutations = new List<char>() { 'A', 'G', 'T', 'C' };
            queue.Enqueue(startGene);
            map.Add(startGene, 0);
            map.Add(endGene, int.MaxValue);

            while (queue.Count > 0)
            {
                var current = queue.Dequeue();
                for (int i = 0; i < n; i++)
                {
                    foreach (char c in mutations)
                    {
                        var newGene = current.ToList();
                        newGene[i] = c;
                        var newGeneString = string.Join("", newGene);
                        if (bank.Contains(newGeneString))
                        {
                            var newGeneStep = map[current] + 1;
                            if (!map.ContainsKey(newGeneString))
                            {
                                queue.Enqueue(newGeneString);
                                map.Add(newGeneString, newGeneStep);
                            }
                            if ((map[newGeneString] > newGeneStep))
                            {
                                queue.Enqueue(newGeneString);
                                map[newGeneString] = newGeneStep;
                            }

                        }
                    }
                }
            }
            var result = map[endGene] == int.MaxValue ? -1 : map[endGene];
            return result;
        }
    }
}