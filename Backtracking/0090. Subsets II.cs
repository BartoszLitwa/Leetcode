public class Solution {
    private IList<IList<int>> res;
    private int[] nums;
    public IList<IList<int>> SubsetsWithDup(int[] nums) {
        this.nums = nums;
        Array.Sort(this.nums);
        res = new List<IList<int>>();
        if(nums.Length < 1)
            return res;
        
        var stack = new Stack<int>();
        Backtrack(0, stack);

        return res;
    }

    private void Backtrack(int j, Stack<int> stack){
        if(j == nums.Length){
            res.Add(stack.ToList());
            return;
        }

        stack.Push(nums[j]); // Add new value
        Backtrack(j + 1, stack);
        stack.Pop(); // Remove the used value

        while(j + 1 < nums.Length && nums[j] == nums[j + 1]){ // Skip duplicates
            j++;
        }
        Backtrack(j + 1, stack); // go to the next unique value
    }
}