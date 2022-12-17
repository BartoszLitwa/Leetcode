public class Solution {
    private IList<IList<int>> res = new List<IList<int>>();
    
    public IList<IList<int>> Subsets(int[] nums) {
        if (nums == null || nums.Length == 0)
            return res;
        
        Backtrack(nums, 0, new List<int>());
        
        return res;
    }
    
    private void Backtrack(int[] nums, int i, List<int> cur)
    {
        res.Add(new List<int>(cur)); // Add the current list to the result
        
        if (nums.Length == i) // If we reached the end we do not need to continue
            return;
        
        for (int j = i; j < nums.Length; j++) // Iterate through the rest of the array
        {
            cur.Add(nums[j]); // Add the current number to the current list
            
            Backtrack(nums, j + 1, cur); // Recurse
            
            cur.RemoveAt(cur.Count - 1); // Remove the previously added number
        }
    }
}