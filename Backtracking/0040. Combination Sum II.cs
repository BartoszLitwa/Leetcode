public class Solution {
    private IList<IList<int>> res;
    private int[] cand;
    private int target;

    public IList<IList<int>> CombinationSum2(int[] candidates, int target) {
        if(candidates.Length < 1)
            return res;

        Array.Sort(candidates);
        cand = candidates;
        res = new List<IList<int>>();
        this.target = target;

        var cur = new Stack<int>();
        Backtrack(0, cur, 0);

        return res;
    }

    private void Backtrack(int j, Stack<int> cur, int sum){
        if(sum == target){ // It is important to add it first
            res.Add(cur.ToList());
        } 
        if(sum >= target || j >= cand.Length){
            return;
        }

        int prev = cand[0] - 1;
        for(int i = j; i < cand.Length; i++){
            if(cand[i] == prev) // Skip the same number
                continue;

            cur.Push(cand[i]);
            Backtrack(i + 1, cur, sum + cand[i]);
            cur.Pop();

            prev = cand[i];
        }
    }
}