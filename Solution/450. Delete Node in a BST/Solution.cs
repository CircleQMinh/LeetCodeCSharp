using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhVu
{

    public class Solution
    {
        public TreeNode DeleteNode(TreeNode root, int key)
        {
            if (root == null)
            {
                return root;
            }

            if (root.val > key)
            {
                root.left = DeleteNode(root.left, key);
            }
            else if (root.val < key)
            {
                root.right = DeleteNode(root.right, key);
            }
            else
            {
                if (root.right == null && root.left == null)
                {
                    root = null;
                }
                else if (root.right == null)
                {
                    root = root.left;
                }
                else if (root.left == null)
                {
                    root = root.right;
                }
                else
                {
                    var minRight = DeleteNodeFindMin(root.right);
                    root.val = minRight.val;
                    root.right = DeleteNode(root.right, root.val);
                }
            }

            return root;
        }

        public TreeNode DeleteNodeFindMin(TreeNode root)
        {
            while (root.left != null)
            {
                root = root.left;
            }
            return root;
        }
    }
}