// https://leetcode.com/problems/group-anagrams/description/

public class Solution {
    public IList<IList<string>> GroupAnagrams(string[] strs) {
        
        //1. Using Sort and Map
        // return SortAndMap(strs);
        
        //2. Using int[]
        return IntMap(strs);
    }
    
    private IList<IList<string>> IntMap(string[] strs){
        var result = new List<IList<string>>();
        var map = new Dictionary<string, IList<string>>();

        foreach(var str in strs){
            // Console.WriteLine(str);
            var intMap = new int[26];
            foreach(var ch in str){
                
                intMap[ch-'a']++;
            }
            
            var groupKeySb = new StringBuilder();
            for(int i = 0; i<26; i++){
                groupKeySb.Append(intMap[i]+".");
            }
            
            var groupKey = groupKeySb.ToString();
            // Console.WriteLine(groupKey);
            if(!map.ContainsKey(groupKey)){
                map.Add(groupKey, new List<string>());
            }
            
            map[groupKey].Add(str);
        }
        
        foreach(var group in map.Values){
            result.Add(group);
        }
        return result;
    }
    
    private IList<IList<string>> SortAndMap(string[] strs){
        var result = new List<IList<string>>();
        var map = new Dictionary<string, IList<string>>();
        
        foreach(var str in strs){
            var chars = str.ToCharArray();
            Array.Sort(chars);
            var groupKey = new String(chars);
            
            if(!map.ContainsKey(groupKey)){
                map.Add(groupKey, new List<string>());
            }
            
            map[groupKey].Add(str);
        }
        
        foreach(var group in map.Values){
            result.Add(group);
        }
        return result;
    }
}