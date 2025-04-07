using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhVu
{
    public class Solution
    {
        public bool CanPlaceFlowers(int[] flowerbed, int n)
        {
            var count = 0;
            if (flowerbed.Length == 0)
            {
                return false;
            }
            if (flowerbed.Length == 1)
            {
                return flowerbed[0] == 0 || n == 0;
            }
            if (flowerbed[0] == 0 && flowerbed[1] == 0)
            {
                count++;
                flowerbed[0] = 1;
            }
            if (flowerbed.Length - 2 > 0 && flowerbed[flowerbed.Length - 1] == 0 && flowerbed[flowerbed.Length - 2] == 0)
            {
                count++;
                flowerbed[flowerbed.Length - 1] = 1;
            }
            for (int i = 1; i < flowerbed.Length - 1; i++)
            {
                if (flowerbed[i] == 0 && flowerbed[i - 1] == 0 && flowerbed[i + 1] == 0)
                {
                    count++;
                    flowerbed[i] = 1;
                }
            }
            return count >= n;
        }
    }
}