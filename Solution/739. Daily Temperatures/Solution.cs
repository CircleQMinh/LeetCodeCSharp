using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhVu
{
    public class Solution
    {
        public int[] DailyTemperatures(int[] temperatures)
        {
            var n = temperatures.Length;
            var result = new int[n];
            //var set = new Dictionary<int, int>();
            //for (int i = n - 1; i >= 0; i--)
            //{
            //    if (set.Count == 0)
            //    {
            //        result[i] = 0;
            //        set.Add(i, temperatures[i]);
            //    }
            //    else
            //    {
            //        var current = temperatures[i];
            //        var days = 0;
            //        for (int j = i+1;j < n; j++)
            //        {
            //            if (temperatures[j] > temperatures[i])
            //            {
            //                days = j - i; break;
            //            }
            //        }

            //        result[i] = days;
            //        set.Add(i, current);
            //    }
            //}

            var stack = new Stack<int>();
            stack.Push(0);
            for (int i = 1; i < n; i++)
            {

                while (stack.Count > 0 && temperatures[stack.Peek()] < temperatures[i])
                {
                    var topStack = temperatures[stack.Peek()];
                    var current = temperatures[i];
                    var index = stack.Pop();
                    result[index] = i - index;
                }

                stack.Push(i);
            }

            return result;
        }
    }
}