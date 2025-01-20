using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11._Container_With_Most_Water
{
    public class Solution
    {
        public int MaxArea(int[] height)
        {
            var max = 0;
            //for (int i = 0; i < height.Length - 1; i++)
            //{
            //    for (int j = i+1; j < height.Length; j++)
            //    {
            //        var w = j - i;
            //        var h = Math.Min(height[i], height[j]);
            //        var area = w * h;
            //        if (area > max)
            //        {
            //            max = area;
            //        }
            //    }
            //}

            var left = 0;
            var right = height.Length - 1;
            while (left < right)
            {
                var w = right - left;
                var h = Math.Min(height[left], height[right]);
                var area = w * h;
                if (area > max)
                {
                    max = area;
                }
                if (height[left] > height[right])
                {
                    right--;
                }
                else
                {
                    left++;
                }
            }


            return max;
        }
    }
}
