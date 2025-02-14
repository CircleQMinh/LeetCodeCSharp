using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhVu
{
    public class Solution
    {
        // public int Jump(int[] nums) //too slow
        // {
        //     var steps = new List<int>();
        //     var solutions = new List<List<int>>();

        //     TryJump(nums,0,steps,solutions);
        //     return solutions[0].Count;
        // }

        // public void TryJump (int[] nums, int currentPos, List<int> steps, List<List<int>> solutions)
        // {
        //     var n = nums.Length;
        //     if (currentPos == n - 1)
        //     {
        //         if (solutions.Count == 0 || solutions[0].Count > steps.Count)
        //         {
        //             solutions.Clear();
        //             solutions.Add(new List<int>(steps));
        //         }
        //     }
        //     var currentPosNumberOfStep = nums[currentPos];
        //     for (int i = 1; i <= currentPosNumberOfStep; i++) {
        //         var nextPos = currentPos + i;
        //         if (nextPos < n)
        //         {
        //             steps.Add(i);
        //             TryJump(nums, nextPos, steps, solutions);
        //             steps.RemoveAt(steps.Count - 1);
        //         }
        //     }
        // }
        public int Jump(int[] nums)
        {
            if (nums.Length == 1)
            {
                return 0;
            }

            var jumps = 0;
            var currentMaxPos = 0;
            var currentPos = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                currentMaxPos = Math.Max(currentMaxPos, i + nums[i]);
                if (i == currentPos) // if index catch up to current pos -> jump
                {
                    jumps++; // plus 1 jump at start
                    currentPos = currentMaxPos;
                }
                if (currentPos >= nums.Length - 1)
                {
                    break;
                }

            }
            return jumps;
        }
    }
}