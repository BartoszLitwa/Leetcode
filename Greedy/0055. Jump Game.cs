public class Solution {
    public bool CanJump(int[] nums) {
        int goal = nums.Length - 1;
        for(int i = nums.Length - 1; i >= 0; i--){ // Iterate bottom up
            if(i + nums[i] >= goal) // If we can reach the goal from this position
                goal = i;
        }

        return goal == 0; // If we reach the start position
    }
}