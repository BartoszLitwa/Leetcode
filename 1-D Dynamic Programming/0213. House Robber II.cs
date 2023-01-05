public class Solution {
    public int Rob(int[] nums) {
        if(nums.Length == 1)
            return nums[0];

        // Skip first element, or skip last element
        return Math.Max(Helper(nums[1..]), Helper(nums[..^1]));
    }

    private int Helper(int[] nums){ // House Robber I
        int robM1 = 0, robM2 = 0;

        for(int i = 0; i < nums.Length; i++){
            int temp = Math.Max(robM1, robM2 + nums[i]);
            robM2 = robM1;
            robM1 = temp;
        }

        return robM1;
    }
}