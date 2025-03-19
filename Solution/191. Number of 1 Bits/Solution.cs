using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhVu
{
    public class Solution
    {
        public int HammingWeight(int n)
        {
            int count = 0;
            while (n != 0)
            {
                count += (n & 1); // Check if the last bit is 1
                n >>= 1; // Right shift to check the next bit
            }
            return count;
        }
        // public int HammingWeight(int n)
        // {
        //     var binary = Convert.ToString(n, 2).PadLeft(32, '0');
        //     var count = 0;
        //     for (int i = binary.Length - 1; i >= 0; i--)
        //     {
        //         var bit = binary[i];
        //         count = bit.Equals('1') ? count + 1 : count;

        //     }
        //     return count;
        // }
    }
}