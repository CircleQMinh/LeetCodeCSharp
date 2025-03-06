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
        public TreeNode BuildTree(int[] preorder, int[] inorder)
        {
            var queue = new Queue<int>(preorder);
            return BuildMyTree(queue, inorder);

        }

        public TreeNode BuildMyTree(Queue<int> queue, int[] inorder)
        {
            if (queue.Count > 0 && inorder.Length > 0)
            {
                var value = queue.Dequeue();
                var index = Array.IndexOf(inorder, value);
                var root = new TreeNode(value);
                var leftInOrder = new int[index];
                var rightInOrder = new int[inorder.Length - index - 1];
                leftInOrder = inorder.Take(index).ToArray();
                rightInOrder = inorder.Skip(index + 1).Take(inorder.Length - 1 - index).ToArray();
                root.left = BuildMyTree(queue, leftInOrder);
                root.right = BuildMyTree(queue, rightInOrder);
                return root;
            }
            return null;
        }
    }
}