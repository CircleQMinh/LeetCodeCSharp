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
        public int MaxPathSum(TreeNode root)
        {
            var queue = new Queue<TreeNode>();
            var max = int.MinValue;
            queue.Enqueue(root);
            while (queue.Count > 0)
            {
                var node = queue.Dequeue();
                var left = Math.Max(MaxGain(node.left), 0); //if path gain is negative ignore it -> plus 0
                var right = Math.Max(MaxGain(node.right), 0);
                var currentPath = left + right + node.val;

                max = Math.Max(max, currentPath);
                if (node.left != null)
                {
                    queue.Enqueue(node.left);
                }
                if (node.right != null)
                {
                    queue.Enqueue(node.right);
                }

            }
            return max;
        }

        public int MaxGain(TreeNode root)
        {
            if (root == null)
            {
                return 0;
            }
            var gain = Math.Max(Math.Max(MaxGain(root.left), 0), Math.Max(MaxGain(root.right), 0));
            return gain + root.val;
        }
    }
}