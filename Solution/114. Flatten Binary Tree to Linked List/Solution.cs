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
        public void Flatten(TreeNode root)
        {
            if (root == null)
            {
                return;
            }

            if (root.left != null)
            {
                Flatten(root.left);
            }
            if (root.right != null)
            {
                Flatten(root.right);
            }
            if (root.left != null && root.right == null)
            {

                root.right = root.left;
                root.left = null;
                return;
            }
            if (root.left != null && root.right != null)
            {
                var current = root.left;
                while (current.right != null)
                {
                    current = current.right;
                }
                current.right = root.right;
                root.right = root.left;
                root.left = null;
            }
        }
    }
}