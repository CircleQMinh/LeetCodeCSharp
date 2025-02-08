using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhVu
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
        //public int RemoveDuplicates(int[] nums)
        //{
        //    int i = 1;
        //    while (i < nums.Length) {
        //        if (nums[i-1] == nums[i])
        //        {
        //            nums = RemoveAt(i, nums);
        //            i--;
        //        }
        //        i++;
        //    }
        //    return nums.Length;
        //}

        //public int[] RemoveAt(int index, int[] nums) {
        //    while (index < nums.Length-1)
        //    {
        //        nums[index] = nums[index + 1];
        //        index++;
        //    }
        //    Array.Resize(ref nums, nums.Length-1);
        //    return nums;
        //}
    }
}