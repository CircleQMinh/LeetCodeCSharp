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
            var one = 0;
            var two = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                one = (one ^ nums[i]) & ~two;
                two = (two ^ nums[i]) & ~one;

            }
            return one;
        }
    }
}

//  General Rule for "Every Element Appears N Times Except One"
// If N = 2 → Use XOR. 
// If N = 3 → Use two variables (ones, twos). 
// If N = 4 → Use two variables (ones, twos). 
// If N = 5 → Use three variables (ones, twos, threes). 
// For N = k, use (k-1) bit-tracking variables.

