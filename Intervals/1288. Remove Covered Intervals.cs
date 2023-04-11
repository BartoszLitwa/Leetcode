public class Solution {
    public int RemoveCoveredIntervals(int[][] intervals) {
        intervals = intervals.OrderBy(x => x[0])
                             .ThenBy(x => -x[1]).ToArray();

        int res = 1;
        int[] lastInterval = new int[2] { intervals[0][0], intervals[0][1] };
        for(int i = 1; i < intervals.Length; i++){
            // Compare lastInterval with current interval
            if(lastInterval[0] <= intervals[i][0] && lastInterval[1] >= intervals[i][1])
                continue;
            // Set lastInterval to current interval
            lastInterval = new int[2] { intervals[i][0], intervals[i][1] };
            res++;
        }
        return res;
    }
}