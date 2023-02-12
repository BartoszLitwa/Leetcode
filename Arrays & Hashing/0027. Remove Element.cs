public class Solution {
    public int RemoveElement(int[] nums, int val) {
        int pointer = 0; // Pointer to the next position to be filled

        for(int i = 0; i < nums.Length; i++){
            if(nums[i] != val){ // If not equal to val, fill the position
                nums[pointer++] = nums[i]; // Fill the position
            }
        }

        return nums[0..pointer].Length; // Return the length of the new array
    }
}