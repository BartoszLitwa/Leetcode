public class Solution {
    public int RemoveDuplicates(int[] nums) {
        int left = 0, right = 0;

        while(right < nums.Length){ // Two pointers
            int count = 1;
            while(right + 1 < nums.Length && nums[right] == nums[right + 1]){ // Count the number of duplicates
                count++;
                right++;
            }
            // Add the number of duplicates to the left pointer
            for(int i = 0; i < Math.Min(2, count); i++){ 
                nums[left++] = nums[right];
            }
            right++; // Increment right pointer
        }

        return left; // Return the length of the array
    }
}