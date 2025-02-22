using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhVu
{
    public class Solution
    {
        public int Trap(int[] height)
        {
            var n = height.Length;
            var canHold = new int[n];
            Array.Fill(canHold, 0);
            var nextGreatestToTheRight = BiggestNumberToTheRight(height);
            // reverse input then reverse output
            var nextGreatestToTheLeft = (BiggestNumberToTheRight(height.Reverse().ToArray())).Reverse().ToArray();
            for (int i = 1; i < n - 1; i++)
            {
                var leftWall = nextGreatestToTheLeft[i];
                var rightWall = nextGreatestToTheRight[i];
                canHold[i] = Math.Min(leftWall, rightWall) - height[i];
            }
            return canHold.Where(q => q > 0).Sum(q => q);
        }
        public int[] BiggestNumberToTheRight(int[] arr)
        {
            int n = arr.Length;
            int[] result = new int[n];

            int maxFromRight = -1;

            for (int i = n - 1; i >= 0; i--)
            {
                int current = arr[i];
                result[i] = maxFromRight;
                maxFromRight = Math.Max(maxFromRight, current);
            }

            return result;
        }
    }
}