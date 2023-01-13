public class Solution {
    public int LengthOfLIS(int[] nums) {
        var lis = new int[nums.Length];
        for(int i = 0; i < nums.Length; i++){ // Set each value to 1 since each value is a subsequence of itself
            lis[i] = 1;
        }

        for(int i = nums.Length - 2; i >= 0; i--){ // Iterate bottom up
            for(int j = i + 1; j < nums.Length; j++){ // Itereate each next value in sequence
                if(nums[i] < nums[j]){ // only if next value is greater
                    lis[i] = Math.Max(lis[i], lis[j] + 1);
                }
            }
        }

        return lis.Max();
    }
}