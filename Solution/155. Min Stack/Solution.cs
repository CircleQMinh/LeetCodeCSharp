using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhVu
{
    public class MinStack
    {
        private Stack<int> _stack;
        private Stack<int> _min;
        public MinStack()
        {
            _min = new Stack<int>();
            _min.Push(int.MaxValue);
            _stack = new Stack<int>();
        }

        public void Push(int val)
        {
            _stack.Push(val);
            if (_min.Peek() >= val)
            {
                _min.Push(val);
            }
        }

        public void Pop()
        {
            var p = _stack.Pop();
            if (_min.Peek() == p)
            {
                _min.Pop();
            }
        }

        public int Top()
        {
            return _stack.Peek();
        }

        public int GetMin()
        {
            return _min.Peek();
        }
    }
}