public class Solution {
    public int MaxProduct(int[] nums) {
        int min = 1, max = 1;
        int res = Int32.MinValue;
        // Find max
        for(int i = 0; i < nums.Length; i++){
            res = Math.Max(res, nums[i]);
        }

        for(int i = 0; i < nums.Length; i++){
            int temp = max;
            max = Math.Max(Math.Max(nums[i] * max, nums[i] * min), nums[i]);
            // Use saved value because max would have overwritten val
            min = Math.Min(Math.Min(nums[i] * temp, nums[i] * min), nums[i]);

            res = Math.Max(res, max);
        }
        return res;
    }
}