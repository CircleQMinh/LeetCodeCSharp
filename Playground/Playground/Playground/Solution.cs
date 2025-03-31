using System;
using System.ComponentModel;
using System.Text.RegularExpressions;

namespace Playground
{
    public class Solution
    {
        //public int RemoveDuplicates(int[] nums)
        //{
        //    int i = 1;
        //    int count = 0;
        //    while (i < nums.Length)
        //    {
        //        if (nums[count] != nums[i])
        //        {
        //            count++;
        //            nums[count] = nums[i];
        //        }
        //        i++;
        //    }
        //    return nums.Length == 0 ? 0 : count + 1;
        //}
        public int RemoveElement(int[] nums, int val)
        {
            int i = 0;
            int j = 0;
            int count = 0;
            while (i < nums.Length && j < nums.Length)
            {
                if (nums[j] != val)
                {
                    nums[i] = nums[j];
                    i++;

                }
                else
                {
                    count++;
                }
                j++;
            }

            return nums.Length == 0 ? 0 : nums.Length - count;
        }

        //public int StrStr(string haystack, string needle)
        //{
        //    var result = -1;
        //    if (needle.Length>haystack.Length)
        //    {
        //        return result;
        //    }
        //    var needleStartIndex = 0;
        //    for (int i = 0; i < haystack.Length; i++) {
        //        if (needleStartIndex == needle.Length)
        //        {
        //            return result + 1 - needle.Length;
        //        }
        //        if (haystack[i] == needle[needleStartIndex])
        //        {
        //           result = i;
        //           needleStartIndex++;
        //        }
        //        else
        //        {
        //            result = -1;
        //            i -= needleStartIndex;
        //            needleStartIndex = 0;

        //        }
        //    }
        //    return needleStartIndex == needle.Length ? result + 1 - needle.Length : -1;
        //}

        public int StrStr(string haystack, string needle)
        {
            int n = haystack.Length;
            int m = needle.Length;

            if (m == 0) return 0; // Edge case: empty pattern
            if (n < m) return -1; // Edge case: pattern is longer than text

            // Step 1: Build the LPS array
            int[] lps = BuildLPS(needle);

            // Step 2: Perform pattern matching
            int i = 0; // index for text
            int j = 0; // index for pattern

            while (i < n)
            {
                if (haystack[i] == needle[j])
                {
                    i++;
                    j++;
                }

                if (j == m) // Full match found
                {
                    return i - j; // Return the starting index of the match
                }
                else if (i < n && haystack[i] != needle[j])
                {
                    if (j != 0)
                    {
                        j = lps[j - 1]; // Use LPS array to skip unnecessary comparisons
                    }
                    else
                    {
                        i++;
                    }
                }
            }

            return -1; // No match found
        }
        public int[] BuildLPS(string pattern)
        {
            int m = pattern.Length;
            int[] lps = new int[m];
            int length = 0; // Length of the previous longest prefix suffix
            int i = 1;

            lps[0] = 0; // LPS[0] is always 0

            while (i < m)
            {
                if (pattern[i] == pattern[length])
                {
                    length++;
                    lps[i] = length;
                    i++;
                }
                else
                {
                    if (length != 0)
                    {
                        length = lps[length - 1];
                    }
                    else
                    {
                        lps[i] = 0;
                        i++;
                    }
                }
            }

            return lps;
        }

        public void NextPermutation(int[] nums)
        {
            var left = nums.Length - 2;
            var right = nums.Length - 1;
            var limit = right - 1;
            var isSwap = false;
            while (left >= limit && right >= 1 && limit >= 0)
            {
                if (nums[right] > nums[left])
                {
                    var t = nums[left];
                    nums[left] = nums[right];
                    nums[right] = t;
                    isSwap = true;
                    break;
                }
                else
                {
                    left--;

                }
                if (left < limit)
                {
                    right--;
                    left = right - 1;
                }
                if (right == limit)
                {
                    right = nums.Length - 1;
                    left = right - 1;
                    limit--;
                }
            }

            if (!isSwap)
            {
                for (int i = 0; i < nums.Length; i++)
                {
                    for (int j = i + 1; j < nums.Length; j++)
                    {
                        if (nums[i] > nums[j])
                        {
                            var t = nums[i];
                            nums[i] = nums[j];
                            nums[j] = t;
                        }
                    }
                }
            }
            else
            {
                for (int i = left + 1; i < nums.Length; i++)
                {
                    for (int j = i + 1; j < nums.Length; j++)
                    {
                        if (nums[i] > nums[j])
                        {
                            var t = nums[i];
                            nums[i] = nums[j];
                            nums[j] = t;
                        }
                    }
                }
            }

        }

        public int[] SearchRange(int[] nums, int target)
        {
            var l = -1;
            var r = -1;

            int left = 0;
            int right = nums.Length - 1;

            while (left <= right)
            {
                int middle = left + (right - left) / 2;

                if (nums[middle] == target)
                {
                    var index = middle;
                    for (int i = index; i >= 0; i--)
                    {
                        if (nums[i] == target)
                        {
                            l = i;
                        }
                    }
                    for (int i = index; i <= nums.Length - 1; i++)
                    {
                        if (nums[i] == target)
                        {
                            r = i;
                        }
                    }
                    break;
                }

                if (nums[middle] < target)
                {
                    left = middle + 1;
                }
                else
                {
                    right = middle - 1;
                }
            }



            return [l, r];
        }

        public int BinarySearch(int[] array, int target)
        {
            int left = 0;
            int right = array.Length - 1;

            while (left <= right)
            {
                int middle = left + (right - left) / 2;

                if (array[middle] == target)
                {
                    return middle;
                }

                if (array[middle] < target)
                {
                    left = middle + 1;
                }
                else
                {
                    right = middle - 1;
                }
            }

            return -1;
        }

        public int SearchInsert(int[] nums, int target)
        {
            var result = -1;

            int left = 0;
            int right = nums.Length - 1;
            while (left <= right)
            {
                int middle = left + (right - left) / 2;
                if (nums[middle] == target)
                {
                    result = middle;
                    return result;
                }
                if (nums[middle] < target)
                {
                    left = middle + 1;
                }
                if (nums[middle] > target)
                {
                    right = middle - 1;
                }

            }
            result = left;

            return result;
        }

