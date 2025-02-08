public class Solution {
    public int LengthOfLongestSubstring(string s) {
        var result = 0;
            var sub = "";
            var i = 0;
            while(i < s.Length)
            {
                var curChar = s[i];
                if (!sub.Contains(curChar)) {
                    sub += curChar;
                    result = Math.Max(result,sub.Length);
                }
                else
                {
                    i = i - sub.Length;
                    sub = "";
                }
                i++;
            }
            return result;
    }
}