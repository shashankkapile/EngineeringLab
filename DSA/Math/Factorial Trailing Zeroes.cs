public class Solution {
    public int TrailingZeroes(int n) {
        
        int count = 0;
        while(n>0){
            int multiples = n/5;
            count += multiples;
            
            n = multiples;
        }
        return count;
    }
}