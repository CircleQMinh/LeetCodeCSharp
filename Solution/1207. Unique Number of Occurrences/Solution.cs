using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhVu
{
    public class Solution
    {
        public bool UniqueOccurrences(int[] arr)
        {
            var dic = new Dictionary<int, int>();
            foreach (var item in arr)
            {
                if (!dic.ContainsKey(item))
                {
                    dic.Add(item, 0);
                }
                dic[item]++;
            }

            var set = new HashSet<int>();
            foreach (var item in dic)
            {
                if (!set.Add(item.Value))
                {
                    return false;
                }
            }

            return true;
        }
    }
}