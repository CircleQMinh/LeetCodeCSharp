using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhVu
{
    public class Solution
    {
        public int[] AsteroidCollision(int[] asteroids)
        {
            var stack = new Stack<int>();
            for (int i = 0; i < asteroids.Length; i++)
            {
                var current = asteroids[i];
                if (stack.Count == 0)
                {
                    stack.Push(current);
                    continue;
                }
                var prev = stack.Peek();
                if (prev > 0 && current < 0)
                {
                    var valueCurrent = Math.Abs(current);
                    var valuePrev = Math.Abs(prev);
                    if (valueCurrent >= valuePrev)
                    {
                        stack.Pop();
                        i = valueCurrent == valuePrev ? i : i - 1;
                    }
                }
                else
                {
                    stack.Push(current);
                }
            }
            var result = new int[stack.Count];
            int c = 0;
            while (stack.Count > 0)
            {
                result[c] = stack.Pop();
                c++;
            }
            Array.Reverse(result);
            return result;
        }
    }
}