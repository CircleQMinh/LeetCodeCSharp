using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playground
{
    public class StockSpanner
    {
        private Stack<int> _stack;

        public StockSpanner()
        {
            _stack = new Stack<int>();
        }

        public int Next(int price)
        {
            _stack.Push(price);

            var temp = new Stack<int>();
            var count = 0;

            while (_stack.Count > 0 && _stack.Peek() <= price)
            {
                temp.Push(_stack.Pop());
                count++;
            }

            while (temp.Count > 0) { 
            
                _stack.Push(temp.Pop());
            }
            return count;

        }
    }

    /**
     * Your StockSpanner object will be instantiated and called as such:
     * StockSpanner obj = new StockSpanner();
     * int param_1 = obj.Next(price);
     */
}
