public class Solution {
    public int Rob(int[] nums) {
        int robMinus1 = 0, robMinus2 = 0;
        // [robMinus2, robMinus1, n, n+1, ...]
        for(int i = 0; i < nums.Length; i++){
            int temp = Math.Max(robMinus1, robMinus2 + nums[i]);
            robMinus2 = robMinus1;
            robMinus1 = temp;
        }

        return robMinus1; // Its always goona be the biggest value
    }
}