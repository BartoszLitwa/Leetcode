public class Solution {
    public int MaxProfit(int[] prices) {
        var cached = new Dictionary<(int Index, bool Buying), int>();
        // cached[(i, buying)] = max profit at index i, buying or not
        return Helper(0, true, prices, cached);
    }

    private int Helper(int i, bool buying, int[] prices, Dictionary<(int Index, bool Buying), int> cached){
        if(i >= prices.Length) // no more days
            return 0;
        else if(cached.ContainsKey((i, buying))) // already calculated
            return cached[(i, buying)];

        int cooldown = Helper(i + 1, buying, prices, cached); // cooldown
        int profit = buying ? 
            Helper(i + 1, false, prices, cached) - prices[i] // buy
            : Helper(i + 2, true, prices, cached) + prices[i]; // sell
        cached.Add((i, buying), Math.Max(profit, cooldown));

        return cached[(i, buying)];
    }
}