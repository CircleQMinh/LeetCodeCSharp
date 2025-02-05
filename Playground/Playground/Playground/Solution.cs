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
    }
}
