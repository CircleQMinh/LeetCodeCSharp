using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16._3Sum_Closest
{
    public class Solution
    {
        public int ThreeSumClosest(int[] nums, int target)
        {
            var result = nums[0] + nums[1] + nums[2];
            var dif = Math.Abs(result - target);
            nums = nums.OrderBy(x => x).ToArray();

            for (int i = 0; i < nums.Length -2; i++) { 
                int j = i + 1;
                int k = nums.Length - 1;

                while(j < k)
                {
                    var sum = nums[i] + nums[j] + nums[k];
                    var curDif = Math.Abs(sum - target);

                    if (sum > target)
                    {
                        k--;
                        while (nums[k] == nums[k + 1] && k > j)
                        {
                            k--;
                        }
                    }
                    else if (sum < target)
                    {
                        j++;
                        while (nums[j] == nums[j-1] && j < k)
                        {
                            j++;
                        }
                    }
                    else
                    {
                        return target;
                    }

                    if (curDif < dif)
                    {
                        result = sum;
                        dif = curDif;
                    }
                }
            }
            return result;
        }
    }
}
