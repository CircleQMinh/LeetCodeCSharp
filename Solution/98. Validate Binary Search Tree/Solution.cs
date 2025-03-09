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
        public void GetTreeNodeValueInOrder(TreeNode root, List<int> result)
        {

            if (root.left != null)
            {
                GetTreeNodeValueInOrder(root.left, result);
            }
            result.Add(root.val);
            if (root.right != null)
            {
                GetTreeNodeValueInOrder(root.right, result);
            }
        }
        public bool IsValidBST(TreeNode root)
        {
            var result = new List<int>();
            GetTreeNodeValueInOrder(root, result);
            for (int i = 0; i < result.Count - 1; i++)
            {
                if (result[i] >= result[i + 1])
                {
                    return false;
                }
            }
            return true;
        }
    }
}