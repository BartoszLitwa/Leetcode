public class Solution {
    public bool CanPartition(int[] nums) {
        var sum = nums.Sum();
        if(sum % 2 != 0) // If sum is odd, we can't partition
            return false;

        var set = new HashSet<int>();
        set.Add(0);
        int target = sum / 2; // We are looking for a subset that sums to half the total sum

        for(int i = nums.Length - 1; i >= 0; i--){ // Itereate bottom up
            var copy = new HashSet<int>(set); // We have to create a copy because we can't modify the set while iterating
            foreach(var s in set){
                if(s + nums[i] <= target){ // Only add when the sum would be in bounds
                    copy.Add(s + nums[i]);
                }
            }
            set = copy; // Update set
        }

        // Return whether we have found possible solution
        return set.Contains(target);
    }
}