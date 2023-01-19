public class Solution {
    public bool IsPossibleDivide(int[] nums, int k) {
        if(nums.Length % k != 0) // When it is not dividable by k
            return false; // we cannot create k sets

        var dict = new Dictionary<int, int>();
        var sorted = new List<int>();
        for(int i = 0; i < nums.Length; i++){ // Count the occurances
            if(!dict.ContainsKey(nums[i])){
                dict.Add(nums[i], 1);
                sorted.Add(nums[i]); // Add only 1 copy
            } else {
                dict[nums[i]]++;
            }
        }
        sorted.Sort();

        while(sorted.Count > 0){ // While there are still elements
            var first = sorted[0]; // Get the smallest element
            for(int i = first; i < first + k; i++){ // Itereate over the next k elements
                if(!dict.ContainsKey(i)) // We cannot create consecutive group
                    return false;

                if(--dict[i] == 0){ // Last element
                    if(i != sorted[0]) // its not the smallest available
                        return false;

                    sorted.Remove(i); // Remove it from the beginning
                }
            }
        }
        // If we reach this point, we have created k sets
        return true;
    }
}