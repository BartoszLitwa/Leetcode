public class Solution {
    public IList<IList<int>> PermuteUnique(int[] nums) {
        var res = new List<IList<int>>();
        var stack = new Stack<int>();
        var map = new Dictionary<int, int>(); // <number, count>

        foreach (int num in nums) {
            if (map.ContainsKey(num)) {
                map[num]++;
            } else {
                map[num] = 1;
            }
        }

        Backtrack();
        return res;

        void Backtrack(){
            if(stack.Count == nums.Length){ // Reached the end of the permutation
                res.Add(stack.ToList()); // Copy
                return;
            }

            foreach(var key in map.Keys){
                if(map[key] == 0)
                    continue;

                stack.Push(key); // Add the current number
                map[key]--;
                Backtrack();
                stack.Pop(); // Remove the current number
                map[key]++;
            }
        }
    }
}