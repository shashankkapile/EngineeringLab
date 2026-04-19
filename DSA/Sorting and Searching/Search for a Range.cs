// https://leetcode.com/explore/interview/card/top-interview-questions-medium/110/sorting-and-searching/802/


public class Solution {
    public int[] SearchRange(int[] nums, int target) {

        // #1 write GetFirst and GetLast
        
        // #2 serach insert for target and target+1
         var startIndex = SearchInsertPosition(nums, target);
        
        //element itself does not exist in list
        if(startIndex==nums.Length || nums[startIndex]!=target) return new int[]{-1, -1};

        //find element+1 insert position and return pos-1
        var endIndex = SearchInsertPosition(nums, target+1);
        return new int[] {startIndex, endIndex-1};
    }

    private int SearchInsertPosition(int[] nums, int target)
    {
        int low = 0, high = nums.Length-1;
        int ans = nums.Length;
        while (low <= high)
        {
            int mid = (high+low)/2;
            if (target<=nums[mid])
            {
                ans = mid;
                high = mid-1;
            }
            else
            {
                low = mid+1;
            }
        }
        return ans;
    }
}