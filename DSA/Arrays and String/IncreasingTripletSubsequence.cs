// https://leetcode.com/problems/increasing-triplet-subsequence/
public class Solution {
    public bool IncreasingTriplet(int[] nums) {
        
        int first = Int32.MaxValue;
        int second = Int32.MaxValue;
        for(int i = 0; i<nums.Length; i++){
            var third = nums[i];
            if(third<=first){
                first = third;
            }
            else if(third<=second){
                second = third;
            }
            else return true;
        }
        
        return false;
    }
}