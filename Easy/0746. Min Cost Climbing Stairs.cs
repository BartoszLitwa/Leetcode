public class Solution {
    // More of a DP / Greedy
    public int MinCostClimbingStairs(int[] cost) {
        int step1 = 0, step2 = 0;
        for(int i = cost.Length - 1; i >= 0; i--){
            int currStep = cost[i] + Math.Min(step1, step2);
            // Replace 
            step1 = step2;
            step2 = currStep;
        }
        
        return Math.Min(step1, step2);
    }
    
    // More of a greedy approach - Override the array
    public int MinCostClimbingStairs2(int[] cost) {
        for(int i = 2; i < cost.Length; i++){
            // We want to add the previous min cost
            cost[i] += Math.Min(cost[i - 1], cost[i - 2]);
        }
        
        return Math.Min(cost[cost.Length - 1], cost[cost.Length - 2]);
    }
    
}