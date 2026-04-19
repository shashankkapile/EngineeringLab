// https://leetcode.com/explore/interview/card/top-interview-questions-medium/110/sorting-and-searching/798/

public class Solution {

    public void SortColors(int[] nums) {
        
        // #1. SImple counting
        // CountOptimal(nums);
        
        // #2. Algorithm
        DutchNationalFlagOptimal(nums);
    }
    
    private void DutchNationalFlagOptimal(int[] nums)
    {
        int left = 0, right = nums.Length-1;
        int index = 0;
        
        //if index reaches right then everything on left and right if index is sorted
        while (index<nums.Length && index<=right) 
        {
            if (nums[index] == 0)
            {
                var temp = nums[index];
                nums[index] = nums[left];
                nums[left] = temp;
                left++;
                
                //this position is sorted, goto next position
                index++;
            }
            else if(nums[index]==2)
            {
                var temp = nums[index];
                nums[index] = nums[right];
                nums[right] = temp;
                right--;
                
                //we moved 2 to its right position, but current position is still not sorted.
            }
            else{
                // its a 1 so we are fine, move to next position
                index++;
            }
        }    
    }
    
    private void CountOptimal(int[] nums)
    {
        int zeros = 0, ones = 0, twos = 0;

        foreach(var num in nums)
        {
            if(num==0) zeros++;
            else if(num==1) ones++;
            else twos++;
        }

        
        int index = 0;
        while (zeros-->0)
        {
            nums[index] = 0;
            index++;
        }
        while (ones-->0)
        {
            nums[index] = 1;
            index++;
        }
        while (twos-->0)
        {
            nums[index] = 2;
            index++;
        }
    }
    
}