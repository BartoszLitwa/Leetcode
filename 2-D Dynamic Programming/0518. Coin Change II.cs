public class Solution {
    public int Change(int amount, int[] coins){
        var cached = Enumerable.Repeat(0, amount + 1).ToArray();
        cached[0] = 1; // Amount 0 can be made with 1 way

        for(int c = coins.Length - 1; c >= 0; c--){ // Coin
            var cachedBelow = Enumerable.Repeat(0, amount + 1).ToArray();
            cachedBelow[0] = 1; // Amount 0 can be made with 1 way

            for(int a = 1; a < amount + 1; a++){ // Amount
                cachedBelow[a] = cached[a]; // amount in the same column - coin below
                if(a - coins[c] >= 0) // If current coin can be used
                    cachedBelow[a] += cachedBelow[a - coins[c]]; // Amount - coin to the right
            }
            cached = cachedBelow; // Update the cache
        }
        return cached[amount]; // Take the top left corner
    }

    public int Change2(int amount, int[] coins) {
        var cached = Enumerable.Repeat(Enumerable.Repeat(0, coins.Length + 1).ToArray(), amount + 1).ToArray();
        cached[0] = Enumerable.Repeat(1, coins.Length + 1).ToArray(); // Amount 0 can be made with 1 way

        for(int a = 1; a < amount + 1; a++){ // Amount
            for(int c = coins.Length - 1; c >= 0; c--){ // Coin
                cached[a][c] = cached[a][c + 1]; // Amount ine the same column
                if(a - coins[c] >= 0) // If current coin can be used
                    cached[a][c] += cached[a - coins[c]][c]; // Amount - coin to the right
            }
        }
        // take the top left corner
        return cached[amount][0];
    }
}