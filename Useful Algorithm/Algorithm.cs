using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UsefulAlgorithm
{
    public class Algorithm
    {
        public int MaxSubArray(int[] nums)  // Kadane’s Algorithm
        {
            var max = int.MinValue;
            var current = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                current += nums[i];
                max = Math.Max(max, current);
                current = Math.Max(0, current);
            }
            return max;
        }

        public int BinarySearch(int[] array, int target)
        {
            int left = 0;
            int right = array.Length - 1;

            while (left <= right)
            {
                int middle = left + (right - left) / 2;

                if (array[middle] == target)
                {
                    return middle;
                }

                if (array[middle] < target)
                {
                    left = middle + 1;
                }
                else
                {
                    right = middle - 1;
                }
            }

            return -1;
        }

        public int BinarySearchLeftMost(int[] array, int target)
        {
            int left = 0;
            int right = array.Length;

            while (left < right)
            {
                int middle = left + (right - left) / 2;
                if (array[middle] < target)
                {
                    left = middle + 1;
                }
                else
                {
                    right = middle;
                }
            }
            return left;
        }
        public int BinarySearchRightMost(int[] array, int target)
        {
            int left = 0;
            int right = array.Length;

            while (left < right)
            {
                int middle = left + (right - left) / 2;

                if (array[middle] > target)
                {
                    right = middle;
                }
                else
                {
                    left = middle + 1;
                }
            }
            return right - 1;
        }

        // In Depth-First Search (DFS) for binary trees, you can traverse in three standard orders:

        // Pre-order: Visit Node → Left → Right

        // In-order: Left → Visit Node → Right

        // Post-order: Left → Right → Visit Node

        public void PreOrder(TreeNode root)
        {
            if (root == null) return;

            Console.WriteLine(root.Value); // Visit node
            PreOrder(root.Left);           // Traverse left
            PreOrder(root.Right);          // Traverse right
        }
        public void InOrder(TreeNode root)
        {
            if (root == null) return;

            InOrder(root.Left);             // Traverse left
            Console.WriteLine(root.Value);  // Visit node
            InOrder(root.Right);            // Traverse right
        }


        public void PostOrder(TreeNode root)
        {
            if (root == null) return;

            PostOrder(root.Left);            // Traverse left
            PostOrder(root.Right);           // Traverse right
            Console.WriteLine(root.Value);   // Visit node
        }


    }
}