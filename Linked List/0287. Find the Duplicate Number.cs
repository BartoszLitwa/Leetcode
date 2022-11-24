public class Solution {
    // Floyd's Algo
    // Each value in nums is goind to stay in bounds of nums Length
    public int FindDuplicate(int[] nums) {
        int slow = 0, fast = 0;
        do{ // Detect the cycle 
            slow = nums[slow];
            fast = nums[nums[fast]];
        } while(slow != fast); // Until they colide
        
        fast = 0;
        do{ // Find the numbers where they intersect
            slow = nums[slow];
            fast = nums[fast];
        } while(slow != fast); // Until they colide
        
        return fast;
    }
}