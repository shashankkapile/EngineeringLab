// https://leetcode.com/explore/interview/card/top-interview-questions-medium/109/backtracking/797/

public class Solution {
    public bool Exist(char[][] board, string word) {

        var visited = new bool[board.Length,board[0].Length];

        for(int i = 0; i<board.Length; i++){

            for(int j = 0; j<board[i].Length; j++){
                //TLE
                // if(SearchBrute(i, j, "", visited, board, word))
                // {
                //     return true;
                // }

                if(SearchOptimal(i, j, 0, visited, board, word))
                {
                    return true;
                }
            }
        }
        return false;
    }

    private bool SearchOptimal(int i, int j, int index, bool[,] visited, char[][] board, string word)
    {
        //entire word match found
        if(index==word.Length) return true;
        
        if(i<0 || i==board.Length || j<0 || j==board[0].Length) return false;
        if(visited[i,j]) return false;

        //letter does not match so dont expand recurssion
        if(board[i][j]!=word[index]) return false;


        visited[i,j] = true;
        
        //letter matches so find next matching letter in 4 directions
        if(SearchOptimal(i, j-1, index+1, visited, board, word)) return true; 
        if(SearchOptimal(i-1, j, index+1, visited, board, word)) return true; 
        if(SearchOptimal(i, j+1, index+1, visited, board, word)) return true; 
        if(SearchOptimal(i+1, j, index+1, visited, board, word)) return true; 
        
        visited[i,j] = false;
        return false;
    }

    private bool SearchBrute(int i, int j, string combo, bool[,] visited, char[][] board, string word)
    {
        if(combo==word) return true;
        
        if(i<0 || i==board.Length || j<0 || j==board[0].Length) return false;
        if(visited[i,j]) return false;
        
        visited[i,j] = true;
        
        if(SearchBrute(i, j-1, combo+board[i][j], visited, board, word)) return true; 
        if(SearchBrute(i-1, j, combo+board[i][j], visited, board, word)) return true; 
        if(SearchBrute(i, j+1, combo+board[i][j], visited, board, word)) return true; 
        if(SearchBrute(i+1, j, combo+board[i][j], visited, board, word)) return true; 
        
        visited[i,j] = false;
        return false;
    }
}