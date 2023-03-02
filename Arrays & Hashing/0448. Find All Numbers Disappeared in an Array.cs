public class Solution {
    public IList<int> FindDisappearedNumbers(int[] nums) {
        // Use the array itself as a hash table
        for(int i = 0; i < nums.Length; i++){
            var index = Math.Abs(nums[i]) - 1; // Convert to 0-based index
            nums[index] = Math.Abs(nums[index]) * (-1); // Mark as visited by setting it to negative
        }

        var res = new List<int>();
        for(int i = 0; i < nums.Length; i++){ // Find all positive numbers
            if(nums[i] > 0)
                res.Add(i + 1); // Convert back to 1-based index
        }
        return res;
    }
}