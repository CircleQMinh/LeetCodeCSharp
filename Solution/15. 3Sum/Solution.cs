using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15._3Sum
{
    public class Solution
    {
        public IList<IList<int>> ThreeSum(int[] nums)
        {
            IList<IList<int>> list = new List<IList<int>>();
            nums = nums.OrderBy(q => q).ToArray(); //-4 -1 -1 0 1 2

            for (int i = 0; i < nums.Length - 2; i++)
            {
                if (i > 0 && nums[i] == nums[i - 1])
                {
                    continue;
                }

                var j = i + 1;
                var k = nums.Length - 1;

                while (j < k)
                {
                    var sum = nums[i] + nums[j] + nums[k];
                    if (sum == 0)
                    {
                        var add = new List<int> { nums[i], nums[j], nums[k] };
                        list.Add(add);
                        j++;
                        while (nums[j] == nums[j - 1] && j < k)
                        {
                            j++;
                        }

                    }
                    else if (sum > 0)
                    {
                        k--;
                    }
                    else
                    {
                        j++;
                    }
                }
            }

            return list;
        }

    }
}
