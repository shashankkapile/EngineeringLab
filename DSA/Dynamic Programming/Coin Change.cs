// https://leetcode.com/explore/interview/card/top-interview-questions-medium/111/dynamic-programming/809/
public class Solution {
    public int CoinChange(int[] coins, int amount) {
        
        //0. Does not work for non-canonical denominations!
        // return Greedy(coins, amount);

        //1. Recursive
        // var count = Recur(coins.Length-1, amount, coins);
        // if(count>=Int32.MaxValue) return -1;
        // return (int)count;
        
        //2. Memoization
        // var dp = new long[coins.Length, amount+1];
        // for(int i = 0; i<dp.GetLength(0); i++)
        // {
        //     for(int j = 0; j<=amount; j++)
        //     {
        //         dp[i,j] = -1;
        //     }
        // }
        // var count = Memo(coins.Length-1, amount, coins, dp);
        // if(count>=Int32.MaxValue) return -1;
        // return (int)count;
        
        //3. Tabulation
        // var count = Tab(amount, coins);
        // if(count>=Int32.MaxValue) return -1;
        // return (int)count;
        
        //4. Space optimization
        var count = Space(amount, coins);
        if(count>=Int32.MaxValue) return -1;
        return (int)count;
    }

    private long Space(int amount, int[] coins)
    {
        var dp = new long[amount+1];

        
        for(int amt = 0; amt<=amount; amt++)
        {
            if(amt%coins[0]==0)
            {
                //when index==0, i.e. only 1 coin, then all multiples of amt can be calcualted
                dp[amt] = amt/coins[0];
            }
            else
            {
                dp[amt] = Int32.MaxValue;
            }
        }

        for(int index = 1; index<coins.Length; index++)
        {
            var temp = new long[amount+1]; //to store current answer row
            for(int amt = 1; amt<=amount; amt++) 
            {
                //non pick, move to other coin
                var nonPick = dp[amt]; //dp now represents previous row

                long pick = Int32.MaxValue;
                if (amt >= coins[index])
                {
                    //pick this one coin and dont goto other coin, keep using this repeatedly
                    pick = 1 + temp[amt-coins[index]];
                } 

                temp[amt] = Math.Min(nonPick, pick);
            }
            dp = temp;
        }
                
        return dp[amount];
    }

    private long Tab(int amount, int[] coins)
    {
        var dp = new long[coins.Length, amount+1];

        
        for(int amt = 0; amt<=amount; amt++)
        {
            if(amt%coins[0]==0)
            {
                //when index==0, i.e. only 1 coin, then all multiples of amt can be calcualted
                dp[0, amt] = amt/coins[0];
            }
            else
            {
                dp[0, amt] = Int32.MaxValue;
            }
        }

        for(int index = 1; index<coins.Length; index++)
        {
            for(int amt = 1; amt<=amount; amt++) 
            {
                //non pick, move to other coin
                var nonPick = dp[index-1, amt];

                long pick = Int32.MaxValue;
                if (amt >= coins[index])
                {
                    //pick this one coin and dont goto other coin, keep using this repeatedly
                    pick = 1 + dp[index, amt-coins[index]];
                } 

                dp[index, amt] = Math.Min(nonPick, pick);
            }
        }
               
        return dp[coins.Length-1, amount];
    }
    
    private long Memo(int index, int amount, int[] coins, long[,] dp)
    {
        if (index == 0)
        {
            if(amount==0)
            {
                //reached the goal
                return 0;
            }
            else if(amount % coins[index] == 0)
            {
                //reached the goal but amount still remaining, so count the coins
                return amount/coins[index];
            }
            else
            {
                //can not make the change
                return Int32.MaxValue; //this means we can not break down the amount in change
            }
        }
                
        if(dp[index, amount]!=-1) return dp[index, amount];

        //non pick, move to other coin
        var nonPick = Memo(index-1, amount, coins, dp);

        long pick = Int32.MaxValue;
        if (amount >= coins[index])
        {
            //pick this one coin and dont goto other coin, keep using this repeatedly
            pick = 1 + Memo(index, amount-coins[index], coins, dp);    
        } 

        return dp[index, amount] = Math.Min(nonPick, pick);
    }
    
    private long Recur(int index, int amount, int[] coins)
    {
        if (index == 0)
        {
            if(amount==0)
            {
                //reached the goal
                return 0;
            }
            else if(amount % coins[index] == 0)
            {
                //reached the goal but amount still remaining, so count the coins
                return amount/coins[index];
            }
            else
            {
                //can not make the change
                return Int32.MaxValue; //this means we can not break down the amount in change
            }
        }
                
        //non pick, move to other coin
        var nonPick = Recur(index-1, amount, coins);

        long pick = Int32.MaxValue;
        if (amount >= coins[index])
        {
            //pick this one coin and dont goto other coin, keep using this repeatedly
            pick = 1 + Recur(index, amount-coins[index], coins);    
        } 

        return Math.Min(nonPick, pick);
    }
    
    //Does not work for non-canonical denominations.
    private int Greedy(int[] coins, int amount)
    {
        Array.Sort(coins);
        int total = 0;
        for(int i = coins.Length-1; i>=0; i--)
        {
            int coin = coins[i];
            if (coin <= amount)
            {
                int change = amount/coin;
                // Console.WriteLine(amount+" "+coin+" x "+change);
                amount = amount-(change*coin);

                total += change;
            }
        }

        return amount>0? -1: total;
    }
}