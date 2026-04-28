public class Solution {
    public int MajorityElement(int[] nums) {

        // #1 dictionary
        // #2 sort and return nums[n/2]
        
        // #3 moore's algo, freq++ and freq-- 
        return MooresAlgoOptimal(nums);
    }
    
    
    
    private int MooresAlgoOptimal(int[] nums)
    {
        int freq = 0, maxNum = 0;
        for(int i=0; i<nums.Length; i++){

            if(freq==0){
                maxNum = nums[i];
            }

            if(nums[i] == maxNum){
                freq++;
            }else{
                freq--;
            }
        }    
        return maxNum;
    }
}