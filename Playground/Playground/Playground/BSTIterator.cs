using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playground
{
    public class BSTIterator
    {
        private Queue<TreeNode> _queue;
        public BSTIterator(TreeNode root)
        {
            _queue = new Queue<TreeNode>();
            if (root != null)
            {
                CreateQueue(root);
            }
        }

        public int Next()
        {
            return _queue.Dequeue().val;
        }

        public bool HasNext()
        {
            return _queue.Count > 0;

        }

        private void CreateQueue(TreeNode root)
        {

            if (root.left != null)
            {
                CreateQueue(root.left);
            }
            _queue.Enqueue(root);
            if (root.right != null)
            {
                CreateQueue(root.right);
            }
        }
    }
}
