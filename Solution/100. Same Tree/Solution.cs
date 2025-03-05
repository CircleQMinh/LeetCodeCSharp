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
        public bool IsSameTree(TreeNode p, TreeNode q)
        {
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(p);
            queue.Enqueue(q);

            while (queue.Count > 0)
            {
                var pSide = queue.Dequeue();
                var qSide = queue.Dequeue();
                if ((pSide == null && qSide != null) || (pSide != null && qSide == null))
                {
                    return false;
                }
                if (pSide == null && qSide == null)
                {
                    continue;
                }
                if (qSide.val != pSide.val)
                {
                    return false;
                }

                queue.Enqueue(pSide.left);
                queue.Enqueue(qSide.left);
                queue.Enqueue(pSide.right);
                queue.Enqueue(qSide.right);

            }
            return true;
        }
    }
}