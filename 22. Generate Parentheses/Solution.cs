using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Solution
    {
        public IList<string> GenerateParenthesis(int n)
        {
            var result = new List<string>();
            Generate("", n, result);
            return result;
        }
        public static void Generate(string cur, int n, List<string> result)
        {
            if (cur.Length == n * 2)
            {
                result.Add(cur);
                return;
            }
            else
            {
                var closed = cur.Count(q => q.Equals(')'));
                var open = cur.Count(q => q.Equals('('));

                if (open >= closed)
                {
                    if (open < n)
                    {
                        Generate(cur + "(", n, result);
                        Generate(cur + ")", n, result);
                    }
                    else
                    {
                        Generate(cur + ")", n, result);
                    }
                }

            }
        }
    }
}
