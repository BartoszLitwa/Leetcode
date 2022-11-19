public class Solution {
    public int Search(int[] nums, int target) {
        int left = 0, right = nums.Length - 1;
        while(left <= right){
            int mid = (left + right) / 2;
            
            if(target == nums[mid]){ // We found target
                return mid;
            } else if(nums[mid] >= nums[left]){ // We know we are on the left portion
                // Our target belongs to the right side OR our mid pointer value is less than target
                if(nums[left] > target || nums[mid] < target){ 
                    left = mid + 1; // Set left pointer to our current mid pointer + 1
                } else { // Otherwise
                    right = mid - 1;
                }
            } else {  // We know we are on the right portion
                // Our mid pointer value is greather than target OR right value is greater than target
                if(nums[mid] > target || target > nums[right]){ 
                    right = mid - 1; // means target is on the left
                } else{ // Target is greater than mid value AND target is less than right value
                    left = mid + 1;
                }
            }
        }
        
        return -1;
    }
}