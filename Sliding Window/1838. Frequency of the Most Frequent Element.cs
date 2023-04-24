public class Solution {
    public int MaxFrequency(int[] nums, int k) {
        Array.Sort(nums); // O(nlogn)

        long total = 0; // Accomodate for large cases
        int left = 0, right = 0, res = 0;

        while(right < nums.Length){ // O(n) - still in bounds
            total += nums[right]; // Increase window
            // Invalid window
            while(nums[right] * (right - left + 1) > total + k){
                total -= nums[left++]; // Decrease window
            }
            // Valid window - update result
            res = Math.Max(res, right - left + 1);
            right++;
        }

        return res;
    }
}