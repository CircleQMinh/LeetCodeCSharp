using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhVu
{
    public class Solution
    {
        public IList<IList<int>> CombinationSum2(int[] candidates, int target)
        {
            IList<IList<int>> g = new List<IList<int>>();
            Array.Sort(candidates);
            GenerateCombinations2(0, new List<int>(), candidates, target, g);

            return g;
        }

        public void GenerateCombinations2(int currentIndex, List<int> current, int[] candidates, int target, IList<IList<int>> result)
        {
            if (target == 0)
            {
                var newCombination = new List<int>();
                foreach (int i in current)
                {
                    newCombination.Add(i);
                }
                newCombination.Sort();
                result.Add(newCombination);

            }

            for (int i = currentIndex; i < candidates.Length; i++)
            {
                if (i > currentIndex && candidates[i] == candidates[i - 1])
                {
                    continue;
                }
                if (candidates[i] <= target)
                {
                    current.Add(candidates[i]);
                    GenerateCombinations2(i + 1, current, candidates, target - candidates[i], result);
                    current.RemoveAt(current.Count - 1);
                }
                else
                {
                    break; // if candidates[i] > target then all candidates[i + n] will > target
                }

            }
        }
    }
}