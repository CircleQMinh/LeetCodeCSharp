using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhVu
{
    public class Solution
    {
        public int MinFlips(int a, int b, int c)
        {
            var count = 0;
            int totalBits = sizeof(int) * 8;
            for (int i = 0; i < totalBits; i++)
            {
                int bitA = (a >> i) & 1;
                int bitB = (b >> i) & 1;
                int bitC = (c >> i) & 1;
                if (bitC == 1)
                {
                    var inc = bitA == 1 || bitB == 1 ? 0 : 1;
                    count += inc;
                }
                else
                {
                    var inc = bitA == 1 && bitB == 1 ? 2 : bitA == 1 || bitB == 1 ? 1 : 0;
                    count += inc;
                }
            }
            return count;
        }
    }
}