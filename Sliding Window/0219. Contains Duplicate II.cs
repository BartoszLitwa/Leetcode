public class Solution {
    public bool ContainsNearbyDuplicate(int[] nums, int k) {
        int i = 0;
        var window = new HashSet<int>();
        for(int j = 0; j < nums.Length; j++){ // Iterate right
            if(j - i > k){ // Window size > k
                window.Remove(nums[i++]); //Remove left
            }

            if(window.Contains(nums[j])) // Duplicate
                return true;

            window.Add(nums[j]); // Add right
        }
        return false;
    }
}