using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhVu
{
    public class Solution
    {
        public int RangeBitwiseAnd(int left, int right)
        {
            while (left < right)
            {
                right = right & (right - 1);
            }
            return right;
        }
    }
}