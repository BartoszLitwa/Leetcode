public class Solution {
    // Algorithm: Boyer-Moore Voting Algorithm
    public int MajorityElement(int[] nums) {
        int res = nums[0], count = 1;

        for(int i = 1; i < nums.Length; i++){
            if(nums[i] == res){ // if the current element is the same as the majority element
                count++;
            } else if(--count == 0){ // if the current majority element falls under to the threshold
                count = 1; // reset the count
                res = nums[i]; // set the new majority element
            }
        }

        return res;
    }
}