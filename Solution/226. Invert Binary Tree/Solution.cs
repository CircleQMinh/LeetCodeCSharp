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
        public TreeNode InvertTree(TreeNode root)
        {
            if (root == null)
            {
                return root;
            }
            var q = new Queue<TreeNode>();
            var listNode = new List<int?>();
            q.Enqueue(root);
            while ((q.Count > 0))
            {
                var current = q.Dequeue();
                if (current != null)
                {
                    listNode.Add(current.val);
                    q.Enqueue(current.right);
                    q.Enqueue(current.left);
                }
                else
                {
                    listNode.Add(null);
                }
            }

            var newRoot = new TreeNode(root.val);
            int i = 1;
            q.Enqueue(newRoot);
            while (i < listNode.Count)
            {
                var current = q.Dequeue();
                if (i < listNode.Count && listNode[i] != null)
                {
                    current.left = new TreeNode(listNode[i].Value);
                    q.Enqueue(current.left);
                }
                i++;
                if (i < listNode.Count && listNode[i] != null)
                {
                    current.right = new TreeNode(listNode[i].Value);
                    q.Enqueue(current.right);
                }
                i++;
            }
            return newRoot;
        }
    }
}