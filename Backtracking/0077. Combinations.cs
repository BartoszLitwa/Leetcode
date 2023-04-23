public class Solution {
    public IList<IList<int>> Combine(int n, int k) {
        var res = new List<IList<int>>();
        var list = new List<int>();

        Backtrack(1); // Start from 1

        return res;

        void Backtrack(int number){
            if(list.Count >= k){ // Reached the number of desired numbers in combination
                res.Add(new List<int>(list)); // Create copy
                return;
            }

            for(int i = number; i <= n; i++){
                list.Add(i); // Add the current number
                Backtrack(i + 1); // Go to the next number
                list.Remove(i); // Remove the current number
            }
        }
    }
}