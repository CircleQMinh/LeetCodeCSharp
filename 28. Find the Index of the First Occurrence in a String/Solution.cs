using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhVu
{
    public class Solution
    {
        public int StrStr(string haystack, string needle)
        {
            var result = -1;
            if (needle.Length>haystack.Length)
            {
                return result;
            }
            var needleStartIndex = 0;
            for (int i = 0; i < haystack.Length; i++) {
                if (needleStartIndex == needle.Length)
                {
                    return result + 1 - needle.Length;
                }
                if (haystack[i] == needle[needleStartIndex])
                {
                result = i;
                needleStartIndex++;
                }
                else
                {
                    result = -1;
                    i -= needleStartIndex;
                    needleStartIndex = 0;
                    
                }
            }
            return needleStartIndex == needle.Length ? result + 1 - needle.Length : -1;
        }

        public int StrStr2(string haystack, string needle) //KMP algorithm
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
    }
}