        public bool IsValidSudoku(char[][] board)
        {
            var set = new HashSet<string>();
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    var c = board[i][j];
                    if (!c.Equals('.'))
                    {
                        if (!(
                        set.Add($"Number {c} on row {i}")
                        && set.Add($"Number {c} on col {j}")
                        && set.Add($"Number {c} on box {i / 3},{j / 3}")
                        ))
                        {
                            return false;
                        }

                    }
                }
            }
            return true;
        }

        public void SolveSudoku(char[][] board)
        {
            if (!IsValidSudoku(board))
            {
                return;
            }
            InsertToBoard(board);
        }


        public bool InsertToBoard(char[][] board)
        {

            var (i, j) = FindFirstEmptySpace(board);
            if (i < 0)
            {
                return true;
            }
            for (char num = '1'; num <= '9'; num++)
            {
                if (IsValidPlacement(board, i, j, num))
                {
                    board[i][j] = num;
                    //if (IsValidSudoku(board) && InsertToBoard(board)) // too slow
                    if (InsertToBoard(board))
                    {
                        return true;
                    }
                }
                board[i][j] = '.';
            }

            return false;
        }

        public bool IsValidPlacement(char[][] board, int row, int col, char c)
        {
            for (int i = 0; i < 9; i++)
            {
                // check the row.
                if (board[row][i] == c)
                {
                    return false;
                }
                // check the column.
                if (board[i][col] == c)
                {
                    return false;
                }
                //  3x3 box.
                int boxRow = 3 * (row / 3) + i / 3;
                int boxCol = 3 * (col / 3) + i % 3;
                if (board[boxRow][boxCol] == c)
                {
                    return false;
                }
            }
            return true;
        }

        public (int curI, int curJ) FindFirstEmptySpace(char[][] board)
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (board[i][j].Equals('.'))
                    {
                        return (i, j);
                    }
                }
            }
            return (-1, -1);
        }

        public IList<IList<int>> ThreeSum(int[] nums)
        {
            IList<IList<int>> list = new List<IList<int>>();
            nums = nums.OrderBy(q => q).ToArray(); //-4 -1 -1 0 1 2

            for (int i = 0; i < nums.Length - 2; i++)
            {
                if (i > 0 && nums[i] == nums[i - 1])
                {
                    continue;
                }

                var j = i + 1;
                var k = nums.Length - 1;

                while (j < k)
                {
                    var sum = nums[i] + nums[j] + nums[k];
                    if (sum == 0)
                    {
                        var add = new List<int> { nums[i], nums[j], nums[k] };
                        list.Add(add);
                        j++;
                        while (nums[j] == nums[j - 1] && j < k)
                        {
                            j++;
                        }

                    }
                    else if (sum > 0)
                    {
                        k--;
                    }
                    else
                    {
                        j++;
                    }
                }
            }

            return list;
        }

        public IList<IList<int>> FourSum(int[] nums, int target)
        {
            IList<IList<int>> list = new List<IList<int>>();
            nums = nums.OrderBy(q => q).ToArray(); //-4 -1 -1 0 1 2

            for (int a = 0; a < nums.Length - 3; a++)
            {
                if (a > 0 && nums[a] == nums[a - 1])
                {
                    continue;
                }
                for (int b = a + 1; b < nums.Length - 2; b++)
                {
                    if (b > a + 1 && nums[b] == nums[b - 1])
                    {
                        continue;
                    }

                    var c = b + 1;
                    var d = nums.Length - 1;

                    while (c < d)
                    {
                        // cast numbers to long to avoid overflow lol
                        long sum = (long)nums[a] + nums[b] + nums[c] + nums[d];
                        if (sum == target)
                        {
                            var add = new List<int> { nums[a], nums[b], nums[c], nums[d] };
                            list.Add(add);
                            c++;
                            while (nums[c] == nums[c - 1] && c < d)
                            {
                                c++;
                            }
                        }
                        else if (sum > target)
                        {
                            d--;
                        }
                        else
                        {
                            c++;
                        }
                    }
                }
            }
            return list;
        }

        public int Search(int[] nums, int target)
        {
            var original = new int[nums.Length];

            var pivot = 0;
            var index = 0;
            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] < nums[i - 1])
                {
                    pivot = i;
                }
            }
            if (pivot >= 0)
            {
                for (int i = pivot; i < nums.Length; i++)
                {
                    original[index] = nums[i];
                    index++;
                }
                for (int i = 0; i < pivot; i++)
                {
                    original[index] = nums[i];
                    index++;
                }
            }

            var result = BinarySearch(original, target);

            return result > -1 ? (result + pivot) % nums.Length : -1;
        }

        public string CountAndSay(int n)
        {
            if (n == 1)
            {
                return "1";
            }
            else
            {
                var s = CountAndSay(n - 1);
                return ConvertToPair(s);
            }

        }

        public string ConvertToPair(string s)
        {
            var result = "";
            var resultList = new List<(int count, char c)>();
            var currentChar = 'x';
            var currentCount = 0;

            for (int i = 0; i < s.Length; i++)
            {
                if (currentChar != s[i])
                {
                    if (!(currentChar == 'x'))
                    {
                        resultList.Add((currentCount, s[i - 1]));
                    }
                    currentChar = s[i];
                    currentCount = 0;
                }

                currentChar = s[i];
                currentCount++;
            }
            resultList.Add((currentCount, s[s.Length - 1]));

            for (int i = 0; i < resultList.Count; i++)
            {
                result += $"{resultList[i].count}{resultList[i].c}";
            }

            return result;
        }

        public IList<IList<int>> CombinationSum(int[] candidates, int target)
        {
            IList<IList<int>> g = new List<IList<int>>();
            GenerateCombinations(new List<int>(), candidates, target, g);

            return g;
        }

        public void GenerateCombinations(List<int> current, int[] candidates, int target, IList<IList<int>> result)
        {
            var sum = CalculateSum(current);
            if (sum == target)
            {
                var newCombination = new List<int>();
                foreach (int i in current)
                {
                    newCombination.Add(i);
                }
                newCombination.Sort();
                var isDup = false;
                foreach (var item in result)
                {
                    if (IsSameCombination(newCombination, item.ToList()))
                    {
                        isDup = true;
                        break;
                    }
                }
                if (!isDup)
                {
                    result.Add(newCombination);
                }
            }

            for (int i = 0; i < candidates.Length; i++)
            {
                if (IsValidAdd(current, candidates[i], target))
                {
                    current.Add(candidates[i]);
                    GenerateCombinations(current, candidates, target, result);
                    current.Remove(candidates[i]);
                }
            }
        }

        public bool IsSameCombination(IList<int> a, IList<int> b)
        {
            if (a.Count != b.Count)
            {
                return false;
            }
            for (int i = 0; i < a.Count; i++)
            {
                if (a[i] != b[i])
                {
                    return false;
                }
            }
            return true;
        }

        public bool IsValidAdd(List<int> current, int add, int target)
        {
            return CalculateSum(current) + add <= target;
        }
        public int CalculateSum(List<int> current)
        {
            var sum = 0;
            for (int i = 0; i < current.Count; i++)
            {
                sum += current[i];
            }
            return sum;
        }

        public IList<IList<int>> CombinationSum2(int[] candidates, int target)
        {
            IList<IList<int>> g = new List<IList<int>>();
            Array.Sort(candidates);
            GenerateCombinations2(0, new List<int>(), candidates, target, g);

            return g;
        }

        public void GenerateCombinations2(int currentIndex, List<int> current, int[] candidates, int target, IList<IList<int>> result)
        {
            if (target == 0)
            {
                var newCombination = new List<int>();
                foreach (int i in current)
                {
                    newCombination.Add(i);
                }
                newCombination.Sort();
                result.Add(newCombination);

            }

            for (int i = currentIndex; i < candidates.Length; i++)
            {
                if (i > currentIndex && candidates[i] == candidates[i - 1])
                {
                    continue;
                }
                if (candidates[i] <= target)
                {
                    current.Add(candidates[i]);
                    GenerateCombinations2(i + 1, current, candidates, target - candidates[i], result);
                    current.RemoveAt(current.Count - 1);
                }
                else
                {
                    break; // if candidates[i] > target then all candidates[i + n] will > target
                }

            }
        }
        public int FirstMissingPositive(int[] nums)
        {
            //var n = nums.Length;
            //var set = new HashSet<int>();
            //for (int i = 0; i < n; i++) { 
            //    var cell = nums[i];
            //    if (cell <= 0 || cell > n)
            //    {
            //        continue;
            //    }
            //    set.Add(nums[i]);
            //}

            //for (int i = 1; i <= n; i++)
            //{
            //    if (!set.Contains(i))
            //    {
            //        return i;
            //    }
            //}

            //return n + 1;



            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] <= 0 || nums[i] > nums.Length)
                {
                    nums[i] = nums.Length + 1;
                }

            }

            for (int i = 0; i < nums.Length; i++)
            {
                int value = Math.Abs(nums[i]);
                if (value > nums.Length)
                {
                    continue;
                }
                value = value - 1; // array start at 0, result start at 1
                if (nums[value] > 0) // convert cell at [value] to a negative number
                {
                    nums[value] = nums[value] * -1;
                }


            }

            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] > 0)
                {
                    return i + 1;
                }
            }
            return nums.Length + 1;
        }

        //public int Jump(int[] nums)
        //{
        //    var steps = new List<int>();
        //    var solutions = new List<List<int>>();

        //    TryJump(nums,0,steps,solutions);
        //    return solutions[0].Count;
        //}

        //public void TryJump (int[] nums, int currentPos, List<int> steps, List<List<int>> solutions)
        //{
        //    var n = nums.Length;
        //    if (currentPos == n - 1)
        //    {
        //        if (solutions.Count == 0 || solutions[0].Count > steps.Count)
        //        {
        //            solutions.Clear();
        //            solutions.Add(new List<int>(steps));
        //        }
        //    }
        //    var currentPosNumberOfStep = nums[currentPos];
        //    for (int i = 1; i <= currentPosNumberOfStep; i++) {
        //        var nextPos = currentPos + i;
        //        if (nextPos < n)
        //        {
        //            steps.Add(i);
        //            TryJump(nums, nextPos, steps, solutions);
        //            steps.RemoveAt(steps.Count - 1);
        //        }
        //    }
        //}

        public int Jump(int[] nums)
        {
            if (nums.Length == 1)
            {
                return 0;
            }

            var jumps = 0;
            var currentMaxPos = 0;
            var currentPos = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                currentMaxPos = Math.Max(currentMaxPos, i + nums[i]);
                if (i == currentPos) // if index catch up to current pos -> jump
                {
                    jumps++; // plus 1 jump at start
                    currentPos = currentMaxPos;
                }
                if (currentPos >= nums.Length - 1)
                {
                    break;
                }

            }
            return jumps;
        }

        public IList<IList<int>> Permute(int[] nums)
        {
            var result = new List<IList<int>>();
            GeneratePermute(nums, result, new List<int>());
            return result;
        }
        public void GeneratePermute(int[] nums, IList<IList<int>> result, List<int> current)
        {
            if (current.Count == nums.Length)
            {
                result.Add(new List<int>(current));
            }
            for (int i = 0; i < nums.Length; i++)
            {
                if (!current.Contains(nums[i]))
                {
                    current.Add(nums[i]);
                    GeneratePermute(nums, result, current);
                    current.RemoveAt(current.Count - 1);
                }
            }
        }
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
            GeneratePermuteUnique(nums, new bool[nums.Length], result, new List<int>());
            return result;
        }
        public void GeneratePermuteUnique(int[] nums, bool[] used, IList<IList<int>> result, List<int> current)
        {
            if (current.Count == nums.Length)
            {
                result.Add(new List<int>(current));
            }
            for (int i = 0; i < nums.Length; i++)
            {
                if (used[i])
                {
                    continue;
                }
                if (i > 0 && nums[i] == nums[i - 1] && !used[i - 1])//if nums[i-1]  have not been used and nums[i-1]=num[i]
                {
                    continue;                                   //skip because dont want to start another list with the same number
                }
                current.Add(nums[i]);
                used[i] = true;
                GeneratePermuteUnique(nums, used, result, current);
                current.RemoveAt(current.Count - 1);
                used[i] = false;
            }
        }
        public void Rotate(int[][] matrix)
        {
            var n = matrix.Length;

            for (int i = 0; i < n - 1; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    var t = matrix[i][j];
                    matrix[i][j] = matrix[j][i];
                    matrix[j][i] = t;
                }
            }
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n / 2; j++)
                {
                    var t = matrix[i][j];
                    matrix[i][j] = matrix[i][n - 1 - j];
                    matrix[i][n - 1 - j] = t;
                }
            }
        }

        public IList<IList<string>> GroupAnagrams(string[] strs)
        {
            var result = new List<IList<string>>();
            var dict = new Dictionary<string, List<string>>();

            foreach (var str in strs)
            {
                var sortedStr = SortStringByChar(str);
                if (!dict.ContainsKey(sortedStr))
                {
                    dict.Add(sortedStr, new List<string>());
                }
                dict[sortedStr].Add(str);
            }
            foreach (var key in dict.Keys)
            {
                var hashset = dict[key];
                result.Add(hashset);
            }
            return result;
        }

        public string SortStringByChar(string str)
        {
            var chars = str.ToList();
            chars = chars.Order().ToList();
            var result = "";
            foreach (var item in chars)
            {
                result += item;
            }
            return result;
        }

        public void Merge(int[] nums1, int m, int[] nums2, int n)
        {
            var i = 0;
            var j = 0;

            for (int k = m; k < m + n; k++)
            {
                nums1[i] = int.MaxValue;
            }

            while (j < n)
            {
                if (nums1[i] > nums2[j])
                {
                    for (int k = m + n - 1; k > i; k--)
                    {
                        nums1[k] = nums1[k - 1];
                    }
                    nums1[i] = nums2[j];
                    j++;
                }
                i++;
            }
        }

        public int RemoveDuplicates(int[] nums)
        {
            var count = 0;
            if (nums.Length < 3)
            {
                return nums.Length;
            }
            for (int i = 1; i < nums.Length - 1 - count; i++)
            {
                if (nums[i] == nums[i - 1] && nums[i] == nums[i + 1])
                {
                    count++;
                    for (int j = i + 1; j < nums.Length - 1; j++)
                    {
                        nums[j] = nums[j + 1];
                    }
                    i--;
                }
            }

            return nums.Length - count;
        }
        public int MajorityElement(int[] nums)
        {
            var result = nums[0];
            var count = 1;
            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] != result)
                {
                    count--;
                }
                else
                {
                    count++;
                }
                if (count == 0)
                {
                    result = nums[i];
                    count = 1;
                }
            }
            return result;
        }
        public void Rotate(int[] nums, int k)
        {
            var time = k < nums.Length ? k : k % nums.Length;

            ReverseArray(nums, 0, nums.Length - 1);
            ReverseArray(nums, 0, time - 1);
            ReverseArray(nums, time, nums.Length - 1);

        }

        public void ReverseArray(int[] nums, int start, int end)
        {
            while (start < end)
            {
                (nums[start], nums[end]) = (nums[end], nums[start]);
                start++;
                end--;
            }

        }

        public int MaxProfit(int[] prices)
        {
            var profit = 0;
            var dayToBuy = 0;
            for (int i = 1; i < prices.Length; i++)
            {
                if (prices[dayToBuy] < prices[i])
                {
                    profit = prices[i] - prices[dayToBuy] > profit ? prices[i] - prices[dayToBuy] : profit;
                }
                else
                {
                    dayToBuy = i;
                }
            }

            return profit;
        }
        public int HIndex(int[] citations)
        {
            if (citations.Length == 0)
            {
                return 0;
            }
            Array.Sort(citations);

            int i; int h;
            i = citations.Length - 1;
            h = citations.Length;
            var count = 0;

            while (h > 0 && i >= 0)
            {
                if (citations[i] >= h)
                {
                    count++;
                    i--;
                }
                else
                {
                    h--;
                }
                if (count == h)
                {
                    return h;
                }
            }
            return h;
        }

        public int CanCompleteCircuit(int[] gas, int[] cost)
        {
            var startLocation = -1;
            var n = gas.Length;
            if (n < 2)
            {
                return gas[0] > cost[0] ? 0 : -1;
            }
            for (int i = 0; i < n; i++)
            {
                var index = i % n;
                if (gas[index] > cost[index])
                {
                    startLocation = index;
                    if (TryCompleCircuit(gas, cost, startLocation))
                    {
                        return startLocation;
                    }
                }
            }

            return -1;


        }
        public bool TryCompleCircuit(int[] gas, int[] cost, int start)
        {
            var n = gas.Length;
            var tank = 0;
            for (int i = 0; i < n; i++)
            {
                var index = (start + i) % n;
                tank += gas[index];
                if (tank < cost[index])
                {
                    return false;
                }
                tank -= cost[index];

            }
            return true;
        }
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
        public int Trap(int[] height)
        {
            var n = height.Length;
            var canHold = new int[n];
            Array.Fill(canHold, 0);
            var nextGreatestToTheRight = BiggestNumberToTheRight(height);
            // reverse input then reverse output
            var nextGreatestToTheLeft = (BiggestNumberToTheRight(height.Reverse().ToArray())).Reverse().ToArray();
            for (int i = 1; i < n - 1; i++)
            {
                var leftWall = nextGreatestToTheLeft[i];
                var rightWall = nextGreatestToTheRight[i];
                canHold[i] = Math.Min(leftWall, rightWall) - height[i];
            }
            return canHold.Where(q => q > 0).Sum(q => q);
        }
        public int[] BiggestNumberToTheRight(int[] arr)
        {
            int n = arr.Length;
            int[] result = new int[n];

            int maxFromRight = -1;

            for (int i = n - 1; i >= 0; i--)
            {
                int current = arr[i];
                result[i] = maxFromRight;
                maxFromRight = Math.Max(maxFromRight, current);
            }

            return result;
        }
        public int[] NextGreaterElement(int[] arr)
        {
            int n = arr.Length;
            int[] result = new int[n];
            Stack<int> stack = new Stack<int>();

            for (int i = n - 1; i >= 0; i--)  // Traverse from right to left
            {
                while (stack.Count > 0 && stack.Peek() <= arr[i]) // Pop smaller elements
                    stack.Pop();

                result[i] = (stack.Count > 0) ? stack.Peek() : -1; // Next greater element
                stack.Push(arr[i]); // Push current element
            }

            return result;
        }
        public int LengthOfLastWord(string s)
        {
            var n = s.Length;
            var count = 0;
            var i = n - 1;
            while (i >= 0)
            {
                if (s[i].Equals(' ') && count > 0)
                {
                    return count;
                }
                if (!s[i].Equals(' '))
                {
                    count++;
                }
                i--;
            }
            return count;
        }

        public string ReverseWords(string s)
        {
            var result = "";
            s = s.Trim();
            var split = s.Split(' ');
            for (int i = split.Length - 1; i >= 0; i--)
            {
                if (!string.IsNullOrEmpty(split[i]))
                {
                    result += split[i];
                    result += " ";
                }
            }
            return result.Trim();
        }
        public IList<string> FullJustify(string[] words, int maxWidth)
        {
            var result = new List<string>();
            var currentWords = new List<string>();

            foreach (var word in words)
            {
                var len = word.Length;
                if (!(maxWidth - len - currentWords.Count - currentWords.Sum(q => q.Length) >= 0))
                {
                    result.Add(Justify(currentWords, maxWidth));
                    currentWords.Clear();
                }
                currentWords.Add(word);
            }
            if (currentWords.Count > 0)
            {
                result.Add(JustifyLastLine(currentWords, maxWidth));
            }
            return result;
        }
        public string Justify(List<string> words, int maxWidth)
        {
            var result = string.Join(" ", words);
            var n = words.Count;
            var totalWordLen = result.Length;
            var emptySpaces = maxWidth - totalWordLen;
            while (emptySpaces > 0)
            {
                for (var i = 0; i < n && emptySpaces > 0; i++)
                {
                    var value = words[i];
                    if (value.Equals(words[n - 1]) && n > 1)
                    {
                        continue;
                    }
                    words[i] = words[i] + " ";
                    emptySpaces--;
                }
            }
            result = string.Join(" ", words);

            return result;
        }
        public string JustifyLastLine(List<string> words, int maxWidth)
        {
            var result = string.Join(" ", words);
            var totalWordLen = result.Length;
            var emptySpaces = maxWidth - totalWordLen;

            for (var i = 0; i < emptySpaces; i++)
            {
                result += " ";
            }
            return result;
        }
        public bool IsPalindrome(string s)
        {
            var list = s.Where(q => char.IsLetterOrDigit(q)).Select(q => char.ToLower(q)).ToList();
            var l = 0;
            var r = list.Count - 1;
            while (l < r)
            {
                if (list[l] != list[r])
                {
                    return false;
                }
                l++;
                r--;
            }

            return true;
        }
        public bool IsSubsequence(string s, string t)
        {
            var currentIndex = 0;
            for (var i = 0; i < t.Length && currentIndex < s.Length; i++)
            {
                if (s[currentIndex].Equals(t[i]))
                {
                    currentIndex++;
                }
            }
            return currentIndex == s.Length;
        }

        public int[] TwoSum(int[] numbers, int target)
        {
            var n = numbers.Length;
            var l = 0;
            var r = n - 1;
            while (l < r)
            {
                var sum = numbers[l] + numbers[r];
                if (sum > target)
                {
                    r--;
                }
                else if (sum < target)
                {
                    l++;
                }
                else
                {
                    return [l + 1, r + 1];
                }
            }
            return [l + 1, r + 1];
        }

        public int MinSubArrayLen(int target, int[] nums)
        {
            //return CheckSubArray(target,nums);
            var n = nums.Length;
            var l = 0;
            var r = 0;
            var sum = 0;
            var result = int.MaxValue;
            while (r < n)
            {
                sum += nums[r];
                while (sum >= target)
                {
                    var currentLen = r - l + 1;
                    result = Math.Min(result, currentLen);
                    sum -= nums[l];
                    l++;
                }
                r++;
            }
            return result == int.MaxValue ? 0 : result;
        }

        //public int CheckSubArray(int target, int[] nums, int currentLen = 1)
        //{
        //    var n = nums.Length;
        //    if (currentLen > nums.Length)
        //    {
        //        return 0;
        //    }

        //    for (var i = 0; i < n-currentLen+1; i++) { 
        //        var arr = new List<int>();
        //        for (var j = i; j < i+currentLen; j++)
        //        {
        //            arr.Add(nums[j]);
        //        }
        //        if (CalculateSumArray(arr) >= target)
        //        {
        //            return currentLen;
        //        }
        //    }
        //    return CheckSubArray(target,nums,currentLen+1);
        //}

        //public int CalculateSumArray(List<int> arr)
        //{
        //    return arr.Sum(x => x);
        //}

        public IList<int> SpiralOrder(int[][] matrix)
        {
            var result = new List<int>();
            var i = 0;
            var j = -1;
            var m = matrix.Length;
            var n = matrix[0].Length;
            var top = -1;
            var left = -1;
            var right = n;
            var bot = m;
            var dir = "right";
            var count = 0;
            while (count < m * n)
            {

                if (dir == "right")
                {
                    j++;
                    if (j == right)
                    {
                        top++;
                        dir = "down";
                        j--;
                        continue;
                    }
                }
                if (dir == "down")
                {
                    i++;
                    if (i == bot)
                    {
                        right--;
                        dir = "left";
                        i--;
                        continue;
                    }
                }
                if (dir == "left")
                {
                    j--;
                    if (j == left)
                    {
                        bot--;
                        dir = "up";
                        j++;
                        continue;
                    }
                }
                if (dir == "up")
                {
                    i--;
                    if (i == top)
                    {
                        left++;
                        dir = "right";
                        i++;
                        continue;
                    }
                }
                result.Add(matrix[i][j]);
                count++;
            }
            return result;
        }
        public void GameOfLife(int[][] board)
        {
            var m = board.Length;
            var n = board[0].Length;

            for (var i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    CheckElement(i, j, board);
                }
            }
            ReAssignBoard(board);

        }

        public void ReAssignBoard(int[][] board)
        {
            var deadToDead = 2;
            var deadToAlive = 3;
            var aliveToDead = 4;
            var aliveToAlive = 5;
            var m = board.Length;
            var n = board[0].Length;

            for (var i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (board[i][j] == deadToDead || board[i][j] == aliveToDead)
                    {
                        board[i][j] = 0;
                    }
                    if (board[i][j] == aliveToAlive || board[i][j] == deadToAlive)
                    {
                        board[i][j] = 1;
                    }
                }
            }
        }

        public void CheckElement(int x, int y, int[][] board)
        {
            var m = board.Length;
            var n = board[0].Length;

            var dirI = new int[] { -1, -1, -1, 0, 0, 1, 1, 1 };
            var dirJ = new int[] { -1, 0, 1, -1, 1, -1, 0, 1 };


            var deadToDead = 2;
            var deadToAlive = 3;
            var aliveToDead = 4;
            var aliveToAlive = 5;

            var numberAlive = 0;
            var numberDead = 0;

            for (int i = 0; i < 8; i++)
            {
                var row = x + dirI[i];
                var col = y + dirJ[i];

                if (row < 0 || col < 0 || row > m - 1 || col > n - 1)
                {
                    continue;
                }

                if (board[row][col] == 0 || board[row][col] == deadToDead || board[row][col] == deadToAlive)
                {
                    numberDead++;
                }
                if (board[row][col] == 1 || board[row][col] == aliveToDead || board[row][col] == aliveToAlive)
                {
                    numberAlive++;
                }
            }
            board[x][y] = board[x][y] == 0
                ? numberAlive == 3 ? deadToAlive : deadToDead
                : numberAlive == 2 || numberAlive == 3 ? aliveToAlive : aliveToDead;
        }

        public bool IsIsomorphic(string s, string t)
        {
            if (s.Length != t.Length)
            {
                return false;
            }

            var charS = s.Distinct().ToList();
            var charT = s.Distinct().ToList();

            if (charS.Count != charT.Count)
            {
                return false;
            }

            var map = new Dictionary<char, char>();
            for (int i = 0; i < charS.Count; i++)
            {
                map.Add(charS[i], charT[i]);
            }

            for (int i = 0; i < s.Length; i++)
            {
                if (map[s[i]] != t[i])
                {
                    return false;
                }
            }
            return true;
        }

        public IList<int> FindSubstring(string s, string[] words)
        {
            var result = new List<int>();
            var concatenatedString = new HashSet<string>();
            //GenerateConcatenatedStrings(words, new List<int>(), concatenatedString);
            //foreach (var item in concatenatedString) {
            //    var index = s.IndexOf(item);
            //    if (index >= 0)
            //    {
            //        result.Add(index);
            //    }
            //}

            var sLen = s.Length;
            var wordLen = words[0].Length;
            var wordCount = words.Length;

            if (sLen < wordLen * wordCount)
            {
                return result;
            }

            var numberOfWords = new Dictionary<string, int>();
            foreach (var word in words)
            {
                if (!numberOfWords.ContainsKey(word))
                {
                    numberOfWords.Add(word, 0);
                }
                numberOfWords[word]++;
            }
            var numberOfAppearWords = new Dictionary<string, int>();
            for (int i = 0; i < wordLen; i++)
            {
                var left = i;
                var right = i;
                while (right + wordLen <= sLen)
                {
                    var currentWord = s.Substring(right, wordLen);
                    right += wordLen;
                    if (numberOfWords.ContainsKey(currentWord))
                    {
                        if (!numberOfAppearWords.ContainsKey(currentWord))
                        {
                            numberOfAppearWords.Add(currentWord, 0);
                        }
                        numberOfAppearWords[currentWord]++;

                        // if a word appear too many times  remove 1 word from the start of current subtring (s[left] to s[right]) until false
                        while (numberOfAppearWords[currentWord] > numberOfWords[currentWord])
                        {
                            var wordToRemove = s.Substring(left, wordLen);
                            left += wordLen;
                            numberOfAppearWords[wordToRemove]--;
                        }
                        // if found a substring(s[left] to s[right] using all word in words add start index to result)
                        if (right - left == wordLen * wordCount)
                        {
                            result.Add(left);
                        }
                    }
                    else
                    {
                        // reset the dictionary use to check
                        numberOfAppearWords.Clear();
                        //skip current word, move to next one
                        left = right;
                    }

                }
                numberOfAppearWords.Clear();
            }


            return result;
        }

        //public void GenerateConcatenatedStrings(string[] words,List<int> current, HashSet<string> strings)
        //{
        //    if (current.Count == words.Length)
        //    {
        //        var stringToAdd = "";
        //        foreach (var item in current) { 
        //            stringToAdd += words[item];  
        //        }
        //        strings.Add(stringToAdd);
        //    }

        //    for (int i = 0; i < words.Length; i++) {
        //        if (!current.Contains(i))
        //        {
        //            current.Add(i);
        //            GenerateConcatenatedStrings(words, current, strings);
        //            current.RemoveAt(current.Count - 1);
        //        }
        //    }
        //}

        public string MinWindow(string s, string t)
        {
            if (s.Length < t.Length)
            {
                return "";
            }

            var charInT = new Dictionary<char, int>();
            foreach (char c in t)
            {
                if (!charInT.ContainsKey(c))
                {
                    charInT.Add(c, 0);
                }
                charInT[c]++;
            }

            var left = 0;
            var right = 0;
            var minLen = int.MaxValue;
            var minStart = 0;

            var charInCurrent = new Dictionary<char, int>();
            var numberOfTcharInCurrent = 0;
            var numberOfTchar = charInT.Count;
            while (right < s.Length)
            {
                var cRight = s[right];
                if (!charInCurrent.ContainsKey(cRight))
                {
                    charInCurrent.Add(cRight, 0);
                }
                charInCurrent[cRight]++;
                if (charInT.ContainsKey(cRight) && charInCurrent[cRight] == charInT[cRight])
                {
                    numberOfTcharInCurrent++;
                }

                while (numberOfTcharInCurrent == numberOfTchar)
                {
                    if (minLen > right - left + 1)
                    {
                        minLen = right - left + 1;
                        minStart = left;
                    }
                    var cLeft = s[left];
                    charInCurrent[cLeft]--;
                    if (charInT.ContainsKey(cLeft) && charInT[cLeft] > charInCurrent[cLeft])
                    {
                        numberOfTcharInCurrent--;
                    }
                    left++;

                }
                right++;
            }

            return minLen == int.MaxValue ? "" : s.Substring(minStart, minLen); ;
            //return FindMinWindow(charInT, s, t.Length);
        }

        //public string FindMinWindow(Dictionary<char,int> charInT, string s,int currentLen)
        //{
        //    if (s.Length-currentLen < 0)
        //    {
        //        return string.Empty;
        //    }
        //    for (int i = 0; i <= s.Length-currentLen; i++)
        //    {
        //        var current = s.Substring(i,currentLen);
        //        if (StringContainAllChar(new Dictionary<char, int>(charInT), current))
        //        {
        //            return current;
        //        }
        //    }
        //    return FindMinWindow(charInT, s, currentLen+1);
        //}

        //public bool StringContainAllChar(Dictionary<char, int> charInT, string current)
        //{
        //    foreach (var item in current)
        //    {
        //        if (charInT.ContainsKey(item))
        //        {
        //            charInT[item]--;
        //        }
        //    }
        //    return charInT.All(q => q.Value == 0);
        //}

        public bool IsAnagram(string s, string t)
        {
            if (s.Length != t.Length)
            {
                return false;
            }
            var map = new Dictionary<char, int>();
            foreach (char c in s)
            {
                if (!map.ContainsKey(c))
                {
                    map.Add(c, 0);
                }
                map[c]++;
            }

            foreach (char c in t)
            {
                if (!map.ContainsKey(c) || map[c] == 0)
                {
                    return false;
                }
                else
                {
                    map[c]--;
                }
            }
            return true;
        }

        public bool IsHappy(int n)
        {
            var map = new HashSet<int>();
            var sum = 0;
            while (true)
            {
                while (n > 9)
                {
                    var digit = n % 10;
                    n = n / 10;
                    sum += digit * digit;
                }
                sum += n * n;
                if (sum == 1)
                {
                    return true;
                }

                var success = map.Add(sum);
                if (!success)
                {
                    return false;
                }
                n = sum;
                sum = 0;
            }
        }

        public bool ContainsNearbyDuplicate(int[] nums, int k)
        {
            if (k > nums.Length)
            {
                return false;
            }
            var map = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (!map.ContainsKey(nums[i]))
                {
                    map.Add(nums[i], i);
                }
                else
                {
                    var result = Math.Abs(map[nums[i]] - i);
                    if (result <= k)
                    {
                        return true;
                    }
                    else
                    {
                        map[nums[i]] = i;
                    }
                }

            }
            return false;
        }

        public int LongestConsecutive(int[] nums)
        {
            //var map = new HashSet<int>();
            //var result = 0;

            //for (int i = 0; i < nums.Length; i++)
            //{

            //    var value = nums[i];
            //    map.Add(value);
            //    var count = 1;
            //    while (map.Contains(value-1))
            //    {
            //        count++;
            //        value--;
            //    }
            //    value = nums[i];
            //    while (map.Contains(value+1))
            //    {
            //        count++;
            //        value++;
            //    }
            //    if (count > result)
            //    {
            //        result = count;
            //    }
            //}

            //return result;
            if (nums.Length == 0)
            {
                return 0;
            }
            var map = new HashSet<int>(nums);
            var result = 0;
            foreach (int i in map)
            {
                if (!map.Contains(i - 1))
                {
                    var count = 1;
                    var value = i;
                    while (map.Contains(value + 1))
                    {
                        count++;
                        value++;
                    }
                    result = Math.Max(result, count);
                }
            }
            return result;
        }
        public IList<string> SummaryRanges(int[] nums)
        {
            if (nums.Length == 0)
            {
                return new List<string>();
            }
            var result = new List<string>();
            var previous = 0;
            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] - nums[i - 1] != 1)
                {
                    result.Add(ContructString(nums[previous], nums[i - 1]));
                    previous = i;
                }

            }
            result.Add(ContructString(nums[previous], nums[nums.Length - 1]));
            return result;
        }

        public string ContructString(int a, int b)
        {
            if (a == b)
            {
                return $"{a}";
            }
            return $"{a}->{b}";
        }
        public int[][] Merge(int[][] intervals)
        {
            var result = new List<int[]>();
            intervals = intervals.OrderBy(q => q[0]).ToArray();
            result.Add(intervals[0]);

            for (int i = 1; i < intervals.Length; i++)
            {

                var prevS = result[result.Count - 1][0];
                var prevE = result[result.Count - 1][1];
                var currS = intervals[i][0];
                var currE = intervals[i][1];

                if (prevS <= currS && currE <= prevE)
                {
                    result[result.Count - 1][0] = prevS;
                    result[result.Count - 1][1] = prevE;
                    continue;
                }
                if (currS <= prevE && prevE <= currE)
                {
                    result[result.Count - 1][0] = Math.Min(currS, prevS);
                    result[result.Count - 1][1] = currE;

                    continue;
                }
                if (currS <= prevS && prevS <= currE)
                {
                    result[result.Count - 1][0] = currS;
                    result[result.Count - 1][1] = Math.Max(currE, prevE);

                    continue;
                }
                if (currS <= prevS && prevE <= currE)
                {
                    result[result.Count - 1][0] = currS;
                    result[result.Count - 1][1] = currE;

                    continue;
                }

                result.Add(intervals[i]);

            }

            return result.DistinctBy(q => (q[0], q[1])).ToArray();
        }

        public int[][] Insert(int[][] intervals, int[] newInterval)
        {
            var result = new List<int[]>();
            var overlap = new List<int[]>();

            foreach (var interval in intervals)
            {
                var oldS = interval[0];
                var oldE = interval[1];
                var newS = newInterval[0];
                var newE = newInterval[1];
                if (oldS <= newE && newS <= oldE)
                {
                    overlap.Add(interval);
                }
                else
                {
                    result.Add(interval);
                }
            }
            overlap.Add(newInterval);
            var maxE = overlap.Max(q => q[1]);
            var minS = overlap.Min(q => q[0]);

            result.Add([minS, maxE]);

            return result.OrderBy(q => q[0]).ToArray();
        }

        public int FindMinArrowShots(int[][] points)
        {
            points = points.OrderBy(q => q[0]).ToArray();
            var result = 0;
            var overlap = new List<int[]>();
            overlap.Add(points[0]);
            for (var i = 1; i < points.Length; i++)
            {

                if (!IsAllOverlap(overlap, points[i]))
                {
                    result++;
                    overlap.Clear();
                }
                overlap.Add(points[i]);
            }

            return overlap.Count > 0 ? result + 1 : result;
        }

        public bool IsAllOverlap(List<int[]> currents, int[] newP)
        {
            foreach (var item in currents)
            {
                var oldS = item[0];
                var oldE = item[1];
                var newS = newP[0];
                var newE = newP[1];
                if (!(oldS <= newE && newS <= oldE))
                {
                    return false;
                }
            }
            return true;
        }

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

        public int Calculate(string s)
        {
            int length = s.Length;
            int sign = 1;
            int ans = 0;
            int currNo = 0;
            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < length; i++)
            {
                if (char.IsDigit(s.ElementAt(i)))
                {
                    currNo = s.ElementAt(i) - '0';
                    while (i + 1 < length && char.IsDigit(s.ElementAt(i + 1)))
                    {
                        currNo = currNo * 10 + s.ElementAt(i + 1) - '0';
                        i++;
                    }
                    currNo = currNo * sign;
                    ans += currNo;
                    currNo = 0;
                    sign = 1;
                }
                else if (s.ElementAt(i) == '+')
                {
                    sign = 1;
                }
                else if (s.ElementAt(i) == '-')
                {
                    sign = -1;
                }
                else if (s.ElementAt(i) == '(')
                {
                    stack.Push(ans);
                    stack.Push(sign);
                    ans = 0;
                    sign = 1;
                }
                else if (s.ElementAt(i) == ')')
                {
                    int prevSign = stack.Pop();
                    ans = prevSign * ans;
                    int precAns = stack.Pop();
                    ans = precAns + ans;
                }
            }
            return ans;
        }

        public bool HasCycle(ListNode head)
        {
            var set = new HashSet<ListNode>();

            while (head != null)
            {
                var success = set.Add(head);
                if (!success)
                {
                    return true;
                }
                head = head.next;
            }
            return false;
        }

        //public Node CopyRandomList(Node head)
        //{
        //    var set = new Dictionary<Node, Node>();

        //    var current = head;
        //    while (current != null) {
        //        var newNode = new Node(current.val);
        //        set.Add(current, newNode);
        //        current = current.next;
        //    }

        //    var newNodeHead = new Node(0);
        //    var result = newNodeHead;

        //    current = head;
        //    while (current != null) {
        //        var copy = set[current];
        //        newNodeHead.next = copy;
        //        newNodeHead.next.next = current.next == null ? null : set[current.next];
        //        newNodeHead.next.random = current.random == null ? null : set[current.random];
        //        if (newNodeHead.next != null)
        //        {
        //            newNodeHead = newNodeHead.next;
        //        }
        //        current = current.next;
        //    }



        //    return result.next;
        //}

        public ListNode CreateLinkedList(List<int> list)
        {
            var result = new ListNode();
            var current = result;
            foreach (var item in list)
            {
                current.next = new ListNode(item);
                current = current.next;
            }
            // Return head of the linked list
            return result.next;
        }
        public ListNode ReverseBetween(ListNode head, int left, int right)
        {
            if (right - left <= 0)
            {
                return head;
            }
            var current = head;
            var start = head;
            var end = new ListNode();
            var count = 0;

            var index = 0; // convert to 0-index
            left--;
            right--;


            var previous = end;

            while (current != null)
            {
                if (index >= left && index <= right)
                {

                    var newNode = new ListNode(current.val);
                    newNode.next = previous;
                    previous = newNode;
                }
                if (index == right + 1)
                {
                    end = current;
                }
                if (index == left - 1)
                {
                    start = current;
                }

                current = current.next;
                index++;
            }
            count = index;

            current = previous;
            index = 0;
            while (current.next != null)
            {
                if (index == right - left)
                {
                    break;
                }
                index++;
                current = current.next;
            }

            current.next = count - 1 == right ? null : end;
            start.next = previous;

            return left == 0 ? head.next : head;
        }

        public ListNode DeleteDuplicates(ListNode head)
        {
            var result = new ListNode();
            var set = new HashSet<int>();
            var valueToDelete = new HashSet<int>();

            var current = head;
            var currentResult = result;

            while (current != null)
            {
                var value = current.val;
                if (!set.Add(value))
                {
                    valueToDelete.Add(value);
                }
                current = current.next;

            }

            current = head;
            while (current != null)
            {
                var value = current.val;
                if (!valueToDelete.Contains(value))
                {
                    currentResult.next = new ListNode(value);
                    currentResult = currentResult.next;
                }
                current = current.next;
            }
            return result.next;
        }

        public ListNode RotateRight(ListNode head, int k)
        {
            if (head == null)
            {
                return null;
            }
            var end = new ListNode();
            var previous = new ListNode();
            var current = head;
            var n = 0;

            while (current != null)
            {
                n++;
                end = current;
                current = current.next;
            }
            k = k % n;
            if (k == 0)
            {
                return head;
            }
            end.next = head; //create a Circular Linked List 



            current = head;
            for (var i = 0; i < Math.Abs(k - n); i++)
            {
                previous = current;
                current = current.next;
            }
            previous.next = null; // not a Circular Linked List anymore

            return current;
        }
        public ListNode Partition(ListNode head, int x)
        {
            if (head == null)
            {
                return null;
            }
            ListNode current = head;
            ListNode prev = null;
            var list = new List<int>();

            while (current != null)
            {
                if (current.val < x)
                {
                    if (prev != null)
                    {
                        prev.next = current.next;
                    }
                    else
                    {
                        head = current.next;
                    }
                    list.Add(current.val);
                }
                else
                {
                    prev = current;
                }
                current = current.next;
            }
            ListNode result = new ListNode();
            current = result;
            foreach (var item in list)
            {
                current.next = new ListNode(item);
                current = current.next;
            }
            current.next = head;
            return result.next;
        }
        public TreeNode CreateTreeNode(List<int?> values)
        {
            if (values == null || values.Count == 0 || values[0] == null)
                return null;

            TreeNode root = new TreeNode(values[0].Value);
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);

            int i = 1;
            while (i < values.Count)
            {
                TreeNode current = queue.Dequeue();

                // Process left child
                if (i < values.Count && values[i] != null)
                {
                    current.left = new TreeNode(values[i].Value);
                    queue.Enqueue(current.left);
                }
                i++;

                // Process right child
                if (i < values.Count && values[i] != null)
                {
                    current.right = new TreeNode(values[i].Value);
                    queue.Enqueue(current.right);
                }
                i++;
            }

            return root;
        }



        public int MaxDepth(TreeNode root)
        {
            return FindMaxDepth(root, 0);
        }

        public int FindMaxDepth(TreeNode current, int max)
        {
            if (current == null)
            {
                return max;
            }
            var left = FindMaxDepth(current.left, max + 1);
            var right = FindMaxDepth(current.right, max + 1);
            return Math.Max(left, right);
        }
        public bool IsSameTree(TreeNode p, TreeNode q)
        {
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(p);
            queue.Enqueue(q);

            while (queue.Count > 0)
            {
                var pSide = queue.Dequeue();
                var qSide = queue.Dequeue();
                if ((pSide == null && qSide != null) || (pSide != null && qSide == null))
                {
                    return false;
                }
                if (pSide == null && qSide == null)
                {
                    continue;
                }
                if (qSide.val != pSide.val)
                {
                    return false;
                }

                queue.Enqueue(pSide.left);
                queue.Enqueue(qSide.left);
                queue.Enqueue(pSide.right);
                queue.Enqueue(qSide.right);

            }

            return true;
        }
        public TreeNode InvertTree(TreeNode root)
        {
            if (root == null)
            {
                return root;
            }
            var q = new Queue<TreeNode>();
            var listNode = new List<int?>();
            q.Enqueue(root);
            while ((q.Count > 0))
            {
                var current = q.Dequeue();

                if (current != null)
                {
                    listNode.Add(current.val);
                    q.Enqueue(current.right);
                    q.Enqueue(current.left);
                }
                else
                {
                    listNode.Add(null);
                }
            }

            var newRoot = new TreeNode(root.val);
            int i = 1;
            q.Enqueue(newRoot);
            while (i < listNode.Count)
            {
                var current = q.Dequeue();
                if (i < listNode.Count && listNode[i] != null)
                {
                    current.left = new TreeNode(listNode[i].Value);
                    q.Enqueue(current.left);
                }
                i++;
                if (i < listNode.Count && listNode[i] != null)
                {
                    current.right = new TreeNode(listNode[i].Value);
                    q.Enqueue(current.right);
                }
                i++;
            }
            return newRoot;
        }

        public bool IsSymmetric(TreeNode root)
        {
            var q = new Queue<TreeNode>();
            q.Enqueue(root.left);
            q.Enqueue(root.right);
            while (q.Count > 0)
            {
                var left = q.Dequeue();
                var right = q.Dequeue();
                if (left == null && right == null)
                {
                    continue;
                }
                if ((left == null && right != null) || (left != null && right == null))
                {
                    return false;
                }
                if (left.val != right.val)
                {
                    return false;

                }

                q.Enqueue(left.right);
                q.Enqueue(right.left);
                q.Enqueue(left.left);
                q.Enqueue(right.right);
            }
            return true;
        }

        //public TreeNode BuildTree(int[] preorder, int[] inorder)
        //{
        //    var queue = new Queue<int>(preorder);
        //    return BuildMyTree(queue, inorder); 

        //}

        public TreeNode BuildMyTree(Queue<int> queue, int[] inorder)
        {
            if (queue.Count > 0 && inorder.Length > 0)
            {
                var value = queue.Dequeue();
                var index = Array.IndexOf(inorder, value);
                var root = new TreeNode(value);
                var leftInOrder = new int[index];
                var rightInOrder = new int[inorder.Length - index - 1];
                leftInOrder = inorder.Take(index).ToArray();
                rightInOrder = inorder.Skip(index + 1).Take(inorder.Length - 1 - index).ToArray();
                root.left = BuildMyTree(queue, leftInOrder);
                root.right = BuildMyTree(queue, rightInOrder);
                return root;
            }
            return null;
        }

        public TreeNode BuildTree(int[] inorder, int[] postorder)
        {
            return BuildMyTreePostOrder(inorder, postorder);
        }
        public TreeNode BuildMyTreePostOrder(int[] inorder, int[] postorder)
        {
            if (postorder.Length > 0)
            {
                var value = postorder[postorder.Length - 1];
                var index = Array.IndexOf(inorder, value);
                var root = new TreeNode(value);

                var leftInOrder = new int[index];
                var rightInOrder = new int[inorder.Length - index - 1];
                var leftPostOrder = new int[index];
                var rightPostOrder = new int[postorder.Length - index - 1];

                leftInOrder = inorder.Take(index).ToArray();
                rightInOrder = inorder.Skip(index + 1).Take(inorder.Length - 1 - index).ToArray();

                leftPostOrder = postorder.Take(index).ToArray();
                rightPostOrder = postorder.Skip(index).Take(postorder.Length - index).ToArray();
                rightPostOrder = rightPostOrder.Take(rightPostOrder.Length - 1).ToArray(); // remove current node val

                root.right = BuildMyTreePostOrder(rightInOrder, rightPostOrder);
                root.left = BuildMyTreePostOrder(leftInOrder, leftPostOrder);

                return root;
            }
            return null;
        }

        //public Node Connect(Node root)
        //{
        //    if (root == null)
        //    {
        //        return root;
        //    }
        //    var queue = new Queue<Node>();
        //    queue.Enqueue(root);

        //    while (queue.Count > 0)
        //    {
        //        var count = queue.Count;
        //        Node prev = null;
        //        for (int i = 0; i < count; i++)
        //        {
        //            var node = queue.Dequeue();
        //            if (prev != null)
        //            {
        //                prev.next = node;
        //            }
        //            prev = node;

        //            if (node.left != null)
        //            {
        //                queue.Enqueue(node.left);
        //            }
        //            if (node.right != null)
        //            {
        //                queue.Enqueue(node.right);
        //            }

        //        }
        //    }
        //    return root;
        //}
        public void Flatten(TreeNode root)
        {
            if (root == null)
            {
                return;
            }

            if (root.left != null)
            {
                Flatten(root.left);
            }
            if (root.right != null)
            {
                Flatten(root.right);
            }
            if (root.left != null && root.right == null)
            {

                root.right = root.left;
                root.left = null;
                return;
            }
            if (root.left != null && root.right != null)
            {
                var current = root.left;
                while (current.right != null)
                {
                    current = current.right;
                }
                current.right = root.right;
                root.right = root.left;
                root.left = null;
            }
        }

        public bool HasPathSum(TreeNode root, int targetSum)
        {
            if (root == null)
            {
                return false;
            }
            if (root.left == null && root.right == null)
            {
                return targetSum == root.val;
            }
            var left = false;
            var right = false;
            if (root.left != null)
            {
                left = CalculatePathSum(root.left, targetSum, 0);
            }
            if (root.right != null)
            {
                right = CalculatePathSum(root.right, targetSum, 0);
            }

            return left || right;

        }

        public bool CalculatePathSum(TreeNode root, int targetSum, int current)
        {
            if (root == null)
            {
                return false;
            }
            var value = current + root.val;
            if (value == targetSum && root.left == null && root.right == null)
            {
                return true;
            }

            return CalculatePathSum(root.left, targetSum, value) || CalculatePathSum(root.right, targetSum, value);
        }

        public int SumNumbers(TreeNode root)
        {
            var result = new List<int>();
            CalcalatePathSum(root, 0, result);
            return result.Sum();
        }

        public void CalcalatePathSum(TreeNode root, int current, List<int> result)
        {
            if (root.left == null && root.right == null)
            {
                result.Add(current * 10 + root.val);
            }
            if (root.left != null)
            {
                CalcalatePathSum(root.left, current * 10 + root.val, result);
            }
            if (root.right != null)
            {
                CalcalatePathSum(root.right, current * 10 + root.val, result);
            }
        }

        public int MaxPathSum(TreeNode root)
        {
            var queue = new Queue<TreeNode>();
            var max = int.MinValue;
            queue.Enqueue(root);
            while (queue.Count > 0)
            {
                var node = queue.Dequeue();
                var left = Math.Max(MaxGain(node.left), 0); //if path gain is negative ignore it -> plus 0
                var right = Math.Max(MaxGain(node.right), 0);
                var currentPath = left + right + node.val;

                max = Math.Max(max, currentPath);
                if (node.left != null)
                {
                    queue.Enqueue(node.left);
                }
                if (node.right != null)
                {
                    queue.Enqueue(node.right);
                }

            }
            return max;
        }

        public int MaxGain(TreeNode root)
        {
            if (root == null)
            {
                return 0;
            }
            var gain = Math.Max(Math.Max(MaxGain(root.left), 0), Math.Max(MaxGain(root.right), 0));
            return gain + root.val;
        }

        public int CountNodes(TreeNode root)
        {
            if (root == null)
            {
                return 0;
            }
            int level = 0;
            var left = root;
            var right = root;
            while (right != null)
            {
                level++;
                left = left.left;
                right = right.right;
            }
            if (left == null) // check if this is a full tree, this always trigger once so the complexity is < o(n)
            {
                return (int)Math.Pow(2, level) - 1;
            }
            // if not full then Calculate like O(N) solution
            return 1 + CountNodes(root.left) + CountNodes(root.right);
        }

        public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            if (root == null || root.val == p.val || root.val == q.val)
            {
                return root;
            }

            var l = LowestCommonAncestor(root.left, p, q);
            var r = LowestCommonAncestor(root.right, p, q);

            if (l != null && r != null)
            {
                return root;
            }
            if (l == null && r != null)
            {
                return r;
            }
            if (l != null && r == null)
            {
                return l;
            }

            return null;
        }

        public IList<int> RightSideView(TreeNode root)
        {
            var result = new Dictionary<int, int>();
            FindRightMost(root, 0, result);
            return result.Select(q => q.Value).ToList();
        }

        public void FindRightMost(TreeNode root, int h, Dictionary<int, int> result)
        {
            if (root == null)
            {
                return;
            }
            if (!result.ContainsKey(h))
            {
                result.Add(h, root.val);
            }
            if (root.right != null)
            {
                FindRightMost(root.right, h + 1, result);
            }
            if (root.left != null)
            {
                FindRightMost(root.left, h + 1, result);
            }
        }
        public IList<double> AverageOfLevels(TreeNode root)
        {
            var result = new List<double>();
            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            while (queue.Count > 0)
            {
                double avg = 0;
                var count = queue.Count;
                for (int i = 0; i < count; i++)
                {
                    var node = queue.Dequeue();
                    if (node.left != null)
                    {
                        queue.Enqueue(node.left);
                    }
                    if (node.right != null)
                    {
                        queue.Enqueue(node.right);
                    }
                    avg += node.val;
                }
                avg /= count;
                result.Add(avg);
            }
            return result;
        }

        public IList<IList<int>> LevelOrder(TreeNode root)
        {
            var result = new List<IList<int>>();
            if (root == null)
            {

                return result;
            }
            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            while (queue.Count > 0)
            {
                var count = queue.Count;
                var list = new List<int>();
                for (int i = 0; i < count; i++)
                {
                    var node = queue.Dequeue();
                    if (node.left != null)
                    {
                        queue.Enqueue(node.left);
                    }
                    if (node.right != null)
                    {
                        queue.Enqueue(node.right);
                    }
                    list.Add(node.val);
                }
                result.Add(list);
            }
            return result;
        }
        public IList<IList<int>> ZigzagLevelOrder(TreeNode root)
        {
            var result = new List<IList<int>>();
            if (root == null)
            {
                return result;
            }
            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            var reverse = true;
            while (queue.Count > 0)
            {
                reverse = !reverse;
                var count = queue.Count;
                var list = new List<int>();
                for (int i = 0; i < count; i++)
                {
                    var node = queue.Dequeue();
                    if (node.left != null)
                    {
                        queue.Enqueue(node.left);
                    }
                    if (node.right != null)
                    {
                        queue.Enqueue(node.right);
                    }
                    list.Add(node.val);
                }
                if (reverse)
                {
                    list.Reverse();
                }
                result.Add(list);
            }
            return result;
        }
        public int GetMinimumDifference(TreeNode root)
        {
            var queue = new Queue<TreeNode>();
            var list = new List<int>();
            queue.Enqueue(root);
            while (queue.Count > 0)
            {
                var node = queue.Dequeue();
                if (node.left != null)
                {
                    queue.Enqueue(node.left);
                }
                if (node.right != null)
                {
                    queue.Enqueue(node.right);
                }
                list.Add(node.val);
            }
            var result = int.MaxValue;
            list = list.Order().ToList();
            for (int i = 0; i < list.Count - 1; i++)
            {
                var s = list[i + 1] - list[i];
                result = Math.Min(result, s);
            }
            return result;
        }
        public int KthSmallest(TreeNode root, int k)
        {
            var result = new List<int>();
            GetTreeNodeValueInOrder(root, result);
            return result[k];
        }
        public void GetTreeNodeValueInOrder(TreeNode root, List<int> result)
        {

            if (root.left != null)
            {
                GetTreeNodeValueInOrder(root.left, result);
            }
            result.Add(root.val);
            if (root.right != null)
            {
                GetTreeNodeValueInOrder(root.right, result);
            }
        }
        public bool IsValidBST(TreeNode root)
        {
            var result = new List<int>();
            GetTreeNodeValueInOrder(root, result);
            for (int i = 0; i < result.Count - 1; i++)
            {
                if (result[i] >= result[i + 1])
                {
                    return false;
                }
            }
            return true;
        }

        public int NumIslands(char[][] grid)
        {
            int count = 0;
            int m = grid.Length;
            int n = grid[0].Length;

            var directions = new (int X, int Y)[] { (-1, 0), (1, 0), (0, -1), (0, 1) };

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (grid[i][j] == '1') // Found an island
                    {
                        count++; // Once find an island check for another island near by and add that to the queue
                        var queue = new Queue<(int X, int Y)>();
                        queue.Enqueue((i, j));
                        grid[i][j] = '0'; // Mark as visited, use 0 instead of hashset to save memory since 0 is useless in this

                        while (queue.Count > 0)
                        {
                            var (x, y) = queue.Dequeue();

                            foreach (var (dx, dy) in directions)
                            {
                                int newX = x + dx, newY = y + dy;

                                if (newX >= 0 && newX < m && newY >= 0 && newY < n && grid[newX][newY] == '1') // Valid location and is an island
                                {
                                    queue.Enqueue((newX, newY));
                                    grid[newX][newY] = '0'; // Mark as visited
                                }
                            }
                        }
                    }
                }
            }

            return count;
        }

        public void Solve(char[][] board)
        {
            int m = board.Length;
            int n = board[0].Length;


            for (int i = 0; i < m; i++)
            {
                if (board[i][0] == 'O')
                {
                    MarkCantBeSurroundedRegion(board, i, 0);
                }
                if (board[i][n - 1] == 'O')
                {
                    MarkCantBeSurroundedRegion(board, i, n - 1);
                }
            }
            for (int i = 1; i < n - 1; i++)
            {

                if (board[0][i] == 'O')
                {
                    MarkCantBeSurroundedRegion(board, 0, i);
                }
                if (board[m - 1][i] == 'O')
                {
                    MarkCantBeSurroundedRegion(board, m - 1, i);
                }
            }

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (board[i][j] == 'O')
                    {
                        board[i][j] = 'X';
                    }
                    if (board[i][j] == 'Q')
                    {
                        board[i][j] = 'O';
                    }
                }
            }

        }
        public void MarkCantBeSurroundedRegion(char[][] board, int i, int j)
        {
            int m = board.Length;
            int n = board[0].Length;
            var directions = new (int X, int Y)[] { (-1, 0), (1, 0), (0, -1), (0, 1) };
            var queue = new Queue<(int X, int Y)>();
            queue.Enqueue((i, j));
            while (queue.Count > 0)
            {
                var (x, y) = queue.Dequeue();
                board[x][y] = 'Q'; // Mark 
                foreach (var (dx, dy) in directions)
                {
                    int newX = x + dx, newY = y + dy;

                    if (newX >= 0 && newX < m && newY >= 0 && newY < n && board[newX][newY] == 'O') // Valid location and is a region
                    {
                        queue.Enqueue((newX, newY));
                        board[newX][newY] = 'Q'; // Mark 
                    }
                }
            }
        }

        //public Node CloneGraph(Node node)
        //{
        //    if (node == null)
        //    {
        //        return null;
        //    }
        //    if (node.neighbors.Count == 0)
        //    {
        //        return new Node(node.val);
        //    }
        //    var set = new Dictionary<int, List<Node>>();
        //    CreateNodeToNeighborsMap(node, set);
        //    var created = new Dictionary<int, Node>();

        //    foreach (var item in set)
        //    {
        //        Node currentNode;
        //        if (!created.ContainsKey(item.Key))
        //        {
        //            currentNode = new Node(item.Key);
        //            created.Add(item.Key, currentNode);
        //        }
        //        else
        //        {
        //            currentNode = created[item.Key];
        //        }

        //        foreach (var nb in item.Value) {
        //            Node newNb;
        //            if (!created.ContainsKey(nb.val))
        //            {
        //                newNb = new Node(nb.val);
        //                created.Add(nb.val, newNb);
        //            }
        //            else { 
        //                newNb = created[nb.val];
        //            }
        //            currentNode.neighbors.Add(newNb);
        //        }
        //    }
        //    return created[1];
        //}

        //public void CreateNodeToNeighborsMap(Node node, Dictionary<int,List<Node>> set)
        //{
        //    var queue = new Queue<Node>();
        //    queue.Enqueue(node);
        //    while (queue.Count > 0) { 
        //        var current = queue.Dequeue();
        //        if (!set.ContainsKey(current.val))
        //        {
        //            set.Add(current.val, current.neighbors.ToList());
        //        }
        //        foreach (var item in current.neighbors)
        //        {
        //            if (item != null && !set.ContainsKey(item.val))
        //            {
        //                queue.Enqueue(item);
        //            }
        //        }

        //    }
        //}

        public double[] CalcEquation(IList<IList<string>> equations, double[] values, IList<IList<string>> queries)
        {
            var result = new double[queries.Count];
            var map = new Dictionary<(string x, string y), double>();
            var list = new Dictionary<string, Node>();

            for (int i = 0; i < equations.Count; i++)
            {
                var equation = equations[i];
                var v1 = equation[0];
                var v2 = equation[1];
                var value = values[i];

                Node currentV1 = !list.ContainsKey(v1) ? new Node(v1) : currentV1 = list[v1]; if (!list.ContainsKey(v1)) list.Add(v1, currentV1);
                Node currentV2 = !list.ContainsKey(v2) ? new Node(v2) : currentV2 = list[v2]; if (!list.ContainsKey(v2)) list.Add(v2, currentV2);

                if (!currentV1.neighbors.Contains(currentV2))
                {
                    currentV1.neighbors.Add(currentV2);
                }

                if (!currentV2.neighbors.Contains(currentV1))
                {
                    currentV2.neighbors.Add(currentV1);
                }

                if (!map.ContainsKey((v1, v2)))
                {
                    map.Add((v1, v2), value);
                    map.Add((v2, v1), 1 / value);
                }
            }

            for (int i = 0; i < queries.Count; i++)
            {
                var query = queries[i];
                var v1 = query[0];
                var v2 = query[1];

                if (!list.ContainsKey(v1) || !list.ContainsKey(v2))
                {
                    result[i] = (-1);
                    continue;
                }

                Node currentV1 = list[v1];
                Node currentV2 = list[v2];
                var path = FindPathFromV1ToV2(currentV1, currentV2, new List<string>(), new List<string>());
                if (path.Count == 0)
                {
                    result[i] = (-1);
                    continue;
                }
                var cal = 1d;
                for (int j = 0; j < path.Count - 1; j++)
                {
                    cal *= map[(path[j], path[j + 1])];
                }
                result[i] = (cal);
            }



            return result;
        }

        public List<string> FindPathFromV1ToV2(Node v1, Node v2, List<string> current, List<string> visited)
        {
            current.Add(v1.val);
            visited.Add(v1.val);
            if (v1.val == v2.val)
            {
                return current;
            }
            foreach (var item in v1.neighbors)
            {
                if (!visited.Contains(item.val))
                {
                    var s = FindPathFromV1ToV2(item, v2, current, visited);
                    if (s.Count > 0)
                    {
                        return s;
                    }
                    current.Remove(item.val);
                }
            }
            current.Remove(v1.val);
            return new List<string>();

        }
        public bool CanFinish(int numCourses, int[][] prerequisites)
        {
            var dictionary = new Dictionary<int, List<int>>();
            for (int i = 0; i < numCourses; i++)
            {
                dictionary.Add(i, new List<int>());
            }
            foreach (var item in prerequisites)
            {
                var need = item[0];
                var pre = item[1];
                dictionary[need].Add(pre);
            }
            foreach (var item in dictionary)
            {
                if (!CanFinishCourse(item.Key, dictionary, new HashSet<int>()))
                {
                    return false;
                }
            }
            return true;
        }

        public bool CanFinishCourse(int courseNumber, Dictionary<int, List<int>> prerequisites, HashSet<int> taken)
        {
            if (prerequisites[courseNumber].Count == 0)
            {
                return true;
            }
            if (!taken.Add(courseNumber))
            {
                return false;
            }

            foreach (var item in prerequisites[courseNumber])
            {
                if (!CanFinishCourse(item, prerequisites, taken))
                {
                    return false;
                }
            }
            // the course is proved to be valid, remove all of it prerequisites
            prerequisites[courseNumber].Clear();

            return true;
        }

        public int[] FindOrder(int numCourses, int[][] prerequisites)
        {
            var dictionary = new Dictionary<int, List<int>>();
            for (int i = 0; i < numCourses; i++)
            {
                dictionary.Add(i, new List<int>());
            }
            foreach (var item in prerequisites)
            {
                var need = item[0];
                var pre = item[1];
                dictionary[need].Add(pre);
            }
            var result = new List<int>();
            if (!IsCyclic(dictionary))
            {
                while (dictionary.Any(q => q.Value.Count == 0 && !result.Contains(q.Key)))
                {
                    var course = dictionary.FirstOrDefault(q => q.Value.Count == 0 && !result.Contains(q.Key));
                    foreach (var item in dictionary)
                    {
                        item.Value.Remove(course.Key);
                    }
                    result.Add(course.Key);
                }
                if (result.Count == dictionary.Count)
                {
                    return result.ToArray();
                }
                return new int[dictionary.Count];

            }
            return result.ToArray();
        }
        // Function to detect cycle in a directed graph
        public static bool IsCyclic(Dictionary<int, List<int>> adj)
        {
            int V = adj.Count;
            // Stores in-degree of each vertex
            int[] inDegree = new int[V];
            // Queue to store vertices with 0 in-degree
            Queue<int> q = new Queue<int>();
            int visited = 0; // Count of visited vertices

            // Calculate in-degree of each vertex
            for (int u = 0; u < V; u++)
            {
                foreach (int v in adj[u])
                {
                    inDegree[v]++;
                }
            }

            // Enqueue vertices with 0 in-degree
            for (int u = 0; u < V; u++)
            {
                if (inDegree[u] == 0)
                {
                    q.Enqueue(u);
                }
            }

            // BFS traversal
            while (q.Count > 0)
            {
                int u = q.Dequeue();
                visited++;
                // Reduce in-degree of adjacent vertices
                foreach (int v in adj[u])
                {
                    inDegree[v]--;
                    // If in-degree becomes 0, enqueue it
                    if (inDegree[v] == 0)
                    {
                        q.Enqueue(v);
                    }
                }
            }

            // If not all vertices are visited, cycle
            return visited != V;
        }
        public int SnakesAndLadders(int[][] board)
        {
            var result = int.MaxValue;
            var n = board.Length;
            var flatten = new int[(n * n) + 1];
            int count = 1;
            var reverse = false;
            for (int i = n - 1; i >= 0; i--)
            {
                if (reverse)
                {
                    for (int j = n - 1; j >= 0; j--)
                    {
                        flatten[count++] = board[i][j];

                    }
                }
                else
                {
                    for (int j = 0; j < n; j++)
                    {
                        flatten[count++] = board[i][j];

                    }
                }
                reverse = !reverse;

            }
            result = FindShortestPathForSnakeAndLadder(flatten);
            return result;
        }
        public int FindShortestPathForSnakeAndLadder(int[] board)
        {
            var distance = new int[board.Length];
            Array.Fill(distance, -1);
            var queue = new Queue<int>();
            queue.Enqueue(1);
            distance[1] = 0;
            while (queue.Count > 0)
            {
                var current = queue.Dequeue();
                for (int next = current + 1; next <= Math.Min(current + 6, board.Length - 1); next++) // [curr + 1, min(curr + 6, n2)]
                {
                    var dest = board[next] == -1 ? next : board[next];

                    if (distance[dest] == -1 || distance[current] + 1 < distance[dest])
                    {
                        distance[dest] = distance[current] + 1;
                        queue.Enqueue(dest);
                    }
                }
            }
            return distance[board.Length - 1];
        }
        public int MinMutation(string startGene, string endGene, string[] bank)
        {
            if (!bank.Contains(endGene))
            {
                return -1;
            }
            var n = startGene.Length;
            var queue = new Queue<string>();
            var map = new Dictionary<string, int>();
            var mutations = new List<char>() { 'A', 'G', 'T', 'C' };
            queue.Enqueue(startGene);
            map.Add(startGene, 0);
            map.Add(endGene, int.MaxValue);

            while (queue.Count > 0)
            {
                var current = queue.Dequeue();
                for (int i = 0; i < n; i++)
                {
                    foreach (char c in mutations)
                    {
                        var newGene = current.ToList();
                        newGene[i] = c;
                        var newGeneString = string.Join("", newGene);
                        if (bank.Contains(newGeneString))
                        {
                            var newGeneStep = map[current] + 1;
                            if (!map.ContainsKey(newGeneString))
                            {
                                queue.Enqueue(newGeneString);
                                map.Add(newGeneString, newGeneStep);
                            }
                            if ((map[newGeneString] > newGeneStep))
                            {
                                queue.Enqueue(newGeneString);
                                map[newGeneString] = newGeneStep;
                            }

                        }
                    }
                }
            }
            var result = map[endGene] == int.MaxValue ? -1 : map[endGene];
            return result;
        }

        public int LadderLength(string beginWord, string endWord, IList<string> wordList)
        {
            if (!wordList.Contains(endWord))
            {
                return 0;
            }

            var n = beginWord.Length;
            var queue = new Queue<string>();
            var set = new HashSet<string>();
            var wordSet = new HashSet<string>(wordList);

            var mutations = new HashSet<char>() { };
            for (int k = 'a'; k <= 'z'; k++)
            {
                mutations.Add((char)k);
            }

            queue.Enqueue(beginWord);
            set.Add(beginWord);

            var count = 1;
            while (queue.Count > 0)
            {

                var size = queue.Count;
                for (int i = 0; i < size; i++)
                {
                    var current = queue.Dequeue();
                    if (current.Equals(endWord))
                    {
                        return count;
                    }
                    for (int j = 0; j < n; j++)
                    {
                        var currentChar = current[j];
                        foreach (char c in mutations)
                        {
                            if (!c.Equals(currentChar))
                            {
                                var newWordArray = current.ToArray();
                                newWordArray[j] = c;
                                var newWord = new string(newWordArray);
                                if (wordSet.Contains(newWord) && !set.Contains(newWord))
                                {
                                    queue.Enqueue(newWord);
                                    set.Add(newWord);
                                }
                            }
                        }
                    }

                }
                count++;
            }

            return 0;
        }

        public IList<string> FindWords(char[][] board, string[] words)
        {
            var m = board.Length;
            var n = board[0].Length;
            var result = new HashSet<string>();
            var root = new TrieNode();
            foreach (var word in words)
            {
                InsertIntoTrie(word, root);
            }

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (root.Children.ContainsKey(board[i][j]))
                    {
                        DFSWordOnBoard(board, "", root, (i, j), result);
                    }
                }
            }

            return result.ToList();
        }
        private void InsertIntoTrie(string word, TrieNode root)
        {
            TrieNode node = root;
            foreach (char c in word)
            {
                if (!node.Children.ContainsKey(c))
                {
                    node.Children[c] = new TrieNode();
                }
                node = node.Children[c];
            }
            node.IsEnd = true;
        }

        public void DFSWordOnBoard(char[][] board, string word, TrieNode node, (int X, int Y) currentPos, HashSet<string> result)
        {
            var c = board[currentPos.X][currentPos.Y];
            if (!node.Children.ContainsKey(c))
            {
                return;
            }
            word += c;
            node = node.Children[c];

            if (node.IsEnd)
            {
                result.Add(word);
                node.IsEnd = false;
            }
            var directions = new (int X, int Y)[] { (-1, 0), (1, 0), (0, -1), (0, 1) };
            var m = board.Length;
            var n = board[0].Length;

            board[currentPos.X][currentPos.Y] = '#';
            foreach (var dir in directions)
            {
                var newX = currentPos.X + dir.X;
                var newY = currentPos.Y + dir.Y;
                if (newX >= 0 && newX < m && newY >= 0 && newY < n && board[newX][newY] != '#')
                {
                    DFSWordOnBoard(board, word, node, (newX, newY), result);
                }
            }
            board[currentPos.X][currentPos.Y] = c;
        }

        public IList<IList<int>> Combine(int n, int k)
        {
            var result = new HashSet<IList<int>>();
            GenerateCombanations(n, k, new List<int>(), result);
            return result.ToList();
        }

        public void GenerateCombanations(int n, int k, List<int> current, HashSet<IList<int>> result)
        {
            if (current.Count == k)
            {
                result.Add(new List<int>(current));
                return;
            }
            var lastNum = current.LastOrDefault();
            for (int i = 1; i <= n; i++)
            {
                if (i > lastNum)
                {
                    current.Add(i);
                    GenerateCombanations(n, k, current, result);
                    current.RemoveAt(current.Count - 1);
                }
            }
        }

        public int TotalNQueens(int n)
        {
            var board = new int[n, n];
            board.Initialize();
            var result = new HashSet<List<int[]>>();
            FindSolutionForNQueen(board, new List<int[]>(), result);
            return result.Count;
        }
        public void FindSolutionForNQueen(int[,] board, List<int[]> currentQ, HashSet<List<int[]>> result)
        {
            var n = board.GetLength(0);
            if (currentQ.Count == n)
            {
                result.Add(new List<int[]>(currentQ));
            }
            var lastQPlaceX = currentQ.Count > 0 ? currentQ.Last()[0] : -1;
            var lastQPlaceY = currentQ.Count > 0 ? currentQ.Last()[1] : -1;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if ((i > lastQPlaceX || (i == lastQPlaceX && j > lastQPlaceY)) && IsValidPlacementForQ(board, currentQ, i, j))
                    {
                        currentQ.Add([i, j]);
                        board[i, j] = 1;

                        FindSolutionForNQueen(board, currentQ, result);

                        currentQ.RemoveAt(currentQ.Count - 1);
                        board[i, j] = 0;
                    }
                }
            }
        }
        public bool IsValidPlacementForQ(int[,] board, List<int[]> currentQ, int placeX, int placeY)
        {
            var n = board.GetLength(0);
            if (board[placeX, placeY] == 1)
            {
                return false;
            }
            var directions = new (int X, int Y)[] { (-1, 0), (1, 0), (0, -1), (0, 1), (-1, -1), (-1, 1), (1, -1), (1, 1) };
            foreach (var dir in directions)
            {
                var newX = placeX + dir.X;
                var newY = placeY + dir.Y;
                while (newX >= 0 && newX < n && newY >= 0 && newY < n)
                {
                    if (board[newX, newY] == 1)
                    {
                        return false;
                    }
                    newX += dir.X;
                    newY += dir.Y;
                }

            }
            return true;
        }

        public bool Exist(char[][] board, string word)
        {
            var m = board.Length;
            var n = board[0].Length;
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (word[0].Equals(board[i][j]))
                    {
                        if (DFSWordInBoard(board, word, (i, j), 0))
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public bool DFSWordInBoard(char[][] board, string word, (int X, int Y) currentPos, int currentIndex)
        {
            var c = board[currentPos.X][currentPos.Y];
            if (word.Length == currentIndex + 1)
            {
                return word[currentIndex] == c;
            }


            if (word[currentIndex] != c)
            {
                return false;
            }

            var directions = new (int X, int Y)[] { (-1, 0), (1, 0), (0, -1), (0, 1) };
            var m = board.Length;
            var n = board[0].Length;

            board[currentPos.X][currentPos.Y] = '#';
            foreach (var dir in directions)
            {
                var newX = currentPos.X + dir.X;
                var newY = currentPos.Y + dir.Y;
                if (newX >= 0 && newX < m && newY >= 0 && newY < n && board[newX][newY] != '#')
                {
                    if (DFSWordInBoard(board, word, (newX, newY), currentIndex + 1))
                    {
                        return true;
                    }
                }
            }
            board[currentPos.X][currentPos.Y] = c;

            return false;
        }
        public TreeNode SortedArrayToBST(int[] nums)
        {

            var n = nums.Length;
            if (n == 0)
            {
                return null;
            }
            var middle = n / 2;
            var root = new TreeNode(nums[middle]);
            root.left = SortedArrayToBST(nums.Take(middle).ToArray());
            root.right = SortedArrayToBST(nums.Skip(middle + 1).Take(n - middle - 1).ToArray());
            return root;
        }

        public ListNode SortList(ListNode head)
        {
            if (head == null || head.next == null)
                return head;

            ListNode current = null;
            var slow = head;
            var fast = head;

            while (fast != null && fast.next != null)
            {
                current = slow;
                slow = slow.next;
                fast = fast.next.next;
            }

            current.next = null;
            var l = SortList(head);
            var r = SortList(slow);
            var result = Merge(l, r);
            return result;

        }

        public ListNode Merge(ListNode l, ListNode r)
        {
            var result = new ListNode();
            var current = result;

            while (l != null && r != null)
            {
                if (l.val < r.val)
                {
                    current.next = new ListNode(l.val);
                    current = current.next;
                    l = l.next;
                }
                else
                {
                    current.next = new ListNode(r.val);
                    current = current.next;
                    r = r.next;
                }
            }

            while (l != null)
            {
                current.next = new ListNode(l.val);
                current = current.next;
                l = l.next;
            }
            while (r != null)
            {
                current.next = new ListNode(r.val);
                current = current.next;
                r = r.next;
            }
            return result.next;
        }

        public QuadTree Construct(int[][] grid)
        {
            var n = grid.Length;

            if (n == 0)
            {
                return null;
            }

            var middle = n / 2;
            var gridValue = grid[0][0];
            var isAllSameValue = true;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (grid[i][j] != gridValue)
                    {
                        isAllSameValue = false;
                        break;
                    }
                }
            }

            if (isAllSameValue)
            {
                return new QuadTree(Convert.ToBoolean(gridValue), true);
            }

            var result = new QuadTree(true, false);


            result.topLeft = Construct(CreateSmallerGrid(grid, 0, middle, 0, middle));
            result.topRight = Construct(CreateSmallerGrid(grid, 0, middle, middle, n));
            result.bottomLeft = Construct(CreateSmallerGrid(grid, middle, n, 0, middle));
            result.bottomRight = Construct(CreateSmallerGrid(grid, middle, n, middle, n));

            return result;

        }

        public int[][] CreateSmallerGrid(int[][] grid, int iStart, int iEnd, int jStart, int jEnd)
        {
            var n = iEnd - iStart;
            var result = new int[n][];
            for (int i = 0; i < n; i++)
            {
                result[i] = new int[n]; // Each row has N columns
            }
            var iCount = 0;
            var jCount = 0;
            for (var i = iStart; i < iEnd; i++)
            {
                jCount = 0;
                for (var j = jStart; j < jEnd; j++)
                {
                    result[iCount][jCount] = grid[i][j];
                    jCount++;
                }
                iCount++;
            }

            return result;
        }

        public int MaxSubArray(int[] nums)
        {
            var max = int.MinValue;
            var current = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                current += nums[i];
                max = Math.Max(max, current);
                if (current < 0)
                {
                    current = 0;
                }
            }
            return max;
        }

        public int MaxSubarraySumCircular(int[] nums)
        {
            var n = nums.Length;
            var max = int.MinValue;
            var min = int.MaxValue;
            var currentMax = 0;
            var currentMin = 0;
            var total = 0;
            var set = new HashSet<int>();
            for (int i = 0; i < n; i++)
            {

                currentMax = Math.Max(nums[i], currentMax + nums[i]);
                max = Math.Max(max, currentMax);


                currentMin = Math.Min(nums[i], currentMin + nums[i]);
                min = Math.Min(min, currentMin);

                total += nums[i];
            }
            return max > 0 ? Math.Max(max, total - min) : max;
        }

        public bool SearchMatrix(int[][] matrix, int target)
        {
            var m = matrix.Length;
            var n = matrix[0].Length;

            int left = 0;
            int right = (m * n) - 1;

            while (left <= right)
            {
                int middle = left + (right - left) / 2;
                int x = middle / n;
                int y = middle % n;

                if (matrix[x][y] == target)
                {
                    return true;
                }

                if (matrix[x][y] < target)
                {
                    left = middle + 1;
                }
                else
                {
                    right = middle - 1;
                }
            }

            return false;

        }

        public int FindMin(int[] nums)
        {
            int left = 0;
            int right = nums.Length - 1;
            int middle = 0;
            //while (left <= right)
            //{
            //    middle = left + (right - left) / 2;
            //    if (left == right)
            //    {
            //        return nums[middle];
            //    }

            //    if (nums[middle] < nums[left] && nums[middle] < nums[right])
            //    {
            //        left = left + 1;
            //        right = right - 1;
            //        continue;
            //    }

            //    if (nums[middle] > nums[right])
            //    {
            //        left = middle + 1;
            //        continue;
            //    }
            //    else
            //    {
            //        right = middle - 1;
            //        continue;
            //    }
            //}

            //return nums[middle];

            while (left < right)
            {
                middle = left + (right - left) / 2;
                if (nums[middle] > nums[right])
                {
                    left = middle + 1;
                }
                else
                {
                    right = middle;
                }
            }
            return nums[left];
        }

        public int FindPeakElement(int[] nums)
        {
            if (nums.Length == 1)
            {
                return 0;
            }
            int left = 0;
            int right = nums.Length - 1;
            var middle = 0;

            while (left <= right)
            {
                middle = left + (right - left) / 2;
                var leftSideOfMid = middle - 1 >= 0 ? nums[middle - 1] : int.MinValue;
                var rightSideOfMid = middle + 1 < nums.Length ? nums[middle + 1] : int.MinValue;
                if (nums[middle] > rightSideOfMid && nums[middle] > leftSideOfMid)
                {
                    return middle;
                }

                if (nums[middle] < nums[middle + 1])
                {
                    left = middle + 1;   // Move towards the higher value (possible peak)
                }
                else
                {
                    right = middle - 1;
                }
            }

            return -1;
        }

        public IList<IList<int>> KSmallestPairs(int[] nums1, int[] nums2, int k)
        {
            var result = new List<IList<int>>();
            if (nums1.Length == 0 || nums2.Length == 0 || k == 0) return result;

            var minHeap = new PriorityQueue<(int i, int j), int>();

            // Initialize the heap with the first k pairs (nums1[i], nums2[0])
            for (int i = 0; i < Math.Min(nums1.Length, k); i++)
            {
                minHeap.Enqueue((i, 0), nums1[i] + nums2[0]);
            }

            while (k > 0 && minHeap.Count > 0)
            {
                var (i, j) = minHeap.Dequeue();
                result.Add(new List<int> { nums1[i], nums2[j] });
                k--;

                // Push the next element in the row (nums1[i], nums2[j+1]) if available
                if (j + 1 < nums2.Length)
                {
                    minHeap.Enqueue((i, j + 1), nums1[i] + nums2[j + 1]);
                }
            }

            return result;
        }
        public int FindMaximizedCapital(int k, int w, int[] profits, int[] capital)
        {
            var n = profits.Length;
            var result = new List<int>();
            var projects = new List<int>();
            for (int i = 0; i < n; i++)
            {
                projects.Add(i);
            }
            projects = projects.OrderBy(q => capital[q]).ToList();

            var index = 0; // Use to move and add project sort by capital
            var maxHeap = new PriorityQueue<int, int>();
            while (k > 0)
            {
                while (index < n && capital[projects[index]] <= w)
                {
                    int project = projects[index++];
                    maxHeap.Enqueue(project, -profits[project]); // Negate to simulate Max-Heap
                }

                if (maxHeap.Count > 0)
                {
                    var project = maxHeap.Dequeue();
                    w = w + profits[project];
                    k--;
                }
                else
                {
                    break;
                }
            }

            return w;
        }
        public string AddBinary(string a, string b)
        {
            var n = Math.Max(a.Length, b.Length);
            var overflow = false;
            var result = "";
            for (int i = 0; i < n; i++)
            {
                var indexA = a.Length - 1 - i;
                var indexB = b.Length - 1 - i;
                var valA = indexA >= 0 ? a[indexA] : '0';
                var valB = indexB >= 0 ? b[indexB] : '0';

                if (valA == '1' && valB == '1')
                {
                    result = overflow ? result + '1' : result + '0';
                    overflow = true;
                }
                else if (valA == '0' && valB == '0')
                {
                    result = overflow ? result + '1' : result + '0';
                    overflow = false;
                }
                else
                {
                    result = overflow ? result + '0' : result + '1';
                    overflow = overflow ? overflow : false;
                }

            }
            if (overflow)
            {
                result += "1";
            }


            char[] charArray = result.ToCharArray();
            Array.Reverse(charArray);
            result = new string(charArray);
            return result;
        }

        //public int SingleNumber(int[] nums) // one
        //{
        //    for (int i = 1; i < nums.Length; i++) {

        //        nums[0] = nums[0] ^ nums[i];
        //    }
        //    return nums[0];
        //}

        public int SingleNumber(int[] nums) //two
        {
            var one = 0;
            var two = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                one = (one ^ nums[i]) & ~two;
                two = (two ^ nums[i]) & ~one;

            }
            return one;
        }

        public int RangeBitwiseAnd(int left, int right)
        {
            while (left < right)
            {
                right = right & (right - 1);
            }
            return right;
        }
        public int[] PlusOne(int[] digits)
        {
            var carry = true;
            var index = digits.Length - 1;

            while (carry && index >= 0)
            {

                if (digits[index] == 9)
                {
                    digits[index] = 0;
                    carry = true;
                }
                else
                {
                    digits[index]++;
                    carry = false;
                }
                index--;
            }
            if (carry)
            {

                var newSize = digits.Length + 1;
                Array.Resize(ref digits, newSize);
                Array.Fill(digits, 0);
                digits[0] = 1;
            }
            return digits;
        }

        public int TrailingZeroes(int n)
        {
            var count = 0;
            FactorialTrailingZeroes(n, ref count);
            return count;
        }
        public int FactorialTrailingZeroes(int n, ref int count)
        {
            var val = n;
            while (val >= 5 && val % 5 == 0)
            {
                val /= 5;
                count++;
            }
            return n == 0 ? 1 : n == 1 ? 1 : n * FactorialTrailingZeroes(n - 1, ref count);
        }

        public int MySqrt(int x)
        {
            long left = 0;
            long right = Math.Max(x / 2, 1);
            while (left < right)
            {
                long middle = left + (right - left) / 2;
                var val = middle * middle;
                if (middle * middle == x)
                {
                    return (int)middle;
                }

                if (middle * middle < x)
                {
                    left = middle + 1;
                }
                else
                {
                    right = middle - 1;
                }
            }
            while (left >= 1)
            {
                if (left * left < x)
                {
                    return (int)left;
                }
                left--;
            }
            return (int)left;

        }
        public double MyPow(double x, int n)
        {
            if (n == 0)
            {
                return 1;
            }
            if (x == 0)
            {
                return 0;
            }
            long exp = n;
            if (exp < 0)
            {
                x = 1 / x;
                exp = -exp;
            }

            double result = 1;
            while (exp > 0)
            {
                if ((exp & 1) == 1) // If exponent is odd, multiply by current x
                {
                    result *= x;
                }
                x *= x;
                exp >>= 1; // Divide exponent by 2
            }

            return result;

        }

        public int MaxPoints(int[][] points)
        {
            var dic = new Dictionary<string, int>();
            var max = 0;
            for (int i = 0; i < points.Length; i++)
            {
                for (int j = i + 1; j < points.Length; j++)
                {
                    var pointA = points[i];
                    var pointB = points[j];

                    var slopeX = (pointA[0] - pointB[0]);
                    var slopeY = (pointA[1] - pointB[1]);
                    var slope = "";
                    var gcd = GCD(slopeX, slopeY);
                    if (gcd > 1)
                    {
                        slopeX /= gcd;
                        slopeY /= gcd;
                    }
                    if (slopeY == 0)
                    {
                        slope = $"IFN";
                    }
                    else if (slopeX == 0)
                    {
                        slope = "0";
                    }
                    else
                    {
                        if (slopeY < 0)
                        {
                            slopeY = -slopeY;
                            slopeX = -slopeX;
                        }
                        slope = $"{slopeX}-{slopeY}";

                    }
                    if (!dic.ContainsKey(slope))
                    {
                        dic.Add(slope, 0);
                    }
                    dic[slope]++;
                }
                var currentMax = dic.Count > 0 ? dic.Max(q => q.Value) : 0;
                max = Math.Max(max, currentMax);
                dic.Clear();
            }

            return max + 1;
        }
        public int GCD(int x, int y)
        {
            var n = Math.Min(Math.Abs(x), Math.Abs(y));
            while (n > 0)
            {
                if (x % n == 0 && y % n == 0)
                {
                    return n;
                }
                n--;
            }
            return 0;
        }
        //public int ClimbStairs(int n)
        //{
        //    if (n == 1)
        //    {
        //        return 1;
        //    }
        //    if (n == 2)
        //    {
        //        return 2;
        //    }
        //    return ClimbStairs(n - 1) + ClimbStairs(n - 2);
        //}
        public int ClimbStairs(int n)
        {
            if (n == 1)
            {
                return 1;
            }
            if (n == 2)
            {
                return 2;
            }
            var prev1 = 1;
            var prev2 = 2;
            for (var i = 3; i <= n; i++)
            {
                var val = prev1 + prev2;
                prev1 = prev2;
                prev2 = val;
            }
            return prev2;
        }

        public int Rob(int[] nums)
        {
            var n = nums.Length;
            var amount = new int[n + 1];
            amount[0] = 0;
            amount[1] = nums[0];
            for (var i = 1; i < n; i++)
            {
                var val = nums[i];
                var amountIndex = i + 1;
                amount[amountIndex] = Math.Max(amount[amountIndex - 2] + val, amount[amountIndex - 1]);
            }
            return amount[n];
        }

        //public bool WordBreak(string s, IList<string> wordDict)
        //{
        //    if (s.All(q=>q.Equals('_')))
        //    {
        //        return true;
        //    }
        //    foreach (var word in wordDict) {

        //        if (s.Contains(word))
        //        {
        //            var temp = s;
        //            s = ReplaceFirst(s,word, "_");
        //            if (WordBreak(s,wordDict))
        //            {
        //                return true;
        //            }
        //            s = temp;
        //        }
        //    }
        //    return false;
        //}

        //public static string ReplaceFirst(string s, string oldString, string newString)
        //{
        //    var regex = new Regex(Regex.Escape(oldString));
        //    var result = regex.Replace(s, newString, 1);
        //    return result;
        //}

        public bool WordBreak(string s, IList<string> wordDict)
        {
            var wordSet = wordDict.ToHashSet();
            var memo = new Dictionary<string, bool>();
            return CheckWordBreak(s, wordSet, memo);
        }

        public bool CheckWordBreak(string s, HashSet<string> set, Dictionary<string, bool> memo)
        {
            if (s.Length == 0)
            {
                return true;
            }
            if (memo.ContainsKey(s))
            {
                return memo[s];
            }
            for (var i = 1; i <= s.Length; i++)
            {
                var left = s.Substring(0, i);
                var right = s.Substring(i);
                if (set.Contains(left))
                {
                    memo[left] = true;
                    if (CheckWordBreak(right, set, memo))
                    {
                        return true;
                    }
                }
            }
            memo[s] = false;
            return false;
        }
        public int CoinChange(int[] coins, int amount)
        {
            var set = coins.Distinct().ToHashSet();
            var memo = new Dictionary<int, int>();
            foreach (var coin in set)
            {
                memo.Add(coin, 1);
            }
            return CheckCoinChange(amount, set, memo);
        }

        public int CheckCoinChange(int amount, HashSet<int> coins, Dictionary<int, int> memo)
        {
            if (amount == 0)
            {
                return 0;
            }
            if (memo.ContainsKey(amount))
            {
                return memo[amount];
            }
            foreach (var coin in coins)
            {

                if (coin <= amount)
                {
                    var newAmount = amount - coin;
                    var newAmountCointCount = CheckCoinChange(newAmount, coins, memo);
                    if (newAmountCointCount != -1)
                    {
                        if (!memo.ContainsKey(amount))
                        {
                            memo.Add(amount, int.MaxValue);
                        }
                        memo[amount] = Math.Min(newAmountCointCount + 1, memo[amount]);
                    }
                }

            }
            if (!memo.ContainsKey(amount))
            {
                memo.Add(amount, -1);
            }
            return memo[amount];
        }

        public int LengthOfLIS(int[] nums)
        {
            var n = nums.Length;
            var max = 1;
            var dp = new int[n];
            Array.Fill(dp, 1);
            for (int i = 1; i < n; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (nums[i] > nums[j])
                    {
                        dp[i] = Math.Max(dp[j] + 1, dp[i]);
                        max = Math.Max(max, dp[i]);
                    }
                }
            }
            return max;
        }

        public int MinimumTotal(IList<IList<int>> triangle)
        {
            var m = triangle.Count;
            var dp = new List<List<int>>();
            dp.Add(triangle[0].ToList());
            for (int i = 1; i < m; i++)
            {
                var rowAbove = dp[i - 1];
                var currentRow = triangle[i];
                var n = currentRow.Count;
                var currentDp = new List<int>();

                for (int j = 0; j < n; j++)
                {
                    var val = currentRow[j];
                    var min = int.MaxValue;
                    var startIndex = j - 1 < 0 ? j : j - 1;
                    var endIndex = Math.Min(rowAbove.Count, j + 1);
                    for (int k = startIndex; k < endIndex; k++)
                    {
                        var total = val + rowAbove[k];
                        min = Math.Min(min, total);
                    }
                    currentDp.Add(min);
                }
                dp.Add(currentDp);
            }

            var result = dp.Last().Min();
            return result;
        }

        public int MinPathSum(int[][] grid)
        {
            var m = grid.Length;
            var n = grid[0].Length;

            int[][] dp = new int[m][];
            for (int i = 0; i < m; i++)
            {
                dp[i] = new int[n];
            }

            var directions = new (int X, int Y)[] { (-1, 0), (0, -1) };

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    var top = int.MaxValue;
                    var left = int.MaxValue;
                    var current = grid[i][j];
                    var newX = i + directions[0].X;
                    var newY = j + directions[0].Y;

                    if (newX >= 0 && newX < m && newY >= 0 && newY < n)
                    {
                        top = dp[newX][newY];
                    }

                    newX = i + directions[1].X;
                    newY = j + directions[1].Y;

                    if (newX >= 0 && newX < m && newY >= 0 && newY < n)
                    {
                        left = dp[newX][newY];
                    }

                    if (top == int.MaxValue && left == int.MaxValue)
                    {
                        dp[i][j] = current;
                    }
                    else
                    {
                        dp[i][j] = Math.Min(top, left) + current;
                    }

                }
            }

            return dp[m - 1][n - 1];
        }

        public int UniquePathsWithObstacles(int[][] grid)
        {
            var m = grid.Length;
            var n = grid[0].Length;
            if (grid[0][0] == 1)
            {
                return 0;
            }
            int[][] dp = new int[m][];
            for (int i = 0; i < m; i++)
            {
                dp[i] = new int[n];
            }
            var directions = new (int X, int Y)[] { (-1, 0), (0, -1) };

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    var top = 0;
                    var left = 0;
                    var current = grid[i][j];
                    var newX = i + directions[0].X;
                    var newY = j + directions[0].Y;

                    if (newX >= 0 && newX < m && newY >= 0 && newY < n)
                    {
                        top = dp[newX][newY];
                    }

                    newX = i + directions[1].X;
                    newY = j + directions[1].Y;

                    if (newX >= 0 && newX < m && newY >= 0 && newY < n)
                    {
                        left = dp[newX][newY];
                    }


                    dp[i][j] = current == 1 ? 0 : top + left;
                    if (i == 0 && j == 0)
                    {
                        dp[i][j] = 1;
                    }

                }
            }

            return dp[m - 1][n - 1];
        }

        public bool IsInterleave(string s1, string s2, string s3)
        {
            var m = s1.Length;
            var n = s2.Length;
            if (s3.Length != s1.Length + s2.Length)
            {
                return false;
            }
            bool[][] dp = new bool[m + 1][];
            for (int i = 0; i <= m; i++)
            {
                dp[i] = new bool[n + 1];
            }
            // dp[i][j] = using i char from s1 and j char from s2 to create i+j char from s3
            dp[0][0] = true;
            //if using 0 char from s2 and i char from s1
            for (int i = 1; i <= m; i++)
            {
                dp[i][0] = s1[i - 1] == s3[i - 1] && dp[i - 1][0];
            }
            // if using 0 char from s1 and j char from s2
            for (int j = 1; j <= n; j++)
            {
                dp[0][j] = s2[j - 1] == s3[j - 1] && dp[0][j - 1];
            }

            for (int i = 1; i <= m; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    dp[i][j] =
                        (dp[i][j - 1] && s2[j - 1] == s3[i + j - 1])
                        ||
                        (dp[i - 1][j] && s1[i - 1] == s3[i + j - 1]);
                }
            }

            return dp[m][n];
        }

        public int MinDistance(string word1, string word2)
        {
            var m = word1.Length;
            var n = word2.Length;

            var dp = new int[m + 1, n + 1];
            dp[0, 0] = 0;
            //step to convert i char from w1 to empty string
            for (int i = 1; i <= m; i++)
            {
                dp[i, 0] = i;
            }
            // step to convert empty string to j char from w2
            for (int j = 1; j <= n; j++)
            {
                dp[0, j] = j;
            }

            for (int i = 1; i <= m; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    if (word1[i - 1] == word2[j - 1])
                    {
                        dp[i, j] = dp[i - 1, j - 1];
                    }
                    else
                    {
                        var insert = dp[i, j - 1] + 1;
                        var replace = dp[i - 1, j - 1] + 1;
                        var delete = dp[i - 1, j] + 1;

                        dp[i, j] = Math.Min(insert, Math.Min(replace, delete));
                    }
                }
            }
             return dp[m, n];
        }

        public int MaxProfitIII(int[] prices)
        {
            var b1 = int.MinValue;
            var s1 = int.MinValue;
            var b2 = int.MinValue;
            var s2 = int.MinValue;
            for (int i = 0; i < prices.Length; i++) { 
                var price = prices[i];
                b1 = Math.Max(b1, -price);
                s1 = Math.Max(s1, b1 + price);
                b2 = Math.Max(b2, s1 - price);
                s2 = Math.Max(s2, b2 + price);   
            }

            return s2;
        }

        public int MaxProfitIV(int k, int[] prices)
        {
            if (k >= prices.Length / 2)
            {
                var profit = 0;
                for (int i = 1; i < prices.Length; i++)
                {
                    if (prices[i] > prices[i - 1])
                    {
                        profit -= prices[i - 1];
                        profit += prices[i];
                    }
                }
                return profit;
            }
            var n = prices.Length;
            var dp = new int[k + 1, n];
            dp[0, 0] = 0;
            for (int i = 1; i <= k; i++)
            {
                dp[i, 0] = 0;
            }
            for (int j = 1; j < n; j++)
            {
                dp[0, j] = 0;
            }

            for (int i = 1; i <= k; i++)
            {
                int maxDiff = -prices[0];
                for (int j = 1; j < n; j++)
                {
                    dp[i,j] = Math.Max(dp[i,j - 1], prices[j] + maxDiff);
                    maxDiff = Math.Max(maxDiff, dp[i - 1,j] - prices[j]);
                }
            }
            return dp[k,n-1];
        }

        public ListNode ReverseKGroup(ListNode head, int k)
        {
            var current = head;
            var part = new ListNode();
            var currentPart = part;
            var count = 0;
            var queue = new Queue<ListNode>();

            while (current != null) { 
                currentPart.next = new ListNode(current.val);
                currentPart = currentPart.next;
                count++;
                if (k == count)
                {
                    queue.Enqueue(Reverse(part.next));
                    part = new ListNode();
                    currentPart = part;
                    count = 0;
                }
                current = current.next;
            
            }
            part = part.next;
            if (part!=null)
            {
                queue.Enqueue(part);
            }

            part = new ListNode();
            currentPart = part;
            while (queue.Count>0) { 
                var node = queue.Dequeue();
                currentPart.next = node;
                while (currentPart.next != null) { 
                    currentPart = currentPart.next;
                }
            }

            return part.next;
        }

        public ListNode Reverse(ListNode head) {
            if (head == null)
            {
                return head;
            }
            var result = new ListNode();
            var current = result;
            var stack = new Stack<ListNode>();
            while (head != null) { 
                stack.Push(head);
                head = head.next;
            }
            while (stack.Count > 0) { 
                var node = stack.Pop();
                current.next = new ListNode(node.val);
                current = current.next;
            }

            return result.next;
        }

        public int MaximalSquare(char[][] matrix)
        {
            var m = matrix.Length;
            var n = matrix[0].Length;
            if (m == n && m == 1)
            {
                return matrix[0][0] == '1' ? 1 : 0;
            }
            int[][] dp = new int[m ][];
            var max = int.MinValue;
            for (int i = 0; i < m; i++)
            {
                dp[i] = new int[n];
            }

            for (int i = 0; i < m; i++)
            {
                dp[i][0] = matrix[i][0] == '1' ? 1 : 0;
                if (dp[i][0] > max)
                {
                    max = dp[i][0];
                }
            }
            for (int j = 0; j < n; j++)
            {
                dp[0][j] = matrix[0][j] == '1' ? 1 : 0;
                if (dp[0][j] > max)
                {
                    max = dp[0][j];
                }
            }
            var directions = new (int X, int Y)[] { (-1, 0), (0, -1), (-1,-1) };
     
            for (int i = 1;i< m; i++)
            {
                for(int j = 1; j < n; j++)
                {
                    var top = int.MaxValue;
                    var left = int.MaxValue;
                    var topLeft = int.MaxValue;

                    var newX = i + directions[0].X;
                    var newY = j + directions[0].Y;

                    if (newX >= 0 && newX < m && newY >= 0 && newY < n)
                    {
                        top = dp[newX][newY];
                    }

                    newX = i + directions[1].X;
                    newY = j + directions[1].Y;

                    if (newX >= 0 && newX < m && newY >= 0 && newY < n)
                    {
                        left = dp[newX][newY];
                    }

                    newX = i + directions[2].X;
                    newY = j + directions[2].Y;

                    if (newX >= 0 && newX < m && newY >= 0 && newY < n)
                    {
                        topLeft = dp[newX][newY];
                    }

                    if (matrix[i][j] == '1')
                    {
                        dp[i][j] = Math.Min(left, Math.Min(top, topLeft)) + 1;
                        if (dp[i][j] > max)
                        {
                            max = dp[i][j];
                        }
                    }
                    else
                    {
                        dp[i][j] = 0;
                    }

                }

            }
            return max*max;
        }

        public string MergeAlternately(string word1, string word2)
        {
            var result = "";
            var i = 0;
            var j = 0;
            while (i < word1.Length && j < word2.Length) {
                if (j<i)
                {
                    result += word2[j];
                    j++;
                }
                else
                {
                    result += word1[i];
                    i++;
                }
            
            }
            while (i < word1.Length )
            {
                result += word1[i];
                i++;
            }
            while (j < word2.Length)
            {
                result += word2[j];
                j++;
            }
            return result;
        }

        public string RemoveStars(string s)
        {
            var n = s.Length;
            var result = "";
            var count = 0;
            for (int i = n-1; i >= 0; i--)
            {
                var c = s[i];
                if (c.Equals('*'))
                {
                    count++;
                }
                else
                {
                    if (count == 0)
                    {
                        result += c;
                    }
                    else
                    {
                        count--;
                    }
                }
            }

            char[] r = result.ToCharArray();
            Array.Reverse(r);
            return new string(r);
        }

        public double FindMaxAverage(int[] nums, int k)
        {
            var n = nums.Length;
            var j = k;
            double result = 0;
            double max = 0;
            for (int i = 0; i < k; i++)
            {
                result += nums[i];
            }
            max =  result/k;
            while (j < n) {
                result -= nums[j - k];
                result += nums[j];
                max = Math.Max(max, result/k);
                j++;
            }
            return max;
        }

        public ListNode DeleteMiddle(ListNode head)
        {
            if (head.next == null)
            {
                return null;
            }

            var slow = head;
            var fast = head;
            var prev = head;

            while (fast.next != null && fast.next.next !=null) {
                prev = slow;
                slow = slow.next;
                fast = fast.next.next;
            }
            if (fast.next != null) //even
            {
                prev = slow;
                slow = slow.next;
            }
            prev.next = slow.next;
            return head;
        }

        public int NumTilings(int n)
        {
            var dp = new long[Math.Max(n+1,3)];
            dp[0] = 1;
            dp[1] = 1;
            dp[2] = 2;
            for (int i = 3;i<=n;i++)
            {
                dp[i] = (2 * dp[i - 1]) % (1000000007) + (dp[i - 3]) % (1000000007);
            }
            return (int)(dp[n] % (1000000007));
        }

        public int GoodNodes(TreeNode root)
        {
            if (root == null) { 
                return 0;
            }
            return 1 + CountGoodNodes(root.right,root.val) + CountGoodNodes(root.left,root.val);
        }

        public int CountGoodNodes(TreeNode root,int currentMax)
        {
            if (root == null) {
                return 0;
            }
            var temp = currentMax;
            var result = 0;
            if (root.val >= currentMax)
            {
                currentMax = root.val;
                
                result = 1 + CountGoodNodes(root.left, currentMax) + CountGoodNodes(root.right, currentMax); 
            }
            else
            {
                result =  CountGoodNodes(root.left, currentMax) + CountGoodNodes(root.right, currentMax);
            }
            currentMax = temp;
            return result;
        }
        public bool CanVisitAllRooms(IList<IList<int>> rooms)
        {
            var n = rooms.Count;
            var queue = new Queue<int>();
            var visited = new HashSet<int>();
            visited.Add(0);
            var keys = rooms[0];
            foreach (var i in keys) { 
                queue.Enqueue(i);          
            }
            while (queue.Count > 0)
            {
                var key = queue.Dequeue();
                if (!visited.Contains(key))
                {
                    visited.Add(key);
                    foreach (var i in rooms[key]) { 
                        queue.Enqueue(i);
                    }
                }
            }

            return visited.Count == n;
        }

        public string GcdOfStrings(string str1, string str2)
        {
            var result = "";
            var shorter = str1.Length < str2.Length ? str1 : str2;

            while(shorter.Length > 0)
            {
                var t1 = str1.Replace(shorter, "");
                var t2 = str2.Replace(shorter, "");

                if (string.IsNullOrEmpty(t1) && string.IsNullOrEmpty(t2))
                {
                    return shorter;
                }
                shorter = shorter.Remove(shorter.Length - 1);
            }

            return result;
        }
        public IList<IList<int>> FindDifference(int[] nums1, int[] nums2)
        {
            var ans1 = new HashSet<int>();
            var ans2 = new HashSet<int>();
            var set = new HashSet<int>();
            foreach (var i in nums1) {
                if (set.Add(i))
                {
                    ans1.Add(i);
                }
            }
            foreach (var i in nums2) {
                if (set.Add(i))
                {
                    ans2.Add(i);
                }
                else
                {
                    ans1.Remove(i);
                }
                
            }
            return new List<IList<int>>() { ans1.ToList(),ans2.ToList()};
        }

        public int PairSum(ListNode head)
        {
            var stack = new Stack<int>();
            var fast = head;
            var slow = head;
            var max = int.MinValue;
            while (fast.next != null && fast.next.next != null) { 
                stack.Push(slow.val);    
                slow = slow.next;
                fast = fast.next.next;
            }
            stack.Push(slow.val);
            slow = slow.next;
            while(slow != null)
            {
                var v = stack.Pop();
                var value = slow.val + v;
                max = Math.Max(max, value);
                slow = slow.next;
            }
            return max;
        }

        public int NearestExit(char[][] maze, int[] entrance)
        {
            var m = maze.Length;
            var n = maze[0].Length;
            var startX = entrance[0];
            var startY = entrance[1];

            var dic = new Dictionary<(int X, int Y),int>();
            var directions = new (int X, int Y)[] { (-1, 0), (1, 0), (0, -1), (0, 1) };
            var queue = new Queue<(int X, int Y)>();

            queue.Enqueue((startX, startY));
            maze[startX][startY] = '+';
            var step = 0;

            while (queue.Count > 0) {
                var count = queue.Count;
                for (int i = 0; i < count; i++) {
                    var current = queue.Dequeue();
               
                    if ((current.X == 0 || current.X == m - 1 || current.Y == 0 || current.Y == n - 1) && (current.X != startX || current.Y != startY))
                    {
                        return step;
                    }

                    if (!dic.ContainsKey(current))
                    {
                        dic.Add(current, int.MaxValue);
                    }
                    dic[current] = Math.Min(dic[current],step);
                    foreach (var (dx, dy) in directions)
                    {
                        int newX = current.X + dx, newY = current.Y + dy;

                        if (newX >= 0 && newX < m && newY >= 0 && newY < n && maze[newX][newY] == '.' )
                        {
                            queue.Enqueue((newX, newY));
                            maze[newX][newY] = '+';
                        }
                    }
                }
                step++;
            }

            return -1;
        }

        public void DFSNearestExit(char[][] maze, (int X,int Y) current, (int X, int Y) exit, int currentStep,HashSet<(int X, int Y)> visited, Dictionary<(int X,int Y),int> result)
        {
            var m = maze.Length;
            var n = maze[0].Length;

            if (current.X == exit.X && current.Y == exit.Y)
            {
                result[exit] = Math.Min(currentStep, result[exit]);
            }
            var directions = new (int X, int Y)[] { (-1, 0), (1, 0), (0, -1), (0, 1) };
            visited.Add(current);
            foreach (var (dx, dy) in directions)
            {
                int newX = current.X + dx, newY = current.Y + dy;

                if (newX >= 0 && newX < m && newY >= 0 && newY < n && maze[newX][newY] == '.' && !visited.Contains((newX,newY))) 
                {
                    visited.Add((newX, newY));
                    DFSNearestExit(maze, (newX, newY), exit , currentStep + 1, visited, result);
             
                }
            }
            visited.Remove(current);
        }

        //public int GuessNumber(int n)
        //{
        //    var left = 1;
        //    var right = n;
        //    var mid = 0;
        //    var result = 999;
        //    while (result != 0) {
        //        mid = left + (right - left) / 2;
        //        result = guess(mid);
        //        if (result == -1)
        //        {
        //            right = mid-1; 
        //        }
        //        else
        //        {
        //            left = mid+1;
        //        }
        //    }
        //    return mid;
        //}

        public TreeNode DeleteNode(TreeNode root, int key)
        {
            var result = root;
            var queue = new Queue<TreeNode>();
            if (root == null)
            {
                return result;
            }

            queue.Enqueue(root);
            while (queue.Count > 0) {
                var current = queue.Dequeue();
                if (current.val == key)
                {
                    if (current.right == null && current.left == null)
                    {
                        current = null;
                    }
                    else if (current.right == null && current.left !=null)
                    {
                        current.val = current.left.val;
                        current.right = current.left.right;
                        current.left = current.left.left;
                    }
                    else if (current.right != null && current.left == null)
                    {
                        current.val = current.right.val;
                        current.left = current.right.left;
                        current.right = current.right.right;
                    }
                    else //both left & right
                    {
                        var right = current.right;
                        var prev = current;
                        while (right.left != null) {
                            prev = right;
                            right = right.left; 
                        }
                        current.val = right.val;
                        if (right.val == current.right.val)
                        {
                            current.right = current.right.right;
                        }
                        else
                        {
                            right = null;
                        }

                    }
                    break;
                }
                if (current.left != null)
                {
                    queue.Enqueue(current.left);
                }
                if (current.right!=null)
                {
                    queue.Enqueue(current.right);
                }
            }
            return result;
        }

    }
}





