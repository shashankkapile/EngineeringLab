// https://leetcode.com/explore/interview/card/top-interview-questions-medium/110/sorting-and-searching/806/
public class Solution {
    public bool SearchMatrix(int[][] matrix, int target) {

        // #1 linear
        // #2 linear rows, BS on cols
        // #3 can I start from one point and go left right according to condition?
        return SpecialBinarySearchOptimal(matrix, target);   
    }
    
    private bool SpecialBinarySearchOptimal(int[][] matrix, int target)
    {
        int i = 0, j = matrix[0].Length-1;

        while(i<matrix.Length && j >= 0)
        {
            if(matrix[i][j]==target) return true;

            if (target < matrix[i][j])
            {
                j--; //go left
            }
            else
            {
                i++; //go down
            }
        }
        return false;
    }
}