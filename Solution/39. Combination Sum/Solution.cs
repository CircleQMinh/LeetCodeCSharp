using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhVu
{
    public class Solution {
        public IList<IList<int>> CombinationSum(int[] candidates, int target) {
            IList<IList<int>> g = new List<IList<int>>();
            GenerateCombinations(new List<int>(), candidates, target, g);

            return g;
        }
        public void GenerateCombinations(List<int> current, int[] candidates, int target, IList<IList<int>> result)
        {
            var sum = CalculateSum(current);
            if (sum == target)
            {
                var newCombination = new List<int>();
                foreach (int i in current)
                {
                    newCombination.Add(i);
                }
                newCombination.Sort();
                var isDup = false;
                foreach (var item in result)
                {
                    if (IsSameCombination(newCombination,item.ToList()))
                    {
                        isDup = true;
                        break;
                    }
                }
                if (!isDup)
                {
                    result.Add(newCombination);
                }
            }

            for (int i = 0; i < candidates.Length; i++) { 
                if(IsValidAdd(current, candidates[i], target))
                {
                    current.Add(candidates[i]);
                    GenerateCombinations(current, candidates, target, result);
                    current.Remove(candidates[i]);
                }
            }
        }

        public bool IsSameCombination(List<int> a, List<int> b)
        {
            if (a.Count != b.Count)
            {
                return false;
            }
            for (int i = 0; i < a.Count; i++) {
                if (a[i] != b[i])
                {
                    return false;
                }
            }
            return true;
        }

        public bool IsValidAdd(List<int> current, int add,int target)
        {
            return CalculateSum(current) + add <= target;
        }
        public int CalculateSum(List<int> current)
        {
            var sum = 0;
            for (int i = 0; i < current.Count; i++)
            {
                sum += current[i];
            }
            return sum;
        }
    }
}