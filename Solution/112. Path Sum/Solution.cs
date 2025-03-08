using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhVu
{
    /**
     * Definition for a binary tree node.
     * public class TreeNode {
     *     public int val;
     *     public TreeNode left;
     *     public TreeNode right;
     *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
     *         this.val = val;
     *         this.left = left;
     *         this.right = right;
     *     }
     * }
     */
    public class Solution
    {
        public bool HasPathSum(TreeNode root, int targetSum)
        {
            if (root == null)
            {
                return false;
            }
            if (root.left == null && root.right == null)
            {
                return targetSum == root.val;
            }
            var left = false;
            var right = false;
            if (root.left != null)
            {
                left = CalculatePathSum(root.left, targetSum, root.val);
            }
            if (root.right != null)
            {
                right = CalculatePathSum(root.right, targetSum, root.val);
            }

            return left || right;
        }

        public bool CalculatePathSum(TreeNode root, int targetSum, int current)
        {
            if (root == null)
            {
                return false;
            }
            var value = current + root.val;
            if (value == targetSum && root.left == null && root.right == null)
            {
                return true;
            }

            return CalculatePathSum(root.left, targetSum, value) || CalculatePathSum(root.right, targetSum, value);
        }
    }
}