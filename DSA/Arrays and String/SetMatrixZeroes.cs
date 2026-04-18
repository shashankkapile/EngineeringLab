// https://leetcode.com/problems/set-matrix-zeroes/
public class Solution {
    public void SetZeroes(int[][] matrix) {
        // #1 brute force with whole new matrix
        // #2 use row and col sets
        // #3 use bitwise for row and col, ensure larger input
        // #4 use first row and col as variables
        var firstCol = 1;
        for(int i = 0; i<matrix.Length; i++){
            for(int j = 0; j<matrix[i].Length; j++){
                
                if(matrix[i][j]==0){
                    //note the row and col should be zero
                    
                    if(j==0){
                        //if first column
                        matrix[i][0] = 0;
                        firstCol = 0;
                    }
                    else{
                        //other cells
                        matrix[i][0] = 0;
                        matrix[0][j] = 0;    
                    }
                }
            }
        }
        
        //first fill submatrix starting 1,1
        for(int i = 1; i<matrix.Length; i++){
            for(int j = 1; j<matrix[i].Length; j++){
                if(matrix[i][0]==0 || matrix[0][j]==0){
                    matrix[i][j] = 0;
                }
            }
        }
        
        //fill first row
        if(matrix[0][0]==0) for(int col = 0; col<matrix[0].Length; col++) matrix[0][col]=0;
        
        //fill first col
        if(firstCol==0) for(int row = 0; row<matrix.Length; row++) matrix[row][0]=0;
    }
}