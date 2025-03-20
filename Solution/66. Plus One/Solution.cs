using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhVu
{
    public class Solution
    {
        public int[] PlusOne(int[] digits)
        {
            var carry = true;
            var index = digits.Length - 1;

            while (carry && index >= 0)
            {

                if (digits[index] == 9)
                {
                    digits[index] = 0;
                    carry = true;
                }
                else
                {
                    digits[index]++;
                    carry = false;
                }
                index--;
            }
            if (carry)
            {

                var newSize = digits.Length + 1;
                Array.Resize(ref digits, newSize);
                Array.Fill(digits, 0);
                digits[0] = 1;
            }
            return digits;
        }
    }
}