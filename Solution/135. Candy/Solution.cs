using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhVu
    public class Solution
{
    public int Candy(int[] ratings)
    {
        var n = ratings.Length;
        var result = new int[n];
        Array.Fill(result, 1);
        for (int i = 1; i < n; i++)
        {
            if (ratings[i] > ratings[i - 1])
            {
                result[i] = result[i - 1] + 1;
            }
        }
        for (int i = n - 2; i >= 0; i--)
        {
            if (ratings[i] > ratings[i + 1])
            {
                result[i] = Math.Max(result[i + 1] + 1, result[i]);
            }
        }
        return result.Sum(q => q);
    }
}
}