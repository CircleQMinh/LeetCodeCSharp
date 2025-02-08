using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhVu
{
    public class Solution
    {
        public IList<IList<int>> FourSum(int[] nums, int target)
        {
            IList<IList<int>> list = new List<IList<int>>();
            nums = nums.OrderBy(q => q).ToArray(); 

            for (int a = 0; a < nums.Length - 3; a++)
            {
                if (a > 0 && nums[a] == nums[a - 1])
                {
                    continue;
                }
                for (int b = a + 1; b < nums.Length - 2; b++)
                {
                    if (b > a + 1 && nums[b] == nums[b - 1])
                    {
                        continue;
                    }

                    var c = b + 1;
                    var d = nums.Length - 1;

                    while (c < d) {
                        // cast numbers to long to avoid overflow lol
                        long sum = (long)nums[a] + nums[b] + nums[c] + nums[d];
                        if (sum == target)
                        {
                            var add = new List<int> { nums[a], nums[b], nums[c], nums[d] };
                            list.Add(add);
                            c++;
                            while (nums[c] == nums[c - 1] && c < d)
                            {
                                c++;
                            }
                        }
                        else if (sum > target)
                        {
                            d--;
                        }
                        else {
                            c++;
                        }
                    }
                }
            }
            return list;
        }
    }
}