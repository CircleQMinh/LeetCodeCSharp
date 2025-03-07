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
        public TreeNode BuildTree(int[] inorder, int[] postorder)
        {
            return BuildMyTreePostOrder(inorder, postorder);
        }
        public TreeNode BuildMyTreePostOrder(int[] inorder, int[] postorder)
        {
            if (postorder.Length > 0)
            {
                var value = postorder[postorder.Length - 1];
                var index = Array.IndexOf(inorder, value);
                var root = new TreeNode(value);

                var leftInOrder = new int[index];
                var rightInOrder = new int[inorder.Length - index - 1];
                var leftPostOrder = new int[index];
                var rightPostOrder = new int[postorder.Length - index - 1];

                leftInOrder = inorder.Take(index).ToArray();
                rightInOrder = inorder.Skip(index + 1).Take(inorder.Length - 1 - index).ToArray();

                leftPostOrder = postorder.Take(index).ToArray();
                rightPostOrder = postorder.Skip(index).Take(postorder.Length - index).ToArray();
                rightPostOrder = rightPostOrder.Take(rightPostOrder.Length - 1).ToArray(); // remove current node val

                root.right = BuildMyTreePostOrder(rightInOrder, rightPostOrder);
                root.left = BuildMyTreePostOrder(leftInOrder, leftPostOrder);

                return root;
            }
            return null;
        }
    }
}