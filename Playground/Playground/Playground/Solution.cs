using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playground
{
    public class Solution
    {
        public int RemoveDuplicates(int[] nums)
        {
            int i = 1;
            int count = 0;
            while (i < nums.Length)
            {
                if (nums[count] != nums[i])
                {
                    count++;
                    nums[count] = nums[i];
                }
                i++;
            }
            return nums.Length == 0 ? 0 : count + 1;
        }
        public int RemoveElement(int[] nums, int val)
        {
            int i = 0;
            int j = 0;
            int count = 0;
            while (i < nums.Length && j < nums.Length)
            {
                if (nums[j] != val)
                {
                    nums[i] = nums[j];
                    i++;
                  
                }
                else
                {
                    count ++;
                }
                j++;
            }

            return nums.Length == 0 ? 0 : nums.Length - count;
        }
    }
}
