// https://leetcode.com/problems/longest-palindromic-substring/
// Input: s = "babad"
// Output: "bab"
// Explanation: "aba" is also a valid answer
// Input: s = "cbbd"
// Output: "bb"

public class Solution {
    public string LongestPalindrome(string s) {

      return LongestPalindromeOptimal(s);
    }

    public string LongestPalindromeOptimal(string s) {
        var current = 0;
        var startIndex = 0;
        var maxLen = 0;

        while (current < s.Length)
        {
            //check for odd palindrome
            var left = current;
            var right = current;
            while(left>=0 && right<s.Length && s[left] == s[right])
            {
                var len = right - left + 1;
                if (maxLen < len)
                {
                    startIndex = left;
                    maxLen = len;
                }
                left--; right++;
            }

            //check for even palindrome
            left = current - 1;
            right = current;
            while(left>=0 && right<s.Length && s[left] == s[right])
            {
                var len = right - left + 1;
                if (maxLen < len)
                {
                    startIndex = left;
                    maxLen = len;
                }
                left--; right++;
            }
            current++;
        }

        return s.Substring(startIndex, maxLen);
    }
}
