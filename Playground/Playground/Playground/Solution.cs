using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Playground
{
    public class Solution
    {
        public int RemoveDuplicates(int[] nums)
        {
            int i = 1;
            int count = 0;
            while (i < nums.Length)
            {
                if (nums[count] != nums[i])
                {
                    count++;
                    nums[count] = nums[i];
                }
                i++;
            }
            return nums.Length == 0 ? 0 : count + 1;
        }
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
                    for (int i = index; i>= 0; i--)
                    {
                        if(nums[i] == target){
                            l = i;
                        }
                    }
                    for (int i = index; i <= nums.Length -1; i++)
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
            while (left <= right) {
                int middle = left + (right - left) / 2;
                if (nums[middle] == target)
                {
                    result = middle;
                    return result;
                }
                if (nums[middle] < target) { 
                    left = middle + 1;
                }
                if (nums[middle] > target) { 
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
                if (IsValidPlacement(board,i,j,num))
                {
                    board[i][j] = num;
                    //if (IsValidSudoku(board) && InsertToBoard(board)) // too slow
                    if ( InsertToBoard(board))
                    {
                        return true;
                    }
                }
                board[i][j] = '.';
            }

            return false ;
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

        public (int curI,int curJ) FindFirstEmptySpace(char[][] board)
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
            return (-1,-1);
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

                    while (c < d) {
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
                        else {
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
            for (int i = 1; i < nums.Length; i++) {
                if (nums[i] < nums[i-1])
                {
                    pivot = i;
                }
            }
            if(pivot >= 0)
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

            return  result > -1 ? (result + pivot) % nums.Length : -1;
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

            for (int i = 0; i< s.Length; i++)
            {
                if(currentChar != s[i])
                {
                    if (!(currentChar == 'x'))
                    {
                        resultList.Add((currentCount, s[i-1]));
                    }
                    currentChar = s[i];
                    currentCount = 0;
                }

                currentChar = s[i];
                currentCount++;
            }
            resultList.Add((currentCount, s[s.Length - 1]));
            
            for (int i = 0;i< resultList.Count; i++)
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
                    if (IsSameCombination(newCombination,item.ToList()))
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

            for (int i = 0; i < candidates.Length; i++) { 
                if(IsValidAdd(current, candidates[i], target))
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
            for (int i = 0; i < a.Count; i++) {
                if (a[i] != b[i])
                {
                    return false;
                }
            }
            return true;
        }

        public bool IsValidAdd(List<int> current, int add,int target)
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
            GenerateCombinations2(0,new List<int>(), candidates, target, g);

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

            for (int i = currentIndex; i < candidates.Length; i++) {
                if (i > currentIndex && candidates[i] == candidates[i-1])
                {
                    continue;
                }
                if (candidates[i] <= target)
                {
                    current.Add(candidates[i]);
                    GenerateCombinations2(i+1, current, candidates, target - candidates[i], result);
                    current.RemoveAt(current.Count -1);
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
    }
}
