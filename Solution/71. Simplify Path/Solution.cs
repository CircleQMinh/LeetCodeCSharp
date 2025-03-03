using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhVu
{
    public class Solution
    {
        public string SimplifyPath(string path)
        {
            var result = "/";
            var split = path.Split('/');
            split = split.Where(q => !string.IsNullOrEmpty(q)).ToArray();
            var stack = new Stack<string>();
            foreach (var item in split)
            {
                if (item.Equals(".."))
                {
                    var outs = "";
                    stack.TryPop(out outs);
                }
                else
                {
                    if (!(item.Equals(".")))
                    {
                        stack.Push(item);
                    }
                }
            }
            while (stack.Count > 0)
            {
                var p = stack.Pop();
                result = p + result;
                result = "/" + result;
            }
            if (result.EndsWith('/') && result.Length > 1)
            {
                result = result.Remove(result.Length - 1);
            }
            return result;
        }
    }
}