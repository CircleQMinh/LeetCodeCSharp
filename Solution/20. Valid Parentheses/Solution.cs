using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Solution
    {
        public bool IsValid(string s)
        {
            var current = "";
            var open = new List<char> { '{', '[', '(' };
            foreach (var item in s)
            {
                if (open.Contains(item))
                {
                    current += item;
                }
                else
                {
                    if (current.Length == 0)
                    {
                        return false;
                    }
                    var last = current[current.Length - 1];
                    if (
                        item.Equals('}') && last != '{'
                        || item.Equals(']') && last != '['
                        || item.Equals(')') && last != '('
                        )
                    {
                        return false;
                    }
                    else
                    {
                        current = current.Substring(0, current.Length - 1);
                    }
                }
            }
            return current.Length == 0;
        }
    }
}
