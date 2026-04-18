// https://leetcode.com/problems/3sum/

public class Solution {
    public IList<IList<int>> ThreeSum(int[] nums) {

        // #1 brute force n^3
        // #2 x+y+z=0 so y+z = -x so -y+z, is it 2sum now?
        // #3 sort, fix first, iterate second third like subarray, adjust second third

        Array.Sort(nums);
        var result = new List<IList<int>>();
        
        for(int i = 0; i<nums.Length-2; i++){
            
            
            //skip duplicates
            while(i>0 && i<nums.Length-2 && nums[i-1]==nums[i]) i++;
            
            int j = i+1, k = nums.Length-1;

            while(j<k){
                var sum = nums[i]+nums[j]+nums[k];
                if(sum==0){
                    result.Add(new List<int>{nums[i],nums[j],nums[k]});
                    
                    //skip duplicates
                    j++;
                    while(nums[j-1]==nums[j] && j<k) j++;
                    k--;
                    while(nums[k]==nums[k+1] && j<k) k--;
                }
                else if(sum>0){
                    k--;
                }
                else{
                    j++;
                }
            }
        }
        return result;
    }
}