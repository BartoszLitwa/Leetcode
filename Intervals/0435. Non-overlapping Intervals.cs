public class Solution {
    public int EraseOverlapIntervals(int[][] intervals) {
        intervals = intervals.OrderBy(x => x[0]).ToArray();
        int res = 0;
        var prevEnd = intervals[0][1];
        for(int i = 1; i < intervals.Length; i++){
            if(intervals[i][0] >= prevEnd){ // start >= prevEnd
                prevEnd = intervals[i][1];
            } else { // Overlapping
                res++;
                prevEnd = Math.Min(intervals[i][1], prevEnd);
            }
        }
        return res;
    }
}