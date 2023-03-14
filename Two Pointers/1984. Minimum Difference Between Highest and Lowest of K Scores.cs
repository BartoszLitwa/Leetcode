public class Solution {
    public int MinimumDifference(int[] nums, int k) {
        if(k == 1) // nums[k] - nums[k] == 0 always
            return 0;

        Array.Sort(nums); // O(nlogn)
        int left = 1, right = k; 

        int res = nums[k - 1] - nums[0]; // Set the first possible result
        while(right < nums.Length){ // O(n)
            res = Math.Min(res, nums[right++] - nums[left++]);
        }

        return res;
    }
}