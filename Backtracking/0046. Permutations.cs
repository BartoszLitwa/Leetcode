public class Solution {
    private IList<IList<int>> res;
    private int[] nums;

    public IList<IList<int>> Permute(int[] nums) {
        res = new List<IList<int>>();
        this.nums = nums;
        if(nums.Length < 1)
            return res;
        
        var stack = new Stack<int>();
        Perm(stack);
        return res;
    }

    private void Perm(Stack<int> stack){
        if(stack.Count == nums.Length){ // If our current stack is full
            res.Add(stack.ToList()); // Add the copy of the stack to the result
            return;
        }

        for(int i = 0; i < nums.Length; i++){
            if(stack.Contains(nums[i])) // If we already used this number we do not need to
                continue;

            stack.Push(nums[i]); // Add this number to the stack
            Perm(stack); // Recurse
            stack.Pop(); // Remove the number from the stack
        }
    }
}