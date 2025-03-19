using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhVu
{
    public class Solution
    {
        // public uint reverseBits(uint n)
        // {
        //     var binary = Convert.ToString(n, 2).PadLeft(32, '0');
        //     var newBinary = "";
        //     for (int i = binary.Length - 1; i >= 0; i--)
        //     {
        //         var bit = binary[i];
        //         newBinary += bit;
        //     }
        //     var number = Convert.ToInt32(newBinary, 2);
        //     return (uint)number;
        // }

        public uint reverseBits(uint n)
        {
            uint result = 0;
            for (int i = 0; i < 32; i++)
            {
                result = (result << 1) | (n & 1); // Shift result left, add LSB of n
                n >>= 1; // Right shift n
            }
            return result;
        }
    }
}