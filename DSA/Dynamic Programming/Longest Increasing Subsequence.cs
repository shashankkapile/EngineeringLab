public class Solution {
    public int LengthOfLIS(int[] nums)
    {
        
        // #1. Recursion
        // return Recur(nums.Length-1, nums.Length, nums);

        // #2. Memoization
        // var dp = new int[nums.Length, nums.Length+1];
        // for(int current = 0; current<nums.Length; current++)
        // {
        //     for(int next = 0; next<=nums.Length; next++)
        //     {
        //         dp[current, next] = -1;
        //     }
        // }
        // return Memo(nums.Length-1, nums.Length, nums, dp);
    
        // #3. Tabulation
        // return Tab(nums);

        // #4. Space
        return Space(nums);
    }
    private int Space(int[] nums)
    {
        var dp = new int[nums.Length+1];
        for(int next = 0; next<=nums.Length; next++)
        {
            if (next!=nums.Length && nums[0] < nums[next])
            {
                dp[next] = 1;
            }
        }

        if(nums.Length==1) dp[1] = 1;// if len is 1, set dp[length] as 1
        
        for(int current = 1; current<nums.Length; current++)
        {
            for(int next = 0; next<=nums.Length; next++)
            {
                 //do not pick this, move to other element on left
                var nonPick = 0 + dp[next];
                
                var pick = 0;
                if (next==nums.Length || nums[current] < nums[next])
                {
                    //include in LIS as it fits the rule, move to other element on left
                    pick = 1 + dp[current];
                }

                dp[next] = Math.Max(pick, nonPick);
            }
        }

        return dp[nums.Length];
    }
    
    private int Tab(int[] nums)
    {
        var dp = new int[nums.Length, nums.Length+1];
        for(int next = 0; next<=nums.Length; next++)
        {
            if (next!=nums.Length && nums[0] < nums[next])
            {
                dp[0, next] = 1;
            }
        }

        if(nums.Length==1) dp[0,1] = 1;// if len is 1, set dp[length-1, length] as 1
        
        for(int current = 1; current<nums.Length; current++)
        {
            for(int next = 0; next<=nums.Length; next++)
            {
                 //do not pick this, move to other element on left
                var nonPick = 0 + dp[current-1, next];
                
                var pick = 0;
                if (next==nums.Length || nums[current] < nums[next])
                {
                    //include in LIS as it fits the rule, move to other element on left
                    pick = 1 + dp[current-1, current];
                }

                dp[current, next] = Math.Max(pick, nonPick);
            }
        }

        return dp[nums.Length-1, nums.Length];
    }
    
    private int Memo(int current, int next, int[] nums, int[,] dp)
    {
        if (current == 0)
        {
            if(nums.Length==1){
                return 1;
            }
            else if(next!=nums.Length && nums[current]<nums[next]){
                //can pick this number as it fits LIS rule
                return 1;
            }
            else
            {
                //cant pick this in LIS
                return 0;  
            } 
        }

        if(dp[current, next]!=-1) return dp[current, next];
        
        //do not pick this, move to other element on left
        var nonPick = 0 + Memo(current-1, next, nums, dp);
        
        var pick = 0;
        if (next==nums.Length || nums[current] < nums[next])
        {
            //include in LIS as it fits the rule, move to other element on left
            pick = 1 + Memo(current-1, current, nums, dp);
        }

        return dp[current, next] = Math.Max(pick, nonPick);
    }
    
    private int Recur(int current, int next, int[] nums)
    {
        if (current == 0)
        {
            if(nums.Length==1){
                return 1;
            }
            else if(next!=nums.Length && nums[current]<nums[next]){
                //can pick this number as it fits LIS rule
                return 1;
            }
            else
            {
                //cant pick this in LIS
                return 0;  
            } 
        }

        //do not pick this, move to other element on left
        var nonPick = 0 + Recur(current-1, next, nums);
        
        var pick = 0;
        if (next==nums.Length || nums[current] < nums[next])
        {
            //include in LIS as it fits the rule, move to other element on left
            pick = 1 + Recur(current-1, current, nums);
        }

        return Math.Max(pick, nonPick);
    }
}
