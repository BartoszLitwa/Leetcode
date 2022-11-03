public class Solution {
    public bool ContainsDuplicate(int[] nums) {
        var digits = new HashSet<int>();
        for(int i = 0; i < nums.Length; i++){
            if(digits.Contains(nums[i]))
                return true;
            
            digits.Add(nums[i]);
            
        }
        
        return false;
    }
}