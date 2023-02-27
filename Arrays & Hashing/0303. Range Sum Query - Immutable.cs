public class NumArray {
    private int[] prefixes;

    public NumArray(int[] nums) {
        prefixes = new int[nums.Length];
        prefixes[0] = nums[0]; // First element is the same
        for(int i = 1; i < nums.Length; i++){ // Calculate the prefix sum
            prefixes[i] = prefixes[i - 1] + nums[i];
        }
    }
    
    public int SumRange(int left, int right) { // Return the sum of the range
        // Sum of the right - sum of the left - 1
        return prefixes[right] - (left - 1 >= 0 ? prefixes[left - 1] : 0);
    }
}

/**
 * Your NumArray object will be instantiated and called as such:
 * NumArray obj = new NumArray(nums);
 * int param_1 = obj.SumRange(left,right);
 */