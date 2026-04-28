public class Solution {
    public bool IsHappy(int n) {
        
        var set = new HashSet<int>();
        set.Add(n);

        while(n>1){
            int sum = 0;
            while(n>0){
                var digit = n%10;
                sum += (digit*digit);
                n = n/10;
            }
            
            if(sum==1) return true;
            if(set.Contains(sum)) return false;
            set.Add(sum);
            n = sum;
        }
        
        return true;
    }
}

// 2147483647
// 19
// 23
// 100
// 2