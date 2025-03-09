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
        public int GetMinimumDifference(TreeNode root)
        {
            var queue = new Queue<TreeNode>();
            var list = new List<int>();
            queue.Enqueue(root);
            while (queue.Count > 0)
            {
                var node = queue.Dequeue();
                if (node.left != null)
                {
                    queue.Enqueue(node.left);
                }
                if (node.right != null)
                {
                    queue.Enqueue(node.right);
                }
                list.Add(node.val);
            }
            var result = int.MaxValue;
            list = list.Order().ToList();
            for (int i = 0; i < list.Count - 1; i++)
            {
                var s = list[i + 1] - list[i];
                result = Math.Min(result, s);
            }
            return result;
        }
    }
}