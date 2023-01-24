public class Solution {
    public int[][] Merge(int[][] intervals) {
        var sorted = intervals.OrderBy(i => i[0]).ToList();
        var res = new List<int[]> { sorted[0] };
        for(int i = 1; i < sorted.Count; i++){
            if(sorted[i][0] <= res[res.Count -1][1]) { // Take last and compare to current one
                // Modify the end value of the last interval
                res[res.Count - 1][1] = Math.Max(res[res.Count - 1][1], sorted[i][1]);
            } else {
                res.Add(sorted[i]);
            }
        }

        return res.ToArray();
    }
}