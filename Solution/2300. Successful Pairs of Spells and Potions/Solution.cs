using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhVu
{
    public class Solution
    {
        public int[] SuccessfulPairs(int[] spells, int[] potions, long success)
        {
            var n = spells.Length;
            var result = new int[n];
            Array.Sort(potions);
            for (int i = 0; i < n; i++)
            {
                result[i] = CountSuccessfulPairs(spells[i], potions, success);
            }
            return result;
        }
        public int CountSuccessfulPairs(int spell, int[] array, long target)
        {
            var n = array.Length;
            //for (int i = 0; i < n; i++) {
            //    long s = spell * array[i];
            //    if ( s >= target)
            //    {
            //        return n - i;
            //    }
            //}
            //return 0;

            int left = 0;
            int right = n;

            while (left < right)
            {
                int middle = left + (right - left) / 2;
                long s = (long)array[middle] * (long)spell;
                if (s < target)
                {
                    left = middle + 1;
                }
                else
                {
                    right = middle;
                }
            }
            return n - left;
        }
    }
}