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
        public IList<int> RightSideView(TreeNode root)
        {
            var result = new Dictionary<int, int>();
            FindRightMost(root, 0, result);
            return result.Select(q => q.Value).ToList();
        }

        public void FindRightMost(TreeNode root, int h, Dictionary<int, int> result)
        {
            if (root == null)
            {
                return;
            }
            if (!result.ContainsKey(h))
            {
                result.Add(h, root.val);
            }
            if (root.right != null)
            {
                FindRightMost(root.right, h + 1, result);
            }
            if (root.left != null)
            {
                FindRightMost(root.left, h + 1, result);
            }
        }
    }
}