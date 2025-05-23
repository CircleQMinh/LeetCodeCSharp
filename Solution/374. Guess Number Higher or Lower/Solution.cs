using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhVu
{
    /** 
     * Forward declaration of guess API.
     * @param  num   your guess
     * @return 	     -1 if num is higher than the picked number
     *			      1 if num is lower than the picked number
     *               otherwise return 0
     * int guess(int num);
     */

    public class Solution : GuessGame
    {
        public int GuessNumber(int n)
        {
            var left = 1;
            var right = n;
            var mid = 0;
            var result = 999;
            while (result != 0)
            {
                mid = left + (right - left) / 2;
                result = guess(mid);
                if (result == -1)
                {
                    right = mid - 1;
                }
                else
                {
                    left = mid + 1;
                }
            }
            return mid;
        }
    }
}