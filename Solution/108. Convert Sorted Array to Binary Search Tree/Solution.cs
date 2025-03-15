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
        public TreeNode SortedArrayToBST(int[] nums)
        {

            var n = nums.Length;
            if (n == 0)
            {
                return null;
            }
            var middle = n / 2;
            var root = new TreeNode(nums[middle]);
            root.left = SortedArrayToBST(nums.Take(middle).ToArray());
            root.right = SortedArrayToBST(nums.Skip(middle + 1).Take(n - middle - 1).ToArray());
            return root;
        }
    }
}