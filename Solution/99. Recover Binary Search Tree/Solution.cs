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
        public void RecoverTree(TreeNode root)
        {
            var list = new List<int>();
            DFS_RecoverTree_FindNode(root, list);
            list = list.OrderBy(q => q).ToList();
            DFS_RecoverTree_RecoverNode(root, list);

        }
        public void DFS_RecoverTree_FindNode(TreeNode root, List<int> list)
        {
            if (root == null)
            {
                return;
            }

            DFS_RecoverTree_FindNode(root.left, list);
            list.Add(root.val);
            DFS_RecoverTree_FindNode(root.right, list);
        }

        public void DFS_RecoverTree_RecoverNode(TreeNode root, List<int> list)
        {
            if (root == null)
            {
                return;
            }

            DFS_RecoverTree_RecoverNode(root.left, list);
            root.val = list[0];
            list.RemoveAt(0);
            DFS_RecoverTree_RecoverNode(root.right, list);
        }
    }
}