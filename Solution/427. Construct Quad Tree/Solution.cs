using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhVu
{
    /*
    // Definition for a Node node.
    public class Node {
        public bool val;
        public bool isLeaf;
        public Node topLeft;
        public Node topRight;
        public Node bottomLeft;
        public Node bottomRight;

        public Node() {
            val = false;
            isLeaf = false;
            topLeft = null;
            topRight = null;
            bottomLeft = null;
            bottomRight = null;
        }

        public Node(bool _val, bool _isLeaf) {
            val = _val;
            isLeaf = _isLeaf;
            topLeft = null;
            topRight = null;
            bottomLeft = null;
            bottomRight = null;
        }

        public Node(bool _val,bool _isLeaf,Node _topLeft,Node _topRight,Node _bottomLeft,Node _bottomRight) {
            val = _val;
            isLeaf = _isLeaf;
            topLeft = _topLeft;
            topRight = _topRight;
            bottomLeft = _bottomLeft;
            bottomRight = _bottomRight;
        }
    }
    */

    public class Solution
    {
        public Node Construct(int[][] grid)
        {
            var n = grid.Length;

            if (n == 0)
            {
                return null;
            }

            var middle = n / 2;
            var gridValue = grid[0][0];
            var isAllSameValue = true;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (grid[i][j] != gridValue)
                    {
                        isAllSameValue = false;
                        break;
                    }
                }
            }

            if (isAllSameValue)
            {
                return new Node(Convert.ToBoolean(gridValue), true);
            }

            var result = new Node(true, false);


            result.topLeft = Construct(CreateSmallerGrid(grid, 0, middle, 0, middle));
            result.topRight = Construct(CreateSmallerGrid(grid, 0, middle, middle, n));
            result.bottomLeft = Construct(CreateSmallerGrid(grid, middle, n, 0, middle));
            result.bottomRight = Construct(CreateSmallerGrid(grid, middle, n, middle, n));

            return result;

        }

        public int[][] CreateSmallerGrid(int[][] grid, int iStart, int iEnd, int jStart, int jEnd)
        {
            var n = iEnd - iStart;
            var result = new int[n][];
            for (int i = 0; i < n; i++)
            {
                result[i] = new int[n]; // Each row has N columns
            }
            var iCount = 0;
            var jCount = 0;
            for (var i = iStart; i < iEnd; i++)
            {
                jCount = 0;
                for (var j = jStart; j < jEnd; j++)
                {
                    result[iCount][jCount] = grid[i][j];
                    jCount++;
                }
                iCount++;
            }

            return result;
        }
    }
}