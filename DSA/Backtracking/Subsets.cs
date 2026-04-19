// https://leetcode.com/explore/interview/card/top-interview-questions-medium/109/backtracking/796/

public class Solution {
    public IList<IList<int>> Subsets(int[] nums) {

        var result = new List<IList<int>>();
        
        // #1 better backtracking
        // GenerateBetter(0, new List<int>(), nums, result);
        
        // #2 optimal 
        GenerateOptimal(0, new List<int>(), nums, result);

        return result;
    }
    
    private void GenerateOptimal(int index, List<int> subset, int[] nums, IList<IList<int>> result)
    {
        if (index == nums.Length)
        {
            result.Add(new List<int>(subset));  
            return;
        }

        //nonPick
        GenerateOptimal(index+1, subset, nums, result);

        //pick
        subset.Add(nums[index]);
        GenerateOptimal(index+1, subset, nums, result);
        subset.RemoveAt(subset.Count-1);
    }
    
    private void GenerateBetter(int index, List<int> subset, int[] nums, IList<IList<int>> result)
    {
        if(index>nums.Length) return;
        
        result.Add(new List<int>(subset));


        for(int i = index; i<nums.Length; i++)
        {
            subset.Add(nums[i]);
            GenerateBetter(i+1, subset, nums, result);
            subset.RemoveAt(subset.Count-1);
        }
    }
}