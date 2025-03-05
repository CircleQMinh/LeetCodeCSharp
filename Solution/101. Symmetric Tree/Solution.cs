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
        public bool IsSymmetric(TreeNode root)
        {
            var q = new Queue<TreeNode>();
            q.Enqueue(root.left);
            q.Enqueue(root.right);
            while (q.Count > 0)
            {
                var left = q.Dequeue();
                var right = q.Dequeue();
                if (left == null && right == null)
                {
                    continue;
                }
                if ((left == null && right != null) || (left != null && right == null))
                {
                    return false;
                }
                if (left.val != right.val)
                {
                    return false;

                }

                q.Enqueue(left.right);
                q.Enqueue(right.left);
                q.Enqueue(left.left);
                q.Enqueue(right.right);
            }
            return true;
        }
    }
}