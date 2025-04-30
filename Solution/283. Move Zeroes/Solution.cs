using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhVu
{
    public class Solution
    {
        public void MoveZeroes(int[] nums)
        {
            var n = nums.Length;
            var zeroP = 0;
            var numP = 0;
            while (true)
            {
                while (zeroP < n && nums[zeroP] != 0)
                {
                    zeroP++;
                }
                numP = zeroP + 1;
                while (numP < n && nums[numP] == 0)
                {
                    numP++;
                }
                if (!(numP < n && zeroP < n))
                {
                    break;
                }

                nums[zeroP] = nums[numP];
                nums[numP] = 0;
            }
        }
    }
}