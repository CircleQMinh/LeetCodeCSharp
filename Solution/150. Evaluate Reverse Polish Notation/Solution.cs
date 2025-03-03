using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhVu
{
    public class Solution
    {
        public int EvalRPN(string[] tokens)
        {
            var stack = new Stack<int>();
            foreach (var token in tokens)
            {
                if (token.Equals("+") || token.Equals("-") || token.Equals("*") || token.Equals("/"))
                {
                    var numB = stack.Pop();
                    var numA = stack.Pop();
                    switch (token)
                    {
                        case "+":
                            stack.Push(numA + numB);
                            break;
                        case "-":
                            stack.Push(numA - numB);
                            break;
                        case "*":
                            stack.Push(numA * numB);
                            break;
                        case "/":
                            stack.Push(numA / numB);
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    var num = int.Parse(token);
                    stack.Push(num);
                }
            }
            return stack.Pop();
        }
    }
}