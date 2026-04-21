public class Solution {
    public bool CanJump(int[] nums) {
        // return Recur(0, nums);
        
        // var dp = new int[nums.Length];
        // for(int i = 0; i<dp.Length; i++) dp[i] = -1;
        // return Memo(0, nums, dp);

        return OptimalFor(nums);
    }

    private bool OptimalFor(int[] nums){
        int max = 0;
        for(int i = 0; i<nums.Length; i++){
            max = Math.Max(max, i+nums[i]);
            if(max>=nums.Length-1) return true; //can already jump to end
            
            //a hole here so cant jump further
            if(max==i) return false; 
        }
        return false;
    }
    
    private bool Memo(int index, int[] nums, int[] dp)
    {
        if (index == nums.Length - 1)
        {
            return true;
        }
        
        if(nums[index]==0) return false;

        if(dp[index]!=-1) return dp[index]==1;
        
        for(int i = 1; i<=nums[index]; i++)
        {
            if(Memo(index+i, nums, dp))
            {
                dp[index] = 1;
                return true;
            }
        }
        dp[index] = 0;
        return false;
    }

    private bool Recur(int index, int[] nums)
    {
        if (index == nums.Length - 1)
        {
            return true;
        }
        if(nums[index]==0) return false;

        for(int i = 1; i<=nums[index]; i++)
        {
            if(Recur(index+i, nums))
            {
                return true;
            }
        }
        return false;
    }
    
    
    
}