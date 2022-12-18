public class Solution {
    private IList<IList<int>> res = new List<IList<int>>();
    private int[] cand;
    private int targ;

    public IList<IList<int>> CombinationSum(int[] candidates, int target) {
        cand = candidates;
        targ = target;

        var cur = new Stack<int>();
        DFS(0, cur, 0);

        return res;
    }

    private void DFS(int i, Stack<int> cur, int total){
        if(total == targ){ // If we found the match
            res.Add(new List<int>(cur.ToList())); // Create the copy and add it
            return;
        }
        if(i >= cand.Length || total > targ){ // IF we used each number or surpassed the target value
            return;
        }
        cur.Push(cand[i]); // Continue the decision tree with this number
        DFS(i, cur, total + cand[i]); // Multiple number of the same

        cur.Pop(); // No longer use this number
        DFS(i + 1, cur, total); // Continue no longer using the i-th candidate
    }
}