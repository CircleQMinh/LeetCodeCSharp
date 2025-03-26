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
        public int GoodNodes(TreeNode root)
        {
            if (root == null)
            {
                return 0;
            }
            return 1 + CountGoodNodes(root.right, root.val) + CountGoodNodes(root.left, root.val);
        }

        public int CountGoodNodes(TreeNode root, int currentMax)
        {
            if (root == null)
            {
                return 0;
            }
            var temp = currentMax;
            var result = 0;
            if (root.val >= currentMax)
            {
                currentMax = root.val;

                result = 1 + CountGoodNodes(root.left, currentMax) + CountGoodNodes(root.right, currentMax);
            }
            else
            {
                result = CountGoodNodes(root.left, currentMax) + CountGoodNodes(root.right, currentMax);
            }
            currentMax = temp;
            return result;
        }
    }
}