using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhVu
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
}