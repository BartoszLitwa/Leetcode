public class Solution {
    // Binary search works only on sorted arrays
    public int Search(int[] nums, int target) {
        if(nums.Length == 0)
            return -1;
        
        int left = 0;
        int right = nums.Length - 1;
        
        while(left <= right){
            int midPoint = left + (right - left) / 2;
            
            if(nums[midPoint] == target){
                return midPoint;
            } else if(nums[midPoint] > target) { // Is on the right of the midPoint
                right = midPoint - 1;
            } else {// Is on the left of the midPoint
                left = midPoint + 1;
            }
        }
        
        return -1;
    }
}