public class Solution {
    // Bellman-Ford algorithm
    public int FindCheapestPrice(int n, int[][] flights, int src, int dst, int k) {
        var prices = Enumerable.Repeat(Int32.MaxValue, n).ToList();
        prices[src] = 0;

        for(int i = 0; i < k + 1; i++){ // k stops
            var tempPrices = new List<int>(prices); // Create a copy
            foreach(var f in flights){ // source, destination, price
                if(prices[f[0]] == Int32.MaxValue) // Not reachable
                    continue;
                if(prices[f[0]] + f[2] < tempPrices[f[1]]) // Update the price
                    tempPrices[f[1]] = prices[f[0]] + f[2];
            }
            prices = tempPrices; // Update the orginal prices
        }
        // Return the price of destination
        return prices[dst] == Int32.MaxValue ? -1 : prices[dst];
    }
}