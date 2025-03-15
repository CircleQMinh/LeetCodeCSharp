using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playground
{
    public class QuadTree
    {
        public bool val;
        public bool isLeaf;
        public QuadTree topLeft;
        public QuadTree topRight;
        public QuadTree bottomLeft;
        public QuadTree bottomRight;

        public QuadTree()
        {
            val = false;
            isLeaf = false;
            topLeft = null;
            topRight = null;
            bottomLeft = null;
            bottomRight = null;
        }

        public QuadTree(bool _val, bool _isLeaf)
        {
            val = _val;
            isLeaf = _isLeaf;
            topLeft = null;
            topRight = null;
            bottomLeft = null;
            bottomRight = null;
        }

        public QuadTree(bool _val, bool _isLeaf, QuadTree _topLeft, QuadTree _topRight, QuadTree _bottomLeft, QuadTree _bottomRight)
        {
            val = _val;
            isLeaf = _isLeaf;
            topLeft = _topLeft;
            topRight = _topRight;
            bottomLeft = _bottomLeft;
            bottomRight = _bottomRight;
        }
    }
}
