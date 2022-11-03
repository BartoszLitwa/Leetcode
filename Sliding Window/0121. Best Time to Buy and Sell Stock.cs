public class Solution {
    // Kadane's Algorithm
    public int MaxProfit(int[] prices) {
        int maxCur = 0, maxSoFar = 0;
        for(int i = 1; i < prices.Length; i++) {
            // Add the current price diff
            maxCur += prices[i] - prices[i-1];
            // Reset the cMax since we are not interested in loss
            maxCur = 0 > maxCur ? 0 : maxCur;
            // Standard if current Max is bigger than global Max
            maxSoFar = maxCur > maxSoFar ? maxCur : maxSoFar;
        }
        return maxSoFar;
    }
    
    public int MaxProfit2(int[] prices) {
        int maxProfit = 0, least = prices[0], tProfit = 0;
        
        for(int i = 1; i < prices.Length; i++){
            // Check if current value is lower than the previous dip
            if(prices[i] < least){
                least = prices[i];
            }
            
            // calculate profit if sold today
            tProfit = prices[i] - least;
            if(maxProfit < tProfit){
                maxProfit = tProfit;
            }
        }
        
        return maxProfit;
    }
}