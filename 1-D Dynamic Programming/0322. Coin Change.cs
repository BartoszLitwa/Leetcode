public class Solution {
    // O(amount * coin.Length)
    // O(amount)
    public int CoinChange(int[] coins, int amount) {
        var cached = new int[amount + 1];
        cached[0] = 0; // to get 0 its always gonna be 0
        for(int i = 1; i < cached.Length; i++){
            cached[i] = amount + 1; // Set the placeholder value
        }

        for(int i = 1; i < amount + 1; i++){ // Compute for each value unti amount
            for(int c = 0; c < coins.Length; c++){ // For each coin
                if(i - coins[c] >= 0){ // If its still gonna be valid
                    // Take option with less coins
                    // Add 1 to result from i - coins[c]
                    cached[i] = Math.Min(cached[i], 1 + cached[i - coins[c]]);
                }
            }
        }

        // Return only when cached amount is not default
        return cached[amount] != amount + 1 ? cached[amount] : -1;
    }
}