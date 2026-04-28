    class Solution {
    public int celebrity(int[,] mat) {
        int rows = mat.GetLength(0), cols = mat.GetLength(1);
        // Console.WriteLine(rows+" "+cols);
        
        int i = 0, j = cols-1;
        while(i<rows && j>=0){
            if(mat[i,j]==1){
                i++;
            }
            else{
                j--;
            }
        }
        
        // Console.WriteLine(i+" "+j);
        if(i<rows && IsCelebrity(i, rows, cols, mat)){
            return i;
        }
        
        if(j>=0 && IsCelebrity(j, rows, cols, mat)){
            return j;
        }
        
        return -1;
    }
    
    private bool IsCelebrity(int index, int rows, int cols, int[,] mat){

        //i do not know anyone, but me
        for(int col = 0; col<cols; col++){
            if(index!=col && mat[index,col]==1){
                return false;
            }
        }
        
        //everyone knows me including me
        for(int row = 0; row<rows; row++){
            if(mat[row, index]!=1){
                return false;
            }
        }
        
        return true;
    }
}