public class Solution {
    public int MySqrt(int x) {
        if(x<=0) return 0;
        if(x<=2) return 1;
        int low = 1, high = x/2+1;
        int ans = 0;
        while(low<=high){

            int mid = (low+high)/2;
            
            // mid*mid = x i.e.
            // x/mid = mid
            // so check
            int sqr = x/mid;
            if(sqr==mid){
                return mid;
            }
            if(mid<sqr){
                low = mid+1;
                ans = mid;
            }
            else{
                high = mid-1;
            }
        }     
        return ans;
    }
}