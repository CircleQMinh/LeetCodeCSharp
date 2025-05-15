using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhVu
{
    public class Solution
    {
        public int[] CountBits(int n)
        {
            var list = new List<int>();
            for (int i = 0; i <= n; i++)
            {
                var current = i;
                var count = 0;
                while (current > 0)
                {
                    if (current % 2 == 1)
                    {
                        count++;
                    }
                    current = current / 2;
                }
                list.Add(count);
            }
            return list.ToArray();
        }
    }
}