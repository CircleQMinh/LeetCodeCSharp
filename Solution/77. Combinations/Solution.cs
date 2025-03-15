using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhVu
{
    public class Solution
    {
        public IList<IList<int>> Combine(int n, int k)
        {
            var result = new HashSet<IList<int>>();
            GenerateCombanations(n, k, new List<int>(), result);
            return result.ToList();
        }

        public void GenerateCombanations(int n, int k, List<int> current, HashSet<IList<int>> result)
        {
            if (current.Count == k)
            {
                result.Add(new List<int>(current));
                return;
            }
            var lastNum = current.LastOrDefault();
            for (int i = 1; i <= n; i++)
            {
                if (i > lastNum)
                {
                    current.Add(i);
                    GenerateCombanations(n, k, current, result);
                    current.RemoveAt(current.Count - 1);
                }
            }
        }
    }
}