// https://leetcode.com/explore/interview/card/top-interview-questions-medium/108/trees-and-graphs/792/
public class Solution {
    public int NumIslands(char[][] grid) {

        int islands = 0;
        var visited = new bool[grid.Length,grid[0].Length];
        for(int i = 0; i<grid.Length; i++)
        {
            for(int j = 0; j<grid[0].Length; j++)
            {
                if(grid[i][j]=='0' || visited[i,j]) continue;
                Visit(i, j, grid, visited);
                islands++;
            }
        }
        return islands;
    }

    private void Visit(int i, int j, char[][] grid, bool[,] visited)
    {
        if(i<0 || i>=grid.Length || j<0 || j>=grid[0].Length) return;

        if(grid[i][j]=='0' || visited[i,j]) return;

        visited[i,j] = true;

        Visit(i, j-1, grid, visited);
        Visit(i-1, j, grid, visited);
        Visit(i, j+1, grid, visited);
        Visit(i+1, j, grid, visited);
    }
}