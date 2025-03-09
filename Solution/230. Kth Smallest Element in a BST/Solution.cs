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
        public int KthSmallest(TreeNode root, int k)
        {
            var result = new List<int>();
            FindKSmallest(root, result);
            return result[k - 1];
        }
        public void FindKSmallest(TreeNode root, List<int> result)
        {

            if (root.left != null)
            {
                FindKSmallest(root.left, result);
            }
            result.Add(root.val);
            if (root.right != null)
            {
                FindKSmallest(root.right, result);
            }
        }
    }
}