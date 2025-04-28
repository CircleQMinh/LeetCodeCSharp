using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhVu
{
    public class Solution
    {
        public IList<IList<int>> CombinationSum3(int k, int n)
        {
            var result = new HashSet<IList<int>>();
            FindCombinationSum3(k, n, new List<int>(), result);
            return result.ToList();
        }

        public void FindCombinationSum3(int k, int n, List<int> current, HashSet<IList<int>> result)
        {

            if (current.Sum() == n && current.Count == k)
            {
                var newList = new List<int>(current);
                result.Add(newList);
                return;
            }
            var max = current.Any() ? current.Max() : 0;
            for (int i = 1; i <= 9; i++)
            {
                if (!current.Contains(i) && current.Count < k && i > max)
                {
                    current.Add(i);
                    FindCombinationSum3(k, n, current, result);
                    current.Remove(i);
                }
            }

        }
    }
}