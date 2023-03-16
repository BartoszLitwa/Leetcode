public class Solution {
    public int RemoveDuplicates(int[] nums) {
        int left = 0, right = 0;
        while(right < nums.Length){ // Until we reach the end of the array
            if(nums[left] == nums[right]){ // If the left and right are the same, we move the right pointer
                right++;
            } else { // If different, move right to left, and move left pointer to the next one
                nums[++left] = nums[right++];
            }
        }

        return left + 1; // Return the length of the array
    }
}