public class Solution {
    public int UniquePaths(int m, int n) {

        //1. bottom up recurssion
        // return Recur(0, 0, m, n);
        
        //2. top down recurssion
        // var dp = new int[m, n];
        // for(int i = 0; i<m; i++)
        // {
        //     for(int j = 0; j<n; j++)
        //     {
        //         dp[i,j] = -1;
        //     }
        // }
        // return Memo(0, 0, m, n, dp);
        
        return Tab(m, n);

//         return Paths(m, n);
    }

    private int Paths(int m, int n){
        int[] top = new int[n];
        for(int i = 0; i<n; i++) top[i] = 1;
        int current = 1;

        for(int i = 1; i<m; i++){
            int left = 1;
            for(int j = 1; j<n; j++){
                current = left + top[j];
                left = current;
                top[j] = current;
            }
        }
        return current;
    }

    // private int Paths(int m, int n){

    //     var dp = new int[m,n];
    //     for(int i = 0; i<m; i++) dp[i,0] = 1;
    //     for(int i = 0; i<n; i++) dp[0,i] = 1;

    //     for(int i = 1; i<m; i++){
    //         for(int j = 1; j<n; j++){
    //             dp[i,j] = dp[i-1,j] + dp[i,j-1];
    //         }
    //     }

    //     return dp[m-1,n-1];
    // }

    
    
    private int Tab(int m, int n)
    {
        var dp = new int[m, n];

        //base case
        dp[m-1, n-1] = 1;

        for(int i = m-1; i>=0; i--)
        {
            for(int j = n-1; j>=0; j--)
            {
                if(i==m-1 && j==n-1) continue;
                
                var rightCount = (j+1<n) ? dp[i, j+1] : 0;
                var downCount = (i+1<m) ? dp[i+1, j] : 0;
                dp[i,j] = rightCount + downCount;
            }
        }

        return dp[0,0];
    }
    
    private int Memo(int i, int j, int m, int n, int[,] dp)
    {
        if(i==m || j==n) return 0;
        if(i==m-1 && j==n-1) return 1;
        
        if(dp[i,j]!=-1) return dp[i,j];

        var rightCount = Memo(i, j+1, m, n, dp);
        var downCount = Memo(i+1, j, m, n, dp);
        return dp[i,j] = rightCount + downCount;
    }
    
    private int Recur(int i, int j, int m, int n)
    {
        if(i==m || j==n) return 0;
        if(i==m-1 && j==n-1) return 1;

        var rightCount = Recur(i, j+1, m, n);
        var downCount = Recur(i+1, j, m, n);
        return rightCount + downCount;
    }
}