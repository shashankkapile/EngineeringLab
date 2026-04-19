// https://leetcode.com/explore/interview/card/top-interview-questions-medium/109/backtracking/794/

public class Solution {
    public IList<string> GenerateParenthesis(int n) {

        var result = new List<string>();
        // GenerateBetter(n, n, "", result);
        
        GenerateOptimal(n, n, new List<char>(), result);
        return result;
    }

    private void GenerateOptimal(int open, int close, IList<char> str, List<string> result){
        if(open==0 && close==0){
            result.Add(new string(str.ToArray()));
            return;
        }
        
        if(open>0){
            str.Add('(');
            GenerateOptimal(open-1, close, str, result);
            str.RemoveAt(str.Count-1);
        }
        if(open<close){
            str.Add(')');
            GenerateOptimal(open, close-1, str, result);
            str.RemoveAt(str.Count-1);
        }
    }
    
    private void GenerateBetter(int open, int close, string str, List<string> result){

        if(open==0 && close==0){
            result.Add(str);
            return;
        }

        if(open>0){
            GenerateBetter(open-1, close, str+"(", result);
        }
        if(open<close){
            GenerateBetter(open, close-1, str+")", result);
        }
    }
}