public class Solution {
    public int SingleNumber(int[] nums) {
        int res = 0; // It is important to set initial value to 0
        for(int i = 0; i < nums.Length; i++){
            // Each value XOR 0 cancels out - 0 ^ x = x
            // XOR the same number will result in 0 - in our case previous value
            res ^= nums[i]; // XOR operation
        }
        
        return res;
    }
}