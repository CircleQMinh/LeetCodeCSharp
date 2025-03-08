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
        public int CountNodes(TreeNode root)
        {
            if (root == null)
            {
                return 0;
            }
            int level = 0;
            var left = root;
            var right = root;
            while (right != null)
            {
                level++;
                left = left.left;
                right = right.right;
            }
            if (left == null) // check if this is a full tree, this always trigger once so the complexity is < o(n)
            {
                return (int)Math.Pow(2, level) - 1;
            }
            // if not full then Calculate like O(N) solution
            return 1 + CountNodes(root.left) + CountNodes(root.right);
        }
    }
}