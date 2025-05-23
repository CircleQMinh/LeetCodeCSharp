using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhVu
{
    public class Solution
    {
        public int SingleNumber(int[] nums)
        {
            for (int i = 1; i < nums.Length; i++)
            {

                nums[0] = nums[0] ^ nums[i];
            }
            return nums[0];
        }
    }
}

//  General Rule for "Every Element Appears N Times Except One"
// If N = 2 → Use XOR. 
// If N = 3 → Use two variables (ones, twos). 
// If N = 4 → Use two variables (ones, twos). 
// If N = 5 → Use three variables (ones, twos, threes). 
// For N = k, use (k-1) bit-tracking variables.

