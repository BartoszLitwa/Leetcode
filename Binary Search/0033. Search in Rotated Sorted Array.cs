public class Solution {
    // easier to comprehend solution
    public int Search(int[] nums, int target){
        //Find the pivot
        int left = 1, right = nums.Length - 1, pivot = nums.Length;
        while(left <= right){
            int mid = (left + right) / 2;
            if(nums[mid] >= nums[0]){ // We are on the left portion still
                left = mid + 1;
            } else {
                pivot = Math.Min(pivot, mid); // set the pivot to lowest val
                right = mid - 1;
            }
        }
        
        //Find the value
        bool leftSide = target >= nums[0]; // Check if our target on the left Side
        left = leftSide ? 0 : pivot; // If not true our left is found pivot
        right = leftSide ? pivot - 1 : nums.Length - 1;
        while(left <= right){
            int mid = (left + right) / 2;
            if(nums[mid] == target){ // We found target
                return mid;
            } else if(target < nums[mid]){ // On the left side
                right = mid - 1;
            } else { // On the right side
                left = mid + 1;
            }
        }
        
        return -1;
    }
    
    public int Search2(int[] nums, int target) {
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