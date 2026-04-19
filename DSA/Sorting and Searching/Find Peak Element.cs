// https://leetcode.com/explore/interview/card/top-interview-questions-medium/110/sorting-and-searching/801/

public class Solution {
    public int FindPeakElement(int[] nums) {
        
        // #1. Linear
        return LinearBetter(nums);
        
        // #2. Binary search
        // return BinaryOptimal(nums);
    }
    
    private int LinearBetter(int [] nums){
        if(nums.Length==1) return 0;
        
        //left most edge can be peak
        if(nums[0]>nums[1]) return 0;
        
        //right most edge can be peak
        if(nums[nums.Length-2]<nums[nums.Length-1]) return nums.Length-1;
        
        for(int i = 1; i<nums.Length-1; i++){
            if(nums[i-1]<nums[i] && nums[i]>nums[i+1]) return i;
        }
        return -1;
    }
    
    private int BinaryOptimal(int[] nums){
        //base cases.
        if(nums.Length==1) return 0;
        
        //left most edge can be peak
        if(nums[0]>nums[1]) return 0;
        
        //right most edge can be peak
        if(nums[nums.Length-2]<nums[nums.Length-1]) return nums.Length-1;
        
        int low = 0, high = nums.Length-1;
        
        low++; high--; //skip edge positions as they are not peaks clearly
        while (low <= high)
        {
            int mid = (high+low)/2;
            Console.WriteLine(low+" "+mid+" "+high);
            if(nums[mid-1]<nums[mid] && nums[mid]>nums[mid+1]) return mid;
                
            if(nums[mid-1]<nums[mid]){
              low = mid+1;  
            } 
            else{
              high = mid-1;  
            } 
            
        }
        return -1;
    }
}