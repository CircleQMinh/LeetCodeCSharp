using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhVu
{
    public class Solution {
        //public IList<IList<int>> PermuteUnique(int[] nums)
        //{
        //    var result = new List<IList<int>>();
        //    GeneratePermuteUnique(nums, result, new List<int>());
        //    return result;
        //}
        //public void GeneratePermuteUnique(int[] nums, IList<IList<int>> result, List<int> current)
        //{
        //    if (current.Count == nums.Length)
        //    {
        //        var list = new List<int>();
        //        var isDup = false;
        //        foreach (int i in current) { 
        //            list.Add(nums[i]);
        //        }
        //        foreach (var item in result) {
        //            if (item.SequenceEqual(list))
        //            {
        //                isDup = true;
        //                break;
        //            }
        //        }
        //        if (!isDup)
        //        {
        //            result.Add(list);
        //        }

        //    }
        //    for (int i = 0; i < nums.Length; i++)
        //    {
        //        if (!current.Contains(i))
        //        {
        //            current.Add(i);
        //            GeneratePermuteUnique(nums, result, current);
        //            current.RemoveAt(current.Count - 1);
        //        }
        //    }
        //}
        public IList<IList<int>> PermuteUnique(int[] nums)
        {
            var result = new List<IList<int>>(); 
            Array.Sort(nums); // Sort to skip duplicates
            GeneratePermuteUnique(nums,new bool[nums.Length], result, new List<int>());
            return result;
        }
        public void GeneratePermuteUnique(int[] nums, bool[] used,IList<IList<int>> result, List<int> current)
        {
            if (current.Count == nums.Length)
            {
                result.Add(new List<int>(current));
            }
            for (int i = 0; i < nums.Length; i++)
            {
                if (used[i]) {
                    continue;
                }
                if (i > 0 && nums[i] == nums[i-1] && !used[i-1])//if nums[i-1]  have not been used and nums[i-1]=num[i]
                {
                    continue;                                   //skip because dont want to start another list with the same number
                }
                current.Add(nums[i]);
                used[i] = true;
                GeneratePermuteUnique(nums, used,result, current);
                current.RemoveAt(current.Count - 1);
                used[i] = false;
            }
        }
    }
}