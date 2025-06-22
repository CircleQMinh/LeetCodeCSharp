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
        public IList<int> InorderTraversal(TreeNode root)
        {
            var list = new List<int>();
            DFS_InorderTraversal(root, list);
            return list;
        }

        public void DFS_InorderTraversal(TreeNode root, List<int> list)
        {
            if (root == null)
            {
                return;
            }

            DFS_InorderTraversal(root.left, list);
            list.Add(root.val);
            DFS_InorderTraversal(root.right, list);
        }
    }
}