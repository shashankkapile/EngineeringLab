// https://leetcode.com/explore/interview/card/top-interview-questions-medium/109/backtracking/795/

public class Solution {
    public IList<IList<int>> Permute(int[] nums) {
        
        var result = new List<IList<int>>();
        Generate(0, nums, result);
        return result;
    }

    private void Generate(int index, int[] permutation, IList<IList<int>> result){
        if(index==permutation.Length){
            result.Add(new List<int>(permutation));
            return;
        }

        for(int i = index; i<permutation.Length; i++){
            var temp = permutation[index];
            permutation[index] = permutation[i];
            permutation[i] = temp;

            Generate(index+1, permutation, result);

            temp = permutation[index];
            permutation[index] = permutation[i];
            permutation[i] = temp;
        }
    }
}