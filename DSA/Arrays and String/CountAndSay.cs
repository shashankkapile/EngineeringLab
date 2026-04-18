// https://leetcode.com/problems/count-and-say/description/

public class Solution {
    public string CountAndSay(int n) {
        // return Recur(n);
        return Iter(n);    
    }

    private string Iter(int n){    
        var result = "1";
        for(int k = 2; k<=n; k++){

            var prev = result;
            var sb = new StringBuilder();
            int count = 1;
            for(int i = 1; i<prev.Length; i++){
                if(prev[i-1]!=prev[i]){
                    sb.Append(count);
                    sb.Append(prev[i-1]);
                    count = 1;
                }
                else{
                    count++;
                }
            }
            sb.Append(count);
            sb.Append(prev[prev.Length-1]);
            result = sb.ToString();
            // Console.WriteLine(k+" "+result);
        }
        return result;
    }

    private string Recur(int n){
        if(n==1) return "1";

        var prev = Recur(n-1);
        
        // Console.WriteLine(n+" "+prev);
        var sb = new StringBuilder();
        int count = 1;
        for(int i = 1; i<prev.Length; i++){
            if(prev[i-1]!=prev[i]){
                sb.Append(count);
                sb.Append(prev[i-1]);
                count = 1;
            }
            else{
                count++;
            }
        }
        sb.Append(count);
        sb.Append(prev[prev.Length-1]);
        // Console.WriteLine("Result: "+sb.ToString());
        return sb.ToString();
    }
}