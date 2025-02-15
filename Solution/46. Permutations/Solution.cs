using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhVu
{
    public class Solution
    {
        public IList<IList<int>> Permute(int[] nums)
        {
            var result = new List<IList<int>>();
            GeneratePermute(nums, result, new List<int>());
            return result;
        }
        public void GeneratePermute(int[] nums, IList<IList<int>> result, List<int> current)
        {
            if (current.Count == nums.Length)
            {
                result.Add(new List<int>(current));
            }
            for (int i = 0; i < nums.Length; i++)
            {
                if (!current.Contains(nums[i]))
                {
                    current.Add(nums[i]);
                    GeneratePermute(nums, result, current);
                    current.RemoveAt(current.Count - 1);
                }
            }
        }
    }
}