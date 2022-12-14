public class Solution {
    // Quick select
    public int FindKthLargest(int[] nums, int k) {
        k = nums.Length - k; // Set the k to the index of the array
        int left = 0, right = nums.Length - 1;
        int pivot = nums[right], p = left;
        while(true){
            pivot = nums[right]; // Number to which we will be comparing other
            p = left; // pointer

            for(int i = left; i < right; i++){
                if(nums[i] <= pivot){ // If true swap the 
                    int temp = nums[i];
                    nums[i] = nums[p];
                    nums[p] = temp;
                    p++; // Increase p pointer
                }
            }
            // Swap the number on pointer and the last one
            int tem = nums[p];
            nums[p] = nums[right];
            nums[right] = tem;

            if(p > k) { // the number is on the left side of the p
                right = p - 1;
            } else if(p < k){ // the number is on the right
                left = p + 1;
            } else { // We found the number
                return nums[p];
            }
        }

        return nums[p];
    }
}