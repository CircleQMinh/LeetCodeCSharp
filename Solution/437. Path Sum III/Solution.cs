using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Solution
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
        public int PathSum(TreeNode root, int targetSum)
        {
            return DFS_PathSum(root, targetSum);
        }

        public int DFS_PathSum(TreeNode root, long target)
        {
            if (root == null)
            {
                return 0;
            }
            return CountPathFromNode(root, target) +
            DFS_PathSum(root.left, target) +
            DFS_PathSum(root.right, target);

        }
        public int CountPathFromNode(TreeNode node, long target)
        {
            if (node == null)
            {
                return 0;
            }
            int count = 0;
            if (node.val == target)
            {
                count++;
            }

            count += CountPathFromNode(node.left, target - node.val);
            count += CountPathFromNode(node.right, target - node.val);
            return count;
        }
    }
}