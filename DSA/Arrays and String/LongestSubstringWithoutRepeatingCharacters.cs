// https://leetcode.com/problems/longest-substring-without-repeating-characters/description/

public class Solution {
    public int LengthOfLongestSubstring(string s) {

        // #1 all subarray with set
        // #2 linear with set and remove until duplicate exist
        // #3 using map, dont remove
        // return Better(s); 
        return OptimalUsingIndex(s);  
    }

    private int OptimalUsingIndex(string s) {
        // "abcabcbb"
        // "bbbbb"
        // "pwwkew"
        // "au"
        // "abba"
        if(s.Length==0) return 0;
        
        var map = new Dictionary<char, int>();
        int left = 0, right = 0;
        int maxLen = 0;
        
        while(left<=right && right<s.Length){
            // Console.WriteLine("before: "+left+" "+right);

            if(!map.ContainsKey(s[right])){
                map.Add(s[right], right);
            }
            else{
                left = Math.Max(left, map[s[right]]+1); //one next to previous seen
                map[s[right]]=right;
            }
            maxLen = Math.Max(maxLen, right-left+1);
            right++;
            // Console.WriteLine("after: "+left+" "+right);
        }
        return maxLen;
    }

    private int Better(string s){  
        int left = 0, right = 0;
        int maxLen = 0;
        HashSet<char> set = new HashSet<char>();
        while(right<s.Length){
            while(set.Count>0 && set.Contains(s[right])){
                set.Remove(s[left]);
                left++;
            }
            set.Add(s[right]);
            maxLen = Math.Max(maxLen, set.Count);
            right++;
        }
        return maxLen;  
    }
}