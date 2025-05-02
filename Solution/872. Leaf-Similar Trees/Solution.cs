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
        public bool LeafSimilar(TreeNode root1, TreeNode root2)
        {
            var l1 = GetLeafNodeValues(root1);
            var l2 = GetLeafNodeValues(root2);
            if (l1.Count != l2.Count)
            {
                return false;
            }
            for (int i = 0; i < l1.Count; i++)
            {
                if (l1[i] != l2[i])
                {
                    return false;
                }
            }
            return true;
        }

        public List<int> GetLeafNodeValues(TreeNode root)
        {
            var result = new List<int>();
            var stack = new Stack<TreeNode>();
            stack.Push(root);
            while (stack.Count > 0)
            {
                var node = stack.Pop();
                if (node.right == null && node.left == null)
                {
                    result.Add(node.val);
                }
                if (node.right != null)
                {
                    stack.Push(node.right);
                }
                if (node.left != null)
                {
                    stack.Push(node.left);
                }
            }
            return result;
        }
    }
}