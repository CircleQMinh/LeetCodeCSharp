using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhVu
{

    public class Solution
    {
        public int MaxDepth(TreeNode root)
        {
            return FindMaxDepth(root, 0);
        }

        public int FindMaxDepth(TreeNode current, int max)
        {
            if (current == null)
            {
                return max;
            }
            var left = FindMaxDepth(current.left, max + 1);
            var right = FindMaxDepth(current.right, max + 1);
            return Math.Max(left, right);
        }
    }
}