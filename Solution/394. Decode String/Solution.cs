using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhVu
{
    public class Solution
    {
        public string DecodeString(string s)
        {
            var stack = new Stack<string>();
            for (var i = 0; i < s.Length; i++)
            {
                if (s[i] == ']')
                {
                    var currentText = "";
                    while (stack.Peek() != "[")
                    {
                        currentText = stack.Pop() + currentText;
                    }

                    stack.Pop();

                    var currentNumText = stack.Pop();
                    while (stack.Count > 0 && char.IsDigit(stack.Peek().ToCharArray()[0]))
                    {
                        currentNumText = stack.Pop() + currentNumText;
                    }
                    var currentNum = int.Parse(currentNumText);
                    var decodeText = "";
                    for (var j = 0; j < currentNum; j++)
                    {
                        decodeText += currentText;
                    }
                    stack.Push(decodeText);
                }
                else
                {
                    stack.Push(s[i].ToString());
                }
            }
            var result = "";
            while (stack.Count > 0)
            {
                result = stack.Pop() + result;
            }
            return result;
        }
    }
}