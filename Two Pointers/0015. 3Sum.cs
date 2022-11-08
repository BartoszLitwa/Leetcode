public class Solution {
    // O(n^2)
    public IList<IList<int>> ThreeSum(int[] nums) {
        var res = new List<IList<int>>();
        Array.Sort(nums); // Sort the input array O(n log n)
        
        var n = nums.Length;
        for(int i = 0; i < n; i++){ // O(n^2)
            if(i > 0 && nums[i - 1] == nums[i]) // IF previous value is the same as current
                continue; // skip it
            
            int left = i + 1, right = n - 1; // Start left at next value
            while(left < right){
                var triple = nums[i] + nums[left] + nums[right];
                
                if(triple == 0){ // If 3Sum is found
                    res.Add(new List<int>() {nums[i], nums[left], nums[right]});
                    // Increase the left pointer since we found 3Sum on this index
                    left++;
                    // We do NOT want to check for the same value at the same pos as previously
                    while(left < right && nums[left] == nums[left - 1]){
                        left++;
                    }
                } else if (triple < 0){ // If target value is bigger
                    left++; // Increase left index
                } else { // If target value is lower
                    right--; // Decrease right index
                }
            }
        }
        
        
        return res;
    }
}