// https://leetcode.com/explore/interview/card/top-interview-questions-medium/110/sorting-and-searching/804/
public class Solution {
    public int Search(int[] nums, int target) {

        // #1 linear brute force
        
        // #2 check which side is sorted, and BS
        return BinarySearchOptimal(nums, target);
    }
    
    private int BinarySearchOptimal(int[] nums, int target)
    {
        int low = 0, high = nums.Length-1;
        while (low <= high)
        {
            int mid = (low+high)/2;
            if(nums[mid]==target) return mid;

            //find out which half is sorted
            if (nums[low] <= nums[mid])
            {
                //left half is sorted
                //check if target exist in sorted left half
                if(nums[low]<=target && target <= nums[mid])
                {
                    // if exist, goto this sorted left half
                    high = mid-1;
                }
                else
                {
                    //target does not exist in sorted left half, explore other unsorted right half
                    low = mid+1;
                }                    
            }
            else
            {
                //right half is sorted
                //check if target exist in sorted right half
                if(nums[mid]<=target && target <= nums[high])
                {
                    //if exist, goto this sorted right half
                    low = mid + 1;
                }
                else
                {
                    //target does not exist in sorted right half, explore other unsorted left half
                    high = mid-1;
                }
            }
        }
        return -1;
    }
}