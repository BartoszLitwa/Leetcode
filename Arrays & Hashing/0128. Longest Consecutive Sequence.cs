public class Solution {
    public int LongestConsecutive(int[] nums) {
        var hashSet = new HashSet<int>();
        
        for(int i = 0; i < nums.Length; i++){
            hashSet.Add(nums[i]);
        }
        
        int longestSeq = 0;
        // Iterate elements until there are no left items in hashSet
        for(int i = 0; i < nums.Length && hashSet.Count > 0; i++){
            int left = nums[i] - 1;
            int right = nums[i] + 1;
            
            while(hashSet.Remove(left)) // Remove every item until we find our most "left" elem
                left--;
            
            while(hashSet.Remove(right)) // Remove every item until we find our most "right" elem
                right++;
            
            // Check if the diff between left and right elem is the longest
            longestSeq = Math.Max(longestSeq, right - left - 1);
        }
        
        return longestSeq;
    }
    
    public int LongestConsecutive2(int[] nums) {
        var hashSet = new HashSet<int>();
        
        for(int i = 0; i < nums.Length; i++){
            hashSet.Add(nums[i]);
        }
        
        int longestSeq = 0;
        for(int i = 0; i < nums.Length; i++){
            // It does not have "left neighbour"
            if(!hashSet.Contains(nums[i] - 1)){ // Starting sequence
                int length = 1;
                while(hashSet.Contains(nums[i] + length)){ // Until it has right neighbour
                    length++; // increase the length
                }
                
                longestSeq = Math.Max(longestSeq, length);
            }
        }
        
        return longestSeq;
    }
}