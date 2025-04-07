using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhVu
{
    public class Solution
    {
        public int MaxLevelSum(TreeNode root)
        {
            var result = 1;
            var level = 0;
            var max = int.MinValue;
            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            while (queue.Count > 0)
            {
                var count = queue.Count;
                var sum = 0;
                level++;
                for (int i = 0; i < count; i++)
                {
                    var node = queue.Dequeue();
                    sum += node.val;

                    if (node.left != null)
                    {
                        queue.Enqueue(node.left);
                    }
                    if (node.right != null)
                    {
                        queue.Enqueue(node.right);
                    }
                }

                if (sum > max)
                {
                    max = sum;
                    result = level;
                }
            }

            return result;
        }
    }
}